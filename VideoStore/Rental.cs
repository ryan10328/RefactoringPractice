using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public int DaysRented
        {
            get
            {
                return _daysRented;
            }
        }

        public Movie Movie
        {
            get
            {
                return _movie;
            }
        }


        public Rental(Movie movie,int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public double GetAmount()
        {
            double thisAmount = 0;
            //determine amounts for each line
            switch (Movie.PriceCode)
            {
                case MovieType.REGULAR: //普通片
                    thisAmount += 2;
                    if (DaysRented > 2)
                        thisAmount += (DaysRented - 2) * 1.5;
                    break;

                case MovieType.NEW_RELEASE: //新片
                    thisAmount += DaysRented * 3;
                    break;

                case MovieType.CHILDRENS: //兒童片
                    thisAmount += 1.5;
                    if (DaysRented > 3)
                        thisAmount += (DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}
