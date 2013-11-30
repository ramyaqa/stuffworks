using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffWorks
{
    /// <summary>
    /// How long does a program take to run?
    ///     It depends on what you do and how you do. Understand that there are many ways to write a program and 
    ///     the program run time performs differently than other.
    ///     
    /// When to talk about Complexities:
    ///     Whenever working with a collection of items. 
    ///     Example: 
    ///         working on all items
    ///         sorting the collection
    ///         searching
    /// 
    /// Difference between algebraic complexities (linear, polynomial, constant, logarithemic, exponential)
    ///     let X be the number of items in an array
    ///     Linear: If you do operations in single "for" loop running through all the items in the array and program spends "a" amount of time per item, it takes aX to complete
    ///     Polynomial: If you do operation in two or more "for" loop running through array within each loop, it takes X * X ... times. Usually X^2, X^3, X^4 is considered polynomial. 
    ///     Exponential: If you have an array of X items and you run the program generating X number of "for" loops, the program takes X^X times to run. 
    ///     Logarithmic: Rather than a list that is straight, consider a list that is in Tree form. you only need to go log X times to reach any element in the Tree. 
    ///     Constant: Rather than a list or a tree, consider you have a hashtable where you know where to look for each of the element. 
    ///     
    /// Worst Case:
    ///     The alogorithm that usually makes the program run longest. Anything polynomial is worst. 
    ///     What is polynomial... 
    ///     
    ///     What 
    /// Best Case:  
    ///     The alogorithm that usually makes the program run in best possible time. Anything linear (good) or logarithmic (better) or constant (best)
    /// </summary>
    class Complexity
    {
        static int[] numOneToTenArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static int[] numOneToTenUnsorted = new int[] { 6, 9, 4, 10, 1, 2, 7, 8, 3, 5 };
        
        /// <summary>
        ///Problem: Given an array, modify such that array will now contain squares. 
        /// [1,2,3] ==> [1,4,9]
        /// Runs for loop single time for all elements
        /// </summary>
        public static void SquareArrayLinear(){
            int[] X = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             //***** LINEAR   X ******
             for(int i = 0 ; i < X.Length ; i++)
             {
                 //do some operation on X[i]
                 X[i] = X[i] * X[i];  //==> takes "a" amount of time. 
             }
             
             //Total run = a * X = aX 
        }

        /// <summary>
        ///Problem: Given an array, modify such that array will now contain squares. 
        /// [1,2,3] ==> [1,4,9]
        /// Runs for loop within another for loop for all the elements
        /// </summary>
        public static void SquareArrayPolynomial()
        {
            int[] X = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //***** POLYNOMIAL   X^2 ******
            for (int i = 0; i < X.Length; i++)  // This loop runs X times
            {
                for (int j = 0; j < X.Length; j++) // This loop runs another X times
                {
                    if (i == j) //square only when indexes match. 
                    {
                        //do some operation on X[i]
                        X[i] = X[i] * X[j];  //==> takes "a" amount of time. 
                    }
                }
            }

            //Total run = a * X * X = aX^2 
        }
    }
}
