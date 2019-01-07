using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;

namespace GAPhoto
{
    public class GAVectorProject : IDisposable
    {
        public const byte VERSIONMAJOR = 0;
        public const byte VERSIONMINOR = 1;

        public string Filename = "";
        public bool Changed = false;

        public GAProjectProperties Properties;
        public GARepresentation BestYet;
        public FastBitmap SourceImage;

        public double BestComparison = double.MaxValue;

        private bool _disposed = false;
        public GAVectorProject()
        {
        }
        public GAVectorProject(string filename)
        {
            Filename = filename;
            Load();
        }

        ~GAVectorProject()
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
                    Properties = null;
                    BestYet = null;
                    SourceImage.Dispose();
                }
                _disposed = true;
            }
        }

        public void Load()
        {
            FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read);

            try
            {
                BinaryReader br = new BinaryReader(fs);
                string header = br.ReadString();
                if (header == "GAVECTORPROJECT")
                {
                    byte major = br.ReadByte();
                    byte minor = br.ReadByte();

                    if ((major < VERSIONMAJOR) || ((major == VERSIONMAJOR) && (minor <= VERSIONMINOR)))
                    {
                        GZipStream gz = new GZipStream(fs, CompressionMode.Decompress);

                        br = new BinaryReader(gz);

                        //Load The Image to a MemoryStream
                        float resx = br.ReadSingle();
                        float resy = br.ReadSingle();

                        int bmlength = br.ReadInt32();
                        byte[] buffer = br.ReadBytes(bmlength);
                        MemoryStream ms = new MemoryStream(buffer);
                        Bitmap bt = new Bitmap(ms);
                        bt.SetResolution(resx, resy);
                        ms.Close();
                        buffer = null;

                        // Draw the Bitmap onto a 24bpp canvas
                        SourceImage = new FastBitmap(bt.Width, bt.Height, PixelFormat.Format24bppRgb);
                        Graphics gp = Graphics.FromImage(SourceImage.GetBitmap());
                        gp.DrawImage(bt, PointF.Empty);
                        gp.Dispose();

                        Properties = new GAProjectProperties(br);
                        BestYet = new GARepresentation(br);
                        BestComparison = br.ReadDouble();
                    }
                    else
                    {
                        throw new Exception("Version incorrect, this version " + VERSIONMAJOR.ToString() + "." + VERSIONMINOR.ToString() + ", file version " + major.ToString() + "." + minor.ToString());
                    }
                }
                else
                {
                    throw new Exception("Not a GAVector Project File");
                }
            }
            catch (IOException)
            {
                throw new Exception("File is Corrupt");
            }
            finally
            {
                fs.Close();
            }
        }
        public void Save()
        {
            FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.Write);

            // Header, Version
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write("GAVECTORPROJECT");
            bw.Write((byte)VERSIONMAJOR);
            bw.Write((byte)VERSIONMINOR);
            bw.Dispose();
            //Compressed Contents
            GZipStream gz = new GZipStream(fs, CompressionMode.Compress);

            bw = new BinaryWriter(gz);

            //Bitmap & Resolution
            Bitmap b = SourceImage.GetBitmap();
            bw.Write((float)b.HorizontalResolution);
            bw.Write((float)b.VerticalResolution);
            MemoryStream ms = new MemoryStream();

            b.Save(ms, ImageFormat.Tiff);
            bw.Write((int)ms.Length);
            bw.Flush();
            ms.WriteTo(gz);
            ms.Close();
            bw.Flush();

            Properties.WriteBinary(bw);
            BestYet.WriteBinary(bw);
            bw.Write(BestComparison);
            bw.Flush();

            Changed = false;
        }

    }
}
