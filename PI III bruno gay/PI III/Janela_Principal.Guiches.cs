namespace PI_III
{
    partial class Janela_Principal
    {
        private System.Windows.Forms.Button guiches;
        private VerticalProgressBar verticalProgressBar1;

        private void CriarGuiches()
        {
            int quantidade = 20;

            for (int i = 0; i < quantidade; i++)
            {
                // 
                // button
                // 
                this.guiches = new System.Windows.Forms.Button();
                this.guiches.Location = new System.Drawing.Point(i*(150-quantidade*3)+10, 550);
                this.guiches.Size = new System.Drawing.Size(100-(quantidade*3), 100-(quantidade*3));
                this.guiches.Click += new System.EventHandler(this.Clique_Guiche);

                if (i == 0)   this.guiches.Text = "A";
                if (i == 1)   this.guiches.Text = "B";
                if (i == 2)   this.guiches.Text = "C";
                if (i == 3)   this.guiches.Text = "D";
                if (i == 4)   this.guiches.Text = "E";
                if (i == 5)   this.guiches.Text = "F";
                if (i == 6)   this.guiches.Text = "G";
                if (i == 7)   this.guiches.Text = "H";
                if (i == 8)   this.guiches.Text = "I";
                if (i == 9)   this.guiches.Text = "J";
                if (i == 10)  this.guiches.Text = "K";
                if (i == 11)  this.guiches.Text = "L";

                this.verticalProgressBar1 = new VerticalProgressBar();
                this.SuspendLayout();

                this.verticalProgressBar1.BackColor = System.Drawing.SystemColors.Window;
                this.verticalProgressBar1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                this.verticalProgressBar1.Location = new System.Drawing.Point(i * (150 - quantidade * 3) + (45 - 3*quantidade), 380);
                this.verticalProgressBar1.Name = "verticalProgressBar1";
                this.verticalProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                this.verticalProgressBar1.RightToLeftLayout = true;
                this.verticalProgressBar1.Size = new System.Drawing.Size(18, 163);
                this.verticalProgressBar1.TabIndex = 2;
                this.verticalProgressBar1.Value = 30;

                // 
                // Janela Principal
                // 
                this.Controls.Add(this.guiches);
                this.Controls.Add(this.verticalProgressBar1);
                this.ResumeLayout(false);
            }
        }
    }
}