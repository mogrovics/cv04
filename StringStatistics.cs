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
            char[] separator = {' ', '.', ',', '!', '?', '(', ')', '\n' };
            
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

            //loop checks every substring created by separators for uppercase letter at the beginning of each "sentence"
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

        //method to determine most commonly occurring words in a string
        //https://stackoverflow.com/questions/8707208/find-the-highest-occuring-words-in-a-string-c-sharp
        public string[] MaxOccurringWord()
        {
            char[] separator = { ' ', '.', ',', '!', '?', '(', ')', '\n' };
            string[] words = testString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counter = new Dictionary<string, int>(); //pair of keys (words) and values (number of occurances)

            //filling of dictionary counter
            foreach (string word in words)
            {
                if (counter.ContainsKey(word)) //if a word already is in the dictionary, increment it's value (count) by 1
                {
                    counter[word]++;
                }
                else //if a word is not in the dictionary, add it with a count of 1 
                    counter[word] = 1;
            }

            var wordCounter = counter.ToArray();
            Array.Sort(wordCounter, (val1, val2) => val1.Value.CompareTo(val2.Value)); //sort by number of occurrences (asc)
            Array.Reverse(wordCounter); //reverse the array (dsc)

            int maxOccurance = wordCounter[0].Value; //maximum occurrance
            wordCounter = wordCounter.Where(val => val.Value == maxOccurance).ToArray(); //filter the array so that only words with maximum occurrance remain

            int wordCounterSize = wordCounter.Length;
            string[] mostOccurringList = new string[wordCounterSize];
            
            //loop that adds most occurring words to a special array
            for (int i = 0; i < wordCounterSize; i++)
            {
                mostOccurringList[i] = wordCounter[i].Key;
            }

            return mostOccurringList; 
        }

        //method to make array printable
        public string OccuranceToString()
        {
            string[] words = MaxOccurringWord();
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

        //method to sort a string alphabetically
        public string[] AlphabetSort()
        {
            char[] separator = { ' ', '.', ',', '!', '?', '(', ')', '\n' };
            string[] words = testString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(words);

            return words;
        }

        //method to make array printable
        public string SortedToString()
        {
            string[] words = AlphabetSort();
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
