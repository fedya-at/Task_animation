using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace atelierTask
{
  
    class LongRun
    {
        int x;
        int y;
        long s;
        public LongRun()
        {
            x = 0;
            y = 0;
            s = 0;

        }
        private long dummyFunction()
        {

            for (int x = 0; x < 10000; x++)
            {
                for (int y = 0; y < 100000; y++)
                {
                    s++;
                }
            }
            return s;
        }
        private long dummyFunction(CancellationToken cancel)
        {
            long s = 0;
            for (int x = 0; x < 10000; x++)
            {
                for (int y = 0; y < 100000; y++)
                {
                    if (cancel.IsCancellationRequested)
                    {
                        return s;
                    }

                }
                s++;
            }

            return s;
        }
        public long count()
        {
            for (int x = 0; x < 10000; x++)
            {
                for (int y = 0; y < 100000; y++)
                {
                    s++;
                }
            }
            return s;
        }
        public async Task<long> CountAsync()
        {
            return await Task.Run<long>(() =>
            {
                for (int x = 0; x < 1000000; x++)
                {
                    for (int y = 0; y < 10000000; y++)
                    {
                        s++;
                    }
                }
                return s;


            }

            );
        }
        public async Task<long> CountAsync2()
        {
            return await Task.Run<long>(() => dummyFunction());
        }
        public async Task<long> CountAsync3()
        {
            
            return await Task.Run<long>(() => dummyFunction());
        }
        public async Task<long> CountAsync4(CancellationToken ct)
        {
            try
            {
                return await Task.Run<long>(() => dummyFunction(ct), ct);

            }
            catch (OperationCanceledException e)
            {
                throw e;

            }

        }

    
}
}
