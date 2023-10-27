#region Using 
using ConsoleJson.Data;
#endregion

namespace TestConsoleJson
{
    #region Public Class OrderWorkerValidateTest

    /// <summary>
    /// Тесты на валидацию данных в OrderWorker
    /// </summary>
    public class OrderWorkerValidateTest
    {
        #region Private Fields

        /// <summary>
        /// Фабрика для создания OrderWorker
        /// </summary>
        private OrderWorkerFactory orderWorkerFactory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// Тест на валидацию при корректных данных с корректными аргументами
        /// </summary>
        [Fact]
        public void TestValidateValidOrderCorrectOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при корректных данных с некорректным путем до исходного файла
        /// </summary>
        [Fact]
        public void TestValidateValidOrderInCorrectInputOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при корректных данных с некорректным страной в аргументах
        /// </summary>
        [Fact]
        public void TestValidateValidOrderInCorrectCountryOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при корректных данных с некорректным путем для сохранения файла
        /// </summary>
        [Fact]
        public void TestValidateValidOrderInCorrectOutputOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных TaxValue (больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidTaxValueMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        ///  Тест на валидацию при некорректных данных TaxValue(несколько больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllTaxValueMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value += (decimal)1.1;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        ///  Тест на валидацию при некорректных данных TaxValue (меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidTaxValueLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1.1;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        ///  Тест на валидацию при некорректных данных TaxValue (несколько меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value -= (decimal)1.1;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        ///  Тест на валидацию при некорректных данных LineItemsQuantity (больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных LineItemsQuantity (несколько больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity += 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных LineItemsQuantity (меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных LineItemsQuantity (несколько меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity -= 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных TaxValue (меньше) и LineItemsQuantity (больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidTaxValueLessItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных TaxValue (несколько меньше) и LineItemsQuantity (несколько больше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessAllItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value -= (decimal)1.1;
            }

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity += 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных TaxValue (больше) и LineItemsQuantity (меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidTaxValueLessMoreItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            Assert.False(orderWorker.ValidateFile());
        }

        /// <summary>
        /// Тест на валидацию при некорректных данных TaxValue (несколько больше) и LineItemsQuantity (несколько меньше) при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessMoreAllItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value += (decimal)1.1;
            }

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity -= 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }
        #endregion
    }
    #endregion
}
