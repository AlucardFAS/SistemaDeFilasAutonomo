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
        void processo(Queue<Pessoas>[] fila, Pessoas[] pessoas, GuichesSetup[] guiches, double tempo)
        {
            int turno = 1;
            //obtendo a quantidade de guiches
            int quantidadeGuiches = guiches.Length;

            int quantidadeFilas = 0;
            int i = 0;
            while (i < quantidadeGuiches)
            {
                i += guiches[i].guichesIguais;
                quantidadeFilas++;
            }

            i = 0;

            //esse laço vai até entrar todas as pessoas nas filas
            while (i < pessoas.Length)
            {
                //jogando as pessoas na fila do guiche A (ou dos guiches A)
                while (pessoas[i].chegada == turno)
                {
                    fila[0].Enqueue(pessoas[i]);
                    i++;
                    if (i >= pessoas.Length) break; //quando o i for maior do que a quantidade de pessoas
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
                turno = contarTurnos(tempo, turno);
            }

            //Atualizando o label que conta os turnos
            textoTurno.Text = "Turno: " + turno;
            textoTurno.Refresh();
            Refresh();

            //esse laço vai até esvaziar todos os guiches, assim, terminando
            Boolean continuar = true;
            while (continuar)
            {

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

                continuar = false;
                for (int j = 0; j < quantidadeGuiches; j++) if (guiches[j].vazio == false) continuar = true;
                if (continuar == false) break;

                turno = contarTurnos(tempo, turno);

                //Atualizando o label que conta os turnos
                textoTurno.Text = "Turno: " + turno;
                textoTurno.Refresh();
                Refresh();
            }

            MessageBox.Show("Turno terminado: " + turno);
        }
    }
}
