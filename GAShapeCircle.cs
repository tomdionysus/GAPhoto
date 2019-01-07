using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using SvgNet.SvgGdi;

namespace GAPhoto
{
    public class GAShapeCircle : GAShape
    {
        public new const GAShapeType Type = GAShapeType.Circle;
        public int Size;

        public GAShapeCircle(GARepresentation owner)
        {
            Owner = owner;
            PolyPoints.Add(PointF.Empty);
        }
        public GAShapeCircle(GARepresentation owner, BinaryReader br)
        {
            Owner = owner;
            ReadBinary(br);
        }
        public override GAShape Duplicate(GARepresentation newowner)
        {
            GAShapeCircle p = new GAShapeCircle(newowner);
            p.PolyPoints[0] = new PointF(PolyPoints[0].X, PolyPoints[0].Y);
            p.ShapeColour = ShapeColour;
            p.Size = Size;
            return p;
        }

        public override void Randomize(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            PolyPoints[0] = GetRandomPoint(rd, prop);
            ShapeColour = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255), rd.Next(255));
            Size = rd.Next(prop.MaxPointMovement) + 1;
        }
        public override void Draw(IGraphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            SolidBrush p = new SolidBrush(ShapeColour);
            RectangleF r = new RectangleF(PolyPoints[0].X - (Size / 2), PolyPoints[0].Y - (Size / 2), Size, Size);
            g.FillEllipse(p, r);
        }
        public override void Mutate(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            for (int i = 0; i < rd.Next(prop.MaxPointChanges) + 1; i++)
            {
                switch (rd.Next(3))
                {
                    case 0:
                        MutateColour(rd, prop);
                        break;
                    case 1:
                        MutatePosition(rd, prop);
                        break;
                    case 2:
                        MutateSize(rd, prop);
                        break;
                }
            }
        }

        public override PointF GetRandomPoint(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            return new PointF(NextFloat(rd, Owner.MaxX), NextFloat(rd, Owner.MaxY));
        }

        public override int GetTotalPoints()
        {
            return 1;
        }
        public override int GetByteSize()
        {
            // 2x PolyPoints[0] 32bits
            // 1x Size 32Bits
            // 4x ARGB Byte
            return 16;
        }

        public void MutatePosition(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            PointF pt = PolyPoints[0];
            switch (rd.Next(2))
            {
                case 0:
                    pt.X += positionnudge(rd, prop);
                    break;
                case 1:
                    pt.Y += positionnudge(rd, prop);
                    break;
            }

            pt.X = limit(pt.X, Owner.MaxX, 0);
            pt.Y = limit(pt.Y, Owner.MaxY, 0);

            PolyPoints[0] = pt;
        }
        public void MutateSize(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            int maxsize = Math.Max(Owner.MaxX, Owner.MaxY);
            if (Size == 1)
            {
                Size = 2;
                return;
            }
            else if (Size == maxsize)
            {
                Size = maxsize - 1;
            }
            else
            {
                Size += sizenudge(rd, prop);
            }
            Size = limit(Size, maxsize, 1);
        }

        public override void WriteBinary(BinaryWriter wt)
        {
            wt.Write((byte)Type);
            wt.Write(Size);
            wt.Write((double)PolyPoints[0].X);
            wt.Write((double)PolyPoints[0].Y);
            WriteBinaryColour(wt);
        }
        public void ReadBinary(BinaryReader br)
        {
            Size = br.ReadInt32();
            PolyPoints.Clear();
            PolyPoints.Add(new PointF((float)br.ReadDouble(), (float)br.ReadDouble()));
            ReadBinaryColour(br);
        }

        private void WriteBinaryColour(BinaryWriter bw)
        {
            bw.Write((byte)ShapeColour.R);
            bw.Write((byte)ShapeColour.G);
            bw.Write((byte)ShapeColour.B);
            bw.Write((byte)ShapeColour.A);
        }
        private void ReadBinaryColour(BinaryReader br)
        {
            byte r = (byte)br.ReadByte();
            byte g = (byte)br.ReadByte();
            byte b = (byte)br.ReadByte();
            byte a = (byte)br.ReadByte();

            ShapeColour = Color.FromArgb(a, r, g, b);
        }

        private int sizenudge(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            int diff = rd.Next(prop.MaxPointMovement) + 1;
            if (rd.Next(2) == 0) diff *= -1;
            return diff;
        }

        public override void WriteSVG(XmlWriter xw)
        {
            xw.WriteStartElement("circle");
            xw.WriteAttributeString("cx", PolyPoints[0].X.ToString() + "px");
            xw.WriteAttributeString("cy", PolyPoints[0].Y.ToString() + "px");
            xw.WriteAttributeString("r", (Size/2).ToString() + "px");
            xw.WriteAttributeString("fill", "#" + ShapeColour.R.ToString("X").PadLeft(2, '0') + ShapeColour.G.ToString("X").PadLeft(2, '0') + ShapeColour.B.ToString("X").PadLeft(2, '0'));
            xw.WriteAttributeString("opacity", (((double)ShapeColour.A / 255)).ToString());
            xw.WriteEndElement();
        }
    }
}
