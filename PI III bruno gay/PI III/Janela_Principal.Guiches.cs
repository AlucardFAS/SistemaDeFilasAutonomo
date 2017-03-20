using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PI_III
{
    partial class Janela_Principal
    {
        private System.Windows.Forms.Button[] guichesBotao;
        private VerticalProgressBar[] verticalProgressBar;
        private System.Windows.Forms.ProgressBar[] progressBar;

        private void entrarGuiches(Pessoas pessoa, GuichesSetup guiche) {
            guiche.vazio = false;
            guiche.pessoaDentro = pessoa;
        }
        GuichesSetup[] atualizarGuiches(GuichesSetup[] guiches, Queue<Pessoas>[] fila){
            int quantidadeGuiches = guiches.Length;
            char proximoGuiche;

            for (int i = 0; i < quantidadeGuiches; i++){
                if (guiches[i].vazio == false && guiches[i].ultimoTurno < guiches[i].turnosNecessarios){
                    guiches[i].ultimoTurno++;
                }
                else if (guiches[i].vazio == false && guiches[i].ultimoTurno >= guiches[i].turnosNecessarios){
                    guiches[i].vazio = true;
                    guiches[i].ultimoTurno = 1;
                    guiches[i].pessoaDentro.atualGuiche++;

                    //testando se a pessoa ainda tem guiches pra ir, se não, ela cai no esquecimento e segue o jogo
                    if (guiches[i].pessoaDentro.atualGuiche >= guiches[i].pessoaDentro.guiches.Length) return guiches;
                    //verificando o proximo guiche que ela tem que ir
                    proximoGuiche = guiches[i].pessoaDentro.guiches[guiches[i].pessoaDentro.atualGuiche];

                    //achando o guiche que a pessoa tem de ir
                    int j = 0;
                    while (guiches[j].guiche != proximoGuiche) j++;

                    //verificando se tem um guiche da mesma letra
                    if (j+1 < quantidadeGuiches && guiches[j].guiche == guiches[j+1].guiche) 
                        if (guiches[j].vazio == false && guiches[j+1].vazio == true && guiches[j+1].atendente == true|| fila[j].Count > fila[j+1].Count && guiches[j+1].atendente == true) j++;

                    //enviando a pessoa para a fila
                    fila[j].Enqueue(guiches[i].pessoaDentro);
                        
                }
            }
            return guiches;
        }
        private void criarGuiches(int quantidade, GuichesSetup[] guiches){
            //declarando os vetor em função da quantidade de guiches
            verticalProgressBar = new VerticalProgressBar[quantidade > 15 ? 15 : quantidade];
            progressBar = new System.Windows.Forms.ProgressBar[quantidade > 15 ? (quantidade - 15) : 0];
            guichesBotao = new Button[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                // 
                // guiches
                // 
                guichesBotao[i] = new System.Windows.Forms.Button();
                int inicio;
                String aux = "";

                if (i <= 14)
                    inicio = TAMANHO_HORIZONTAL - (TAMANHO_HORIZONTAL / quantidade * (quantidade - 1)) - (100 - (quantidade * 3));
                else inicio = (TAMANHO_VERTICAL-250) - ((TAMANHO_VERTICAL-250) / (quantidade-14) * (quantidade-15)) - (100 - (quantidade *3));
                if (i <= 14)  //gerando os 15 primeiros guiches de baixo
                    this.guichesBotao[i].Location = new System.Drawing.Point((quantidade > 15 ? TAMANHO_HORIZONTAL/15*i:TAMANHO_HORIZONTAL/quantidade*i) + (inicio/2), TAMANHO_VERTICAL - 90);
                else{   //gerando os 5 ultimos guiches no lado direito em cima
                    this.guichesBotao[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                    this.guichesBotao[i].Location = new System.Drawing.Point(1270, (TAMANHO_VERTICAL - 250) / (quantidade-14)*(i-14) - (inicio/2));
                }
               //gerando o tamanho dos guiches
                this.guichesBotao[i].Size = new System.Drawing.Size(100-(quantidade*3), 100-(quantidade*3));
                
                this.guichesBotao[i].Click += new System.EventHandler(this.Clique_Guiche);

                //texto dos guiches
                aux += guiches[i].guiche;
                this.guichesBotao[i].Text = aux;
                aux = "";

                if (i <= 14){   //criando as 15 primeiras barras de progresso
                    verticalProgressBar[i] = new VerticalProgressBar();

                    inicio = TAMANHO_HORIZONTAL-(TAMANHO_HORIZONTAL/quantidade * (quantidade-1) + 18);
                    verticalProgressBar[i].Location = new System.Drawing.Point ((quantidade > 14 ? TAMANHO_HORIZONTAL/15*i:TAMANHO_HORIZONTAL/quantidade*i) + inicio/2, 410);
                    verticalProgressBar[i].Size = new System.Drawing.Size(18, 163);
                    verticalProgressBar[i].Maximum = 10;

                    this.Controls.Add(this.verticalProgressBar[i]);
                }
                else {  //criando as ultimas 5 barras de progresso
                    progressBar[i-15] = new System.Windows.Forms.ProgressBar();

                    inicio = (TAMANHO_VERTICAL - 250)-(((TAMANHO_VERTICAL- 250)/(quantidade-14)*(quantidade-15) - 60));
                    progressBar[i-15].Location = new System.Drawing.Point(1100, (TAMANHO_VERTICAL - 250)/(quantidade-14)*(i-15) + (inicio/2));
                    progressBar[i-15].Size = new System.Drawing.Size(163, 18);

                    this.Controls.Add(this.progressBar[i-15]);             
                } 
                // 
                // Janela Principal
                // 
                this.Controls.Add(this.guichesBotao[i]);
                this.ResumeLayout(false);
            }
            //progressBar[2].Value = 30;
            //verticalProgressBar[1].Value = 30;
        }

    }
}