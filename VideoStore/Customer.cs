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
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + Name + "\n";

            foreach (var each in rentals)// 取得租借記錄
            {
                //顯示此筆租借記錄
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetAmount().ToString("0") + "\n";
            }

            //footer 列印
            result += "Amount owed is " + GetTotalCharge().ToString("0") + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints().ToString("0") + " frequent renter points ";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var each in _rentals)// 取得租借記錄
            {
                result += each.GetAmount();
            }
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach(var each in _rentals)
            {
                result += each.GetFrequentRenterPoint();
            }
            return result;
        }

    }
}
