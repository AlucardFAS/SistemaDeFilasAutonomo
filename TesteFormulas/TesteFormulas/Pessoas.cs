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
        public static void carregarFila(Pessoas[] pessoas)
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
        public static Pessoas[] gerarUsuarioRandom(int quantidade, char ultimoguiche, int ultimotempochegada)
        {
            //Função para criar usuario aleatórios.
            //Recebe a quantidade de usuario, tem que receber o char do ultimo guiche e o ultimo turno que algum "cliente" deve chegar
            //retorna um vetor de pessoas. Que seria a fila do arquivo txt fila.

            int aux;
            Pessoas[] b = new Pessoas[quantidade];
            Random ran = new Random();
            //aleatorizando um vetor chegada com chegadas de 1 até o ultimotempochegada
            int[] chegada = new int[quantidade];

            for (int j = 0; j < quantidade; j++) 
                chegada[j] = ran.Next(1, ultimotempochegada);
            
            Array.Sort<int>(chegada);   //ordenando o vetor com as chegadas


            for (int i = 0; i < quantidade; i++)
            {
                b[i] = new Pessoas();
                
                b[i].usuario = (i + 1);
                b[i].chegada = chegada[i];  //settando a chegada das pessoas de acordo com o vetor chegada

                b[i].guiches = new char[Convert.ToInt32(ultimoguiche) - (Convert.ToInt32('A') - 1)];
                Console.WriteLine("tamanho guiches: "+b[i].guiches.Length); //verificando o tamanho de cada array
                b[i].guiches[0] = 'A';
                for (int j = 1; j < ran.Next(5, (Convert.ToInt32(ultimoguiche) + 1)); j++)
                {
                    aux = b[i].guiches[j - 1];
                    if (aux == (Convert.ToInt32(ultimoguiche)))
                        break;
                    b[i].guiches[j] = ((char)ran.Next((aux + 1), (Convert.ToInt32(ultimoguiche))));
                }
            }
            return b;
        }
        public static void resetPessoas(Pessoas[] pessoas) {
            for (int i = 0; i < pessoas.Length; i++)
                pessoas[i].atualGuiche = 0;
        }
    }
}
