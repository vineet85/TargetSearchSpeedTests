using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TargetInterviewCaseStudy3
{
    /// <summary>
    /// Class to perform searches using regular expressions.
    /// </summary>
    /// <seealso cref="TargetInterviewCaseStudy3.SearchBase" />
    public class RegularExpressionSearch : SearchBase
    {
        public RegularExpressionSearch(string filePath) : base (filePath)
        {
        }

        public override void SearchPrintResults(string searchTerm)
        {
            results = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, string> documentTextPair in documentTextPairs)
            {
                string fileName = documentTextPair.Key;
                string searchText = documentTextPair.Value;

                int hits = FindHits(searchText, searchTerm);

                results.Add(new KeyValuePair<string, int>(fileName, hits));
            }

            PrintSearchResults(results);
        }

        private int FindHits(string searchText, string searchTerm)
        {
            // Using regex \bword\b to match on word boundaries.
            return Regex.Matches(searchText, @"\b" + searchTerm + @"\b").Count;
        }
    }
}