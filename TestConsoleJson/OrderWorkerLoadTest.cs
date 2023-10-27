using ConsoleJson.Data;

namespace TestConsoleJson
{
    public class OrderWorkerLoadTest
    {
        private OrderWorkerFactory orderWorkerFactory= new();

        [Fact]
        public void TestLoadCorrectOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.Order != null);

        }

        [Fact]
        public void TestLoadInCorrectInput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.True(orderWorker.Order == null);
        }

        [Fact]
        public void TestLoadInCorrectCountry()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.Order != null);
        }

        [Fact]
        public void TestLoadInCorrectOutput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.True(orderWorker.Order != null);
        }
    }
}
