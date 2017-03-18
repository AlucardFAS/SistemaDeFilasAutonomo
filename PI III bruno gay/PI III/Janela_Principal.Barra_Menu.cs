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

        private void barraMenu()
        {
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
    }
}