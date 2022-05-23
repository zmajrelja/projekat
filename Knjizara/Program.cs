using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjizara
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form log_in = new log_in();

            uloga = 0;

            log_in.ShowDialog();

            if (uloga == 0)
                Application.Exit();
            else if (uloga == 1)
                Application.Run(new Main());
            else
                Application.Run(new MainA());
            


        }

        static public string ime, prezime;
        static public int uloga, korisnik;
    }
}
