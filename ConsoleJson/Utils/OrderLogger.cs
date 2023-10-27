
namespace ConsoleJson.Utils
{
    #region Public Class OrderLogger

    /// <summary>
    /// Класс для логирования данных
    /// </summary>
    public class OrderLogger
    {
        #region Public Fields

        /// <summary>
        /// Состояние объекта (паттерн Singleton)
        /// </summary>
        public static readonly OrderLogger Instance = new OrderLogger();
        #endregion

        #region Private Fields

        /// <summary>
        /// Путь к файлу логов
        /// </summary>
        private const string path = "log.txt";
        #endregion

        #region Private Constructor
        private OrderLogger() { }
        #endregion

        #region Public Methods
        
        /// <summary>
        /// Получение состояние обьекта (паттерн Singleton)
        /// </summary>
        /// <returns></returns>
        public static OrderLogger GetInstance() { return Instance; }

        /// <summary>
        /// Логирование данных в файл с датой и вывод в консоль
        /// </summary>
        /// <param name="jsonOrder"></param>
        public void Log(string jsonOrder)
        {
            Console.WriteLine(jsonOrder);

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "\n" + jsonOrder);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString() + " Не удалось записать лог в файл");
            }
        }
        #endregion
    }
    #endregion
}
