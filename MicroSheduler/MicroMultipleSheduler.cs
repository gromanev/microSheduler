using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroSheduler
{
    public class MicroMultipleSheduler : MicroShedulerBase
    {
        private static List<MicroMultipleSheduler> Pool { get; set; }
        private MicroMultipleSheduler() { }

        private MicroMultipleSheduler(Func<Task<bool>> sheduleMethod, double successInterval, double failedInterval)
        {
            base.SuccessInterval = successInterval;
            base.FailInterval = failedInterval;

            base.StartSheduler(sheduleMethod);
        }

        public static void Start(Func<Task<bool>> sheduleMethod, double successInterval = 1, double failedInterval = 1)
        {
            if (Pool == null) Pool = new List<MicroMultipleSheduler>();
            Pool.Add(new MicroMultipleSheduler(sheduleMethod, successInterval, failedInterval));
        }
    }
}
