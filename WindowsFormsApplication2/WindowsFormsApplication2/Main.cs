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

namespace WindowsFormsApplication2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;//cria uma string que recebe as linhas
            string[] setup;//declara o vetor de setup
            char[] ra;
            setup = new string[9];//declara que setup terá 9 posições
            ra = new char[20];

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\fernando.asilva10\Desktop\WindowsFormsApplication2\setup\Setup.txt");//busca o arquivo de texto
            while ((line = file.ReadLine()) != null)//laço que le linha por linha
            {
                setup[counter] = line;//setup recebe a linha lida no arquivo de Setup
                if (counter == 0)//este if serve para ver os atendentes da primeira linha
                {
                    int atendentes = Convert.ToInt32(line);//converte a string em int
                    textBox1.Text = atendentes.ToString();

                }
                else if (counter == 1)
                {
                    int cont = line.Length;

                    switch (cont - 3)
                    {
                        case 1:
                            checkBox1.Checked = true;
                            checkBox1.Visible = true;
                            break;
                        case 2:
                            checkBox2.Checked = true;
                            checkBox2.Visible = true;
                            break;
                        case 3:
                            checkBox3.Checked = true;
                            checkBox2.Visible = true;
                            break;
                        case 4:
                            checkBox6.Checked = true;
                            checkBox6.Visible = true;
                            break;
                        case 5:
                            checkBox5.Checked = true;
                            checkBox5.Visible = true;
                            break;
                        case 6:
                            checkBox4.Checked = true;
                            checkBox4.Visible = true;
                            break;
                        case 7:
                            checkBox12.Checked = true;
                            checkBox12.Visible = true;
                            break;
                        case 8:
                            checkBox11.Checked = true;
                            checkBox11.Visible = true;
                            break;
                        case 9:
                            checkBox10.Checked = true;
                            checkBox10.Visible = true;
                            break;
                        case 10:
                            checkBox9.Checked = true;
                            checkBox9.Visible = true;
                            break;
                        case 11:
                            checkBox8.Checked = true;
                            checkBox8.Visible = true;
                            break;
                        case 12:
                            checkBox7.Checked = true;
                            checkBox7.Visible = true;
                            break;
                        case 13:
                            checkBox18.Checked = true;
                            checkBox18.Visible = true;
                            break;
                        case 14:
                            checkBox17.Checked = true;
                            checkBox17.Visible = true;
                            break;
                        case 15:
                            checkBox16.Checked = true;
                            checkBox16.Visible = true;
                            break;
                        case 16:
                            checkBox15.Checked = true;
                            checkBox15.Visible = true;
                            break;
                        case 17:
                            checkBox14.Checked = true;
                            checkBox14.Visible = true;
                            break;
                        case 18:
                            checkBox13.Checked = true;
                            checkBox13.Visible = true;
                            break;
                        case 19:
                            checkBox24.Checked = true;
                            checkBox24.Visible = true;
                            break;
                        case 20:
                            checkBox23.Checked = true;
                            checkBox23.Visible = true;
                            break;
                    }
                    cont -= 3;
                    textBox2.Text = cont.ToString();
                }
                else if(counter == 2)
                {
                    var chars = line.ToCharArray();
                    for(int i=0;i<23;i++)
                    {
                        if (i > 2)
                        {
                            ra[i - 3] = chars[i];
                        }
                    }
                }
                    
                //MessageBox.Show(setup[counter]);//demonstra em message box as linhas lidas
                counter++;//aumenta o contador para ler e armazenar novas linhas até o fim do arquivo(!=null)
            }

            file.Close();//fecha o txt
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
