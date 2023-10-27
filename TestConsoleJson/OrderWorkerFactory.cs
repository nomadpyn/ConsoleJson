#region Using
using ConsoleJson.Data;
using ConsoleJson.Models;
#endregion

namespace TestConsoleJson
{
    #region Internal Class OrderWorkerFactory

    /// <summary>
    /// Фабрика для создания необходимых вариантов OrderWorker для тестов
    /// </summary>
    internal class OrderWorkerFactory
    {
        #region Private Fields

        /// <summary>
        /// Корректных аргументы командной строки
        /// </summary>
        private readonly Arguments correctArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "RUS", OutputPath = "C:\\Orders\\order_out.json" };

        /// <summary>
        /// Некорректный путь к исходному файлу
        /// </summary>
        private readonly Arguments inCorrectInputArguments = new() { InputPath = "C:\\Orders\\request.json", Country = "RUS", OutputPath = "C:\\Orders\\order_out.json" };

        /// <summary>
        /// Некорректная страна
        /// </summary>
        private readonly Arguments inCorrectCountyArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "NO", OutputPath = "C:\\Orders\\order_out.json" };

        /// <summary>
        /// Некорректный путь для сохранения файла
        /// </summary>
        private readonly Arguments inCorrectOutputArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "RUS", OutputPath = "L:\\order.json" };
        #endregion

        #region Public Methods

        /// <summary>
        /// Корректный OrderWorker
        /// </summary>
        /// <returns></returns>
        public OrderWorker CreateCorrectOrderWorker()
        {
            OrderWorker ow = new OrderWorker(correctArguments);

            return new OrderWorker(correctArguments);
        }

        /// <summary>
        /// OrderWorker c неверным исходным путем файла
        /// </summary>
        /// <returns></returns>
        public OrderWorker CreateInCorrectInputOrderWorker()
        {
            return new OrderWorker(inCorrectInputArguments);
        }

        /// <summary>
        /// OrderWorker c неверной страной
        /// </summary>
        /// <returns></returns>
        public OrderWorker CreateInCorrectCountryOrderWorker()
        {
            return new OrderWorker(inCorrectCountyArguments);
        }

        /// <summary>
        /// OrderWorker c неверным путем сохранения файла
        /// </summary>
        /// <returns></returns>
        public OrderWorker CreateInCorrectOutputOrderWorker()
        {
            return new OrderWorker(inCorrectOutputArguments);
        }
        #endregion
    }
#endregion
}
