using System;
using System.Collections.Generic;

namespace Apricode4.Models.Entities
{
    public class VideoGame
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Название игры
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Разработчик игры
        /// </summary>
        public string StudioDeveloper { get; set; }

        /// <summary>
        /// Список жанров игры
        /// </summary>
        public List<Genre> Genres { get; set; }

    }

}
