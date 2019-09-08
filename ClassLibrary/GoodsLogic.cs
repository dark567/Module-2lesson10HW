using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsLogic
    {
        /// <summary>
        /// List all goods
        /// </summary>
        public static Goods[] GetGoods
        {
            get
            {
                return Goods._modelGoods.ToArray(); // Серега, реально не понимаю почему List<Goods>  надо конвертировать в Array . 
                // https://stackoverflow.com/questions/1147497/c-sharp-listt-toarray-performance-is-bad
            }
        }
        /*
        Причины для вызова ToArray ()
        Если возвращаемое значение не предназначено для изменения, возвращение его в виде массива делает этот факт немного яснее.
        Если ожидается, что вызывающая сторона выполняет много непоследовательных обращений к данным, это может повысить производительность для массива по сравнению с List <>.
        Если вы знаете, вам нужно будет передать возвращенное значение сторонней функции, которая ожидает массив.
        Совместимость с вызывающими функциями, которые должны работать с .NET версии 1 или 1.1. Эти версии не имеют типа List <> (или каких-либо общих типов, в этом отношении).
        Причины не вызывать ToArray ()
        Если вызывающая сторона когда-либо должна добавить или удалить элементы, список <> абсолютно необходим.
        Преимущества производительности не обязательно гарантированы, особенно если вызывающий абонент получает доступ к данным последовательно. Существует также дополнительный шаг преобразования из List <> в массив, который занимает время обработки.
        Вызывающая сторона всегда может самостоятельно преобразовать список в массив.
        */
        /// <summary>
        /// add new goods
        /// </summary>
        /// <param name="_modelgoods">new item array goods</param>
        public static void AddGoods(Goods _modelgoods)
        {
            Goods._modelGoods.Add(_modelgoods);
        }

        /// <summary>
        /// del items array
        /// </summary>
        /// <param name="_index">index array</param>
        public static void RemoveGoods(int _index)
        {
            Goods._modelGoods.RemoveAt(_index);
        }

        /// <summary>
        /// метод эмулятор просрочки – по указанной дате поставки И КОЛИЧЕЧЕСТВО ДНЕЙ возвращает дату просрочки
        /// </summary>
        /// <param name="_expirationDate">count days expiration</param>
        /// <param name="DateAddGoodsToStorePlace">date limit</param>
        /// <returns></returns>
        public static DateTime CalcLimitExpirationDate(double _expirationDate, DateTime DateAddGoodsToStorePlace)
        {
            return DateAddGoodsToStorePlace.AddDays(_expirationDate);
        }
    }
}
