using ConsoleJson.Data;
using ConsoleJson.Utils;

namespace ConsoleJson
{
    internal class Program
    {
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
    }
}