using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StuffWorks
{
    public static class ArrayHelper
    {
        /****** WHAT ARE COLLECTIONS? ************/
        /*
            Collections are nothing but a group of objects. It can be a a collection of anything. Usually collections are of a same type, 
         * example collection of simple type
         *      collection are collection of string, collection of integers, collection of datetime fields
         * example collection of complex type
         *      collection are collection of car class in (Automobile.cs), collection of 
         * /
        
         Array: Array is a primitive collection
         
         Lists: Lists allow duplicate items, can be accessed by index, and support linear traversal.
             •  ArrayList - An array-based list that doesn't support generic types. It does not enforce type safety and should generally be avoided.
             •  List - An array list that supports generic types and enforces type-safety. Since it is non-contiguous, it can grow in size without re-allocating memory for the entire list. This is the more commonly used list collection.

        Hashes: Hashes are look-ups in which you give each item in a list a "key" which will be used to retrieve it later. Think of a hash like a table index where you can ask questions like "I'm going to find this object by this string value. Duplicate keys are not allowed.
            •  HashTable - A basic key-value-pair map that functions like an indexed list.
            •  Dictionary - A hashtable that supports generic types and enforces type-safety.
 
        Queues: Queues controls how items in a list are accessed. You typically push/pop records from a queue in a particular direction (from either the front or back). Not used for random access in the middle.
                • Stack - A LIFO list where you push/pop records on top of each other.
                • Queue - A FIFO list where you push records on top and pop them off the bottom

        */


        ///SCENARIO 1: you have a data file in csv (comma seperated value) format that you need create into a list
        public static void LoadCarFile()
        {
            ///A simple array of integers
            int[] someRandomNumbers = new int[] { 1, 5, 9, 121, 23421, 48896 };


            /// Exercise. Create an array of string
            /// Exercise. Create an array of object and include primitive types. like { 2, "apple", "two", 4.56 }


            string[] carsDataFile = c3_FileStuff.ReadFileLineByLine(@"..\..\data\cars.csv");

            ///ForEach construct is useful when you want to do some operation on a collection WITHOUT affecting 
            ///the integrity or structure of the collection (add, swap or delete an item inside collection). 
            ///you can modify the referenced item. 
            foreach (string currentLine in carsDataFile)
            {
                string[] tokensInEachLine = currentLine.Split(',');
                ///write the line by adding strings
                Console.WriteLine("Current Line from Cars data file = " + currentLine);
                ///another way of writing the same string
                Console.WriteLine(string.Format("Current Line from Cars data file = {0}", currentLine));
                //Exercise
                //Automobiles.Car carCreatedFromLine = new Automobiles.Car();

            }



        }
    }
}
