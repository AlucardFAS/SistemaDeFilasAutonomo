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
        
        public Janela_Principal(){
            ClientSize = new System.Drawing.Size(TAMANHO_HORIZONTAL, TAMANHO_VERTICAL);    //definindo tamanho da janela principal
            Text = "Projeto Rocinha";   //nome da janela principal
            int totalClientes = File.ReadAllLines("Dados/Fila.txt").Length;

            pessoas = new Pessoas[totalClientes];

            barraMenu(pessoas);
            criarGuiches();
            gerarBotoes();

        }

        private void carregarSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarSetup();
        }
        private void carregarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pessoas = carregarFila();

            MessageBox.Show(""+pessoas[0].usuario);
        }
        private void criarSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cria Setup");
        }
        private void criarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criar Fila");
        }
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tutorial");
        }
        private void Clique_Guiche(object sender, EventArgs e)
        {
            MessageBox.Show("Vai se fude");
        }

    }
}
