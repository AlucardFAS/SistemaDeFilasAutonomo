namespace PI_III
{
    partial class Janela_Principal
    {
        private System.Windows.Forms.Button guiches;
        private VerticalProgressBar verticalProgressBar1;
        private System.Windows.Forms.ProgressBar progressBar1;

        private void criarGuiches()
        {
            int quantidade = 20;

            for (int i = 0; i < quantidade; i++)
            {
                // 
                // guiches
                // 
                guiches = new System.Windows.Forms.Button();
                int inicio;

                if (i <= 14)
                    inicio = TAMANHO_HORIZONTAL - (TAMANHO_HORIZONTAL / quantidade * (quantidade - 1)) - (100 - (quantidade * 3));
                else inicio = (TAMANHO_VERTICAL-250) - ((TAMANHO_VERTICAL-250) / (quantidade-14) * (quantidade-15)) - (100 - (quantidade *3));
                if (i <= 14)  //gerando os 15 primeiros guiches de baixo
                    this.guiches.Location = new System.Drawing.Point((quantidade > 15 ? TAMANHO_HORIZONTAL/15*i:TAMANHO_HORIZONTAL/quantidade*i) + (inicio/2), TAMANHO_VERTICAL - 70);
                else{   //gerando os 5 ultimos guiches no lado direito em cima
                    this.guiches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                    this.guiches.Location = new System.Drawing.Point(1270, (TAMANHO_VERTICAL - 250) / (quantidade-14)*(i-14) - (inicio/2));
                }
               //gerando o tamanho dos guiches
                this.guiches.Size = new System.Drawing.Size(100-(quantidade*3), 100-(quantidade*3));
                
                this.guiches.Click += new System.EventHandler(this.Clique_Guiche);

                //solução temporaria de texto de guiches
                if (i == 0)   this.guiches.Text = "A";
                if (i == 1)   this.guiches.Text = "B";
                if (i == 2)   this.guiches.Text = "C";
                if (i == 3)   this.guiches.Text = "D";
                if (i == 4)   this.guiches.Text = "E";
                if (i == 5)   this.guiches.Text = "F";
                if (i == 6)   this.guiches.Text = "G";
                if (i == 7)   this.guiches.Text = "H";
                if (i == 8)   this.guiches.Text = "I";
                if (i == 9)   this.guiches.Text = "J";
                if (i == 10)  this.guiches.Text = "K";
                if (i == 11)  this.guiches.Text = "L";
                if (i == 12)  this.guiches.Text = "M";
                if (i == 13)  this.guiches.Text = "N";
                if (i == 14)  this.guiches.Text = "O";
                if (i == 15)  this.guiches.Text = "P";
                if (i == 16)  this.guiches.Text = "Q";

                if (i <= 14){   //criando as 15 primeiras barras de progresso
                    this.verticalProgressBar1 = new VerticalProgressBar();

                    inicio = TAMANHO_HORIZONTAL-(TAMANHO_HORIZONTAL/quantidade * (quantidade-1) + 18);
                    this.verticalProgressBar1.Location = new System.Drawing.Point ((quantidade > 14 ? TAMANHO_HORIZONTAL/15*i:TAMANHO_HORIZONTAL/quantidade*i) + inicio/2, 430);
                    this.verticalProgressBar1.Size = new System.Drawing.Size(18, 163);
                    //this.verticalProgressBar1.Value = 30;
                }
                else {  //criando as ultimas 5 barras de progresso
                    this.progressBar1 = new System.Windows.Forms.ProgressBar();
                    inicio = (TAMANHO_VERTICAL - 250)-(((TAMANHO_VERTICAL- 250)/(quantidade-14)*(quantidade-15) - 60));
                    this.progressBar1.Location = new System.Drawing.Point(1100, (TAMANHO_VERTICAL - 250)/(quantidade-14)*(i-15) + (inicio/2));
                    this.progressBar1.Size = new System.Drawing.Size(163, 18);
                    
                } 
                // 
                // Janela Principal
                // 
                this.Controls.Add(this.guiches);
                this.Controls.Add(this.verticalProgressBar1);
                this.Controls.Add(this.progressBar1);
                this.ResumeLayout(false);
            }
        }
    }
}