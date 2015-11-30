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
    }
}
