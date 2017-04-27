using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    static class Program{
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Janela_Principal java = new Janela_Principal();
            java.BackgroundImage = global::PI_III.Properties.Resources.PI_IIIwpp;
            Application.Run(java);
        }
    }
}
