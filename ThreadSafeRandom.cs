using System;
using System.Collections.Generic;
using System.Text;

namespace GAPhoto
{
    public class ThreadSafeRandom
    {
        private static Random random = new Random();
        public int Next()
        {
            lock (random)
            {
                return random.Next();
            }
        }
        public int Next(int Max)
        {
            lock (random)
            {
                return random.Next(Max);
            }
        }
        public int Next(int Min, int Max)
        {
            lock (random)
            {
                return random.Next(Min, Max);
            }
        }
    }
}
