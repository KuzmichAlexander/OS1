using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace OperationSystems_1
{
    public class Log
    {
        static string writePath = @"log.txt";
        static public void StartProgram()
        {
            string hash = new Random().Next(1, 500000).ToString() + "sgkerhd&d" + new Random().Next(1, 500000).ToString() + "rteewf";
            string start = "Start session...\n" + $"Session hash: {hash} \n";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine(start);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine(ex);
                }
            }

        }
        static public void Report(Result res, string hash)
        {
            string report = $"Из потока {hash} на обработку пришло значение:{res._StartNum} /// Время: {res._TimeStart} \n Результат вычислений: {res._result} /// Время окончания вычисления: {res._TimeEnd}";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine(report);
                    sw.WriteLine("---------------------------------------------------------\n");
                }
            }
            catch 
            {
            
            }
        }
        static public void SimularValue(InputParam res)
        {
            string report = $"Из потока:{res.CurHash} пришло значение, которое уже вычисляется \n/// Время окончания вычисления: {res.TimeEnd} \nПодобное значение уже вычисляется \n Результат вычисления был отправлен пользователю без очереди";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine(report);
                    sw.WriteLine("---------------------------------------------------------\n");
                }
            }
            catch
            {

            }
        }
    }
}
