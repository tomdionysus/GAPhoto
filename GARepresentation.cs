using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using SvgNet;
using SvgNet.SvgGdi;

namespace GAPhoto
{
    [Serializable]
    public class GARepresentation
    {
        public List<GAShape> Shapes = new List<GAShape>();
        public int MaxX;
        public int MaxY;
        public Color BackgroundColour = Color.White;

        public int TotalPoints = 0;
        public int ByteSize = 0;

        public int OpPointAdded = 0;
        public int OpPointRemove = 0;
        public int OpPointMoved = 0;
        public int OpLinesCurves = 0;

        public int OpChangeColour = 0;
        public int OpSwapPoints = 0;

        public int OpShapeSplit = 0;
        public int OpShapeMerged = 0;
        public int OpShapeAdd = 0;
        public int OpShapeRemove = 0;

        public int OpShapeSwap = 0;

        public uint Generation = 0;
        public uint Iterations = 0;

        public GARepresentation()
        {
            MaxX = 100;
            MaxY = 120;
        }
        public GARepresentation(BinaryReader br)
        {
            ReadBinary(br);
        }
        public GARepresentation(int x, int y)
        {
            MaxX = x;
            MaxY = y;
        }
        public GARepresentation(Bitmap seed, int granule)
        {
            MaxX = seed.Width;
            MaxY = seed.Height;
        }

        public void GenericSeed(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            Shapes.Clear();

            AddShape(rd, prop, 0);

            UpdateTotalPoints();
        }
        public void MatrixSeed(Bitmap seed, GAProjectProperties prop)
        {

            Shapes.Clear();

            int plug = prop.Granularity / 2;

            for (int x = 0; x < MaxX; x += prop.Granularity)
            {
                for (int y = 0; y < MaxY; y += prop.Granularity)
                {
                    GAShapeFilledPolycurve gap = new GAShapeFilledPolycurve(this);
                    Color c = seed.GetPixel(Math.Min(x + plug, MaxX - 1), Math.Min(y + plug, MaxY - 1));
                    gap.ShapeColour = Color.FromArgb(128, c.R, c.G, c.B);
                    if ((gap.ShapeColour.ToArgb() & 0xFFFFFF) != (BackgroundColour.ToArgb() & 0xFFFFFF))
                    {
                        if (prop.MatrixSeedingType == GAMatrixSeedingType.Blocks) InitSeedBlocks(prop.Granularity, x, y, gap);
                        if (prop.MatrixSeedingType == GAMatrixSeedingType.Circles) InitSeedCircles(prop.Granularity, x, y, gap);
                        Shapes.Add(gap);
                    }
                }
            }

            UpdateTotalPoints();

        }

        private static void InitSeedBlocks(int granule, int x, int y, GAShape gap)
        {
            // Blocks
            gap.PolyPoints.Add(new PointF(x, y));
            gap.PolyPoints.Add(new PointF(x + granule, y));
            gap.PolyPoints.Add(new PointF(x + granule, y + granule));
            gap.PolyPoints.Add(new PointF(x, y + granule));
        }
        private static void InitSeedCircles(int plug, int x, int y, GAShape gap)
        {
            // Spheres
            float hplug = plug / 2;
            gap.PolyPoints.Add(new PointF(x + hplug, y));
            gap.PolyPoints.Add(new PointF(x + plug, y + hplug));
            gap.PolyPoints.Add(new PointF(x + hplug, y + plug));
            gap.PolyPoints.Add(new PointF(x, y + hplug));
        }

        public void ComputeBackground(FastBitmap source)
        {
            ColourHistogram ch = new ColourHistogram(source.GetBitmap());
            BackgroundColour = ch.MostFrequent();
            ch.Dispose();
        }

