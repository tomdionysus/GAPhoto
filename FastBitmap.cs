using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GAPhoto
{
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct PixelRGB
    {
        public byte B;
        public byte G;
        public byte R;

        public PixelRGB(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }
        public PixelRGB(byte a, byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    unsafe public class FastBitmap : IDisposable
    {

        Bitmap _bitmap = null;
        BitmapData _bitmapData = null;
        private bool _disposed = false;

        public FastBitmap()
        {
        }

        ~FastBitmap()
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
                    if (Locked) Unlock();
                    _bitmap.Dispose();
                    _bitmapData = null;
                }
                _disposed = true;
            }
        }

        public FastBitmap(string fileName)
        {
            _bitmap = new Bitmap(fileName);
        }
        public FastBitmap(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public FastBitmap(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
        }
        public FastBitmap(int width, int height, PixelFormat px)
        {
            _bitmap = new Bitmap(width, height, px);
        }

        public bool Locked
        {
            get
            {
                return (_bitmapData != null);
            }
        }

        public int Width
        {
            get
            {

                return _bitmap.Width;
            }
        }
        public int Height
        {
            get
            {
                return _bitmap.Height;
            }
        }

        public void Lock()
        {

            if (Locked)
            {
                throw new InvalidOperationException("Bitmap is already Locked");
            }

            _bitmapData = _bitmap.LockBits(new Rectangle(Point.Empty, _bitmap.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        }
        public void Unlock()
        {

            if (!Locked)
            {
                throw new InvalidOperationException("Bitmap is not Locked");
            }

            _bitmap.UnlockBits(_bitmapData);
            _bitmapData = null;
        }

        public Color GetPixel(int x, int y)
        {
            if (Locked)
            {
                PixelRGB* p = GetOffset(x, y);
                return Color.FromArgb(255, p->R, p->G, p->B);
            }
            else
            {
                return _bitmap.GetPixel(x, y);
            }
        }
        public void SetPixel(int x, int y, Color color)
        {
            if (Locked)
            {
                PixelRGB* position = GetOffset(x, y);
                position->R = color.R;
                position->G = color.G;
                position->B = color.B;
            }
            else
            {
                _bitmap.SetPixel(x, y, color);
            }
        }

        public void Invert()
        {
            if (!Locked)
            {
                throw new InvalidOperationException("Bitmap is not Locked");
            }

            for (int y = 0; y < _bitmapData.Width; y++)
            {

                for (int x = 0; x < _bitmapData.Height; x++)
                {
                    PixelRGB* pos = GetOffset(x, y);
                    pos->R = (byte)(255 - pos->R);
                    pos->G = (byte)(255 - pos->G);
                    pos->B = (byte)(255 - pos->B);
                    pos++;
                }
            }
        }

        public Bitmap GetBitmap()
        {
            return (Bitmap)_bitmap;
        }

        public BitmapData GetBitmapData()
        {
            if (!Locked)
            {
                throw new InvalidOperationException("Bitmap is not Locked");
            }
            return (BitmapData)_bitmapData;
        }

        public PixelRGB* GetOffset(int x, int y)
        {
            byte* pbase = (byte*)_bitmapData.Scan0.ToPointer();
            int offset = (y * _bitmapData.Width + x) * sizeof(PixelRGB);
            return (PixelRGB*)(pbase + offset);
        }

        public static double UltraCompare(FastBitmap s, FastBitmap t)
        {

            if (!s.Locked) s.Lock();
            if (!t.Locked) t.Lock();

            double diff = 0;

            for (int y = 0; y < s._bitmapData.Height; y++)
            {
                byte* sp = (byte*)s._bitmapData.Scan0.ToPointer();
                byte* tp = (byte*)t._bitmapData.Scan0.ToPointer();
                sp = sp + (s._bitmapData.Stride * y);
                tp = tp + (t._bitmapData.Stride * y);

                for (int x = 0; x < s._bitmapData.Width; x++)
                {
                    int di = 0;
                    for (int c = 0; c < 3; c++)
                    {
                        int d = *(sp++) - *(tp++);
                        if (d < 0) d = d * -1;
                        di += d;
                    }
                    diff += di;
                }
            }

            s.Unlock();
            t.Unlock();

            return diff;
        }

        public FastBitmap Duplicate()
        {
            Bitmap newbt = _bitmap.Clone(new Rectangle(0, 0, Width, Height), _bitmap.PixelFormat);
            return new FastBitmap(_bitmap);
        }
    }
}
