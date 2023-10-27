#region
using ConsoleJson.Data;
#endregion

namespace TestConsoleJson
{
    #region Public Class OrderWorkerSaveTest

    /// <summary>
    /// Тесты на сохранения данных
    /// </summary>
    public class OrderWorkerSaveTest
    {
        #region Private Fields

        /// <summary>
        /// Фабрика для создания OrderWorker
        /// </summary>
        private OrderWorkerFactory orderWorkerFactory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// Тест при корректных аргументах
        /// </summary>
        [Fact]
        public void TestSaveCorrectOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.SaveAndLogOrder());

        }

        /// <summary>
        /// Тест при некорректном пути исходного файла
        /// </summary>
        [Fact]
        public void TestSaveInCorrectInput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.False(orderWorker.SaveAndLogOrder());
        }

        /// <summary>
        /// Тест при некорректной стране
        /// </summary>
        [Fact]
        public void TestSaveInCorrectCountry()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.SaveAndLogOrder());
        }

        /// <summary>
        /// Тест при некорректном пути сохранения файла
        /// </summary>
        [Fact]
        public void TestSaveInCorrectOutput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.False(orderWorker.SaveAndLogOrder());
        }
        #endregion
    }
    #endregion
}
