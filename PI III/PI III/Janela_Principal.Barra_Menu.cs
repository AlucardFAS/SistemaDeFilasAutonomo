using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{
    partial class Janela_Principal{

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarFilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarFilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;

        private void barraMenu(){
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarFilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarFilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarSetupToolStripMenuItem,
            this.carregarFilaToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // carregarSetupToolStripMenuItem
            // 
            this.carregarSetupToolStripMenuItem.Name = "carregarSetupToolStripMenuItem";
            this.carregarSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.carregarSetupToolStripMenuItem.Text = "Carregar Setup";
            this.carregarSetupToolStripMenuItem.Click += new System.EventHandler(this.carregarSetupToolStripMenuItem_Click);
            // 
            // carregarFilaToolStripMenuItem
            // 
            this.carregarFilaToolStripMenuItem.Name = "carregarFilaToolStripMenuItem";
            this.carregarFilaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.carregarFilaToolStripMenuItem.Text = "Carregar Fila";
            this.carregarFilaToolStripMenuItem.Click += new System.EventHandler(this.carregarFilaToolStripMenuItem_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarSetupToolStripMenuItem,
            this.criarFilaToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // criarSetupToolStripMenuItem
            // 
            this.criarSetupToolStripMenuItem.Name = "criarSetupToolStripMenuItem";
            this.criarSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.criarSetupToolStripMenuItem.Text = "Criar Setup";
            this.criarSetupToolStripMenuItem.Click += new System.EventHandler(this.criarSetupToolStripMenuItem_Click);
            // 
            // criarFilaToolStripMenuItem
            // 
            this.criarFilaToolStripMenuItem.Name = "criarFilaToolStripMenuItem";
            this.criarFilaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.criarFilaToolStripMenuItem.Text = "Criar Fila";
            this.criarFilaToolStripMenuItem.Click += new System.EventHandler(this.criarFilaToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // Janela_Principal
            // 
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void carregarSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
    
           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try{
                Array.Clear(guiches, 0, guiches.Length);    //limpando o vetor pessoas antes de carregar os guiches novamente
                Array.Clear(atendentesIniciais, 0, atendentesIniciais.Length);  //limpando o vetor de relação de atendentes iniciais que é setado dentro do carregarSetup

                guiches = CarregarSetup(openFileDialog1.FileName);  //chama a função que carrega o setup em função do arquivo escolhido

                Array.Clear(fila, 0, fila.Length);  //limpa o vetor de filas antes de criar as filas novamente

                fila = new Queue<Pessoas>[guiches.Length];  //criando as filas em função da quantidade de guiches
                for (int i = 0; i < fila.Length; i++) fila[i] = new Queue<Pessoas>();   //instanciando as filas
                }
                catch (Exception){  //caso escolha um arquivo que não tem o formato de setup, dispara um erro e carrega o setup padrão
                    MessageBox.Show("Por favor, carregar um arquivo válido de Setup");
                    MessageBox.Show("O setup foi retornado para o padrão");

                    guiches = CarregarSetup("Dados/Setup.txt");

                    fila = new Queue<Pessoas>[guiches.Length];  //criando as filas em função da quantidade de guiches
                    for (int i = 0; i < fila.Length; i++) fila[i] = new Queue<Pessoas>();   //instanciando as filas
                }
                this.Controls.Clear();  //limpa todos os guiches atuais (e infelizmente a barra menu e os botões de play)

                barraMenu(); //cria a barra de menus novamente
                criarGuiches(guiches.Length, guiches);  //cria os guiches novamente
                GerarPlay(fila, guiches);  //cria os botões de play de novo

                /*try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        
                        using (myStream)
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                */
            }
        }

        private void carregarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try{
                pathFila = openFileDialog1.FileName; //seta a pathFila de acordo com o txt escolhido
                }catch(Exception){  //caso escolha um arquivo que não tem o formato de filas, dispara um erro e carrega a fila padrão
                    MessageBox.Show("Por favor, escolha um arquivo válido de Filas");
                    MessageBox.Show("A fila foi retornada para o padrão");
                    pathFila = "Dados/Fila.txt";
                }

                this.Controls.Clear();  //limpa todos os guiches atuais (e infelizmente a barra menu e os botões de play)

                barraMenu(); //cria a barra de menus novamente
                criarGuiches(guiches.Length, guiches);  //cria os guiches novamente
                GerarPlay(fila, guiches);  //cria os botões de play de novo
            }

        }
        private void criarSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("naaao");
        }
        private void criarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em Construção.");
        }
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verde - Guiche Ocupado.\nAmarelo - Guiche Disponível.\nVermelho - Guiche Desativado.");
        }
        private void Clique_Guiche(object sender, EventArgs e)
        {
            //MessageBox.Show("Em construção");
        }
    }

}