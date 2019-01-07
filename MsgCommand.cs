using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using JQFramework;

namespace GAPhoto
{
    public enum MsgCommandCommands { Init, LoadBestYet, SaveBestYet, Stop };
    [Serializable]
    public class MsgCommand: JQMessage
    {
        public MsgCommand(JQJob job, MsgCommandCommands cmd)
        {
            Job = job;
            Command = cmd;
        }

        [NonSerializedAttribute]
        public JQJob Job;
        public MsgCommandCommands Command;
        [NonSerializedAttribute]
        public GAProjectProperties Properties;
        public GARepresentation Best;
        [NonSerializedAttribute]
        public FastBitmap Img;
        [NonSerializedAttribute]
        public ThreadSafeRandom Entropy;
        public double BestComparison;
        public uint Iterations;
    }
}
