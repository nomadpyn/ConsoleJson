using ConsoleJson.Data;
using ConsoleJson.Models;

namespace TestConsoleJson
{
    internal class OrderWorkerFactory
    {
        private readonly Arguments correctArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "RUS", OutputPath = "C:\\Orders\\order_out.json" };

        private readonly Arguments inCorrectInputArguments = new() { InputPath = "C:\\Orders\\request.json", Country = "RUS", OutputPath = "C:\\Orders\\order_out.json" };

        private readonly Arguments inCorrectCountyArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "NO", OutputPath = "C:\\Orders\\order_out.json" };

        private readonly Arguments inCorrectOutputArguments = new() { InputPath = "C:\\Orders\\order.json", Country = "RUS", OutputPath = "L:\\order.json" };

        public OrderWorker CreateCorrectOrderWorker()
        {
            OrderWorker ow = new OrderWorker(correctArguments);

            return new OrderWorker(correctArguments);
        }

        public OrderWorker CreateInCorrectInputOrderWorker()
        {
            return new OrderWorker(inCorrectInputArguments);
        }

        public OrderWorker CreateInCorrectCountryOrderWorker()
        {
            return new OrderWorker(inCorrectCountyArguments);
        }

        public OrderWorker CreateInCorrectOutputOrderWorker()
        {
            return new OrderWorker(inCorrectOutputArguments);
        }


    }
}
