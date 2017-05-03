using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_III
{
    public class EstatisticaComb
    {
        public String combinacao;
        public int quantidadeTurnos;
        public int quantidadePessoas;

        public EstatisticaComb() {
            this.quantidadeTurnos = 0;
            this.quantidadePessoas = 0;
        }
        public void setEstatisticaComb(Char [] combinacaoChars, int quantidadeTurnos, int quantidadePessoas){
            this.combinacao = new string(combinacaoChars);
            this.quantidadeTurnos = quantidadeTurnos;
            this.quantidadePessoas = quantidadePessoas;
        }
    }

}
