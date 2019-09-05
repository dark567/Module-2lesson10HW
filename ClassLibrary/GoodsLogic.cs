using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsLogic
    {

        public static Goods[] GetGoods
        {
            get
            {
                return Goods._modelGoods.ToArray();
            }
        }

        public static void AddGoods(Goods _modelgoods)
        {
            Goods._modelGoods.Add(_modelgoods);
        }

        public static void RemoveGoods(int _index)
        {
            Goods._modelGoods.RemoveAt(_index);
        }

        public DateTime CalcLimitExpirationDate(double _expirationDate, DateTime DateAddGoodsToStorePlace)
        {
            return DateAddGoodsToStorePlace.AddDays(_expirationDate);
        }
    }
}
