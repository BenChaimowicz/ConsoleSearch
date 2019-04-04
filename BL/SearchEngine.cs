using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public static class SearchEngine
    {
        public static CurrentSearch currentSearch;

        public delegate void InvalidDirHandler(object source, EventArgs args);
        public static event InvalidDirHandler DirDoesNotExist;

        public static void OnDirDoesNotExist()
        {
            DirDoesNotExist?.Invoke(null, EventArgs.Empty);            
        }
        public static void NewSearch(string file, string dirs)
        {
            currentSearch = new CurrentSearch(file, dirs);
        }

        public static void Start()
        {
            bool isValidDir;
            if (currentSearch.SearchDirectory == "none")
            {
                isValidDir = true;
                foreach (string drive in Directory.GetLogicalDrives())
                {
                    SearchFile(drive);
                }
            }
            else
            {
                isValidDir = Directory.Exists(currentSearch.SearchDirectory);
                if (isValidDir)
                {
                    SearchFile(currentSearch.SearchDirectory);
                }
                else
                {
                    OnDirDoesNotExist();
                }
            }
            if (isValidDir)
            {
                LogSearchToDatabase();
            }
        }

        private static void FindResults(string dir)
        {
            foreach (string file in Directory.GetFiles(dir))
            {
                string fileonly = file.Substring(file.LastIndexOf("\\"));
                if (fileonly.ToLower().Contains(currentSearch.SearchFile))
                {
                    currentSearch.AddResult(file.ToLower());
                }
            }
        }

        private static void SearchFile(string sDir)
        {
            if (!currentSearch.rootSearched)
            {
                FindResults(sDir);
                currentSearch.rootSearched = true;
            }
            foreach (string dir in Directory.GetDirectories(sDir))
            {
                try
                {
                    FindResults(dir);
                    SearchFile(dir);
                }
                catch (UnauthorizedAccessException)
                {
                    currentSearch.PermissionExceptions++;
                }
            }
        }

        private static void LogSearchToDatabase()
        {
            string dbResults = string.Join(", ", currentSearch.Results);
            DB.LogSearch(currentSearch.SearchFile, currentSearch.SearchDirectory, dbResults, currentSearch.SearchDate);
        }
    }
}
