using GameShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameShop.DataAccess
{
    public class GameBoughtOrderRepository : IGameBoughtOrderRepository
    {
        public IEnumerable<GameBoughtOrder> GetAll()
        {
            return
                _context.Orders.OrderBy(k => k.Date);
        }

        private GameBoughtOrderContext _context;

        public GameBoughtOrderRepository
            (GameBoughtOrderContext context)
        {
            _context = context;
        }

        public int Save(GameBoughtOrder gameBought)
        {
            _context.Orders.Add(gameBought);
            _context.SaveChanges();
            return gameBought.Id;
        }


    }
}