        public void Mutate(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            for (int j = 0; j < rd.Next(prop.MaxPolygonChanges) + 1; j++)
            {
                int tochange = rd.Next(Shapes.Count);

                int type = rd.Next(10);
                if ((type == 0) && (prop.AllowAdditionalShapes) && ((!prop.LimitPolygons) || (Shapes.Count < prop.PolygonLimit)))
                {
                    // New Shape
                    AddShape(rd, prop, tochange);
                }
                else if ((type == 1) && (prop.AllowShapeRemoval) && (Shapes.Count > 1))
                {
                    // Delete Shape
                    RemoveShape(tochange);
                }
                else if ((type == 2) && (Shapes.Count > 1))
                {
                    // Swap Two Shapes (Drawing Order)
                    SwapShapes(rd, tochange);
                }
                else
                {
                    // Change a Shape
                    Shapes[tochange].Mutate(rd, prop);
                }
            }
        }

        private void AddShape(ThreadSafeRandom rd, GAProjectProperties prop, int tochange)
        {
            GAShape gap = GAShape.CreateRandom(rd, prop, this);
            Shapes.Insert(tochange, gap);
            OpShapeAdd++;
        }
        private void SwapShapes(ThreadSafeRandom rd, int tochange)
        {
            int toswap = tochange;
            while (toswap == tochange) toswap = rd.Next(Shapes.Count);
            GAShape temp = Shapes[tochange];
            Shapes[tochange] = Shapes[toswap];
            Shapes[toswap] = temp;
            OpShapeSwap++;
        }
        private void RemoveShape(int tochange)
        {
            Shapes.RemoveAt(tochange);
            OpShapeRemove++;
        }

        public void UpdateTotalPoints()
        {
            TotalPoints = 0;
            ByteSize = 0;
            foreach (GAShape s in Shapes)
            {
                TotalPoints += s.GetTotalPoints();
                ByteSize += s.GetByteSize();
            }
        }

        public void Draw(IGraphics gp)
        {
                foreach (GAShape gap in Shapes)
                {
                    gap.Draw(gp);
                }
        }

        public GARepresentation Duplicate()
        {
            GARepresentation newrep = new GARepresentation(MaxX, MaxY);
            foreach (GAShape gp in Shapes)
            {
                GAShape newgap = gp.Duplicate(newrep);
                newrep.Shapes.Add(newgap);
            }
            newrep.BackgroundColour = BackgroundColour;

            newrep.OpChangeColour = OpChangeColour;
            newrep.OpLinesCurves = OpLinesCurves;
            newrep.OpPointAdded = OpPointAdded;
            newrep.OpPointMoved = OpPointMoved;
            newrep.OpPointRemove = OpPointRemove;
            newrep.OpSwapPoints = OpSwapPoints;

            newrep.OpShapeAdd = OpShapeAdd;
            newrep.OpShapeRemove = OpShapeRemove;
            newrep.OpShapeSplit = OpShapeSplit;
            newrep.OpShapeMerged = OpShapeMerged;

            newrep.OpShapeSwap = OpShapeSwap;

            newrep.Generation = Generation;
            newrep.Iterations = Iterations;

            newrep.UpdateTotalPoints();

            return newrep;

        }

        public void WriteBinary(BinaryWriter bw)
        {
            bw.Write(Generation);
            bw.Write(Iterations);
            bw.Write(MaxX);
            bw.Write(MaxY);
            bw.Write(Shapes.Count);

            bw.Flush();

            for (int i = 0; i < Shapes.Count; i++)
            {
                Shapes[i].WriteBinary(bw);
            }

            bw.Write((byte)BackgroundColour.R);
            bw.Write((byte)BackgroundColour.G);
            bw.Write((byte)BackgroundColour.B);

        }
        public void ReadBinary(BinaryReader br)
        {
            Generation = br.ReadUInt32();
            Iterations = br.ReadUInt32();
            MaxX = br.ReadInt32();
            MaxY = br.ReadInt32();

            int count = br.ReadInt32();
            Shapes.Clear();

            for (int i = 0; i < count; i++)
            {
                Shapes.Add(GAShape.ReadBinary(this,br));
            }

            byte r = br.ReadByte();
            byte g = br.ReadByte();
            byte b = br.ReadByte();
            BackgroundColour = Color.FromArgb(r, g, b);

        }

        public unsafe void DrawToFastBitmap(FastBitmap bitmap)
        {
            Graphics gp = Graphics.FromImage(bitmap.GetBitmap());
            gp.Clear(BackgroundColour);
            Draw(new GdiGraphics(gp));
            gp.Dispose();
        }
    }

}