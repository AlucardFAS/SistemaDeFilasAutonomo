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
        //private System.Windows.Forms.ToolTip[] toolTip;

        private void entrarGuiches(Pessoas pessoa, GuichesSetup guiche) {
            guiche.vazio = false;
            guiche.pessoaDentro = pessoa;
        }

        private void criarGuiches(int quantidade, GuichesSetup[] guiches){
            //declarando os vetores em função da quantidade de guiches
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
                    inicio = Constantes.TAMANHO_HORIZONTAL - (Constantes.TAMANHO_HORIZONTAL / quantidade * (quantidade - 1)) - (100 - (quantidade * 3));
                else inicio = (Constantes.TAMANHO_VERTICAL-250) - ((Constantes.TAMANHO_VERTICAL-250) / (quantidade-14) * (quantidade-15)) - (100 - (quantidade *3));
                if (i <= 14)  //gerando os 15 primeiros guiches de baixo
                    this.guichesBotao[i].Location = new System.Drawing.Point((quantidade > 15 ? Constantes.TAMANHO_HORIZONTAL/15*i:Constantes.TAMANHO_HORIZONTAL/quantidade*i) + (inicio/2), Constantes.TAMANHO_VERTICAL - 90);
                else{   //gerando os 5 ultimos guiches no lado direito em cima
                    this.guichesBotao[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                    this.guichesBotao[i].Location = new System.Drawing.Point(1270, (Constantes.TAMANHO_VERTICAL - 250) / (quantidade-14)*(i-14) - (inicio/2));
                }
               //gerando o tamanho dos guiches
                this.guichesBotao[i].Size = new System.Drawing.Size(100-(quantidade*3), 100-(quantidade*3));
                
                this.guichesBotao[i].Click += new System.EventHandler(this.Clique_Guiche);
                this.guichesBotao[i].BackColor = System.Drawing.Color.DarkGray;
                //texto dos guiches
                aux += guiches[i].guiche;
                this.guichesBotao[i].Text = aux;
                aux = "";


                

                this.Controls.Add(this.guichesBotao[i]);
                this.ResumeLayout(false);
            } 


                verticalProgressBar = new VerticalProgressBar[quantidade > 15 ? 15 : quantidade];
                progressBar = new System.Windows.Forms.ProgressBar[quantidade > 15 ? (quantidade - 15) : 0];

                //Criando barras de progresso
                for (int j = 0; j < quantidade; j++) {
                    if (j <= 14){   //criando as 15 primeiras barras de progresso
                        verticalProgressBar[j] = new VerticalProgressBar();

                        int inicio = Constantes.TAMANHO_HORIZONTAL - (Constantes.TAMANHO_HORIZONTAL / quantidade * (quantidade - 1) + 18);


                        if (guiches[j].guichesIguais % 2 == 0) verticalProgressBar[j].Location = new System.Drawing.Point((quantidade > 14 ? Constantes.TAMANHO_HORIZONTAL / 15 * (j + guiches[j].guichesIguais/2 - 1) : Constantes.TAMANHO_HORIZONTAL / quantidade * (j + guiches[j].guichesIguais/2 - 1)) + inicio / 2 + (Constantes.TAMANHO_HORIZONTAL / (quantidade>15 ? 15:quantidade) / 2), 410);
                            else verticalProgressBar[j].Location = new System.Drawing.Point((quantidade > 14 ? Constantes.TAMANHO_HORIZONTAL / 15 * (j + guiches[j].guichesIguais /2) : Constantes.TAMANHO_HORIZONTAL / quantidade * (j + guiches[j].guichesIguais / 2)) + inicio / 2, 410);
                            verticalProgressBar[j].Size = new System.Drawing.Size(18, 163);
                            verticalProgressBar[j].Maximum = 10;

                            this.Controls.Add(this.verticalProgressBar[j]);
                        
                        j += guiches[j].guichesIguais - 1 ;
                    }
                    else
                    {  //criando as ultimas 5 barras de progresso
                        progressBar[j - 15] = new System.Windows.Forms.ProgressBar();

                        int inicio = (Constantes.TAMANHO_VERTICAL - 250) - (((Constantes.TAMANHO_VERTICAL - 250) / (quantidade - 14) * (quantidade - 15) - 60));

                        if (guiches[j].guichesIguais % 2 == 0) progressBar[j - 15].Location = new System.Drawing.Point(1100, (Constantes.TAMANHO_VERTICAL - 250) / (quantidade - 14) * ((j - 15) + guiches[j].guichesIguais / 2 - 1) + (inicio / 2) + ((Constantes.TAMANHO_VERTICAL - 250) / (quantidade-14) / 2));
                        else progressBar[j - 15].Location = new System.Drawing.Point(1100, (Constantes.TAMANHO_VERTICAL - 250) / (quantidade - 14) * ((j - 14) + guiches[j].guichesIguais / 2 - 1) + (inicio / 2));

                        progressBar[j - 15].Size = new System.Drawing.Size(163, 18);

                        this.Controls.Add(this.progressBar[j - 15]);

                        j += guiches[j].guichesIguais - 1;
                    }
                    
            }
        }
    }
}