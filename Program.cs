﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv04
{
    class Program
    {
        static void Main(string[] args)
        {
            string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
                + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                + "posledni veta!";

            StringStatistics test = new StringStatistics(testovaciText);

            Console.WriteLine(testovaciText);

            Console.WriteLine("\nIs infected: {0}", test.IsInfected());
            Console.WriteLine("Words: {0, 10}", test.WordCount());
            Console.WriteLine("Lines: {0, 10}", test.LineCount());
            Console.WriteLine("Sentences: {0, 6}\n", test.SentenceCount());
            
            Console.WriteLine("Longest words: {0}", test.LongestToString());
            Console.WriteLine("Shortest words: {0}", test.ShortestToString());
            Console.WriteLine("Most common word: {0}", test.OccuranceToString());
            Console.WriteLine("Words alphabetically: {0}", test.SortedToString());
            Console.ReadLine();
        }
    }
}
