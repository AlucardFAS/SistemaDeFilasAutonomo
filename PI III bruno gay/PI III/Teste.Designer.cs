namespace PI_III
{
    partial class Teste
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.verticalProgressBar1 = new VerticalProgressBar();
            this.SuspendLayout();
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.verticalProgressBar1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.verticalProgressBar1.Location = new System.Drawing.Point(128, 97);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.verticalProgressBar1.RightToLeftLayout = true;
            this.verticalProgressBar1.Size = new System.Drawing.Size(18, 163);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 30;
            // 
            // Teste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.verticalProgressBar1);
            this.Name = "Teste";
            this.Text = "Teste";
            this.ResumeLayout(false);

        }

        #endregion

        private VerticalProgressBar verticalProgressBar1;





    }
}