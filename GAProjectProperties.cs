using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GAPhoto
{
    public enum GASeeding { RandomSeed, MatrixSeed }
    public enum GAMatrixSeedingType { Circles, Blocks }

    public class GAProjectProperties
    {
        public GASeeding Seeding = GASeeding.RandomSeed;
        public GAMatrixSeedingType MatrixSeedingType = GAMatrixSeedingType.Blocks;
        public int Granularity = 5;

        public bool UsePoints = true;
        public bool UseLines = true;
        public bool UseCurves = true;
        public bool UseClosedPolygons = true;
        public bool UseClosedPolycurves = true;
        public bool UseFilledPolygons = true;
        public bool UseFilledPolycurves = true;
        public bool UsePaths = true;
        public bool BackgroundColorFromHistogram = true;
        public bool LimitPolygons = false;
        public int PolygonLimit = 100;
        public bool LimitPoints = false;
        public int PointLimit = 100;
        public int ThreadLimit = 2;

        public int MaxPolygonChanges = 1;
        public int MaxPointChanges = 5;
        public int MaxPointMovement = 10;
        public int MaxColorMovement = 32;

        public bool AllowAdditionalShapes = true;
        public bool AllowShapeRemoval = true;
        public bool AllowPointSwapping = true;
        public bool AllowShapeSplitting = true;
        public bool AllowShapeMerging = true;

        public GAProjectProperties()
        {
        }
        public GAProjectProperties(BinaryReader br)
        {
            ReadBinary(br);
        }

        public void ReadBinary(BinaryReader br)
        {
            Seeding = (GASeeding)br.ReadByte();
            MatrixSeedingType = (GAMatrixSeedingType)br.ReadByte();
            Granularity = br.ReadInt32();

            UsePoints = br.ReadBoolean();
            UseLines = br.ReadBoolean();
            UseCurves = br.ReadBoolean();
            UseFilledPolygons = br.ReadBoolean();
            UseFilledPolycurves = br.ReadBoolean();
            UsePaths = br.ReadBoolean();
            BackgroundColorFromHistogram = br.ReadBoolean();
            LimitPolygons = br.ReadBoolean();
            PolygonLimit = br.ReadInt32();
            LimitPoints = br.ReadBoolean();
            PointLimit = br.ReadInt32();

            ThreadLimit = br.ReadInt16();

            MaxPolygonChanges = br.ReadInt32();
            MaxPointChanges = br.ReadInt32();
            MaxPointMovement = br.ReadInt32();
            MaxColorMovement = br.ReadInt32();

            AllowAdditionalShapes = br.ReadBoolean();
            AllowShapeRemoval = br.ReadBoolean();
            AllowPointSwapping = br.ReadBoolean();
            AllowShapeSplitting = br.ReadBoolean();
            AllowShapeMerging = br.ReadBoolean();
        }
        public void WriteBinary(BinaryWriter bw)
        {
            bw.Write((byte)Seeding);
            bw.Write((byte)MatrixSeedingType);
            bw.Write(Granularity);

            bw.Write(UsePoints);
            bw.Write(UseLines);
            bw.Write(UseCurves);
            bw.Write(UseFilledPolygons);
            bw.Write(UseFilledPolycurves);
            bw.Write(UsePaths);

            bw.Write(BackgroundColorFromHistogram);
            bw.Write(LimitPolygons);
            bw.Write(PolygonLimit);
            bw.Write(LimitPoints);
            bw.Write(PointLimit);
            bw.Write((Int16)ThreadLimit);

            bw.Write(MaxPolygonChanges);
            bw.Write(MaxPointChanges);
            bw.Write(MaxPointMovement);
            bw.Write(MaxColorMovement);

            bw.Write(AllowAdditionalShapes);
            bw.Write(AllowShapeRemoval);
            bw.Write(AllowPointSwapping);
            bw.Write(AllowShapeSplitting);
            bw.Write(AllowShapeMerging);

            bw.Flush();
        }
    }
}
