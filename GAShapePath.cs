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
    public class GAShapePath: GAShape
    {
        public new const GAShapeType Type = GAShapeType.Path;
        public GraphicsPath Path;

        public GAShapePath(GARepresentation owner)
        {
            Owner = owner;
        }
        public GAShapePath(GARepresentation owner, BinaryReader br)
        {
            Owner = owner;
            ReadBinary(br);
        }
        public override GAShape Duplicate(GARepresentation newowner)
        {
            return null;
        }

        public override void Randomize(ThreadSafeRandom rd, GAProjectProperties prop)
        {
        }
        public override void Draw(IGraphics g)
        {
        }
        public override void Mutate(ThreadSafeRandom rd, GAProjectProperties prop)
        {
        }

        public override int GetTotalPoints()
        {
            return 0;
        }
        public override int GetByteSize()
        {
            return 0;
        }

        public override void WriteBinary(BinaryWriter wt)
        {
            wt.Write((byte)Type);
        }
        public void ReadBinary(BinaryReader wt)
        {
        }

        public override void WriteSVG(XmlWriter xw)
        {
            xw.WriteComment("GAShapePath WriteSVG is not yet impemented.");
        }
    }
}