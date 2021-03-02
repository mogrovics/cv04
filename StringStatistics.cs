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
    }
}
