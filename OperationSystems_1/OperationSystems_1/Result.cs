using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationSystems_1
{
    public class Result
    {
        public Result(string result, string startnum)
        {
            this._result = result;
            this._TimeStart = DateTime.Now;
            this._StartNum = startnum;
        }
        public DateTime _TimeStart { get; set; }
        public string _result { get; set; }
        public string _StartNum { get; set; }
        public DateTime _TimeEnd { get; set; }
    }
}
