using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace GAPhoto
{
    public enum GAShapeType { Polygon, PolyCurve, Path, Line }
    [Serializable]
    public class GAShape
    {
        public List<Point> PolyPoints = new List<Point>();
        public Color PolyColor = Color.FromArgb(255, 0, 0, 0);
        public GAShapeType Type;

        public GARepresentation Owner;

        public GAShape(GARepresentation owner)
        {
            Owner = owner;
        }
        public GAShape(GARepresentation owner, BinaryReader br)
        {
            Owner = owner;
            ReadBinary(br);
        }

        public void Draw(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(PolyColor);
            Pen pb = new Pen(sb);

            Point[] apoints = PolyPoints.ToArray();
            switch (Type)
            {
                case GAShapeType.Polygon:
                    gp.FillPolygon(sb, apoints);
                    break;
                case GAShapeType.PolyCurve:
                    gp.FillClosedCurve(sb, apoints, System.Drawing.Drawing2D.FillMode.Winding, 1);
                    break;
                case GAShapeType.Line:
                    gp.DrawLine(pb, apoints[0], apoints[1]);
                    break;

            }
        }

        public void Randomize(Random rd, GAProjectProperties prop)
        {
            PolyPoints.Clear();

            Point p;

            for (int i = 0; i < 4; i++)
            {
                p = new Point(rd.Next(Owner.MaxX), rd.Next(Owner.MaxY));
                PolyPoints.Add(p);
            }

            PolyColor = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255), rd.Next(255));

            int type = rd.Next(3);
            if ((type == 0) && (prop.UseFilledPolygons))
            {
                Type = GAShapeType.Polygon;
            }
            else if ((type == 1) && (prop.UseFilledPolycurves))
            {
                Type = GAShapeType.PolyCurve;
            }
            else if ((type == 2) && (prop.UseLines))
            {
                Type = GAShapeType.Line;
            }

        }

        public void Mutate(Random rd, GAProjectProperties prop)
        {

            for (int i = 0; i < rd.Next(prop.MaxPointChanges) + 1; i++)
            {
                int type = rd.Next(20);

                if ((type == 0) && (PolyPoints.Count < 256) && ((!prop.LimitPoints) || (PolyPoints.Count <= prop.PointLimit)) && (Type!=GAShapeType.Line))
                {
                    // Add A Point
                    AddRandomPoint(rd, prop);
                    Owner.OpPointAdded++;
                }
                else if ((type == 1) && (PolyPoints.Count > 4))
                {
                    // Remove A Point
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
                else if ((type == 4) && (prop.AllowShapeSplitting) && (PolyPoints.Count > 5))
                {
                    // Split Polygon
                    Split(rd);
                    Owner.OpShapeSplit++;
                }
                else
                {
                    MutateRandomPoint(rd, prop);
                    Owner.OpPointMoved++;
                }
            }
        }

        private void Split(Random rd)
        {
            int cur = 0;

            GAShape gp = null;

            Queue<GAShape> nw = new Queue<GAShape>();

            while (cur < PolyPoints.Count && ((PolyPoints.Count - cur) > 2))
            {
                gp = Duplicate(Owner);
                gp.PolyPoints.Clear();
                for (int i = 0; i < 3 + rd.Next(PolyPoints.Count - cur); i++) gp.PolyPoints.Add(PolyPoints[cur++]);
                nw.Enqueue(gp);
            }
            while (cur < PolyPoints.Count) gp.PolyPoints.Add(PolyPoints[cur++]);

            gp = nw.Dequeue();
            PolyPoints = gp.PolyPoints;
            while (nw.Count > 0) Owner.Shapes.Add(nw.Dequeue());
        }

        private void SwapPoints(Random rd)
        {
            int tochange = rd.Next(PolyPoints.Count);
            int tochange2 = tochange;
            while (tochange2 == tochange) tochange2 = rd.Next(PolyPoints.Count);
            Point p = PolyPoints[tochange];
            PolyPoints[tochange] = PolyPoints[tochange2];
            PolyPoints[tochange2] = p;
        }

        private void AddRandomPoint(Random rd, GAProjectProperties prop)
        {
            Point p = GetRandomPoint(rd, prop);
            PolyPoints.Insert(rd.Next(PolyPoints.Count), p);
        }

        private void RemoveRandomPoint(Random rd)
        {
            PolyPoints.RemoveAt(rd.Next(PolyPoints.Count));
        }

        private void MutateRandomPoint(Random rd, GAProjectProperties prop)
        {
            int tochange = rd.Next(PolyPoints.Count);
            Point pt = PolyPoints[tochange];
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

        private void MutateColour(Random rd, GAProjectProperties prop)
        {
            int r, b, g, a = 0;
            r = PolyColor.R;
            g = PolyColor.G;
            b = PolyColor.B;
            a = PolyColor.A;
            switch (rd.Next(4))
            {
                case 0:
                    //Change Red
                    r += colournudge(rd, prop);
                    break;
                case 1:
                    // Change Green
                    g += colournudge(rd, prop);
                    break;
                case 2:
                    // Change Blue
                    b += colournudge(rd, prop);
                    break;
                case 3:
                    // Change Transarency
                    a += colournudge(rd, prop);
                    break;
            }
            r = limit(r, 255, 0);
            g = limit(g, 255, 0);
            b = limit(b, 255, 0);
            a = limit(a, 255, 0);

            PolyColor = Color.FromArgb(a, r, g, b);
        }

        private Point GetRandomPoint(Random rd, GAProjectProperties prop)
        {
            int
                maxX = 0,
                maxY = 0,
                minX = Owner.MaxX,
                minY = Owner.MaxY;

            // Find Outer Limits
            foreach (Point p in PolyPoints)
            {
                if (maxX < p.X) maxX = p.X;
                if (maxY < p.Y) maxY = p.Y;

                if (minX > p.X) minX = p.X;
                if (minY > p.Y) minY = p.Y;
            }

            maxX = limit(maxX + prop.MaxPointMovement, Owner.MaxX, 0);
            maxY = limit(maxY + prop.MaxPointMovement, Owner.MaxY, 0);
            minX = limit(minX - prop.MaxPointMovement, Owner.MaxX, 0);
            minY = limit(minY - prop.MaxPointMovement, Owner.MaxY, 0);

            return new Point(minX + rd.Next(maxX - minX), minY + rd.Next(maxY - minY));
        }

        private int limit(int val, int max, int min)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }

        public GAShape Duplicate(GARepresentation newowner)
        {
            GAShape newgap = new GAShape(newowner);
            newgap.PolyColor = this.PolyColor;
            newgap.Type = this.Type;

            foreach (Point p in PolyPoints)
            {
                newgap.PolyPoints.Add(new Point(p.X, p.Y));
            }
            return newgap;
        }

        public int positionnudge(Random rd, GAProjectProperties prop)
        {
            int diff = rd.Next(prop.MaxPointMovement) + 1;
            if (rd.Next(2) == 0) diff *= -1;
            return diff;
        }

        public int colournudge(Random rd, GAProjectProperties prop)
        {
            int diff = rd.Next(prop.MaxColorMovement) + 1;
            if (rd.Next(2) == 0) diff *= -1;
            return diff;
        }

        public void WriteBinary(BinaryWriter bw)
        {

            bw.Write((Byte)Type);
            switch (Type)
            {
                case GAShapeType.Polygon:
                    WriteBinaryColour(bw);
                    WriteBinaryPoints(bw);
                    break;
                case GAShapeType.PolyCurve:
                    WriteBinaryColour(bw);
                    WriteBinaryPoints(bw);
                    break;
                default:
                    throw new Exception("GAShape.WriteBinary - Type " + Type.ToString() + " unsupported");
            }

        }
        private void WriteBinaryColour(BinaryWriter bw)
        {
            bw.Write((byte)PolyColor.R);
            bw.Write((byte)PolyColor.G);
            bw.Write((byte)PolyColor.B);
            bw.Write((byte)PolyColor.A);
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

        public void ReadBinary(BinaryReader br)
        {
            Type = (GAShapeType)br.ReadByte();
            switch (Type)
            {
                case GAShapeType.Polygon:
                    ReadBinaryColour(br);
                    ReadBinaryPoints(br);
                    break;
                case GAShapeType.PolyCurve:
                    ReadBinaryColour(br);
                    ReadBinaryPoints(br);
                    break;
                default:
                    throw new Exception("GAShape.ReadBinary - Type " + Type.ToString() + " unsupported");

            }
        }

        private void ReadBinaryColour(BinaryReader br)
        {
            byte r = (byte)br.ReadByte();
            byte g = (byte)br.ReadByte();
            byte b = (byte)br.ReadByte();
            byte a = (byte)br.ReadByte();

            PolyColor = Color.FromArgb(a, r, g, b);
        }
        private void ReadBinaryPoints(BinaryReader br)
        {
            PolyPoints.Clear();

            byte count = br.ReadByte();
            for (int i = 0; i < count; i++)
            {
                PolyPoints.Add(
                    new Point(
                        br.ReadInt32(),
                        br.ReadInt32()
                        )
                    );
            }
        }

        private Point Midpoint(Point a, Point b)
        {
            return new Point((a.X + b.X) / 2, (b.Y + b.Y) / 2);
        }

        public void SortPoints()
        {
            throw new NotImplementedException();
            List<Point> newpp = new List<Point>();
            foreach (Point p in newpp)
            {
            }
        }

        public double distance(Point a, Point b)
        {
            throw new NotImplementedException();
            return Math.Sqrt((a.X - b.X) ^ 2 + (a.Y - b.Y) ^ 2);
        }
    }
}
