using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CurrentSearch
    {
        public string SearchFile{ get; set; }
        public string SearchDirectory { get; set; }
        public List<string> Results { get; }
        public DateTime SearchDate;
        public int PermissionExceptions { get; set; }
        public bool rootSearched { get; set; }

        public delegate void ResultHandler(object source, ResultArgs args);
        public event ResultHandler ResultFound;

        public CurrentSearch(string file, string dirs)
        {
            rootSearched = false;
            SearchFile = file.ToLower();
            SearchDirectory = dirs.ToLower();
            Results = new List<string>();
            SearchDate = DateTime.Now;
            PermissionExceptions = 0;
        }

        public void AddResult(string res)
        {
            Results.Add(res);
            OnSearchResultFound(res);
        }

        protected virtual void OnSearchResultFound(string res)
        {
            ResultFound?.Invoke(this, new ResultArgs() { Result = res });
        }
    }

    public class ResultArgs : EventArgs
    {
        public string Result { get; set; }
    }
}
