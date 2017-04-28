using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFormulas
{
    partial class Program
    {
        private static int atendente;
        private static char[] postos;
        private static char[] atendente_pos;
        private static int troca;
        private static int[] posto;

        private static GuichesSetup[] AleatorizarSetup()
        {
            Random rand = new Random();//cria variavel random


            /*============================================================*/
            /*======================Número de Postos======================*/
            /*============================================================*/


            int num_postos = rand.Next(6, 20);//declara que o numero de guiches sera um numero entre 6 e 20
            int postos_dif = rand.Next(3, num_postos);//declara o numero de postos diferentes, exemplo, A B C D E, sendo que os postos poderão ser entre A até E no máximo


            /*============================================================*/
            /*=======================Atendentes===========================*/
            /*============================================================*/


            atendente = rand.Next(3, num_postos);//declara que os atendentes são um número entre 3 e o numero de postos.


            /*============================================================*/
            /*====================Relação de Postos=======================*/
            /*============================================================*/


            postos = new char[num_postos];//postos recebe o tamanho do numero de postos(aleatorizado logo acima)
            for (int i=0;i<postos_dif;i++)//esse for adiciona uma de cada letra aos postos, para que, por exemplo, não corra o risco de não ter uma letra A
            {
                postos[i] = Convert.ToChar(65+i);
            }
            for(int i=postos_dif; i<num_postos; i++)//esse for adiciona os postos respetidos, caso haja espaço(o número de postos diferentes ser diferente do numero de postos)
            {
                postos[i] = (char)rand.Next(65,65 + postos_dif);
            }
            Array.Sort(postos);//Organiza os postos


            /*============================================================*/
            /*===================Relação de Atendentes====================*/
            /*============================================================*/


            int[] dif_postos = new int[postos_dif];//cria um vetor do tamanho de postos diferentes
            Array.Clear(dif_postos, 0, postos_dif-1);//zera o vetor
            int o = 0,j = 0;
            char a = 'A';
            while (o < num_postos) //cria um vetor dizendo a quantidade de cada um dos postos(EX: [2 postos A , 3 postos B , 4 postos C])
            {
                if(postos[o] == a)
                {
                    dif_postos[j]++;
                }
                else
                {
                    j++;
                    a++;
                    dif_postos[j]++;
                }
                o++;
            }

            j = 0;
            int aux = atendente;
            atendente_pos = new char[atendente];
            while (aux != 0)//distribui os atendentes entre os postos até que não sobre atendentes
            {
                o = rand.Next(0, postos_dif-1);
                
                if (dif_postos[o] != 0)
                {
                    dif_postos[o]--;
                    atendente_pos[j] = Convert.ToChar(65 + o);
                    aux--;
                    j++;
                }
                
            }
            Array.Sort(atendente_pos);


            /*============================================================*/
            /*====================Tempo de cada posto=====================*/
            /*============================================================*/


            posto = new int[num_postos];
            for (int i = 0; i < posto.Length; i++)
            {
                posto[i] = rand.Next(1, 9);
            }


            /*============================================================*/
            /*======================Tempo de troca========================*/
            /*============================================================*/
            
            troca = rand.Next(1,5);

            a = 'A';

            GuichesSetup[] guichesSetup;
            guichesSetup = new GuichesSetup[num_postos];


            for (int i=0;i<num_postos;i++)
            {
                guichesSetup[i] = new GuichesSetup();
                guichesSetup[i].guiche = postos[i];
                if (guichesSetup[i].guiche == a) guichesSetup[i].turnosNecessarios = posto[i];
                a++;
            }
            Console.WriteLine("atendente = "+atendente);
            Console.WriteLine("troca = " + troca);
            for(int i=0;i<postos.Length;i++)
            {
                Console.Write(postos[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < atendente_pos.Length; i++)
            {
                Console.Write(atendente_pos[i]);
            }
            Console.WriteLine();
            a = 'A';
            for (int i = 0; i < posto.Length; i++)
            {
                Console.WriteLine("posto "+a+" = " + posto[i]);
                a++;
            }

            //testando os guichesSetup
            for (int i = 0; i < num_postos; i++) {
                //Console.WriteLine("guiche"+i+": "+guichesSetup[i].atendente);
            }

            return guichesSetup;
        }
        private static GuichesSetup[] carregarSetup()
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

                    for (int i = 0; i < vetor_aux.Length; i++)
                    {
                        if (vetor_aux[i] == ':')
                        {
                            condicional = 1;
                        }
                        else if (condicional == 1)
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
                else if (counter >= 4)
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
                    posto[counter - 4] = Convert.ToInt32(temp);
                    //MessageBox.Show(Convert.ToString(posto[counter-4]));
                }


                counter++;//aumenta o contador para ler e armazenar novas linhas até o fim do arquivo(!=null)
            }

            //obtendo a quantidade de guiches (metodo provisorio enquanto não arruma a classe)
            int quantidade = 0;
            String auxiliar = "";

            for (int i = 0; i < 20; i++) auxiliar += postos[i];
            auxiliar = new String(auxiliar.Where(Char.IsLetter).ToArray());
            quantidade = auxiliar.Length;

            //criando as classes setupguiches
            GuichesSetup[] guichesSetup;
            guichesSetup = new GuichesSetup[quantidade];

            //setando os guiches
            int j = 0;
            char aux = 'x'; //serve para guardar o char do ultimo posto, para comparar com o que vai ser lido atualmente
            for (int i = 0; i < quantidade; i++)
            {
                guichesSetup[i] = new GuichesSetup();

                guichesSetup[i].guiche = postos[i]; //simplesmente joga o char do guiche

                //isso serve para verificar quantos guiches iguais tem, assim o primeiro guiches dos iguais (por exemplo, 3 guiches A's, o primeiro A terá a quantidadeGuiches igual a 3)
                if (guichesSetup[i].guiche != aux)
                {
                    int k = i + 1;
                    aux = guichesSetup[i].guiche;

                    while (postos[k] == aux)
                    {   //atualizando a quantidade de guiches iguais (somente no primeiro guiche)
                        guichesSetup[i].guichesIguais++;
                        k++;
                    }
                }

                //colocando os atendentes nos devidos guiches
                if (atendente_pos[j] == guichesSetup[i].guiche)
                {
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
                if (guichesSetup[i].guiche == 'K') guichesSetup[i].turnosNecessarios = posto[10];
                if (guichesSetup[i].guiche == 'L') guichesSetup[i].turnosNecessarios = posto[11];
                if (guichesSetup[i].guiche == 'M') guichesSetup[i].turnosNecessarios = posto[11];
            }
            file.Close();//fecha o txt

            atendentesIniciais = new Boolean[guichesSetup.Length];
            for (int k = 0; k < guichesSetup.Length; k++)
            {
                atendentesIniciais[k] = guichesSetup[k].atendente;
            }


            return guichesSetup;
        }
    }
}
