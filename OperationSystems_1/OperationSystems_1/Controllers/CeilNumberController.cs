using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace OperationSystems_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CeilNumberController : ControllerBase
    {
        TaskQueue _taskqueue;
        public CeilNumberController(TaskQueue taskqueue)
        {
            this._taskqueue = taskqueue;
        }

        // GET: api/CeilNumber/
        [HttpGet("{id}", Name = "Get")]
        public Result Get(decimal id)
        {
            const int TIME_TO_WAKEUP = 4000;
            string answer = MathOperation(id);

            Result res = new Result(answer, id.ToString());

            if (_taskqueue.Count == 0)
            {
                _taskqueue.Add(id, DateTime.Now.AddMilliseconds(TIME_TO_WAKEUP));

                Thread.Sleep((_taskqueue[id] - DateTime.Now));

                res._TimeEnd = DateTime.Now;
                Log.Report(res);
                _taskqueue.Remove(id);
                return res;
            }
            else if (_taskqueue.ContainsKey(id))
            {
                Thread.Sleep(_taskqueue[id] - DateTime.Now);

                res._TimeEnd = DateTime.Now;
                Log.SimularStack(res);
                return res;
            }
            else
            {
                _taskqueue.Add(id, DateTime.Now.AddMilliseconds(TIME_TO_WAKEUP * _taskqueue.Count + _taskqueue.Last().Value.Millisecond));
                Thread.Sleep(_taskqueue[id] - DateTime.Now);

                _taskqueue.Remove(id);
                res._TimeEnd = DateTime.Now;
                Log.Report(res);
                return res;
            }
        }

        private string MathOperation(decimal num)
        {
            return Math.Ceiling(num).ToString();
        }
    }


}
