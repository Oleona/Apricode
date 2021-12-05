using System.Collections.Generic;

namespace Apricode4.Models
{
    /// <summary>
    /// Пользовательское представление игры
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Название игры
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Разработчик игры
        /// </summary>
        public string StudioDeveloper { get; set; }

        /// <summary>
        /// Названия жанров игры
        /// </summary>
        public List<string> GenreNames { get; set; }


    }
}
