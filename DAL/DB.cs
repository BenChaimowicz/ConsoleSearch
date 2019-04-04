using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DB
    {
        public static FileSearchEntities DataBase = new FileSearchEntities();

        private static int GetID()
        {
            if (DataBase.Searches.Count() == 0)
            {
                return 1;
            }
            return DataBase.Searches.Max(s => s.ID + 1);

        }

        public static void LogSearch(string file, string dirs, string results, DateTime date)
        {
            Search search = new Search
            {
                ID = GetID(),
                File = file,
                Directory = dirs,
                Results = results,
                Date = date
            };
            try
            {
                DataBase.Searches.Add(search);
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
