#region
using ConsoleJson.Data;
#endregion

namespace TestConsoleJson
{
    #region Public Class OrderWorkerLoadTest

    /// <summary>
    /// Тесты на загрузку исходного файла
    /// </summary>
    public class OrderWorkerLoadTest
    {
        #region Private Fields

        /// <summary>
        /// Фабрика для создания OrderWorker
        /// </summary>
        private OrderWorkerFactory orderWorkerFactory= new();
        #endregion

        #region Public Fields

        /// <summary>
        /// Тест при корректных аргументах
        /// </summary>
        [Fact]
        public void TestLoadCorrectOrder()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateCorrectOrderWorker();

            Assert.True(orderWorker.Order != null);

        }

        /// <summary>
        /// Тест при некорректном пути исходного файла
        /// </summary>
        [Fact]
        public void TestLoadInCorrectInput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectInputOrderWorker();

            Assert.True(orderWorker.Order == null);
        }

        /// <summary>
        /// Тест при некорректной стране
        /// </summary>
        [Fact]
        public void TestLoadInCorrectCountry()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectCountryOrderWorker();

            Assert.True(orderWorker.Order != null);
        }

        /// <summary>
        /// Тест при некорректном пути сохранения файла
        /// </summary>
        [Fact]
        public void TestLoadInCorrectOutput()
        {
            OrderWorker orderWorker = orderWorkerFactory.CreateInCorrectOutputOrderWorker();

            Assert.True(orderWorker.Order != null);
        }
        #endregion
    }
    #endregion
}
