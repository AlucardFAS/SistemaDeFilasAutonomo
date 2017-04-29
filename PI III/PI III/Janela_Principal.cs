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
        Boolean[] atendentesIniciais;

       
        
        public Janela_Principal(){


            //this.BackgroundImage = global::PI_III.Properties.Resources.PI_IIIwpp;
            StartPosition = FormStartPosition.CenterScreen; //deixando a tela bem no centro
            ClientSize = new System.Drawing.Size(TAMANHO_HORIZONTAL, TAMANHO_VERTICAL);    //definindo tamanho da janela principal
            Text = "Projeto Integrador 3";   //nome da janela principal
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            //int totalGuiches;

            guiches = CarregarSetup("Dados/Setup.txt");

            pessoas = Pessoas.carregarFila(pessoas, "Dados/Fila.txt");

            int quantidade = guiches.Length;
            fila = new Queue<Pessoas>[quantidade];  //criando as filas em função da quantidade de guiches
            for (int i = 0; i < fila.Length; i++) fila[i] = new Queue<Pessoas>();   //instanciando as filas

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
            processo(fila, pessoas, guiches, 0);
        }
    }
}
