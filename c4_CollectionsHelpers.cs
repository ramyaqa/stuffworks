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
             •  List - An array list that supports generic types and enforces type-safety. Since it is non-contiguous, 
                     it can grow in size without re-allocating memory for the entire list. This is the more commonly used list collection.
             •  HashSet - An array list that will not allow duplicates. Items are called Keys 

        Hashes: Hashes are look-ups in which you give each item in a list a "key" which will be used to retrieve it later. 
                Think of a hash like a table index where you can ask questions like "I'm going to find this object by this string value. Duplicate keys are not allowed.
            •  HashTable - A basic key-value-pair map that functions like an indexed list.
            •  Dictionary - A hashtable that supports generic types and enforces type-safety.
 
        Queues: Queues controls how items in a list are accessed. You typically push/pop records from a queue in a particular 
                    direction (from either the front or back). Not used for random access in the middle.
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

        /// <summary>
        /// TODO
        /// </summary>
        public static void CreateIntegerArray()
        {
            int[] someRandomNumbers = new int[] { 1, 5, 9, 121, 23421, 48896 };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static void CreateCharArray()
        {
            char[] someRandomChars = new char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static void CreateStringArray()
        {
            string[] someRandomString = new string[] { "hello", "world", "I", "am", "great" };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static void CreateFloatArray()
        {
            float[] someRandomNumbers = new float[] { 1.0f, 5.3f, 9.55f, 121.001f, 23421, 48896 };
        }

        public static void CreateCharArrayFromString(string str)
        {
            char[] charArrayFromString = new char[str.Length]; 
            ///Note that you must specify the length of array beforehand for memory allocation
            ///In the above case, you know that a string will be converted to char array exactly
            ///the size of the string.

            for (int i = 0; i < str.Length; i++)
            {
                charArrayFromString[i] = str[i];
            }
        }

        public static void CreateCharArrayUsingLibrary(string str)
        {
            char[] charArrayFromString = str.ToCharArray();
        }

        /// <summary>
        /// 23373 should return int [] {2,3,3,7,3}
        /// </summary>
        /// <param name="number"></param>
        public static void CreateNumberArrayFromAnyNumber(int number)
        {
            /// we do not know the size of the array to initialize by just seeing the number
            /// we could try a couple of things
            ///     convert to string and find a length
            ///     initialize a List<int> so we need not know the size of integer. 
            ///     

            List<int> FirstWayToCreateNumberList = new List<int>(); //No need to specify the size
            int[] SecondWayToCreateNumberArray = new int [number.ToString().Length]; //because input is integer 0100 is always sent as 100. careful if input is string
            int counterForSecondArray = 0;
            /// Take 23373 and go from digit to digit. changing to string is easy. but lets say we should not use string here
            /// To get the last digit of any number, you can divide by 10 and get the reminder
            /// To get all the other digits except last, you can simply divide by zero and take the quotient
            /// 

            while (number > 0)
            {
                int lastDigit = number % 10;
                int allNumberExceptLastDigit = number / 10;
                FirstWayToCreateNumberList.Add(lastDigit);
                SecondWayToCreateNumberArray[counterForSecondArray++] = lastDigit; // note the ++. What is the difference between ++i and i++;
            }

            int[] FirstWayToCreateNumberArray = FirstWayToCreateNumberList.ToArray();
        }
    }
}
