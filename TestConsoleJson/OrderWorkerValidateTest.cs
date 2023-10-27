using ConsoleJson.Data;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;

namespace TestConsoleJson
{
    public class OrderWorkerValidateTest
    {
        private OrderWorkerFactory orderWorkerFactory = new();

        [Fact]
        public void TestValidateValidOrderCorrectOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }        

        [Fact]
        public void TestValidateValidOrderInCorrectInputOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestValidateValidOrderInCorrectCountryOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestValidateValidOrderInCorrectOutputOrderWorker()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.True(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidTaxValueMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;

            Assert.False(orderWorker.ValidateFile());
        }

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

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1.1;

            Assert.False(orderWorker.ValidateFile());
        }

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

        [Fact]
        public void TestLoadCorrectInValidItemsQuatityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidAllItemsQuatityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity += 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidItemsQuatityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidAllItemsQuatityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity -= 21;
            }

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessItemsQuatityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessAllItemsQuatityMoreOrder()
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

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessMoreItemsQuatityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            Assert.False(orderWorker.ValidateFile());
        }

        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessMoreAllItemsQuatityLessOrder()
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

    }
}
