#region Using
using ConsoleJson.Data;
using ConsoleJson.Utils;
#endregion

namespace ConsoleJson
{
    #region Internal class Program
    internal class Program
    {
        #region Static Methods

        /// <summary>
        /// Основной класс программы, в котором происходит получение аргументов и последовательная работы с OrderWorker объектом,
        /// в частности создание, расчет и сохранение данных
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ArgumentBuilder builder = new(args);

            if (builder.myArguments != null)
            {
                OrderWorker orderWorker = new(builder.myArguments);

                orderWorker.CalculateTax();

                orderWorker.SaveAndLogOrder();
            }
            else
            {
                OrderLogger orderLogger = OrderLogger.GetInstance();

                orderLogger.Log("Неверные аргументы");
            }
        }
        #endregion
    }
    #endregion
}