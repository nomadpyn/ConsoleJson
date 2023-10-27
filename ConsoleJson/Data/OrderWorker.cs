using ConsoleJson.Helpers;
using ConsoleJson.Models;
using ConsoleJson.Utils;
using System.Text.Json;

namespace ConsoleJson.Data
{
    public class OrderWorker
    {
        public JsonOrder? Order { get; private set; }

        public bool isValid { get; private set; } = false;

        private Arguments Arguments;

        private OrderLogger? logger;

        private delegate decimal TaxCountryDelegage(int quantity, decimal subtotalamount);

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

        public bool ValidateFile()
        {
            if (Order != null)
            {
                if (ValidateTaxValue() && ValidateLineItemsQuanity())
                {

                    return SetValidateConfig(true);
                }
                return SetValidateConfig(false);
            }

            return false;
        }

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

        private bool ValidateLineItemsQuanity()
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

        private decimal CalculateUsaTax(int quantity, decimal subtotalamount)
        {
            decimal taxAmount = 0;

            foreach (var tax in Order.Taxes)
            {
                taxAmount += ((quantity * subtotalamount) * tax.Value);
            }

            return decimal.Round(taxAmount, 2);
        }

        private decimal CalculateRusTax(int quantity, decimal subtotalamount)
        {
            decimal taxAmount = 0;

            foreach (var tax in Order.Taxes)
            {
                taxAmount += (quantity * subtotalamount) - ((quantity * subtotalamount) / (1 + tax.Value));
            }

            return decimal.Round(taxAmount, 2);
        }

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

        private bool SetValidateConfig(bool config)
        {
            if (config)
                Order.Status = 1;
            else
                Order.Status = 0;

            isValid = config;

            return isValid;

        }
    }
}
