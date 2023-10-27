using ConsoleJson.Data;
using ConsoleJson.Models;
using ConsoleJson.Utils;

namespace TestConsoleJson
{
    public class OrderWorkerCreateTest
    {
        [Fact]
        public void TestCreateOrderWorkerNullArguments()
        {
            Arguments args = null;

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }

        [Fact]
        public void TestCreateOrderWorkerEmptyArguments()
        {
            Arguments args = new();

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }

        [Fact]
        public void TestCreateOrderWorkerCorrectArguments()
        {
            Arguments args = new() { InputPath = "arg1", Country = "arg2", OutputPath = "arg3"};

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }
    }
}
