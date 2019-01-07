using System;
using System.Collections.Generic;
using System.Text;

namespace GAPhoto
{
    public class MovingAverage
    {
        private Queue<int> _items = new Queue<int>();
        public int Length;

        public MovingAverage()
        {
            Length = 5;
        }
        public MovingAverage(int length)
        {
            Length = length;
        }

        public void Update(int item)
        {
                _items.Enqueue(item);
                if (_items.Count > Length) _items.Dequeue();
        }

        public double Average()
        {
                double output = 0;
                foreach (int i in _items) output += i;
                return output / _items.Count;
        }
    }

    public class MovingAverageF
    {
        private Queue<double> _items = new Queue<double>();
        public int Length;

        public MovingAverageF()
        {
            Length = 5;
        }
        public MovingAverageF(int length)
        {
            Length = length;
        }

        public void Update(double item)
        {
                _items.Enqueue(item);
                if (_items.Count > Length) _items.Dequeue();
        }

        public double Average()
        {

                double output = 0;
                foreach (double i in _items) output += i;
                return output / _items.Count;
        }
    }
}
