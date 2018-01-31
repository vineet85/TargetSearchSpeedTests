﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TargetInterviewCaseStudy3;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SearchSpeedTests
{
    [TestClass]
    public class SearchSpeedTests
    {
        const int numberofSearches = 2000000;
        const string filePath = @"..\\..\\..\\TargetInterviewCaseStudy3\\SearchFiles";
        const string testOutputFilePath = @"..\\..\\..\\";
        static List<string> words = new List<string>();
        static StringMatchSearch sm;
        static RegularExpressionSearch rg;
        static PreProcessSearch pp;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            sm = new StringMatchSearch(filePath);
            rg = new RegularExpressionSearch(filePath);
            pp = new PreProcessSearch(filePath);

            // Create output file for tests
            WriteToOutPutFile(testOutputFilePath, "New Test Started", false);

            // Initialize words for test
            foreach (var docTextPair in sm.documentTextPairs)
            {
                List<string> wordsInFile = new List<string>(docTextPair.Value.Split(' '));
                words.AddRange(wordsInFile);
            }
        }

        private static void WriteToOutPutFile(string fileName, string text, bool append)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName + @"\TestOutPut.txt", append))
            {
                file.WriteLine(text);
            }
        }

        [TestMethod]
        public void TestStringMatchTestSpeed()
        {
            Random rm = new Random();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int counter = 0;
            while (counter < numberofSearches)
            {
                string searchTerm = words[rm.Next(words.Count)];
                searchTerm = SantitizeTerm(searchTerm);
                sm.SearchPrintResults(searchTerm);
                counter++;
            }
            sw.Stop();

            double seconds = (double)sw.ElapsedMilliseconds / 1000;

            WriteToOutPutFile(testOutputFilePath, string.Format("Elapsed Time(seconds) for StringMatch test is: {0}", seconds), true);
        }

        private string SantitizeTerm(string searchTerm)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            searchTerm = rgx.Replace(searchTerm, "");
            return searchTerm;
        }

        [TestMethod]
        public void TestRegularExpressionsTestSpeed()
        {
            Random rm = new Random();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int counter = 0;
            while (counter < numberofSearches)
            {
                string searchTerm = words[rm.Next(words.Count)];
                searchTerm = SantitizeTerm(searchTerm);
                rg.SearchPrintResults(searchTerm);
                counter++;
            }
            sw.Stop();

            double seconds = (double)sw.ElapsedMilliseconds / 1000;

            WriteToOutPutFile(testOutputFilePath, string.Format("Elapsed Time(seconds) for RegularExpressions test is: {0}", seconds), true);
        }

        [TestMethod]
        public void TestPreProcessTestSpeed()
        {
            Random rm = new Random();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int counter = 0;
            while (counter < numberofSearches)
            {
                string searchTerm = words[rm.Next(words.Count)];
                searchTerm = SantitizeTerm(searchTerm);
                pp.SearchPrintResults(searchTerm);
                counter++;
            }
            sw.Stop();

            double seconds = (double)sw.ElapsedMilliseconds / 1000;

            WriteToOutPutFile(testOutputFilePath, string.Format("Elapsed Time(seconds) for PreProcess test is: {0}", seconds), true);
        }
    }
}
