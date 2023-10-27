#region Using
using ConsoleJson.Helpers;
using ConsoleJson.Models;
using ConsoleJson.Utils;
using System.Text.Json;
#endregion

namespace ConsoleJson.Data
{
    #region Public Class OrderWorker

    /// <summary>
    /// Основый класс программы для работы с order
    /// </summary>
    public class OrderWorker
    {
        #region Public Fields
        
        /// <summary>
        /// Данные из файла order.json
        /// </summary>
        public JsonOrder? Order { get; private set; }

        /// <summary>
        /// Значение валидности документа для работы 
        /// </summary>
        public bool isValid { get; private set; } = false;
        #endregion

        #region Private Fields

        /// <summary>
        /// Аргументы командной строки
        /// </summary>
        private Arguments Arguments;

        /// <summary>
        /// Логгер
        /// </summary>
        private OrderLogger? logger;

        /// <summary>
        /// Делегат для выбора расчета налога по стране из аргументов
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="subtotalamount"></param>
        /// <returns></returns>
        private delegate decimal TaxCountryDelegage(int quantity, decimal subtotalamount);
        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор, который принимает аргумент командной строки
        /// Если аргументы корректные, то происходит загрузка файла и его валидация для дальнейшей работы
        /// </summary>
        /// <param name="arguments"></param>
        public OrderWorker(Arguments arguments)
        {
            Arguments = arguments;

            if (ValidateArguments())
            {
                logger = OrderLogger.Instance;

                loadFile();

                isValid = ValidateFile();
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Валидация данных
        /// </summary>
        /// <returns></returns>
        public bool ValidateFile()
        {
            if (Order != null)
            {
                if (ValidateTaxValue() && ValidateLineItemsQuantity())
                {
                    return SetValidateConfig(true);
                }
                return SetValidateConfig(false);
            }

            return false;
        }

        /// <summary>
        /// Расчет налога
        /// </summary>
        /// <returns></returns>
        public bool CalculateTax()
        {
            TaxCountryDelegage taxCountry = SelectCountryToCalculateTax();

            if (isValid && taxCountry != null)
            {
                if (Order != null && Order.LineItems.Count > 0)
                {
                    foreach (var item in Order.LineItems)
                    {
                        item.CalculatedAmounts.TaxAmount = taxCountry(item.Quantity, item.CalculatedAmounts.SubTotalAmount);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Сохранение и логирование данных
        /// </summary>
        /// <returns></returns>
        public bool SaveAndLogOrder()
        {
            bool result = false;
            if (isValid)
            {
                if (SaveJsonFile())
                {
                    string data = String.Empty;

                    try
                    {
                        data = JsonSerializer.Serialize(Order);
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        data = ex.Message;
                        result = false;
                    }
                    finally
                    {
                        logger?.Log(data);
                    }

                }
                else
                {
                    logger?.Log("Произошла ошибка записи данных в файл");
                    result = false;
                }
            }

            return result;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Валидация аргументов командной строки
        /// </summary>
        /// <returns></returns>
        private bool ValidateArguments()
        {
            if (Arguments != null)
            {
                if (Arguments.Country.Equals(String.Empty) || Arguments.InputPath.Equals(String.Empty) || Arguments.OutputPath.Equals(String.Empty))
                { return false; }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Загрузка данных из файла по указаному в аргументах пути
        /// </summary>
        private void loadFile()
        {
            string path = Arguments.InputPath;

            if (path != null)
            {
                try
                {
                    string data = File.ReadAllText(path);

                    Order = JsonSerializer.Deserialize<JsonOrder>(data);
                }
                catch (Exception ex)
                {
                    logger?.Log(ex.Message);
                }
            }
            else
            {
                logger?.Log("Некорретный путь для доступа к файлу");
            }
        }

        /// <summary>
        /// Валидация документа по признаку Tax.Value
        /// </summary>
        /// <returns></returns>
        private bool ValidateTaxValue()
        {
            if (Order != null && Order.Taxes.Count > 0)
            {
                foreach (var item in Order.Taxes)
                {
                    if (!(item.Value >= 0 && item.Value < 1))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Валидация документа по признаку LineItems.Quantity
        /// </summary>
        /// <returns></returns>
        private bool ValidateLineItemsQuantity()
        {
            if (Order != null && Order.LineItems.Count > 0)
            {
                foreach (var item in Order.LineItems)
                {
                    if (!(item.Quantity > 0 && item.Quantity <= 20))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Выбор метода для расчета налога в зависимости от страны, указанной в аргументах
        /// </summary>
        /// <returns></returns>
        private TaxCountryDelegage SelectCountryToCalculateTax()
        {
            switch (Arguments.Country)
            {
                case CountryValue.RUS:
                    {
                        return CalculateRusTax;
                    }
                case CountryValue.USA:
                    {
                        return CalculateUsaTax;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// Расчет налога для USA
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="subtotalamount"></param>
        /// <returns></returns>
        private decimal CalculateUsaTax(int quantity, decimal subtotalamount)
        {
            decimal taxAmount = 0;

            foreach (var tax in Order.Taxes)
            {
                taxAmount += ((quantity * subtotalamount) * tax.Value);
            }

            return decimal.Round(taxAmount, 2);
        }

        /// <summary>
        /// Расчет налога для RUS
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="subtotalamount"></param>
        /// <returns></returns>
        private decimal CalculateRusTax(int quantity, decimal subtotalamount)
        {
            decimal taxAmount = 0;

            foreach (var tax in Order.Taxes)
            {
                taxAmount += (quantity * subtotalamount) - ((quantity * subtotalamount) / (1 + tax.Value));
            }

            return decimal.Round(taxAmount, 2);
        }

        /// <summary>
        /// Сохранение документа по указаному пути в аргументах
        /// </summary>
        /// <returns></returns>
        private bool SaveJsonFile()
        {
            bool saveStatus = false;
            try
            {
                using (FileStream fs = new FileStream(Arguments.OutputPath, FileMode.Create))
                {
                    JsonSerializer.Serialize<JsonOrder>(fs, Order);
                }
                saveStatus = true;
            }
            catch (Exception ex)
            {
                logger?.Log(ex.Message);
            }
            return saveStatus;
        }

        /// <summary>
        /// Изменение параметров после валидации данных
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private bool SetValidateConfig(bool config)
        {
            if (config)
                Order.Status = 1;
            else
                Order.Status = 0;

            isValid = config;

            return isValid;

        }
        #endregion
    }
    #endregion
}
