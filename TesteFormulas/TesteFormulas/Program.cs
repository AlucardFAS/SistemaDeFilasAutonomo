using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFormulas
{
    partial class Program
    {

        static Pessoas[] pessoas;
        static Queue<Pessoas>[] fila;
        static GuichesSetup[] guiches;

        public static Boolean[] atendentesIniciais;


        public static void Main(string[] args)
        {
            int formula1 = 0; //risos
            int formula2 = 0;

            //int totalClientes = File.ReadAllLines("Dados/Fila.txt").Length; //contando o numero de pessoas que terão na fila


            



            //ÁREA DE TESTES
            for (int i = 0; i < 100; i++)
            {
                guiches = AleatorizarSetup();

                char ultimoGuiche = guiches[guiches.Length - 1].guiche;
                Random rand = new Random();
                int qntAtendentes = rand.Next(30, 50);
                int tmpChegada = qntAtendentes - 10;


                pessoas = Pessoas.gerarUsuarioRandom(qntAtendentes, ultimoGuiche, tmpChegada);

                fila = new Queue<Pessoas>[guiches.Length];  //criando as filas em função da quantidade de guiches
                for (int j = 0; j < fila.Length; j++) fila[j] = new Queue<Pessoas>();   //instanciando as filas

                formula1 += processo(fila, pessoas, guiches, 1);
                Pessoas.resetPessoas(pessoas);
                formula2 += processo(fila, pessoas, guiches, 2);
                Pessoas.resetPessoas(pessoas);

                Array.Clear(guiches, 0, guiches.Length);
                Array.Clear(pessoas, 0, pessoas.Length);
                Array.Clear(fila, 0, fila.Length);
                Array.Clear(atendentesIniciais, 0, atendentesIniciais.Length);
            }


            Console.WriteLine("Turnos demorados pelo método 1:" +formula1+ "\n"+
                                "Turnos demorados pelo método 2:"+ formula2+ "\n");

            
            Console.ReadKey();

        }
    }
}
