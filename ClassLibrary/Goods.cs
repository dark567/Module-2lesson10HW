using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Goods: StorePlace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double ExpirationDate { get; set; }
        public DateTime DateAddGoodsToStorePlace { get; set; }

        public static List<Goods> _modelGoods;

        static Goods()
        {
            _modelGoods = new List<Goods>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_price"></param>
        /// <param name="_expirationDate"></param>
        public Goods(string _name, decimal _price, int _expirationDate)
        {
            this.Id = new Guid();
            this.Name = _name;
            this.Price = _price;
            this.ExpirationDate = _expirationDate;
            this.DateAddGoodsToStorePlace = DateTime.Now;
        }

    }
}
