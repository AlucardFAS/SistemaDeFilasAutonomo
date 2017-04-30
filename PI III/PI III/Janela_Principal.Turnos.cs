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
        private System.Windows.Forms.Button butao;
        private System.Windows.Forms.Label textoTurno;

        void GerarPlay(Queue<Pessoas>[] fila, GuichesSetup[] guiches){
            for (int i = 0; i < 5; i++) //gerando os botões de play
            {
                butao = new System.Windows.Forms.Button();
                butao.Location = new System.Drawing.Point(260 - (i * 60), 300);
                butao.Size = new System.Drawing.Size(60,60);
                this.butao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                this.butao.BackColor = System.Drawing.Color.DarkGray;


                if (i == 0) butao.BackgroundImage = global::PI_III.Properties.Resources._1493335334_icon_play1;
                if (i == 1) butao.BackgroundImage = global::PI_III.Properties.Resources._2x;
                if (i == 2) butao.BackgroundImage = global::PI_III.Properties.Resources._3x;
                if (i == 3) butao.BackgroundImage = global::PI_III.Properties.Resources._10x; ;
                if (i == 4) butao.Text = "Play5";


                Controls.Add(this.butao);

                textoTurno = new System.Windows.Forms.Label();
                this.SuspendLayout();

                textoTurno.AutoSize = true;
                textoTurno.Location = new System.Drawing.Point(30,30);
                textoTurno.Size = new System.Drawing.Size(50, 30);
                
                Controls.Add(textoTurno);

                if (i == 0) butao.Click += new System.EventHandler(this.cliquePlay);
                if (i == 1) butao.Click += new System.EventHandler(this.cliquePlay2);
                if (i == 2) butao.Click += new System.EventHandler(this.cliquePlay3);
                if (i == 3) butao.Click += new System.EventHandler(this.cliquePlay4);
                if (i == 4) butao.Click += new System.EventHandler(this.cliquePlay5);
            }
            //gerando pause
            butao = new System.Windows.Forms.Button();
            butao.Location = new System.Drawing.Point (380, 300);
            butao.Size = new System.Drawing.Size(60, 60);
            
            Controls.Add(this.butao);
            butao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            butao.BackgroundImage = global::PI_III.Properties.Resources._1493339249_pause;
            this.butao.BackColor = System.Drawing.Color.DarkGray;
        }
        void sleep(double tempo)
        {
            String entradaTempo;
            double segundos;
            double milissegundos;
            double tempoInicial;
            double tempoFinal;
            //pegando as entradas de tempo e convertendo para doubles
            entradaTempo = DateTime.Now.ToString("ss");
            if (!Double.TryParse(entradaTempo, out segundos)) MessageBox.Show("Deu ruim na hora de converter");   //caso tenha problema na conversão retorna essa mensagem
            entradaTempo = DateTime.Now.ToString("ffffff");
            if (!Double.TryParse(entradaTempo, out milissegundos)) MessageBox.Show("Deu ruim na hora de converter");  //caso tenha problema na conversão retorna essa mensagem

            tempoInicial = segundos + (milissegundos / 1000000);    //juntando os segundos com os milissegundos numa variavel só
            tempoFinal = tempoInicial + tempo;  //somando o tempo de sleep com o tempo inicial
            while (true)
            {
                if (tempoFinal > 60) tempoFinal -= 60;  //caso o tempofinal passe de 60, para ele retornar ao 0

                entradaTempo = DateTime.Now.ToString("ss");
                if (!Double.TryParse(entradaTempo, out segundos)) MessageBox.Show("Deu ruim na hora de converter");
                entradaTempo = DateTime.Now.ToString("ffffff");
                if (!Double.TryParse(entradaTempo, out milissegundos)) MessageBox.Show("Deu ruim na hora de converter");
                tempoInicial = segundos + (milissegundos / 1000000);
                /*isso foi necessário devido a problemas de que quando se trabalha com vários decimais, não consegue se igualar o
                tempo final com o inicial, e não poderia ter somente um tempoFinal < tempoInicial pois ocorreria um problema
                 entre o segundo 59 e 0*/
                if ((tempoFinal - tempoInicial) < 0 && (tempoFinal - tempoInicial) > -1) return;
            }
        }
    }
}
