using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace GAPhoto
{
    public class ColourHistogram : IDisposable
    {
        private Dictionary<Color, int> _histogram = new Dictionary<Color, int>();
        private bool _disposed = false;

        public ColourHistogram(Bitmap source)
        {
            Compute(source);
        }

        ~ColourHistogram()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _histogram = null;
                }
                _disposed = true;
            }
        }
        public void Compute(Bitmap source)
        {
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    if (!_histogram.ContainsKey(c))
                        _histogram.Add(c, 1);
                    else
                        _histogram[c]++;
                }
            }
        }
        public Color MostFrequent()
        {
            Color c = Color.Empty;
            int best = 0;
            foreach (KeyValuePair<Color, int> k in _histogram)
            {
                if (k.Value > best)
                {
                    c = k.Key;
                    best = k.Value;
                }
            }

            return c;
        }
        public Color LeastFrequent()
        {
            Color c = Color.Empty;
            int best = int.MaxValue;
            foreach (KeyValuePair<Color, int> k in _histogram)
            {
                if (k.Value < best)
                {
                    c = k.Key;
                    best = k.Value;
                }
            }

            return c;
        }


    }
}

