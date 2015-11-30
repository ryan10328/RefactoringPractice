﻿using System;
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
                frequentRenterPoints += GetFrequentRenterPoint(each);
                //顯示此筆租借記錄
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetAmount().ToString("0") + "\n";
                totalAmount += each.GetAmount();  
            }

            //footer 列印
            result += "Amount owed is " + totalAmount.ToString("0") + "\n";
            result += "You earned " + frequentRenterPoints.ToString("0") + " frequent renter points ";
            return result;
        }

        public int GetFrequentRenterPoint(Rental each)
        {
            int frequentRenterPoints = 0;
            //累加 常客點數
            frequentRenterPoints++;

            //兩天以上 額外點數
            if (each.Movie.PriceCode == MovieType.NEW_RELEASE &&
                each.DaysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }

    }
}
