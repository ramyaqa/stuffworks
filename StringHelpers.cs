using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffWorks
{
    public static class StringHelper
    {

        //Input: hello world 
        //Output: HELLO WORLD
        public static string ConvertStringIntoUpperCase(string input)
        {
            return input.ToUpper();
        }

        /// <summary>
        /// First character of every word should be in UPPER case
        /// Input:  hello world, swetha
        /// Output: Hello World, Swetha
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertStringIntoTitleCase(string inputString)
        {
            string outputWord = string.Empty;
            /* Note that you have to change the case of first character of EVERY word */
            /* If you need to do something on EVERY, then you have to deal with a collection */
            
            //Convert string to words. split by space (' ')
            string[] wordsInInputString = inputString.Split(' '); //split sentence into an array of words
            for (int i = 0; i < wordsInInputString.Length; i++)
            {
                //this will iterate through all the words in the string
                string word = wordsInInputString[i];
                char firstCharacter = word[0]; //Note that string is an array of characters
                string restOfWord = word.Substring(1); //Start with the second character. //There is an issue here, find out by running test cases

                string changedWord = firstCharacter.ToString() + restOfWord; // you have to convert char to string before joining. 
                outputWord += changedWord + " "; // add a space between words and join words into string

            }

            return outputWord;
        }

        public static string ConcatStringSimple(string string1, string string2)
        {
            return string1 + string2;
        }

        public static StringBuilder ConcatStringWithStringBuilder(string string1, StringBuilder stringBuilder)
        {
            stringBuilder.Append(string1);
            return stringBuilder;
        }
    }
}
