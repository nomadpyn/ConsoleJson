
namespace ConsoleJson.Utils
{
    public class OrderLogger
    {
        private const string path = "log.txt";

        public static readonly OrderLogger Instance = new OrderLogger();

        private OrderLogger() { }

        public static OrderLogger GetInstance() { return Instance; }

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
    }
}
