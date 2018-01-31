using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TargetInterviewCaseStudy3
{
    /// <summary>
    /// Search using pre-processing of input files.
    /// </summary>
    /// <seealso cref="TargetInterviewCaseStudy3.SearchBase" />
    public class PreProcessSearch : SearchBase
    {
        Dictionary<string, Dictionary<string, int>> hashTable;

        public PreProcessSearch(string filePath) : base(filePath) 
        {
            hashTable = new Dictionary<string, Dictionary<string, int>>();
            BuildHashTable(documentTextPairs);
        }

        /// <summary>
        /// Builds the hash table from the input files. Hashtable is in the form (word - docs(s) - count)
        /// </summary>
        /// <param name="documentTextPairs">The document text pairs.</param>
        private void BuildHashTable(List<KeyValuePair<string, string>> documentTextPairs)
        {
            foreach (KeyValuePair<string, string> documentTextPair in documentTextPairs)
            {
                string fileName = documentTextPair.Key;
                string text = documentTextPair.Value;

                foreach (string word in text.Split())
                {
                    String sanitizedWord = Regex.Replace(word, @"\p{P}", "");

                    if (!hashTable.ContainsKey(sanitizedWord))
                    {
                        hashTable.Add(sanitizedWord, new Dictionary<string, int>() { { fileName, 1 } });
                        
                        // Add remaining files to dictionary with 0 count.
                        foreach(KeyValuePair<string, string> fName in documentTextPairs.FindAll(x => x.Key != fileName))
                        {
                            hashTable[sanitizedWord].Add(fName.Key, 0);
                        }
                    }
                    else
                    {
                        if(!hashTable[sanitizedWord].ContainsKey(fileName))
                        {
                            hashTable[sanitizedWord].Add(fileName, 1);
                        }
                        else
                        {
                            hashTable[sanitizedWord][fileName]++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Searches and prints results.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        public override void SearchPrintResults(string searchTerm)
        {
            results = new List<KeyValuePair<string, int>>();

            // If the hashtable containing preprocessed terms contains the word being searched in results are returned.
            if (hashTable.ContainsKey(searchTerm))
            {
                // Find word/results in hashtable
                Dictionary<string, int> resultsDict = hashTable[searchTerm];
                
                // Add to result set.
                foreach (KeyValuePair<string, int> result in resultsDict)
                {
                    results.Add(new KeyValuePair<string, int>(result.Key, result.Value));
                }
            }
            else
            {
                // Adding empty set if word not found in hashtable.
                foreach (var item in documentTextPairs)
                {
                    results.Add(new KeyValuePair<string, int>(item.Key, 0));
                }
            }

            PrintSearchResults(results);
        }
    }
}