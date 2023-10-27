
namespace ConsoleJson.Models
{
    #region Public Class Arguments

    /// <summary>
    /// Класс для хранения аргументов командной строки
    /// </summary>
    public class Arguments
    {
        #region Public Fields

        /// <summary>
        /// Путь до .json-файла, содержащего order 
        /// </summary>
        public string? InputPath { get; set; } = String.Empty;

        /// <summary>
        /// Страна
        /// </summary>
        public string? Country { get; set; } = String.Empty;

        /// <summary>
        /// Путь для сохранения результата
        /// </summary>
        public string? OutputPath { get; set; } = String.Empty;
        #endregion
    }
    #endregion
}
