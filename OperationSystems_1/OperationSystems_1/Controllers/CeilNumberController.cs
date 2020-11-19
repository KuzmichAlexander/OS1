using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OperationSystems_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CeilNumberController : ControllerBase
    {
        public TaskQueue _taskqueue;
        public decimal current;
        static Stopwatch st = new Stopwatch();
        

        public CeilNumberController(TaskQueue taskqueue)
        {
            this._taskqueue = taskqueue;
        }

        // GET: api/CeilNumber/5
        [HttpGet("{id}", Name = "Get")]
        public Result Get(decimal id)
        {
            
            const int TIME_TO_WAKEUP = 4000;
            string answer = MathOperation(id);

            _taskqueue.Add(id);

            Result res = new Result(answer, id.ToString());

            if (id == _taskqueue.CurrentTask)
            {
                Thread.Sleep(_taskqueue.CurrentTime);
                res._TimeEnd = DateTime.Now;
                Log.SimularStack(res);
                return res;
            }

            CheckQueue(TIME_TO_WAKEUP, id);

            res._TimeEnd = DateTime.Now;

            Log.Report(res);

            return res;
        }

        private string MathOperation(decimal num) {
            return Math.Ceiling(num).ToString();
        }


        private void CheckQueue(int ms, decimal ans)
        {
            Stopwatch thread = new Stopwatch();
            thread.Start();
            while (true)
            {
                if (_taskqueue.Count == 1 || _taskqueue.CurrentTask == ans || _taskqueue[0] == ans)
                {
                    _taskqueue.CurrentTask = ans;
                    Thread.Sleep(ms);
                    _taskqueue.RemoveAt(0);
                    return;
                }
                else
                {
                    Thread.Sleep(Convert.ToInt32(ms * Math.Max(_taskqueue.Count, 1) + thread.ElapsedMilliseconds % ms));
                    _taskqueue.RemoveAt(0);
                    return;
                }
            }
        }
    }

   
}
