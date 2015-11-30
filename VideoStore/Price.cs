using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    public abstract class Price
    {

        public abstract MovieType getPriceCode();

        public abstract double getCharge(int daysRented);

        public virtual int getFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    class ChildrensPrice : Price
    {
        public override MovieType getPriceCode()
        {
            return MovieType.CHILDRENS;
        }

        public override double getCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;

            return result;
        }
    }

    class NewReleasePrice : Price
    {
        public override MovieType getPriceCode()
        {
            return MovieType.NEW_RELEASE;
        }

        public override double getCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int getFrequentRenterPoints(int daysRented)
        {
            //兩天以上 額外點數
            if (daysRented > 1)
                return 2;
            else
                return 1;
        }
    }

    class RegularPrice : Price
    {
        public override MovieType getPriceCode()
        {
            return MovieType.REGULAR;
        }

        public override double getCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;

            return result;
        }
    }


}
