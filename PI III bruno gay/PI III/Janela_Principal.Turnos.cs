﻿using System;
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

        private void cliquePlay(object sender, EventArgs e) //essa função vai ser para dar play na velocidade padrão (1 seg)
        {
            contarTurnos(1);
        }
        private void cliquePlay2(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 2x (0.5 seg)
        {
            contarTurnos(0.5);
        }
        private void cliquePlay3(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 4x (0.25 seg)
        {
            contarTurnos(0.25);
        }
        private void cliquePlay4(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 10x (0.1 seg)
        {
            contarTurnos(0.10);
        }
        private void cliquePlay5(object sender, EventArgs e) //essa função vai ser para dar play na velocidade determinada pelo usuario, não mexer nisso por enquanto, nem ligar ela ao botão
        {
            double variavel = 0.10;
            contarTurnos(variavel);
        }

        void gerarBotoes(){
            for (int i = 0; i < 5; i++) //gerando os botões de play
            {
                butao = new System.Windows.Forms.Button();
                butao.Location = new System.Drawing.Point(600 - (i * 60), 350);
                butao.Size = new System.Drawing.Size(50, 50);
                if (i == 0) butao.Text = "Play";
                if (i == 1) butao.Text = "Play2";
                if (i == 2) butao.Text = "Play3";
                if (i == 3) butao.Text = "Play4";
                if (i == 4) butao.Text = "Play5";

                if (i == 0) butao.Click += new System.EventHandler(this.cliquePlay);
                if (i == 1) butao.Click += new System.EventHandler(this.cliquePlay2);
                if (i == 2) butao.Click += new System.EventHandler(this.cliquePlay3);
                if (i == 3) butao.Click += new System.EventHandler(this.cliquePlay4);
                Controls.Add(this.butao);
            }

            butao = new System.Windows.Forms.Button();
            butao.Location = new System.Drawing.Point (720, 350);
            butao.Size = new System.Drawing.Size(50, 50);
            butao.Text = "Pause";
            Controls.Add(this.butao);
        }
        void contarTurnos(double tempo)
        {
            int turno = 0;
            while (turno < 10){   //até acabar todos os clientes (o <10 é provisório para testes)
                sleep(tempo);
                turno++;
                MessageBox.Show("turno: "+turno);
            }

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