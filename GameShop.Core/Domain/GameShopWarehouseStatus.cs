using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.Core.Domain
{
    public class GameShopWarehouseStatus
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int Amount { get; set; }
    }
}
