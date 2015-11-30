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

        public double GetAmount(int DaysRented)
        {
            double result = 0;
            //determine amounts for each line
            switch (PriceCode)
            {
                case MovieType.REGULAR: //普通片
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5;
                    break;

                case MovieType.NEW_RELEASE: //新片
                    result += DaysRented * 3;
                    break;

                case MovieType.CHILDRENS: //兒童片
                    result += 1.5;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5;
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoint(int DaysRented)
        {
            int frequentRenterPoints = 0;
            //累加 常客點數
            frequentRenterPoints++;

            //兩天以上 額外點數
            if (PriceCode == MovieType.NEW_RELEASE &&
                DaysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }
    }
}
