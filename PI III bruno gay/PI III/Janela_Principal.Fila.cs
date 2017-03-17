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

        private string line;


        private void CarregarFila()
        {

            int turno = 0;
            bool usuario, chegada;


            Queue<char[]> pessoa = new Queue<char[]>();
            Queue<char[]> guiche_a = new Queue<char[]>();
            Queue<char[]> guiche_b = new Queue<char[]>();
            Queue<char[]> guiche_c = new Queue<char[]>();
            Queue<char[]> guiche_d = new Queue<char[]>();
            Queue<char[]> guiche_e = new Queue<char[]>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\victor.etrindade\Desktop\PI3-master\PI III bruno gay\setup\Fila.txt");
            while ((line = file.ReadLine()) != null)
            {

                var char_guiches = line.ToCharArray();
                pessoa.Enqueue(char_guiches);
                for (int i = 0; i < char_guiches.Length; i++)
                {
                    if (char_guiches[i] == 'U')
                    {
                        usuario = true;
                    }
                    else if (char_guiches[i] == 'C')
                    {
                        usuario = false;
                        chegada = true;
                    }
                    else if (char_guiches[i] == 'A')
                    {
                        chegada = false;
                    }
                }

            }

        }
    }
}
