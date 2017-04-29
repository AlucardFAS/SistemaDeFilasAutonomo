using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_III
{
    class Estatistica
    {   //para o tempo médio de um usuário no sistema
        public int tempoTotalUsuarios;
        public int quantidadeUsuarios;

        //para o maior tempo de um usuário no sistema
        public int usuarioMaiorTempo;
        public int maiorTempo;

        //tempo médio por tipo de fila
        //public int[] guicheTempoFila;

        public Estatistica() {
            tempoTotalUsuarios = 0;
            quantidadeUsuarios = 0;
            maiorTempo = 0;
            usuarioMaiorTempo = -1;
        }
        
    }
}
