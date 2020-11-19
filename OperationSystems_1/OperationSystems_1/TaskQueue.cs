using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationSystems_1
{
    public class TaskQueue : List<decimal>
    {
        public decimal CurrentTask { get; set; }
        public int CurrentTime { get; set; }
    }
}
