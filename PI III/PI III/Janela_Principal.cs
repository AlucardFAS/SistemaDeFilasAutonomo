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
            processo(fila, pessoas, guiches, 1);
        }
        private void cliquePlay2(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 2x (0.5 seg)
        {
            processo(fila, pessoas, guiches, 0.5);
        }
        private void cliquePlay3(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 3x (0.33 seg)
        {
            processo(fila, pessoas, guiches, 0.333333);
        }
        private void cliquePlay4(object sender, EventArgs e) //essa função vai ser para dar play na velocidade 10x (0.1 seg)
        {
            processo(fila, pessoas, guiches, 0.10);
        }
        private void cliquePlay5(object sender, EventArgs e) //essa função vai ser para dar play na velocidade determinada pelo usuario, não mexer nisso por enquanto, nem ligar ela ao botão
        {
            
        }
    }
}
