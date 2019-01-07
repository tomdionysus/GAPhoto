using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using SvgNet.SvgGdi;

namespace GAPhoto
{
    public enum GAShapeType { None, Circle, Line, Curve, FilledPolygon, FilledPolycurve, Path }
    public abstract class GAShape
    {
        public List<PointF> PolyPoints = new List<PointF>();
        public GARepresentation Owner;
        public const GAShapeType Type = GAShapeType.None;
        public Color ShapeColour;

        public abstract void Randomize(ThreadSafeRandom rd, GAProjectProperties prop);
        public abstract void Draw(IGraphics g);
        public abstract void Mutate(ThreadSafeRandom rd, GAProjectProperties prop);

        public abstract int GetTotalPoints();
        public abstract int GetByteSize();

        public abstract GAShape Duplicate(GARepresentation newowner);

        public abstract void WriteBinary(BinaryWriter wt);
        public static GAShape ReadBinary(GARepresentation owner, BinaryReader br)
        {
            GAShapeType type = (GAShapeType)br.ReadByte();
            switch (type)
            {
                case GAShapeType.Circle:
                    return new GAShapeCircle(owner, br);
                case GAShapeType.Line:
                    return new GAShapeLine(owner, br);
                case GAShapeType.Curve:
                    return new GAShapeCurve(owner, br);
                case GAShapeType.FilledPolygon:
                    return new GAShapeFilledPolygon(owner, br);
                case GAShapeType.FilledPolycurve:
                    return new GAShapeFilledPolycurve(owner, br);
                case GAShapeType.Path:
                    return new GAShapePath(owner, br);
                default:
                    return null;
            }

        }

        public static GAShape CreateRandom(ThreadSafeRandom rd, GAProjectProperties prop, GARepresentation owner)
        {
            List<GAShapeType> lt = new List<GAShapeType>();
            if (prop.UsePoints) lt.Add(GAShapeType.Circle);
            if (prop.UseLines) lt.Add(GAShapeType.Line);
            if (prop.UseCurves) lt.Add(GAShapeType.Curve);
            if (prop.UseFilledPolygons) lt.Add(GAShapeType.FilledPolygon);
            if (prop.UseFilledPolycurves) lt.Add(GAShapeType.FilledPolycurve);
            //if (prop.UsePaths) lt.Add(GAShapeType.Path);

            if (lt.Count == 0) throw new Exception("GASHape.CreateRandom - No Shapes Allowed");

            GAShape output = null;

            switch (lt[rd.Next(lt.Count)])
            {
                case GAShapeType.Circle:
                    output = new GAShapeCircle(owner);
                    break;
                case GAShapeType.Line:
                    output = new GAShapeLine(owner);
                    break;
                case GAShapeType.Curve:
                    output = new GAShapeCurve(owner);
                    break;
                case GAShapeType.FilledPolygon:
                    output = new GAShapeFilledPolygon(owner);
                    break;
                case GAShapeType.FilledPolycurve:
                    output = new GAShapeFilledPolycurve(owner);
                    break;
                case GAShapeType.Path:
                    output = new GAShapePath(owner);
                    break;
            }

            output.Randomize(rd, prop);
            return output;
        }

        public virtual PointF GetRandomPoint(ThreadSafeRandom rd, GAProjectProperties prop)
        {

            float
                maxX = 0,
                maxY = 0,
                minX = Owner.MaxX,
                minY = Owner.MaxY;

            // Find Outer Limits
            foreach (PointF p in PolyPoints)
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


            return new PointF(minX + NextFloat(rd,maxX - minX), minY + NextFloat(rd,maxY - minY));


            //return new Circle(NextFloat(Entropy,Owner.MaxX),NextFloat(Entropy,Owner.MaxY));
        }
        public void MutateColour(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            int r, b, g, a = 0;
            r = ShapeColour.R;
            g = ShapeColour.G;
            b = ShapeColour.B;
            a = ShapeColour.A;
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

            ShapeColour = Color.FromArgb(a, r, g, b);
        }

        protected int limit(int val, int max, int min)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }
        protected float limit(float val, float max, float min)
        {
            if (val > max) val = max;
            if (val < min) val = min;
            return val;
        }
        protected float positionnudge(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            float diff = NextFloat(rd,prop.MaxPointMovement) + 1;
            if (rd.Next(2) == 0) diff *= -1;
            return diff;
        }
        private int colournudge(ThreadSafeRandom rd, GAProjectProperties prop)
        {
            int diff = rd.Next(prop.MaxColorMovement) + 1;
            if (rd.Next(2) == 0) diff *= -1;
            return diff;
        }
        protected float NextFloat(ThreadSafeRandom rd, int max)
        {
            return NextFloat(rd, (float)max);
        }
        protected float NextFloat(ThreadSafeRandom rd, float max)
        {
            float trx = (float)rd.Next() / (float)int.MaxValue;
            return max * trx;
        }

        public virtual void WriteSVG(XmlWriter xw)
        {
            xw.WriteComment("GAShape WriteSVG is not yet impemented.");
        }
    }
}
