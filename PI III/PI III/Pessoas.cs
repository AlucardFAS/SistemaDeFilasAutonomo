using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_III
{

    class Pessoas
    {
        public int usuario;
        public int chegada;
        public char[] guiches;

        public int atualGuiche;

        //usado para auxiliar o calculo da estatistica de tempo de fila
        public int entradaFila;

        public Pessoas()
        {
            atualGuiche = 0;
            entradaFila = 0;
        }

        public void setPessoa(int u, int c, String g)
        {
            this.usuario = u;
            this.chegada = c;
            this.guiches = g.ToCharArray();
        }
    }
}
