using System;
using System.Collections.Generic;

namespace Apricode4.Models.Entities
{
    public class Genre
    {

        public Guid Id { get; set; }

        /// <summary>
        /// Название жанра
        /// </summary>
        public string GenreName { get; set; }


        /// <summary>
        /// Игры этого жанра
        /// </summary>
        public List<VideoGame> VideoGames { get; set; }

    }

}
