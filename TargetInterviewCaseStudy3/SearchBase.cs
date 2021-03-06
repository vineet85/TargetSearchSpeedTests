﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInterviewCaseStudy3
{
    public abstract class SearchBase
    {
        public List<KeyValuePair<string, string>> documentTextPairs;
        protected List<KeyValuePair<string, int>> results;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBase"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public SearchBase(string filePath)
        {
            documentTextPairs = new List<KeyValuePair<string, string>>();

            // Read files from directory and populate in-memory KeyValuePair store
            string[] fileEntries = Directory.GetFiles(filePath);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);
        }

        /// <summary>
        /// Processes the input files into KeyValuePair format. i.e FileName - FileText
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void ProcessFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            documentTextPairs.Add(new KeyValuePair<string, string>
                (Path.GetFileName(filePath), text));
        }

        /// <summary>
        /// Prints the search results.
        /// </summary>
        /// <param name="results">The results.</param>
        protected void PrintSearchResults(List<KeyValuePair<string, int>> results)
        {
            foreach (KeyValuePair<string, int> resultPair in results)
            {
                Console.WriteLine(string.Format("{0}: {1}", resultPair.Key, resultPair.Value));
            }
        }

        public abstract void SearchPrintResults(string searchTerm);

        /// <summary>
        /// Creates the search class based on input.
        /// </summary>
        /// <param name="searchType">Type of the search.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static SearchBase CreateSearchType(SearchType searchType, string filePath)
        {
            switch(searchType)
            {
                case SearchType.stringmatch: return new StringMatchSearch(filePath);
                case SearchType.regularexpressions: return new RegularExpressionSearch(filePath);
                case SearchType.preprocess: return new PreProcessSearch(filePath);
                default: return null;
            }
        }
    }
}
