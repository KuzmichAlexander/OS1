using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;

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
        [HttpPost]
        public Result Post(InputParams ip)
        {
            Result res = new Result(ip.Num.ToString());

            getDelay(ip);

            string result = MathOperation(ip.Num);

            res._TimeEnd = DateTime.Now;
            res._result = result;

            Log.Report(res, ip.CurHash);

            return res;
        }

        void getDelay (InputParams ip)
        {
            const int TIME_TO_WAKEUP = 4000;

            if (_taskqueue.Count == 0) // Распечатываем очередь
            {
                var stack = new InputParam(ip.Num, ip.CurHash); 
                stack.TimeEnd = DateTime.Now.AddMilliseconds(TIME_TO_WAKEUP);

                _taskqueue.Add(stack);

                Thread.Sleep(stack.TimeEnd - DateTime.Now);

                _taskqueue.Remove(stack);
            }
            //Есть ли такое значение в очереди
            else if (_taskqueue.Any(item => item.Num == ip.Num))
            {
                var stack = new InputParam(ip.Num, ip.CurHash);
                var time = _taskqueue.First(item => item.Num == ip.Num).TimeEnd;
                stack.TimeEnd = time;

                Thread.Sleep(Math.Max((stack.TimeEnd - DateTime.Now).Milliseconds, 0));

                Log.SimularValue(stack);
            }
            //есть ли ещё обработка из этого потока
            else if (_taskqueue.Any(item => item.CurHash == ip.CurHash))
            {
                var stack = new InputParam(ip.Num, ip.CurHash);
                
                //Ищем последний элемент в очереди этого потока
                var time = _taskqueue.Last((item) => item.CurHash == ip.CurHash).TimeEnd;
                stack.TimeEnd = time.AddMilliseconds(TIME_TO_WAKEUP);

                _taskqueue.Add(stack);

                Thread.Sleep(stack.TimeEnd - DateTime.Now);

                _taskqueue.Remove(stack);
            }
            else
            {
                var stack = new InputParam(ip.Num, ip.CurHash);
                var time = DateTime.Now;
                stack.TimeEnd = time.AddMilliseconds(TIME_TO_WAKEUP);

                _taskqueue.Add(stack);

                Thread.Sleep(stack.TimeEnd - DateTime.Now);

                _taskqueue.Remove(stack);

            }
        }
        

        private string MathOperation(float num)
        {
            return Math.Ceiling(num).ToString();
        }
    }


}
