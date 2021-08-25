using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DiceLib
{/// <summary>
///  public class DiceROll
/// </summary>
    public class DiceRoll
    {
        /// <summary>
        ///  private instance fields 
        /// </summary>
        private Random rnd;
        private int numberOfDice;
        private int guess;
        private int result;

        /// <summary>
        /// public int property ID
        /// </summary>
        public  int ID { get; set; }

        /// <summary>
        /// public int  property that can be 1 or 2 
        /// </summary>
       public  int NumberOfDice
        {
            get { return numberOfDice; }
            set
            {
                if (value <1 || value >2)
                    throw new Exception("out of range");
                
                else
                    numberOfDice = value;

            }
        }

        /// <summary>
        ///  public int property if NumberOfDice is 1, then its value is between 1 and 7, otherwise value is between 2 and 12 
        ///  
        /// </summary>
        public int Guess
        { get 
            { return guess; }
            set
            {
                if (NumberOfDice == 1)
                {
                    guess = rnd.Next(1, 7);

                }
                else if (NumberOfDice == 2)
                {
                    guess = rnd.Next(2, 13);
                }
                else throw new Exception("Wrong number");
            } 
        
        }

        /// <summary>
        ///  public property  if NumberOfDice is 1, then its value is between 1 and 7, otherwise value is between 2 and 12 
        /// </summary>
        public int Result
        {
            get
            { return result; }
            set
            { if (NumberOfDice == 1)
                {
                     result = rnd.Next(1, 7);
                }
                else if (NumberOfDice == 2)
                {
                    result = rnd.Next(2, 13);
                }
            }
        }
        /// <summary>
        ///  public random property 
        /// </summary>
       public  Random Rnd { get; set; }

        /// <summary>
        ///  public int method that retun the guess of the user 
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GuessResult( int guess, int number)
        {
            if( number==1)
            {
                guess= rnd.Next(1, 7);
                
            }

            else if(number==2)
            {
                guess = rnd.Next(2, 13);
            }


            return guess;
        }

    }
}
