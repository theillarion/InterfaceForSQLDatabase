namespace WinFormsApp2
{
    partial class Connection
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonSetTable = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(121, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect to SQL database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connection string: ";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(148, 75);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(235, 23);
            this.textBoxConnectionString.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(148, 117);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(146, 30);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Check the connection";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tables:";
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(79, 173);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(103, 23);
            this.comboBoxTables.TabIndex = 5;
            // 
            // buttonSetTable
            // 
            this.buttonSetTable.Location = new System.Drawing.Point(206, 167);
            this.buttonSetTable.Name = "buttonSetTable";
            this.buttonSetTable.Size = new System.Drawing.Size(88, 33);
            this.buttonSetTable.TabIndex = 6;
            this.buttonSetTable.Text = "Set table";
            this.buttonSetTable.UseVisualStyleBackColor = true;
            this.buttonSetTable.Click += new System.EventHandler(this.buttonSetTable_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.toolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.mainToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemHelp.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAbout.Text = "About the program";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 218);
            this.Controls.Add(this.buttonSetTable);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Connection";
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connection_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxConnectionString;
        private Button buttonConnect;
        private Label label3;
        private ComboBox comboBoxTables;
        private Button buttonSetTable;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemExit;
        private ToolStripMenuItem toolStripMenuItemHelp;
        private ToolStripMenuItem toolStripMenuItemAbout;
    }
}