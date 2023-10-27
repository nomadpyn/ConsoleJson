using ConsoleJson.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleJson
{
     public class CalculateTaxTest
    {
        private OrderWorkerFactory orderWorkerFactory = new();

        [Fact]
        public void TestCalculateCorrectOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.CalculateTax());

        }

        [Fact]
        public void TestCalculateInCorrectInput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestCalculateInCorrectCountry()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestCalculateInCorrectOutput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.True(orderWorker.CalculateTax());
        }
        
        [Fact]
        public void TestLoadCorrectInValidTaxValueMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidAllTaxValueMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value += (decimal)1.1;
            }

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1.1;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidAllTaxValueLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var taxes in orderWorker.Order.Taxes)
            {
                taxes.Value -= (decimal)1.1;
            }

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidAllItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity += 21;
            }

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidAllItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            foreach (var item in orderWorker.Order.LineItems)
            {
                item.Quantity -= 21;
            }

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessItemsQuantityMoreOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)-1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 21;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

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

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

        [Fact]
        public void TestLoadCorrectInValidTaxValueLessMoreItemsQuantityLessOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            orderWorker.Order.Taxes.FirstOrDefault().Value = (decimal)1.1;
            orderWorker.Order.LineItems.FirstOrDefault().Quantity = 0;

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }

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

            orderWorker.ValidateFile();

            Assert.False(orderWorker.CalculateTax());
        }
    }
}
