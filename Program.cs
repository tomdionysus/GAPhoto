using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAPhoto
{
    static class Program
    {
        /// <summary>
        /// The main entry Circle for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fm_main main = new fm_main();
            if (args != null)
            {
                if (args.Length > 0)
                {
                    main.InitialProjectFilename = args[0];
                }
            }
            Application.Run(main);
        }
    }
}