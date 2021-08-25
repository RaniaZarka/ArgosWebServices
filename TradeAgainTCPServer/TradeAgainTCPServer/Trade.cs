using System;
using System.Collections.Generic;
using System.Text;

namespace TradeAgainTCPServer
{
    class Trade
    {
        private string tradeType;
        private double price;
        private double salePrice;
        private double purchasePrice;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Trade() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerId"></param>
        /// <param name="shareName"></param>
        /// <param name="sharePrice"></param>
        /// <param name="numberOfShares"></param>
        /// <param name="tradeType"></param>
        /// <param name="price"></param>
        public Trade(int id, int customerId, string shareName, int sharePrice, int numberOfShares, string tradeType, double price)
        {
            ID = id;
            CustomerID = customerId;
            ShareName = shareName;
            SharePrice = sharePrice;
            NumberOfShares = numberOfShares;
            TradeType = tradeType;
            Price = price;

        }
        /// <summary>
        /// public properties
        /// </summary>
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ShareName { get; set; }
        public int SharePrice { get; set; }
        public int NumberOfShares { get; set; }

        /// <summary>
        /// public string Property that accept only Buy or Sell 
        /// </summary>
        public string TradeType
        {
            get { return tradeType; }
            set
            {
                if (tradeType != "Sell" || tradeType != "Buy")
                    throw new Exception("Not valid");
                else tradeType = value;
            }

        }


        //public string TradeType { get; set; }
        /// <summary>
        /// Price public double  property
        /// </summary>
        public static double Price { get; set; }





        /// <summary>
        /// Public static method that calculate the price 
        /// </summary>
        /// <param name="TradeType"></param>
        /// <param name="Price"></param>
        /// <param name="NumberOfShares"></param>
        /// <param name="SharePrice"></param>
        /// <returns></returns>
        public static double CalculatePrice(string TradeType, int NumberOfShares, int SharePrice)
        {

            if (TradeType == "Buy")
            {
                Price = NumberOfShares * SharePrice * 1.005;

            }

            else if (TradeType == "Sell")

            {
                Price = NumberOfShares * SharePrice * 0.995;

            }

            return Price;

        }

    }
}
