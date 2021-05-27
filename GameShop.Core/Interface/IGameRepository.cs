using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.Core.Interface
{
    public interface IGameRepository
    {
        bool IsGameAvailable(Game game);

        IEnumerable<Game> GetAll();
    }
}
