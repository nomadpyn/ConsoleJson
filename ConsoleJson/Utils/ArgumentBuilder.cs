using ConsoleJson.Helpers;
using ConsoleJson.Models;

namespace ConsoleJson.Utils
{
    public class ArgumentBuilder
    {
        public Arguments myArguments;

        public ArgumentBuilder(string[] args)
        {
            myArguments = BuildArguments(args);
        }

        private Arguments BuildArguments(string[] args)
        {
            if(args != null && args.Length == 3)
            {
                                
                myArguments = new()
                {
                    InputPath = args[0],
                    Country = args[1],
                    OutputPath = args[2]
                };

                if(myArguments.Country.Equals(CountryValue.RUS) || myArguments.Country.Equals(CountryValue.USA))
                {
                    return myArguments;
                }

                return null;
            }

            return null;
        }
    }
}
