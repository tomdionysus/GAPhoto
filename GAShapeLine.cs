using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using SvgNet.SvgGdi;

namespace GAPhoto
{
    public class GAShapeLine : GAShape
    {
        public new const GAShapeType Type = GAShapeType.Line;
        public float Width = 1;

        public GAShapeLine(GARepresentation owner)
        {
            Owner = owner;
        }
        public GAShapeLine(GARepresentation owner, BinaryReader br)
        {
            Owner = owner;
            ReadBinary(br);
        }

        public override void Draw(IGraphics gp)
        {
            Pen pb = new Pen(ShapeColour);
            pb.Width = Width;

            PointF[] apoints = PolyPoints.ToArray();

            gp.DrawLines(pb, apoints);
        }

        public override void Randomize(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            PolyPoints.Clear();

            PointF p;

            for (int i = 0; i < 2; i++)
            {
                p = new PointF(rd.Next(Owner.MaxX), rd.Next(Owner.MaxY));
                PolyPoints.Add(p);
            }

            ShapeColour = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255), rd.Next(255));

        }
        public override void Mutate(ThreadSafeRandom rd, GAProjectProperties prop)
        {

            for (int i = 0; i < rd.Next(prop.MaxPointChanges) + 1; i++)
            {
                int type = rd.Next(10);

                if ((type == 0) && (PolyPoints.Count < 256) && ((!prop.LimitPoints) || (PolyPoints.Count <= prop.PointLimit)))
                {
                    // Add A Line
                    AddRandomPoint(rd, prop);
                    Owner.OpPointAdded++;
                }
                else if ((type == 1) && (PolyPoints.Count > 2))
                {
                    // Remove A Line
                    RemoveRandomPoint(rd);
                    Owner.OpPointRemove++;
                }
                else if (type == 2)
                {
                    // Change Colour
                    MutateColour(rd, prop);
                    Owner.OpChangeColour++;
                }
                else if ((type == 3) && (prop.AllowPointSwapping) && (PolyPoints.Count > 3))
                {
                    // Swap Points
                    SwapPoints(rd);
                    Owner.OpSwapPoints++;
                }
                else if (type == 4)
                {
                    // Change Width
                    Width += positionnudge(rd, prop);
                }
                else
                {
                    MutateRandomPoint(rd, prop);
                    Owner.OpPointMoved++;
                }
            }
        }

        private void SwapPoints(ThreadSafeRandom rd)
        {
            int tochange = rd.Next(PolyPoints.Count);
            int tochange2 = tochange;
            while (tochange2 == tochange) tochange2 = rd.Next(PolyPoints.Count);
            PointF p = PolyPoints[tochange];
            PolyPoints[tochange] = PolyPoints[tochange2];
            PolyPoints[tochange2] = p;
        }
        private void AddRandomPoint(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            PointF p = GetRandomPoint(rd, prop);
            PolyPoints.Insert(rd.Next(PolyPoints.Count), p);
        }
        private void RemoveRandomPoint(ThreadSafeRandom rd)
        {
            PolyPoints.RemoveAt(rd.Next(PolyPoints.Count));
        }
        private void MutateRandomPoint(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            int tochange = rd.Next(PolyPoints.Count);
            PointF pt = PolyPoints[tochange];
            switch (rd.Next(3))
            {
                case 0:
                    //Change X
                    pt.X += positionnudge(rd, prop);
                    pt.X = limit(pt.X, Owner.MaxX, 0);
                    break;
                case 1:
                    // Change Y
                    pt.Y += positionnudge(rd, prop);
                    pt.Y = limit(pt.Y, Owner.MaxY, 0);
                    break;
                case 2:
                    //Change X + Y
                    pt.X += positionnudge(rd, prop);
                    pt.X = limit(pt.X, Owner.MaxX, 0);
                    pt.Y += positionnudge(rd, prop);
                    pt.Y = limit(pt.Y, Owner.MaxY, 0);
                    break;
            }
            PolyPoints[tochange] = pt;
        }

        public override GAShape Duplicate(GARepresentation newowner)
        {
            GAShapeLine newgap = new GAShapeLine(newowner);
            newgap.ShapeColour = this.ShapeColour;
            newgap.Width = Width;

            foreach (PointF p in PolyPoints)
            {
                newgap.PolyPoints.Add(new PointF(p.X, p.Y));
            }
            return newgap;
        }

        public override void WriteBinary(BinaryWriter bw)
        {
            bw.Write((byte)Type);
            bw.Write((double)Width);
            WriteBinaryColour(bw);
            WriteBinaryPoints(bw);
        }
        public void ReadBinary(BinaryReader br)
        {
            Width = (float)br.ReadDouble();
            ReadBinaryColour(br);
            ReadBinaryPoints(br);
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

        private void WriteBinaryPoints(BinaryWriter bw)
        {
            bw.Write((byte)PolyPoints.Count);
            for (int i = 0; i < PolyPoints.Count; i++)
            {
                bw.Write((int)PolyPoints[i].X);
                bw.Write((int)PolyPoints[i].Y);
            }
            bw.Flush();
        }
        private void ReadBinaryPoints(BinaryReader br)
        {
            PolyPoints.Clear();

            byte count = br.ReadByte();
            for (int i = 0; i < count; i++)
            {
                PolyPoints.Add(
                    new PointF(
                        br.ReadInt32(),
                        br.ReadInt32()
                        )
                    );
            }
        }

        public override int GetTotalPoints()
        {
            return PolyPoints.Count;
        }
        public override int GetByteSize()
        {
            // 4 x byte colour ARGB
            // PolyPoints.Count x Coordinates x int
            // 1 int width
            return (PolyPoints.Count * 8) + 4 + sizeof(int);
        }

        public override void WriteSVG(XmlWriter xw)
        {
            StringBuilder pts = new StringBuilder();

            foreach (PointF p in PolyPoints)
            {
                pts.Append(p.X.ToString());
                pts.Append(",");
                pts.Append(p.Y.ToString());
                pts.Append(",");
            }
            pts.Remove(pts.Length - 1, 1);

            xw.WriteComment("GAShapeLine WriteSVG UNTESTED");
            xw.WriteStartElement("polyline");
            xw.WriteAttributeString("fill", "none");
            xw.WriteAttributeString("stroke", "#" + ShapeColour.R.ToString("X").PadLeft(2, '0') + ShapeColour.G.ToString("X").PadLeft(2, '0') + ShapeColour.B.ToString("X").PadLeft(2, '0'));
            xw.WriteAttributeString("stroke-width", Width.ToString() + "px");
            xw.WriteAttributeString("opacity", (((double)ShapeColour.A / 255)).ToString());
            xw.WriteAttributeString("points", pts.ToString());
            xw.WriteEndElement();

            /* SVG 1.1 Element
             * 
             <polyline fill="none" stroke="blue" stroke-width="10" 
               points="50,375
                    150,375 150,325 250,325 250,375
                    350,375 350,250 450,250 450,375
                    550,375 550,175 650,175 650,375
                    750,375 750,100 850,100 850,375
                    950,375 950,25 1050,25 1050,375
                    1150,375" />

            */
        }
    }
}