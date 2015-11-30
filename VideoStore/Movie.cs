using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    public enum MovieType
    { 
        CHILDRENS = 2,
        REGULAR = 0,
        NEW_RELEASE =1
    }

    /// <summary>
    /// 純 Moive 資料型類別
    /// </summary>
    public class Movie
    {
        private string _title; //名稱
        private MovieType _priceCode; //價格(代號)

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public MovieType PriceCode
        {
            get {
                return _priceCode;
            }
            set
            {
                _priceCode = value;
            }
        }

        public Movie(string title, MovieType priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
    }
}
