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

        public static void Main(string[] args)
        {
            int formula1; //risos
            int formula2;

            guiches = carregarSetup();

            int totalClientes = File.ReadAllLines("Dados/Fila.txt").Length; //contando o numero de pessoas que terão na fila

            pessoas = new Pessoas[totalClientes];
            for (int i = 0; i < totalClientes; i++)
                pessoas[i] = new Pessoas();

            pessoas[0].carregarFila(pessoas);

            fila = new Queue<Pessoas>[guiches.Length];  //criando as filas em função da quantidade de guiches
            for (int i = 0; i < fila.Length; i++) fila[i] = new Queue<Pessoas>();   //instanciando as filas


            //ÁREA DE TESTES
            formula1 = processo(fila, pessoas, guiches, 0);
            Console.WriteLine("AtualGuiche: "+pessoas[2].atualGuiche);
            pessoas[0].resetPessoas(pessoas);
            Console.WriteLine("AtualGuiche: " + pessoas[2].atualGuiche);

            formula2 = processo(fila, pessoas, guiches, 0);

            Console.WriteLine("Turnos demorados pelo método 1:" +formula1+ "\n"+
                                "Turnos demorados pelo método 2:"+ formula2);

            
            Console.ReadKey();

        }
    }
}
