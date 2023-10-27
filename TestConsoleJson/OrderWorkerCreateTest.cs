#region Using
using ConsoleJson.Data;
using ConsoleJson.Models;
#endregion

namespace TestConsoleJson
{
    #region Public Class OrderWorkerCreateTest

    /// <summary>
    /// Тесты на создание OrderWorker
    /// </summary>
    public class OrderWorkerCreateTest
    {
        #region Public Methods

        /// <summary>
        /// Тест при null аргументах
        /// </summary>
        [Fact]
        public void TestCreateOrderWorkerNullArguments()
        {
            Arguments args = null;

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }

        /// <summary>
        /// Тест при пустых аргументах
        /// </summary>
        [Fact]
        public void TestCreateOrderWorkerEmptyArguments()
        {
            Arguments args = new();

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }

        /// <summary>
        /// Тест при заполненых аргументах
        /// </summary>
        [Fact]
        public void TestCreateOrderWorkerCorrectArguments()
        {
            Arguments args = new() { InputPath = "arg1", Country = "arg2", OutputPath = "arg3"};

            OrderWorker worker = new OrderWorker(args);

            Assert.NotNull(worker);
        }
        #endregion
    }
    #endregion
}
