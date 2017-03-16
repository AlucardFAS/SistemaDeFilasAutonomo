using System;
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
        public Janela_Principal()
        {
            ClientSize = new System.Drawing.Size(1200, 650);    //definindo tamanho da janela principal
            Text = "Projeto Rocinha";   //nome da janela principal
            BarraMenu();
            CriarGuiches();
        }


        private void carregarSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Carregar Setup");
        }
        private void carregarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Carregar Fila");
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
