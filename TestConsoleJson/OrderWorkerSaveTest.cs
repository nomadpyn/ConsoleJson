using ConsoleJson.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleJson
{
    public class OrderWorkerSaveTest
    {
        private OrderWorkerFactory orderWorkerFactory = new();

        [Fact]
        public void TestSaveCorrectOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.SaveAndLogOrder());

        }

        [Fact]
        public void TestSaveInCorrectInput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.False(orderWorker.SaveAndLogOrder());
        }

        [Fact]
        public void TestSaveInCorrectCountry()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.SaveAndLogOrder());
        }

        [Fact]
        public void TestSaveInCorrectOutput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.False(orderWorker.SaveAndLogOrder());
        }
    }
}
