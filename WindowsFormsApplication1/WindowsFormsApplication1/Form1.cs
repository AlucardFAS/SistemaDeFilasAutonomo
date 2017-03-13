using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // if (textBox1.Text == "")
            //{
            //  MessageBox.Show("Fernando sua bixona do caraio!");
            //}
            if(textBox1.Text == "2"){
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                }
            if (textBox1.Text == "1")
            {
                checkBox1.Visible = true;
            }
            
            else
            {
                MessageBox.Show("Deu certo!\nUh uh uh");
                checkBox1.Checked = true;
                // Form1.ActiveForm.BackColor= Color.Cyan;
                this.BackColor = Color.Cyan;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
