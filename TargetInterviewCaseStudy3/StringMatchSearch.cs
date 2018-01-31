using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TargetInterviewCaseStudy3
{
    public class StringMatchSearch : SearchBase
    {
        public StringMatchSearch(string filePath) : base (filePath)
        {

        }
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

        private int GetSearchHits(string searchText, string searchTerm)
        {
            int hits = 0;

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