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

        private static GuichesSetup[] carregarSetup()
        {
            Random rand = new Random();//cria variavel random


            /*============================================================*/
            /*======================Número de Postos======================*/
            /*============================================================*/


            int num_postos = rand.Next(3, 20);//declara que o numero de guiches sera um numero entre 3 e 20
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

            return guichesSetup;
        }
    }
}
