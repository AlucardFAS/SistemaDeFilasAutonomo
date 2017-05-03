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
    public partial class Estatisticas : Form
    {
        public Estatisticas(Estatistica estatistica, List<EstatisticaComb> estatisticaPorGuiches, GuichesSetup[] guiches)
        {
            //InitializeComponent();
            ClientSize = new System.Drawing.Size(340, 700);
            StartPosition = FormStartPosition.CenterScreen;
            //estatisticas de tempo médio
            Label textoMedioTotal = new Label();

            
            textoMedioTotal.AutoSize = true;
            textoMedioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textoMedioTotal.Location = new System.Drawing.Point(10, 10);
            textoMedioTotal.Text = "Tempo médio entre usuarios: " + estatistica.tempoTotalUsuarios / estatistica.quantidadeUsuarios;

            Controls.Add(textoMedioTotal);

            //estatisticas de maior usuario
            Label textoUsuarioMaior = new Label();

            textoUsuarioMaior.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textoUsuarioMaior.AutoSize = true;
            textoUsuarioMaior.Location = new System.Drawing.Point(10, 50);
            textoUsuarioMaior.Text = "Maior tempo entre usuarios: " + estatistica.maiorTempo + "\n" + "Usuario com maior tempo: " + estatistica.usuarioMaiorTempo;

            Controls.Add(textoUsuarioMaior);

            Label[] textoMediaFila = new Label[estatistica.guicheTempoFila.Length];

            //estatisticas por tempo
            int k = 0;
            for (int i = 0; i < estatistica.guicheTempoFila.Length; i++)
                {
                    textoMediaFila[i] = new Label();
                    textoMediaFila[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    textoMediaFila[i].AutoSize = true;
                    textoMediaFila[i].Location = new System.Drawing.Point(10, 120 + i * 20);

                    textoMediaFila[i].Text = "Tempo médio da fila do guiche " + (guiches[k].guiche) + " : " + Math.Round(estatistica.guicheTempoFila[i] / estatistica.quantidadePessoasFila[i], 2);
                    k += guiches[k].guichesIguais;

                    Controls.Add(textoMediaFila[i]);
                }
            //estatisticas por combinação
            Label[] textoMediaComb = new Label[estatisticaPorGuiches.Count];

            for (int i = 0; i < estatisticaPorGuiches.Count; i++)
            {
                textoMediaComb[i] = new Label();
                textoMediaComb[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textoMediaComb[i].AutoSize = true;
                textoMediaComb[i].Location = new System.Drawing.Point(10, 250 + i * 20);

                textoMediaComb[i].Text = "Tempo médio da combinação " + estatisticaPorGuiches[i].combinacao + ": " + estatisticaPorGuiches[i].quantidadeTurnos / estatisticaPorGuiches[i].quantidadePessoas;

                Controls.Add(textoMediaComb[i]);
            }

            
        }
    }
}
