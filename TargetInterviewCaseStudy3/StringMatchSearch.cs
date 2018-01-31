using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TargetInterviewCaseStudy3
{
    /// <summary>
    /// Class to perform string match search.
    /// </summary>
    /// <seealso cref="TargetInterviewCaseStudy3.SearchBase" />
    public class StringMatchSearch : SearchBase
    {
        public StringMatchSearch(string filePath) : base (filePath)
        {
        }

        /// <summary>
        /// Searches using string matching and prints results.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        public override void SearchPrintResults(string searchTerm)
        {
            results = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, string> searchDocTextPair in documentTextPairs)
            {
                string fileName = searchDocTextPair.Key;
                string searchText = searchDocTextPair.Value;
                int hits = GetSearchHits(searchText, searchTerm);
                results.Add(new KeyValuePair<string, int>(fileName, hits));
            }

            PrintSearchResults(results);
        }

        /// <summary>
        /// Gets the search hits using string matching.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="searchTerm">The search term.</param>
        /// <returns></returns>
        private int GetSearchHits(string searchText, string searchTerm)
        {
            int hits = 0;

            // Remove punctuation from text.
            var punctuation = searchText.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = searchText.Split().Select(x => x.Trim(punctuation));

            foreach (string word in words)
            {
                if (word == searchTerm) hits++;
            }

            return hits;
        }

    }
}