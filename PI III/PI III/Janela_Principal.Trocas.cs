using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    partial class Janela_Principal
    {
        void realizarTrocas (GuichesSetup[] guiches, Queue<Pessoas>[] fila)
        {
            int maiorPeso = 0;  //essa variavel serve para achar o maior peso atualmente
            int posicaoMaior = -1;

            int menorPeso = Constantes.infinito;    //essa variavel serve pra achar o menor peso atualmente
            int posicaoMenor = -1;


            atualizarPesos_Atendentes(guiches, fila);

            //area de formulas
            //ainda nao tem rs



            for (int i = 0; i < guiches.Length; i++) {
                if (guiches[i].atendente == false && guiches[i].chegadaAtendente == 0 && guiches[i].peso > maiorPeso)//achando o maior peso (sem atendente e nem com atendente a caminho) e guardando ele e a posicao
                {
                    maiorPeso = guiches[i].peso;
                    posicaoMaior = i;
                }
                if (guiches[i].atendente == true && guiches[i].vazio == true && guiches[i].peso <= menorPeso)//achando o menor peso (com atendente) e guardando ele e a posicao
                {
                    if (guiches[i].peso == menorPeso){  //esse if verifica se menorPesos iguais tem a mesma quantidade de antendentes entre seus guiches, se esse peso, embora igual a outro, tiver mais atendentes em seus devidos guiches, a preferencia de troca será ele

                        int quantidadeAtendente = 0;
                        for (int j = i; j < guiches.Length && j <= i + (guiches[j].guichesIguais-1); j++) 
                            if (guiches[j].atendente == true)
                                quantidadeAtendente++;
                            
                       // MessageBox.Show("quantidadeAtendente: "+quantidadeAtendente);

                        if (quantidadeAtendente >= 2) posicaoMenor = i;
                    }
                    else{
                        menorPeso = guiches[i].peso;
                        posicaoMenor = i;
                    }
                }
            }

            if (maiorPeso > menorPeso + troca)
            {
                trocarAtendentes(guiches, posicaoMenor, posicaoMaior); //se o maiorPeso for maior que o menorPeso + a troca * 3, então, efetuará a troca
            }
        }

        void trocarAtendentes(GuichesSetup[] guiches, int guiche1, int guiche2) {   //essa funcao faz troca de atendentes, da primeira posicao para a 2 posicao
            guiches[guiche1].atendente = false;
            guiches[guiche2].chegadaAtendente = 1;
        }
        void atualizarPesos_Atendentes(GuichesSetup[] guiches, Queue<Pessoas>[] fila)
        {
            int j;
            for (int i = 0; i < guiches.Length; i++)
            {
                //isso serve para o guiche achar a fila referente a ele (a fila de guiches iguais tem o mesmo "numero" do 1 guiche)
                j = i;
                while (j != 0 && guiches[j].guiche == guiches[j - 1].guiche) j--;
                //esse peso inicialmente atribuido é o tamanho da fila * turnos necessarios para atender um cliente, logo é a quantidade de turnos para a fila esvaziar
                guiches[i].peso = fila[j].Count * guiches[i].turnosNecessarios;


            }
        }
        Boolean condicaoEspecial(GuichesSetup[] guiches, Queue<Pessoas>[] fila) {
            Boolean continuar = false;
            for (int k = 0; k < fila.Length; k++) if (fila[k].Count != 0) continuar = true;

            if (continuar == true)
            {
                int i;
                int j;
                for (i = 0; i < fila.Length; i++)
                {
                    if (fila[i].Count != 0 && guiches[i].chegadaAtendente == 0) {

                        //MessageBox.Show("valor de i:" + i);

                        for (j = 0; j < guiches.Length; j++) if (guiches[j].atendente == true) break;

                        //MessageBox.Show("valor de j:" + j);

                        trocarAtendentes(guiches, j, i);
                    }
                }
            }

            return continuar;
        }
    }
}
