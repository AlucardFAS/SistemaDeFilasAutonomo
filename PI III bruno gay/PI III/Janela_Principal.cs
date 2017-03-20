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
            ClientSize = new System.Drawing.Size(TAMANHO_HORIZONTAL, TAMANHO_VERTICAL);    //definindo tamanho da janela principal
            Text = "Projeto Rocinha";   //nome da janela principal

            int totalClientes = File.ReadAllLines("Dados/Fila.txt").Length; //contando o numero de pessoas que terão na fila

            guiches = CarregarSetup();

            pessoas = new Pessoas[totalClientes];
            pessoas = carregarFila();

            int quantidade = guiches.Length;
            fila = criarFilas(fila, quantidade);

            barraMenu(pessoas);
            criarGuiches(quantidade, guiches);

            //fila[0] = new Queue<Pessoas>();
            //fila[0].Enqueue(pessoas[0]);
            GerarPlay(fila, pessoas, guiches);

        }
        private void cliquePlay(object sender, EventArgs e) //essa função vai ser para dar play na velocidade padrão (1 seg)
        {
            int turno = 1;
            //obtendo a quantidade de guiches
            int quantidadeGuiches = guiches.Length;
            
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
                        if (guiches[j].vazio == true && fila[j].Count != 0)   
                            entrarGuiches(fila[j].Dequeue(), guiches[j]);                        
                    

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                guiches = atualizarGuiches(guiches, fila);

                //atualizando as barras de progresso
                for (int j = 0; j < quantidadeGuiches; j++) verticalProgressBar[j].Value = fila[j].Count;

                turno = contarTurnos(1, turno);
            }

            //esse laço vai até esvaziar todos os guiches, assim, terminando
            Boolean continuar = true;
            while (continuar) {

                //jogando as primeiras pessoas das filas nos guiches
                for (int j = 0; j < quantidadeGuiches; j++)
                    if (guiches[j].vazio == true && fila[j].Count != 0)
                        entrarGuiches(fila[j].Dequeue(), guiches[j]);

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                guiches = atualizarGuiches(guiches, fila);

                //atualizando as barras de progresso
                for (int j = 0; j < quantidadeGuiches; j++) verticalProgressBar[j].Value = fila[j].Count;

                turno = contarTurnos(1, turno);
         
                continuar = false;
                for (int j = 0; j < quantidadeGuiches; j++) if (guiches[j].vazio == false) continuar = true;
            }
            MessageBox.Show(""+turno);

        }
        private void cliquePlay2(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 2x (0.5 seg)
        {
            int turno = 1;
            contarTurnos(0.5, turno);
        }
        private void cliquePlay3(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 4x (0.25 seg)
        {
            int turno = 1;
            contarTurnos(0.25, turno);
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
