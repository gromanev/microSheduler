﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroSheduler
{
    public class MicroShedulerBase
    {
        /// <summary>
        /// Таймер
        /// </summary>
        protected Timer Timer;
        protected double Interval = 0;

        /// <summary>
        /// Функция запуска диспетчера
        /// </summary>
        protected void StartSheduler(Func<Task<bool>> sheduleMethod)
        {
            Timer = new Timer(async state =>
            {
                try
                {
                    if (await sheduleMethod()) Interval = 1;
                    else throw new Exception();
                }
                catch (Exception e)
                {
                    Interval = 0.5;
                }
                finally
                {
                    Timer.Change(MinutesToMs(Interval), Timeout.Infinite);
                }
            }, null, MinutesToMs(Interval), Timeout.Infinite);
        }

        /// <summary>
        /// Перевод минут в секнды
        /// </summary>
        /// <param name="minutesCount"></param>
        /// <returns></returns>
        protected int MinutesToMs(double minutesCount)
        {
            return (int)TimeSpan.FromMinutes(minutesCount).TotalMilliseconds;
        }
    }
}
