using System;

namespace HopClassLib
{/// <summary>
///  Public class Hop 
/// </summary>
    public class Hop
    {

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="alphaAcide"></param>
        /// <param name="harvestYear"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        public Hop(int id, string name, double alphaAcide, int harvestYear, int price, int stock)
        {
            ID = id;
            Name = name;
            AlphaAcid = alphaAcide;
            Harvestyear = harvestYear;
            Price = price;
            Stock = stock;
        }
        /// <summary>
        ///  public int ID property
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Public string Name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  public double AlphaAcide property
        /// </summary>
        public double AlphaAcid { get; set; }

        /// <summary>
        /// public property int stock 
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// public int HarvestYear property
        /// </summary>
        public int Harvestyear { get; set; }
        /// <summary>
        ///  public int price property 
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        ///  public override string ToSting method that returns the properties into a string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" ID: {ID}, Name: {Name}, AlphaAcid: {AlphaAcid}, HarvestYear: {Harvestyear} , Price: {Price}";
        }



    }
}
