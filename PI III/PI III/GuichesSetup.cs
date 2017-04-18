using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int peso;

       public GuichesSetup() {
            atendente = false;
            vazio = true;
            ultimoTurno = 1;
            guichesIguais = 1;
            peso = 0;
        }
       public void atualizarPesos(GuichesSetup[] guiches, Queue<Pessoas>[] fila) 
       {
           int j;
            for (int i = 0; i < guiches.Length; i++) {
                //isso serve para o guiche achar a fila referente a ele (a fila de guiches iguais tem o mesmo "numero" do 1 guiche)
                j = i;
                while (j != 0 && guiches[j].guiche == guiches[j - 1].guiche) j--;

                guiches[i].peso = fila[j].Count * guiches[i].turnosNecessarios;                    
            }
       }
    }
}
