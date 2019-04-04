using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL;
using System.Threading.Tasks;

namespace SearchApp
{
    public class Menu
    {
        bool dirInvalid = false;

        public Menu()
        {
        }
        private void ClearMenu()
        {
            Console.Clear();
        }

        public void ShowMenu()
        {
            ClearMenu();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Welcome To SearchApp!");
            Console.WriteLine("Please enter selection:");
            Console.WriteLine("1. Search for file name.");
            Console.WriteLine("2. Search for file name in a directory.");
            Console.WriteLine("3. Exit");
            string selection = Console.ReadLine();
            CheckSelection(selection);
        }

        private void CheckSelection(string selection)
        {
            switch (selection)
            {
                case "1":
                    SearchFile();
                    break;
                case "2":
                    SearchDir();
                    break;
                case "3":
                    Console.WriteLine("Good bye!");
                    break;
                default:
                    ShowMenu();
                    break;
            }
        }

        private void SearchFile()
        {
            Console.WriteLine("Enter file name to search:");
            string filename = Console.ReadLine();
            if (filename != null && filename != "" && filename.Trim(' ').Length != 0)
            {
                SearchEngine.NewSearch(filename, "none");
                Console.WriteLine("Searching. Please wait...");
                SearchEngine.currentSearch.ResultFound += OnResultFound;
                SearchEngine.Start();
                Summarize(SearchEngine.currentSearch);
            }
            else
            {
                Console.WriteLine("Please type a valid file name!");
                Console.ReadLine();
                ShowMenu();
            }
        }
        
        private void SearchDir()
        {
            Console.WriteLine("Enter file name to search:");
            string filename = Console.ReadLine();
            while (filename == "" || filename == null || filename.Trim(' ').Length == 0)
            {
                Console.WriteLine("Please enter a valid file name:");
                filename = Console.ReadLine();
            }
            Console.WriteLine("Enter directory to search in:");
            Console.WriteLine(@"Example: c:\directory");
            string directory = Console.ReadLine();
            while (directory == "" || directory == null || directory.Trim(' ').Length == 0)
            {
                Console.WriteLine("Please enter a valid directory name:");
                directory = Console.ReadLine();
            }
            SearchEngine.NewSearch(filename, directory);
            Console.WriteLine("Searching. Please wait...");
            SearchEngine.currentSearch.ResultFound += OnResultFound;
            SearchEngine.DirDoesNotExist += OnDirDoesNotExist;
            SearchEngine.Start();
            if (dirInvalid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory does not exist!");
                dirInvalid = false;
                Console.ReadLine();
                ShowMenu();
            }
            else
            {
                Summarize(SearchEngine.currentSearch);
            }
            SearchEngine.DirDoesNotExist -= OnDirDoesNotExist;
        }

        public void OnResultFound(object source, ResultArgs args)
        {
            Console.WriteLine(args.Result);
        }

        public void OnDirDoesNotExist(object source,EventArgs args)
        {
            dirInvalid = true;
        }

        private void Summarize(CurrentSearch currentSearch)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Number of results: " + currentSearch.Results.Count);
            Console.WriteLine("Permission exceptions: " + currentSearch.PermissionExceptions);
            Console.WriteLine("Search saved in database.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            SearchEngine.currentSearch.ResultFound -= OnResultFound;
            ShowMenu();
        }
    }
}
