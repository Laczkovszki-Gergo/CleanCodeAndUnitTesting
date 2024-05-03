using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04Homework.Source
{
    public class UserRequest
    {
        public bool IsUserSearchRequested { get; set; }
        public bool IsDataProcessingRequested { get; set; }
        public string[] UserList { get; set; }
        public string SearchTerm { get; set; }
        public int ProcessingIterations { get; set; }
    }
}
