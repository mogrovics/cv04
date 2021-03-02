using System;
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
    }
}
