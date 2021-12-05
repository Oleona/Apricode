using Apricode4.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apricode4.Models
{
    public class GameRepository
    {
        private readonly VideoGameShopContext dbContext = new();

        public async Task CreateOrUpdateAsync(GameModel gameModel)
        {
            if (gameModel == null)
            {
                throw new ArgumentNullException($"{gameModel}");
            }

            var dbGame = await dbContext.VideoGames
                .SingleOrDefaultAsync(x => x.GameName == gameModel.GameName && x.StudioDeveloper == gameModel.StudioDeveloper);

            if (dbGame == null)
            {
                var newDbGame = await CreateNewGame(gameModel);
                dbContext.Add(newDbGame);
            }
            else
            {
                await UpdateExistingGame(dbGame, gameModel);
                dbContext.Update(dbGame);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<GameModel>> ReadAsync(string gameName)
        {
            var dbGames = await dbContext.VideoGames
                .Include(c => c.Genres)
                .Where(c => c.GameName == gameName)
                .ToListAsync();

            return dbGames.Select(dbGame => ConvertEntityToModel(dbGame)).ToList();
        }

        public async Task DelAsync(string gameName, string studioDeveloper)
        {
            var dbGame = await dbContext.VideoGames
                .Include(c => c.Genres)
                .SingleOrDefaultAsync(c => c.GameName == gameName && c.StudioDeveloper == studioDeveloper);

            if (dbGame == null)
            {
                return;
            }

            dbContext.Remove(dbGame);
            await dbContext.SaveChangesAsync();

        }

        private async Task<VideoGame> CreateNewGame(GameModel gameModel)
        {
            var genres = await FindGenresByModel(gameModel);

            return new VideoGame
            {
                GameName = gameModel.GameName,
                StudioDeveloper = gameModel.StudioDeveloper,
                Genres = genres,
            };
        }

        private async Task UpdateExistingGame(VideoGame dbGame, GameModel gameModel)
        {
            var genres = await FindGenresByModel(gameModel);

            dbGame.GameName = gameModel.GameName;
            dbGame.StudioDeveloper = gameModel.StudioDeveloper;
            dbGame.Genres = genres;
        }

        private async Task<List<Genre>> FindGenresByModel(GameModel gameModel)
        {
            return await dbContext.Genres
                .Where(g => gameModel.GenreNames.Contains(g.GenreName))
                .ToListAsync();
        }

        private GameModel ConvertEntityToModel(VideoGame dbGame)
        {
            var genreNames = dbGame.Genres.Select(g => g.GenreName).ToList();

            return new GameModel
            {
                GameName = dbGame.GameName,
                StudioDeveloper = dbGame.StudioDeveloper,
                GenreNames = genreNames,

            };
        }

    }
}
