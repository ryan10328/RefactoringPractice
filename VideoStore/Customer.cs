using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    class Customer
    {
        private string _name; //姓名
        private List<Rental> _rentals = new List<Rental>(); //租借記錄

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string statement()
        {
            double totalAmount = 0; //總消費金額
            int frequentRenterPoints = 0; //常客績點
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + Name + "\n";

            foreach (var each in rentals)// 取得租借記錄
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case MovieType.REGULAR: //普通片
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;

                    case MovieType.NEW_RELEASE: //新片
                        thisAmount += each.DaysRented * 3;
                        break;

                    case MovieType.CHILDRENS: //兒童片
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }

                //累加 常客點數
                frequentRenterPoints++;

                //兩天以上 額外點數
                if (each.Movie.PriceCode == MovieType.NEW_RELEASE &&
                    each.DaysRented >1)
                    frequentRenterPoints++;

                //顯示此筆租借記錄
                result += "\t" + each.Movie.Title + "\t" +
                    thisAmount.ToString("0") + "\n";
                totalAmount += thisAmount;  
            }

            //footer 列印
            result += "Amount owed is " + totalAmount.ToString("0") + "\n";
            result += "You earned " + frequentRenterPoints.ToString("0") + " frequent renter points ";
            return result;
        }
    }
}
