using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFormulas
{
    class Pessoas
    {
        public int usuario;
        public int chegada;
        public char[] guiches;

        public int atualGuiche;

        public Pessoas()
        {
            atualGuiche = 0;
        }

        public void setPessoa(int u, int c, String g)
        {
            this.usuario = u;
            this.chegada = c;
            this.guiches = g.ToCharArray();
        }
        public void carregarFila(Pessoas[] pessoas)
        {
            System.IO.StreamReader arquivo = new System.IO.StreamReader("Dados/Fila.txt");
            string linha;
            string dado = "";
            int usuario = -1;
            int chegada = -1;
            string guiches;


            Boolean stringUsuario = false;
            Boolean stringChegada = false;

            int j = 0;
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
                pessoas[j].setPessoa(usuario, chegada, guiches);
                j++;
            }
            arquivo.Close();
        }
        public void resetPessoas(Pessoas[] pessoas) {
            for (int i = 0; i < pessoas.Length; i++)
                pessoas[i].atualGuiche = 0;
        }
    }
}
