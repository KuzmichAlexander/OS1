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
        static Stopwatch st = new Stopwatch();
        

        public CeilNumberController(TaskQueue taskqueue)
        {
            this._taskqueue = taskqueue;
            StartTimer();
        }

        // GET: api/CeilNumber/5
        [HttpGet("{id}", Name = "Get")]
        public Result Get(decimal id)
        {
            const int TIME_TO_WAKEUP = 4000;
            string answer = MathOperation(id);

            Result res = new Result(answer, id.ToString());

            _taskqueue.Add(answer);

            CheckQueue(TIME_TO_WAKEUP, answer);

            res._TimeEnd = DateTime.Now;

            return res;
        }

        private string MathOperation(decimal num) {
            return Math.Ceiling(num).ToString();
        }

        async static private void StartTimer() {
            await Task.Run(() => {
                st.Start();
            });
        }

        private void CheckQueue(int ms, string ans)
        {
            Stopwatch thread = new Stopwatch();
            thread.Start();
            while (true)
            {
                if(_taskqueue.Count == 1)
                {
                    Thread.Sleep(ms);
                    _taskqueue.RemoveAt(0);
                    return;
                }
                else {
                    Thread.Sleep(Convert.ToInt32(ms * Math.Max(_taskqueue.Count , 1) + thread.ElapsedMilliseconds % ms));
                    _taskqueue.RemoveAt(0);
                    return;
                }
            }
        }
    }

   
}
