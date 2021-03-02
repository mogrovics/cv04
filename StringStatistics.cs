﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv04
{
    class StringStatistics
    {
        public string testString;

        //StringStatistics constructor
        public StringStatistics(string testString)
        {
            this.testString = testString;
        }

        //method to determine word count in a string using common separators
        public int WordCount()
        {
            char[] separator = {' ', '.', ',', '!', '?', '\n'};
            
            return testString.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        //method to determine number of lines using "\n"
        public int LineCount()
        {
            char newLineChar = '\n';
            return testString.Split(newLineChar).Length;
        }

        //method to determine number of sentences
        public int SentenceCount()
        {
            char[] separator = { '.', '!', '?' };
            string[] sentences = testString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;

            //cycle checks every substring created by separators for uppercase letter at the beginning of each "sentence"
            //everytime the condition is met, counter is incremented by 1
            foreach ( string sentence in sentences)
            {
                try
                {
                    char nextLetter = sentence.First(char.IsUpper);
                    counter++;
                }
                catch (Exception)
                {
                    continue;
                }
                
            }
            return counter;
        }

        //method to determine longest words in string
        public string[] LongestWord()
        {
            char[] separator = { ' ', '.', ',', '!', '?', '(', ')', '\n' };
            string[] words = testString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            //sort by lenght (asc)
            Array.Sort(words, (s1, s2) => s1.Length.CompareTo(s2.Length));
            //reverse (dsc)
            Array.Reverse(words);

            int maxLenght = words[0].Length;
            //remove all elements with lenght neq maxlenght
            words = words.Where(word => word.Length == maxLenght).ToArray();

            return words;
        }

        //method to make array printable
        public string LongestToString()
        {
            string[] words = LongestWord();
            string printable = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (i != words.Length - 1)
                    printable += words[i] + ", ";
                else
                    printable += words[i];
            }

            return printable;
        }

        //method to determine shortest words in string
        public string[] ShortestWord()
        {
            char[] separator = { ' ', '.', ',', '!', '?', '(', ')', '\n' };
            string[] words = testString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            //sort by lenght (asc)
            Array.Sort(words, (s1, s2) => s1.Length.CompareTo(s2.Length));

            int minLenght = words[0].Length;
            //remove all elements with lenght neq minlenght
            words = words.Where(word => word.Length == minLenght).ToArray();

            return words;
        }

        //method to make array printable
        public string ShortestToString()
        {
            string[] words = ShortestWord();
            string printable = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (i != words.Length - 1)
                    printable += words[i] + ", ";
                else
                    printable += words[i];
            }

            return printable;
        }
    }
}
