using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationSystems_1
{
    public class TaskQueue : List<InputParam>
    {

    }
    public class InputParam
    {
        public InputParam(float number, string hash)
        {
            this.Num = number;
            this.CurHash = hash;
        }
        public float Num { get; set; }
        public string CurHash { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
