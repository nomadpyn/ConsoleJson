#region Using
using ConsoleJson.Helpers;
using ConsoleJson.Models;
#endregion

namespace ConsoleJson.Utils
{
    #region Public Class ArgumentBuilder

    /// <summary>
    /// Класс для сборки аргументов из командной строки
    /// </summary>
    public class ArgumentBuilder
    {
        #region Public Fields

        /// <summary>
        /// Хранение аргументов командной строки
        /// </summary>
        public Arguments myArguments;
        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор, который принимает массив строк из аргументов командной строки
        /// </summary>
        /// <param name="args"></param>
        public ArgumentBuilder(string[] args)
        {
            myArguments = BuildArguments(args);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Создание обьекта Arguments c валидацией данных
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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
        #endregion
    }
    #endregion
}
