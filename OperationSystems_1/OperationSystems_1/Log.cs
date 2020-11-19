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
            catch
            {

            }

        }
        static public void Report(Result res)
        {
            string report = $"На обработку пришло значение:{res._StartNum} /// Время: {res._TimeStart} \n Результат вычислений: {res._result} /// Время окончания вычисления: {res._TimeEnd}";
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
        static public void SimularStack(Result res)
        {
            string report = $"На обработку пришло значение:{res._StartNum} /// Время: {res._TimeStart} \nПодобное значение уже вычисляется \n Результат вычисления был отправлен пользователю без очереди в: {res._TimeEnd}";
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
