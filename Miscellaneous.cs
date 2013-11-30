using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffWorks
{
    class Miscellaneous
    {
        ///Answer: "xyzcatratabc" 
        ///“abcxyz” contains 2 other strings, 
        ///“ratcatabc” contains 3 other strings, 
        ///“xyzcatratabc” contains 4 other strings"
        public static void REF_MaxNumberOfWordsInWord()
        {
            string[] a = new string[] { "rat", "cat", "abc", "xyz", "abcxyz", "ratcatabc", "xyzcatratabc" };
            int[] score = new int[a.Length - 1];
            int count = 1;

            //loop 1
            for (int i = 0; i < a.Length; i++)
            {
                //loop 2
                for (int j = 0; j < a.Length; j++)
                {
                    if (i != j)
                    {
                        if (a[j].Contains(a[i]))
                        {
                            score[i] = count++;
                        }
                    }
                }

                count = 1;
            }

            Console.WriteLine(a[Math.Max(score[0], score[score.Length - 1])]);    // This will return the answer

            for (int i = 0; i < score.Length; i++)
            {
                Console.WriteLine(score[i]);
            }

        }


    }
}
