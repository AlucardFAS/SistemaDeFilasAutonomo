using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    class GuichesSetup
    {
        public char guiche;
        public Boolean atendente;
        public Boolean vazio;
        public int turnosNecessarios;
        public int guichesIguais;
        //public String nome;

        public int ultimoTurno;
        public Pessoas pessoaDentro;

        public int chegadaAtendente;
        public int peso;

       public GuichesSetup() {
           atendente = false;
           vazio = true;
           ultimoTurno = 1;
           guichesIguais = 1;
           peso = 0;
           chegadaAtendente = 0;
            
       }
       public static void resetGuiches(GuichesSetup[] guiches, Boolean[] atendentesIniciais)
       {
           for (int j = 0; j < guiches.Length; j++)
           {
               guiches[j].peso = 0;
           }
           for (int k = 0; k < guiches.Length; k++)
           {
               guiches[k].atendente = atendentesIniciais[k];
           }

       }
    }
}
