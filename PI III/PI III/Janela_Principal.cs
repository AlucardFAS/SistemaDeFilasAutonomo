using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    public partial class Janela_Principal : Form
    {
        const int TAMANHO_HORIZONTAL = 1350;
        const int TAMANHO_VERTICAL = 670;

        Pessoas[] pessoas;
        Queue<Pessoas>[] fila;
        GuichesSetup[] guiches;

        
        public Janela_Principal(){
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new System.Drawing.Size(TAMANHO_HORIZONTAL, TAMANHO_VERTICAL);    //definindo tamanho da janela principal
            Text = "Projeto Integrador 3";   //nome da janela principal

            int totalClientes = File.ReadAllLines("Dados/Fila.txt").Length; //contando o numero de pessoas que terão na fila

            guiches = CarregarSetup();

            pessoas = new Pessoas[totalClientes];
            pessoas = carregarFila();

            
            
            int quantidade = guiches.Length;

            fila = criarFilas(fila, quantidade);

            barraMenu(pessoas);
            criarGuiches(quantidade, guiches);

            GerarPlay(fila, pessoas, guiches);

        }
        private void cliquePlay(object sender, EventArgs e) //essa função vai ser para dar play na velocidade padrão (1 seg)
        {
            int turno = 1;
            //obtendo a quantidade de guiches
            int quantidadeGuiches = guiches.Length;

            int quantidadeFilas = 0;
            for (int j = 0; j < quantidadeGuiches; j++ ){
                if (j + 1 < quantidadeGuiches && guiches[j].guiche == guiches[j + 1].guiche) j++;
                quantidadeFilas++;
            }
            
            
            int i = 0;

            //esse laço vai até entrar todas as pessoas nas filas
            while (i<pessoas.Length){
                //jogando as pessoas na fila do guiche A (ou dos guiches A)
                while (pessoas[i].chegada == turno)
                {
                    fila[0].Enqueue(pessoas[i]);
                    i++;
                    if (i >= pessoas.Length) break;
                }
                //jogando as primeiras pessoas das filas nos guiches
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    for (int k = 0; k < guiches[j].guichesIguais; k++)
                    {
                        if (guiches[j + k].atendente == true && guiches[j + k].vazio == true && fila[j].Count != 0)
                            entrarGuiches(fila[j].Dequeue(), guiches[j + k]);
                    }
                    j += guiches[j].guichesIguais - 1;
                }

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                guiches = atualizarGuiches(guiches, fila);

                //jogando as primeiras pessoas das filas nos guiches
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    for (int k = 0; k < guiches[j].guichesIguais; k++)
                    {
                        if (guiches[j + k].atendente == true && guiches[j + k].vazio == true && fila[j].Count != 0)
                            entrarGuiches(fila[j].Dequeue(), guiches[j + k]);
                    }
                    j += guiches[j].guichesIguais - 1;
                }

                //atualizando as barras de progresso
                for (int j = 0; j < quantidadeFilas; j++)
                    if (verticalProgressBar[j] != null)
                    {
                        if (fila[j].Count > verticalProgressBar[j].Maximum) verticalProgressBar[j].Maximum *= 10;
                        else if (fila[j].Count < verticalProgressBar[j].Maximum / 10) verticalProgressBar[j].Maximum /= 10;

                        verticalProgressBar[j].Value = fila[j].Count;
                    }
                //atualizando a cor dos botões
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    if (guiches[j].vazio == false) guichesBotao[j].BackColor = System.Drawing.Color.Green;
                    else if (guiches[j].atendente == true) guichesBotao[j].BackColor = System.Drawing.Color.Yellow;
                    else guichesBotao[j].BackColor = System.Drawing.Color.Red;
                }

                //Atualizando o label que conta os turnos
                textoTurno.Text = "Turno: " + turno;
                textoTurno.Refresh();
                Refresh();

                Application.DoEvents();
                turno = contarTurnos(1, turno);
            }

            //Atualizando o label que conta os turnos
            textoTurno.Text = "Turno: " + turno;
            textoTurno.Refresh();
            Refresh();

            //esse laço vai até esvaziar todos os guiches, assim, terminando
            Boolean continuar = true;
            while (continuar) {

                //jogando as primeiras pessoas das filas nos guiches
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    for (int k = 0; k < guiches[j].guichesIguais; k++)
                    {
                        if (guiches[j + k].atendente == true && guiches[j + k].vazio == true && fila[j].Count != 0)
                            entrarGuiches(fila[j].Dequeue(), guiches[j + k]);
                    }
                    j += guiches[j].guichesIguais - 1;
                }

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                guiches = atualizarGuiches(guiches, fila);

                //jogando as primeiras pessoas das filas nos guiches
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    for (int k = 0; k < guiches[j].guichesIguais; k++)
                    {
                        if (guiches[j+k].atendente == true && guiches[j + k].vazio == true && fila[j].Count != 0)
                            entrarGuiches(fila[j].Dequeue(), guiches[j + k]);
                    }
                    j += guiches[j].guichesIguais - 1;
                }

                //atualizando as barras de progresso
                for (int j = 0; j < quantidadeFilas; j++)
                    if (verticalProgressBar[j] != null)
                    {
                        if (fila[j].Count > verticalProgressBar[j].Maximum) verticalProgressBar[j].Maximum *= 10;
                        else if (fila[j].Count < verticalProgressBar[j].Maximum / 10) verticalProgressBar[j].Maximum /= 10;

                        verticalProgressBar[j].Value = fila[j].Count;
                    }

                //atualizando a cor dos botões
                for (int j = 0; j < quantidadeGuiches; j++)
                {
                    if (guiches[j].vazio == false) guichesBotao[j].BackColor = System.Drawing.Color.Green;
                    else if (guiches[j].atendente == true) guichesBotao[j].BackColor = System.Drawing.Color.Yellow;
                    else guichesBotao[j].BackColor = System.Drawing.Color.Red;
                }

                continuar = false;
                for (int j = 0; j < quantidadeGuiches; j++) if (guiches[j].vazio == false) continuar = true;
                if (continuar == false) break;

                turno = contarTurnos(1, turno);

                //Atualizando o label que conta os turnos
                textoTurno.Text = "Turno: " + turno;
                textoTurno.Refresh();
                Refresh();
            }
            
            MessageBox.Show("Turno terminado: "+turno);

        }
        private void cliquePlay2(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 2x (0.5 seg)
        {
            int turno = 1;
            contarTurnos(0.5, turno);
        }
        private void cliquePlay3(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 3x (0.33 seg)
        {
            int turno = 1;
            contarTurnos(0.333333, turno);
        }
        private void cliquePlay4(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 10x (0.1 seg)
        {
            int turno = 1;
            contarTurnos(0.10, turno);
        }
        private void cliquePlay5(object sender, EventArgs e) //essa função vai ser para dar play na velocidade determinada pelo usuario, não mexer nisso por enquanto, nem ligar ela ao botão
        {
            int turno = 1;
            double variavel = 0.10;
            contarTurnos(variavel, turno);
        }
        

    }
}
