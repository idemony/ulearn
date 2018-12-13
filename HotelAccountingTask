using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private void RefreshTotal()
        {
            total = price * nightsCount * (1 - discount / 100);
            Notify(nameof(Total));
        }

        private double price = 0;
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value >= 0)
                {
                    price = value;
                    Notify(nameof(Price));
                    RefreshTotal();
                }
                else
                    throw new ArgumentException();
            }
        }

        private int nightsCount = 0;
        public int NightsCount
        {
            get
            {
                return nightsCount;
            }

            set
            {
                if (value > 0)
                {
                    nightsCount = value;
                    Notify(nameof(NightsCount));
                    RefreshTotal();
                }
                else throw new ArgumentException();
            }
        }

        private void RefreshDiscount()
        {
            discount = (1 - total / (price * nightsCount)) * 100;
            Notify(nameof(Discount));
        }

        private double discount = 0;
        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
                Notify(nameof(Discount));
                if (discount > 100)
                    throw new ArgumentException();
                RefreshTotal();
            }
        }

        private double total = 0;
        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                if (value >= 0)
                {
                    total = value;
                    Notify(nameof(Total));
                    RefreshDiscount();
                }
                else throw new ArgumentException();
            }
        }
    }
}
