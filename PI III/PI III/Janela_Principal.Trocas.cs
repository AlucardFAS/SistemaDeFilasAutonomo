using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    partial class Janela_Principal
    {
        void realizarTrocas (GuichesSetup[] guiches, Queue<Pessoas>[] fila)
        {
            guiches[0].atualizarPesos(guiches, fila);

            for (int i = 0; i < guiches.Length; i++) { 
            
            }
        }
    }
}
