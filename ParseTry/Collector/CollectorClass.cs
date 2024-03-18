using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTry.Collector
{
    public static class CollectorClass
    {
        public static void AggressiveCollectAllGen()
        {
            GC.Collect(2, GCCollectionMode.Aggressive);
            GC.WaitForPendingFinalizers();
        }
    }
}
