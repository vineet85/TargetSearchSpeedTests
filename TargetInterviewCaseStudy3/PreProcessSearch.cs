using System;
using System.Collections.Generic;

namespace TargetInterviewCaseStudy3
{
    public class PreProcessSearch : SearchBase
    {
        Dictionary<string, Dictionary<string, int>> hashTable;

        public PreProcessSearch(string filePath) : base(filePath) 
        {
            hashTable = new Dictionary<string, Dictionary<string, int>>();
            BuildHashTable(documentTextPairs);
        }

        private void BuildHashTable(List<KeyValuePair<string, string>> documentTextPairs)
        {
            foreach (KeyValuePair<string, string> documentTextPair in documentTextPairs)
            {
                string fileName = documentTextPair.Key;
                string text = documentTextPair.Value;

                foreach (string word in text.Split(' '))
                {
                    if(!hashTable.ContainsKey(word))
                    {
                        hashTable.Add(word, new Dictionary<string, int>() { { fileName, 1 } });
                        
                        // Add remaining files to dictionary with 0 count.
                        foreach(KeyValuePair<string, string> fName in documentTextPairs.FindAll(x => x.Key != fileName))
                        {
                            hashTable[word].Add(fName.Key, 0);
                        }
                    }
                    else
                    {
                        if(!hashTable[word].ContainsKey(fileName))
                        {
                            hashTable[word].Add(fileName, 1);
                        }
                        else
                        {
                            hashTable[word][fileName]++;
                        }
                    }
                }
            }
        }

        public override void SearchPrintResults(string searchTerm)
        {
            results = new List<KeyValuePair<string, int>>();

            if (hashTable.ContainsKey(searchTerm))
            {
                // Find word/results in hashtable
                Dictionary<string, int> resultsDict = hashTable[searchTerm];
                
                // Add to results.
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