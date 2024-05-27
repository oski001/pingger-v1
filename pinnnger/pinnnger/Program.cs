using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace pinnnger
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new pingger());
        }
    }
}
