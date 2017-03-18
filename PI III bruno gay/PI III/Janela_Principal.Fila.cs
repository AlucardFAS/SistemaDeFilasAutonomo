using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PI_III
{
    partial class Janela_Principal
    {

        public void carregarFila(){
            System.IO.StreamReader arquivo = new System.IO.StreamReader("dados/fila.txt");
            string linha;
            string dado = "";
            int usuario = -1;
            int chegada = -1;
            string guiches;

            Boolean stringUsuario = false;
            Boolean stringChegada = false;

            while ((linha = arquivo.ReadLine()) != null)
            {
                linha += ";";

                char[] percorredor = linha.ToCharArray();

                int i = 0;
                while (true)
                {
                    if (percorredor[i] == 'U')
                    {
                        stringUsuario = true;
                        i++;
                    }
                    else if (percorredor[i] == 'C')
                    {
                        stringChegada = true;
                        stringUsuario = false;

                        if (!Int32.TryParse(dado, out usuario)) Console.WriteLine("Deu ruim na hora de converter pra int");
                        dado = "";
                        i++;
                    }
                    else if (percorredor[i] == 'A')
                    {
                        stringChegada = false;
                        if (!Int32.TryParse(dado, out chegada)) Console.WriteLine("Deu ruim na hora de converter pra int");
                        dado = "";

                        while (percorredor[i] != ';')
                        {
                            dado += percorredor[i];
                            i++;

                        }
                        guiches = dado;
                        dado = "";
                        break;
                    }

                    if (stringUsuario == true) dado += percorredor[i];
                    if (stringChegada == true) dado += percorredor[i];

                    i++;

                }
                MessageBox.Show("U: " + usuario + "\n" +
                                "C: " + chegada + "\n" +
                                "Guiches: " + guiches);
            }
        }
    }
}
