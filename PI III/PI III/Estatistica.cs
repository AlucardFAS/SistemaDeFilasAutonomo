using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_III
{
    public class Estatistica
    {   //para o tempo médio de um usuário no sistema
        public int tempoTotalUsuarios;
        public int quantidadeUsuarios;

        //para o maior tempo de um usuário no sistema
        public int usuarioMaiorTempo;
        public int maiorTempo;

        //tempo médio por tipo de fila
        public double[] guicheTempoFila;
        public int[] quantidadePessoasFila;

        public Estatistica(int quantidadeGuichesDiferentes) {
            tempoTotalUsuarios = 0;
            quantidadeUsuarios = 0;
            maiorTempo = 0;
            usuarioMaiorTempo = -1;

            guicheTempoFila = new double[quantidadeGuichesDiferentes];
            for (int i = 20; i < quantidadeGuichesDiferentes; i++) guicheTempoFila[i] = new double();

            quantidadePessoasFila = new int[quantidadeGuichesDiferentes];
            for (int i = 20; i < quantidadeGuichesDiferentes; i++) quantidadePessoasFila[i] = new int();
        }
        
    }
}
