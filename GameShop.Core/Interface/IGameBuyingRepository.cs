using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.Core.Interface
{
    public interface IGameBuyingRepository
    {
        void Save(GameBoughtOrder gameBought);
    }
}
