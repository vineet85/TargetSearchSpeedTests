using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInterviewCaseStudy3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run New Search (Y/N)");
            string continueRunning = Console.ReadLine();

            while(continueRunning.ToLower() == "y")
            {
                Console.WriteLine("Enter the path of files to be searched:");
                string filePath = Console.ReadLine();

                Console.WriteLine("Enter the type of search (StringMatch, RegularExpressions, PreProcess): ");
                string searchType = Console.ReadLine().ToLower();

                Console.WriteLine("Enter the search term: ");
                string searchTerm = Console.ReadLine();

                SearchType type = (SearchType)Enum.Parse(typeof(SearchType), searchType);

                SearchBase searchMethod = SearchBase.CreateSearchType(type, filePath);
                searchMethod.SearchPrintResults(searchTerm);

                Console.WriteLine("Run New Search (Y/N)");
                continueRunning = Console.ReadLine();
            }
        }
    }
}
