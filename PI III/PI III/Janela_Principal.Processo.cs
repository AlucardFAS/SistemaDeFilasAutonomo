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
        void processo(Queue<Pessoas>[] fila, String pathFila, GuichesSetup[] guiches, double tempo)
        {
            int turno = 1;

            int guichesDiferentes = GuichesSetup.getGuichesDiferentes(guiches);

            List<EstatisticaComb> estatisticaPorGuiches = new List<EstatisticaComb>();
            Estatistica estatistica = new Estatistica(guichesDiferentes);
            

            GuichesSetup.resetGuiches(guiches, atendentesIniciais);
            
            System.IO.StreamReader arquivo = new System.IO.StreamReader(pathFila);  //carrega a fila
            String linha = arquivo.ReadLine();  //inicializa lendo a linha
            linha += ';';   //já adiciona o . no final da linha

            Boolean continuar = true;
            

            //esse laço vai até entrar todas as pessoas nas filas
            while (continuar)
            {
                //lê as pessoas da fila e joga elas na fila do guiche A
                lerFila(fila[0], turno, ref linha, arquivo, ref continuar);

                //essa função atualiza se o tempo de troca de um atendente que vai de um guiche a outro já passou
                atualizarTempoTroca(guiches);

                //jogando as primeiras pessoas das filas nos guiches
                atualizarFilas(guiches, fila, estatistica, turno);

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                atualizarGuiches(guiches, fila, estatistica, estatisticaPorGuiches, turno);

                //Verificando se vale a pena fazer trocas
                if (troca != 0) realizarTrocas(guiches, fila);

                //jogando as primeiras pessoas das filas nos guiches
                atualizarFilas(guiches, fila, estatistica, turno);

                //atualizando as barras de progresso
                atualizarBarrasProgresso();

                //atualizando a cor dos botões
                atualizarCorBotoes(guiches);

                //Atualizando o label que conta os turnos
                textoTurno.Text = "Turno: " + turno;

                Application.DoEvents();

                turno = contarTurnos(tempo, turno);
            }

            //Atualizando o label que conta os turnos
            textoTurno.Text = "Turno: " + turno;

            for (int k = 0; k < textoFila.Length; k++)
                if (textoFila[k] != null) textoFila[k].Text = ""+fila[k].Count;
            
           // Refresh();

            //esse laço vai até esvaziar todos os guiches, assim, terminando
            continuar = true;
            while (continuar)
            {

                //essa função atualiza se o tempo de troca de um atendente que vai de um guiche a outro já passou
                atualizarTempoTroca(guiches);

                //jogando as primeiras pessoas das filas nos guiches
                atualizarFilas(guiches, fila, estatistica, turno);

                //atualizando os guiches e jogando as pessoas pras respectivas filas
                atualizarGuiches(guiches, fila, estatistica, estatisticaPorGuiches, turno);

                //Verificando se vale a pena fazer trocas
                if (troca != 0) realizarTrocas(guiches, fila);

                //jogando as primeiras pessoas das filas nos guiches
                atualizarFilas(guiches, fila, estatistica, turno);

                //atualizando as barras de progresso
                atualizarBarrasProgresso();

                //atualizando a cor dos botões
                atualizarCorBotoes(guiches);

                //testando se todos os guiches estão vazios, se algum não estiver vazio, então continuar se torna verdade
                continuar = false;
                for (int j = 0; j < guiches.Length; j++) if (guiches[j].vazio == false) continuar = true;
                

                if (continuar == false && troca != 0) continuar = condicaoEspecial(guiches, fila);

                //Atualizando o label que conta os turnos
                textoTurno.Text = "Turno: " + turno;
                textoTurno.Refresh();
               // Refresh();

                Application.DoEvents();

                turno = contarTurnos(tempo, turno);
            }
            MessageBox.Show("Turno terminado: " + (turno-1));
            mostrarEstatisticas(estatistica, estatisticaPorGuiches);
        }
        void lerFila(Queue<Pessoas> fila, int turno, ref string linha, System.IO.StreamReader arquivo, ref Boolean continuar) {
            string dadoString = "";

            int i = 1;
            int usuario = -1;
            int chegada = -1;
            string guichesPessoa;

            char[] percorredor = linha.ToCharArray();

            while (true)
            {
                Pessoas pessoa = new Pessoas();

                if (percorredor[i] == 'C'){ //se o percorredor for C, então o dado anterior é da variável usuario, e assim seta usuario, limpa dadoString e continua
                    if (!Int32.TryParse(dadoString, out usuario)) MessageBox.Show("Deu ruim na hora de converter pra int");
                    dadoString = "";
                    i++;
                }

                else if (percorredor[i] == 'A')
                { //se o percorredor for A, então o dado anterior é da variável chegada, e assim seta chegada, limpa dadoString e continua
                    if (!Int32.TryParse(dadoString, out chegada)) MessageBox.Show("Deu ruim na hora de converter pra int");
                    dadoString = "";

                    if (chegada != turno){  //verifica se a pessoa que está sendo lida é do turno atual, se sim, continua o processo, se não, retorna
                        i = 1;
                        continuar = true;
                        return;
                    }

                    while (percorredor[i] != ';'){  //lê os guiches da pessoa até ;(final da linha)
                        dadoString += percorredor[i];
                        i++;
                    }

                    guichesPessoa = dadoString;
                    pessoa.setPessoa(usuario, chegada, guichesPessoa);  //seta a pessoa de acordo com a informação obtida

                    fila.Enqueue(pessoa);   //joga a pessoa na fila do guiche A

                    if ((linha = arquivo.ReadLine()) == null)   //quando acabar o txt de filas continuar vai ser false e logo o 1º looping principal acabará
                    {
                        continuar = false;
                        return;
                    }
                    dadoString = "";
                    linha += ';';
                    i = 1;

                    percorredor = linha.ToCharArray();  //transformando o percorredor em nova linha
                }

                dadoString += percorredor[i];   //caso o percorredor não esteja nem em C nem em A, então o percorredor está em algum dado
                i++;
            }
        
        }
        void atualizarGuiches(GuichesSetup[] guiches, Queue<Pessoas>[] fila, Estatistica estatistica, List<EstatisticaComb> estatisticaPorGuiches, int turno)
        {
            int quantidadeGuiches = guiches.Length;
            char proximoGuiche;

            for (int i = 0; i < guiches.Length; i++)
            {

                if (guiches[i].vazio == false && guiches[i].ultimoTurno < guiches[i].turnosNecessarios)
                {
                    guiches[i].ultimoTurno++;
                }
                else if (guiches[i].vazio == false && guiches[i].ultimoTurno >= guiches[i].turnosNecessarios)
                {
                    guiches[i].vazio = true;
                    guiches[i].ultimoTurno = 1;
                    guiches[i].pessoaDentro.atualGuiche++;

                    //testando se a pessoa ainda tem guiches pra ir, se não, ela cai no esquecimento e segue o jogo
                    if (guiches[i].pessoaDentro.atualGuiche >= guiches[i].pessoaDentro.guiches.Length)
                    {
                        estatistica.tempoTotalUsuarios += turno - guiches[i].pessoaDentro.chegada;
                        estatistica.quantidadeUsuarios++;

                        //testando se é o maior tempo dentre os usuários
                        if(turno - guiches[i].pessoaDentro.chegada > estatistica.maiorTempo){
                            estatistica.usuarioMaiorTempo = guiches[i].pessoaDentro.usuario;
                            estatistica.maiorTempo = turno - guiches[i].pessoaDentro.chegada;
                        }
                        //adicionando a estatistica por combinação
                        EstatisticaComb estatisticaComb = new EstatisticaComb();
                        
                        estatisticaComb.setEstatisticaComb(guiches[i].pessoaDentro.guiches, turno - guiches[i].pessoaDentro.chegada, 1);

                        string aux = new string(guiches[i].pessoaDentro.guiches);
                        EstatisticaComb resultado = estatisticaPorGuiches.Find(x => x.combinacao == aux);

                        if (resultado != null) {
                            resultado.quantidadePessoas++;
                            resultado.quantidadeTurnos += turno - guiches[i].pessoaDentro.chegada;
                        }
                        else estatisticaPorGuiches.Add(estatisticaComb);

                        return;
                    }
                    //verificando o proximo guiche que ela tem que ir
                    proximoGuiche = guiches[i].pessoaDentro.guiches[guiches[i].pessoaDentro.atualGuiche];

                    //achando o guiche que a pessoa tem de ir
                    int j = 0;
                    while (guiches[j].guiche != proximoGuiche) j++;

                    //enviando a pessoa para a fila
                    fila[j].Enqueue(guiches[i].pessoaDentro);
                    guiches[i].pessoaDentro.entradaFila = turno;

                }
            }
        }
        void atualizarFilas(GuichesSetup[] guiches, Queue<Pessoas>[] fila, Estatistica estatistica , int turno){
            for (int j = 0; j < guiches.Length; j++)
            {
                for (int k = 0; k < guiches[j].guichesIguais; k++)
                {
                    if (guiches[j + k].atendente == true && guiches[j + k].vazio == true && fila[j].Count != 0)
                    {
                        entrarGuiches(fila[j].Dequeue(), guiches[j + k]);
                        

                        estatistica.guicheTempoFila[guiches[j+k].guiche - 'A'] += turno - guiches[j + k].pessoaDentro.entradaFila;
                        estatistica.quantidadePessoasFila[guiches[j+k].guiche - 'A']++;
                        
                    }
                }
                j += guiches[j].guichesIguais - 1;
            }
        }
        void atualizarBarrasProgresso() {
            //atualizando barras de progresso verticais
            for (int j = 0; j < verticalProgressBar.Length; j++)
            {
                if (verticalProgressBar[j] != null)
                {
                    if (fila[j].Count > verticalProgressBar[j].Maximum) verticalProgressBar[j].Maximum *= 10;
                    else if (fila[j].Count != 0 && fila[j].Count < verticalProgressBar[j].Maximum / 10) verticalProgressBar[j].Maximum /= 10;

                    verticalProgressBar[j].Value = fila[j].Count;
                }

                //atualizando a label que conta quantas pessoas tem na fila em cima da barra de progresso
                if (textoFila[j] != null) textoFila[j].Text = "" + fila[j].Count;
            }
            //atualizando barras de progresso verticais
            for (int j = 0; j < verticalProgressBar.Length; j++)
            {
                if (verticalProgressBar[j] != null)
                {
                    if (fila[j].Count > verticalProgressBar[j].Maximum) verticalProgressBar[j].Maximum *= 10;
                    else if (fila[j].Count != 0 && fila[j].Count < verticalProgressBar[j].Maximum / 10) verticalProgressBar[j].Maximum /= 10;

                    verticalProgressBar[j].Value = fila[j].Count;
                }

                //atualizando a label que conta quantas pessoas tem na fila em cima da barra de progresso
                if (textoFila[j] != null) textoFila[j].Text = "" + fila[j].Count;
            }

            //atualizando barras de progresso horizontais
            for (int i = 0; i < progressBar.Length; i++)
            {
                if (progressBar[i] != null)
                {
                    if (fila[i + 15].Count > progressBar[i].Maximum) progressBar[i].Maximum *= 10;
                    else if (fila[i + 15].Count != 0 && fila[i + 15].Count < progressBar[i].Maximum / 10) progressBar[i].Maximum /= 10;

                    progressBar[i].Value = fila[i + 15].Count;
                }
                if (textoFila[i + 15] != null) textoFila[i + 15].Text = "" + fila[i + 15].Count;
            }

          

        }
        void atualizarTempoTroca(GuichesSetup[] guiches)
        {
            for (int i = 0; i < guiches.Length; i++)
                if (guiches[i].chegadaAtendente != 0)   //verificando se tem algum atendente indo a esse guiche
                    if (guiches[i].chegadaAtendente >= troca)   //verificando se já deu o tempo de troca
                    {
                        guiches[i].atendente = true;
                        guiches[i].chegadaAtendente = 0;
                    }
                    else guiches[i].chegadaAtendente++; //caso ainda não deu o tempo de troca, somente incrementa o tempo e segue o jogo
        }
        void atualizarCorBotoes(GuichesSetup[] guiches){

        

            for (int j = 0; j < guiches.Length; j++)
            {   if (guiches[j].chegadaAtendente != 0) {
                    guichesBotao[j].BackgroundImage = Properties.Resources.TrocaChegando;
                    guichesBotao[j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (guiches[j].vazio == false)
                {
                    guichesBotao[j].BackgroundImage = Properties.Resources.atendenteAtendendo;
                    guichesBotao[j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (guiches[j].atendente == true)
                {
                    guichesBotao[j].BackgroundImage = Properties.Resources.atendenteAlone;
                    guichesBotao[j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    guichesBotao[j].BackgroundImage = Properties.Resources.vazio;
                    guichesBotao[j].BackgroundImageLayout = ImageLayout.Stretch;
                }

            }
        }
        void mostrarEstatisticas(Estatistica estatistica, List<EstatisticaComb> estatisticaPorGuiches) {

            /*
            MessageBox.Show("tempoTotalUsuarios: " + estatistica.tempoTotalUsuarios + "\n" +
                                        "quantidadeUsuarios: " + estatistica.quantidadeUsuarios + "\n" +
                                        "médiaTempoTotalUsuarios " + estatistica.tempoTotalUsuarios / estatistica.quantidadeUsuarios);


            MessageBox.Show("usuarioMaiorTempo: " + estatistica.usuarioMaiorTempo + "\n" +
                            "maiorTempo: " + estatistica.maiorTempo);

            int k = 0;
            for (int i = 0; i < estatistica.guicheTempoFila.Length; i++)
            {
                MessageBox.Show("tempofilamedio da fila do guiche " + (guiches[k].guiche) + " : " + estatistica.guicheTempoFila[i] / estatistica.quantidadePessoasFila[i]);
                k += guiches[k].guichesIguais;
            }
            for(int i = 0; i<estatisticaPorGuiches.Count; i++)
                MessageBox.Show("Tempo médio da combinação "+estatisticaPorGuiches[i].combinacao+": "+estatisticaPorGuiches[i].quantidadeTurnos / estatisticaPorGuiches[i].quantidadePessoas);
            //Mostrando estatísticas por combinação de guiche
            //foreach()
            */
            Estatisticas janelaEstatistica = new Estatisticas(estatistica, estatisticaPorGuiches, guiches);
            janelaEstatistica.ShowDialog();
        }
        int contarTurnos(double tempo, int turno)
        {
            sleep(tempo);
            turno++;
            // MessageBox.Show("turno: "+turno);
            return turno;
        }
    }
}
