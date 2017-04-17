using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    partial class Janela_Principal
    {
        private int atendente;
        private char[] postos;
        private char[] atendente_pos;
        private int troca;
        private int[] posto;


        private GuichesSetup[] CarregarSetup()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("Dados/Setup.txt");//busca o arquivo de texto
            int counter = 0;
            postos = new char[20];
            posto = new int[20];
            string line;//cria uma string que recebe as linhas
            string[] setup;//declara o vetor de setup
            setup = new string[50];//declara que setup terá 9 posições
            while ((line = file.ReadLine()) != null)//laço que le linha por linha
            {
                if (counter == 0)
                {
                    atendente = Convert.ToInt32(line);
                    //MessageBox.Show(Convert.ToString(atendente));
                }
                else if (counter == 1)
                {
                    var vetor_aux = line.ToCharArray();
                    postos = new char[20];
                    int condicional = 0, k = 0;

                    for (int i = 0; i < vetor_aux.Length; i++)
                    {
                        if (vetor_aux[i] == ':')
                        {
                            condicional = 1;
                        }
                        else if (condicional == 1)
                        {
                            postos[k] = vetor_aux[i];
                            k++;
                        }
                    }
                    //string temp = new string(postos);
                    //MessageBox.Show(temp);
                }
                else if (counter == 2)
                {
                    var vetor_aux = line.ToCharArray();
                    atendente_pos = new char[20];
                    int condicional = 0, k = 0;

                    for(int i=0 ; i < vetor_aux.Length ; i++)
                    {
                        if(vetor_aux[i] == ':')
                        {
                            condicional = 1;
                        }
                        else if(condicional == 1)
                        {
                            atendente_pos[k] = vetor_aux[i];
                            k++;
                        }
                    }
                    //string temp = new string(atendente_pos);
                    //MessageBox.Show(temp);
                }
                else if (counter == 3)
                {
                    var vetor_aux = line.ToCharArray();
                    char[] numfinal;
                    numfinal = new char[10];
                    int condicional = 0, k = 0;
                    for (int i = 0; i < (vetor_aux.Length); i++)
                    {
                        if (condicional == 1)
                        {
                            numfinal[k] = vetor_aux[i];
                            k++;
                        }
                        else if (vetor_aux[i] == ':')
                        {
                            condicional = 1;
                        }
                    }
                    string temp = new string(numfinal);
                    troca = Convert.ToInt32(temp);
                    //MessageBox.Show(Convert.ToString(troca));
                }
                else if(counter>=4)
                {
                    var vetor_aux = line.ToCharArray();
                    char[] numfinal;
                    numfinal = new char[10];
                    int k = 0, condicional = 0;
                    for (int i = 0; i < (vetor_aux.Length); i++)
                    {
                        if (vetor_aux[i] == ':')
                        {
                            condicional = 1;
                        }

                        else if (i > 0 && condicional != 1)
                        {
                            numfinal[k] = vetor_aux[i];
                            k++;
                        }
                    }

                    string temp = new string(numfinal);
                    posto[counter-4] = Convert.ToInt32(temp);
                    //MessageBox.Show(Convert.ToString(posto[counter-4]));
                }


                counter++;//aumenta o contador para ler e armazenar novas linhas até o fim do arquivo(!=null)
            }

            //obtendo a quantidade de guiches (metodo provisorio enquanto não arruma a classe)
            int quantidade = 0;
            String auxiliar = "";

            for (int i = 0; i < 20; i++)    auxiliar += postos[i];
            auxiliar = new String(auxiliar.Where(Char.IsLetter).ToArray());
            quantidade = auxiliar.Length;

            //criando as classes setupguiches
            GuichesSetup[] guichesSetup;
            guichesSetup = new GuichesSetup [quantidade];

            //setando os guiches
            int j = 0;
            char aux = 'x'; //serve para guardar o char do ultimo posto, para comparar com o que vai ser lido atualmente
            for (int i = 0; i < quantidade; i++){
                guichesSetup[i] = new GuichesSetup();

                guichesSetup[i].guiche = postos[i]; //simplesmente joga o char do guiche
                
                //isso serve para verificar quantos guiches iguais tem, assim o primeiro guiches dos iguais (por exemplo, 3 guiches A's, o primeiro A terá a quantidadeGuiches igual a 3)
                if (guichesSetup[i].guiche != aux){
                    int k = i+1;
                    aux = guichesSetup[i].guiche;

                    while (postos[k] == aux){   //atualizando a quantidade de guiches iguais (somente no primeiro guiche)
                        guichesSetup[i].guichesIguais++;
                        k++;
                    }
                }

                //colocando os atendentes nos devidos guiches
                if (atendente_pos[j] == guichesSetup[i].guiche) {
                    guichesSetup[i].atendente = true;
                    j++;
                }

                if (guichesSetup[i].guiche == 'A') guichesSetup[i].turnosNecessarios = posto[0];
                if (guichesSetup[i].guiche == 'B') guichesSetup[i].turnosNecessarios = posto[1];
                if (guichesSetup[i].guiche == 'C') guichesSetup[i].turnosNecessarios = posto[2];
                if (guichesSetup[i].guiche == 'D') guichesSetup[i].turnosNecessarios = posto[3];
                if (guichesSetup[i].guiche == 'E') guichesSetup[i].turnosNecessarios = posto[4];
                if (guichesSetup[i].guiche == 'F') guichesSetup[i].turnosNecessarios = posto[5];
                if (guichesSetup[i].guiche == 'G') guichesSetup[i].turnosNecessarios = posto[6];
                if (guichesSetup[i].guiche == 'H') guichesSetup[i].turnosNecessarios = posto[7];
                if (guichesSetup[i].guiche == 'I') guichesSetup[i].turnosNecessarios = posto[8];
                if (guichesSetup[i].guiche == 'J') guichesSetup[i].turnosNecessarios = posto[9];
            }
            file.Close();//fecha o txt

            return guichesSetup;
        }
    }
}
