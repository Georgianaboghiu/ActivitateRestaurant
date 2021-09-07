namespace Boghiu_Georgiana
{
    partial class NotaDePlata
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
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.cmbAperitive = new System.Windows.Forms.ComboBox();
            this.cmbFeluriPrincipale = new System.Windows.Forms.ComboBox();
            this.cmbDesert = new System.Windows.Forms.ComboBox();
            this.cmbBauturi = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstOutput
            // 
            this.lstOutput.AllowDrop = true;
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 16;
            this.lstOutput.Location = new System.Drawing.Point(455, 114);
            this.lstOutput.Margin = new System.Windows.Forms.Padding(4);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstOutput.Size = new System.Drawing.Size(254, 276);
            this.lstOutput.TabIndex = 27;
            // 
            // cmbAperitive
            // 
            this.cmbAperitive.FormattingEnabled = true;
            this.cmbAperitive.Items.AddRange(new object[] {
            "Platou branzeturi -40.00",
            "Platou salam -35.00",
            "Bruschete -25.00",
            "Legume la cuptor -25.00",
            "Nachos -25.50",
            "Midii -30.00"});
            this.cmbAperitive.Location = new System.Drawing.Point(43, 55);
            this.cmbAperitive.Name = "cmbAperitive";
            this.cmbAperitive.Size = new System.Drawing.Size(121, 24);
            this.cmbAperitive.TabIndex = 28;
            this.cmbAperitive.Text = "       Aperitive";
            this.cmbAperitive.SelectedIndexChanged += new System.EventHandler(this.cmbAperitive_SelectedIndexChanged);
            // 
            // cmbFeluriPrincipale
            // 
            this.cmbFeluriPrincipale.FormattingEnabled = true;
            this.cmbFeluriPrincipale.Items.AddRange(new object[] {
            "Friptura de vita -30.50",
            "Paste Carbonara -35.00",
            "Pizza Quatro Formaggi -30.00",
            "Supa de legume -15.00",
            "Fructe de mare -40.00",
            "Salata -25.00"});
            this.cmbFeluriPrincipale.Location = new System.Drawing.Point(43, 173);
            this.cmbFeluriPrincipale.Name = "cmbFeluriPrincipale";
            this.cmbFeluriPrincipale.Size = new System.Drawing.Size(149, 24);
            this.cmbFeluriPrincipale.TabIndex = 29;
            this.cmbFeluriPrincipale.Text = "       Feluri Principale";
            this.cmbFeluriPrincipale.SelectedIndexChanged += new System.EventHandler(this.cmbFeluriPrincipale_SelectedIndexChanged);
            // 
            // cmbDesert
            // 
            this.cmbDesert.FormattingEnabled = true;
            this.cmbDesert.Items.AddRange(new object[] {
            "Placinta cu mere -10.50",
            "Tiramisu -15.00",
            "Placinta cu branza -10.50",
            "Tort cu ciocolata -15.00",
            "Tarta -14.50"});
            this.cmbDesert.Location = new System.Drawing.Point(43, 303);
            this.cmbDesert.Name = "cmbDesert";
            this.cmbDesert.Size = new System.Drawing.Size(149, 24);
            this.cmbDesert.TabIndex = 30;
            this.cmbDesert.Text = "       Desert";
            this.cmbDesert.SelectedIndexChanged += new System.EventHandler(this.cmbDesert_SelectedIndexChanged);
            // 
            // cmbBauturi
            // 
            this.cmbBauturi.FormattingEnabled = true;
            this.cmbBauturi.Items.AddRange(new object[] {
            "Apa Minerala -4.00 ",
            "Apa Plata -4.00",
            "Cola -5.00",
            "Cafea -6.00",
            "Suc de fructe -6.00",
            "Ceai -6.00"});
            this.cmbBauturi.Location = new System.Drawing.Point(43, 456);
            this.cmbBauturi.Name = "cmbBauturi";
            this.cmbBauturi.Size = new System.Drawing.Size(149, 24);
            this.cmbBauturi.TabIndex = 31;
            this.cmbBauturi.Text = "       Bauturi";
            this.cmbBauturi.SelectedIndexChanged += new System.EventHandler(this.cmbBauturi_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(473, 486);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Nota finala";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Suma incasata";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(803, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 34);
            this.button2.TabIndex = 35;
            this.button2.Text = "Print preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(832, 114);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(303, 332);
            this.textBox2.TabIndex = 36;
            // 
            // NotaDePlata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 604);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbBauturi);
            this.Controls.Add(this.cmbDesert);
            this.Controls.Add(this.cmbFeluriPrincipale);
            this.Controls.Add(this.cmbAperitive);
            this.Controls.Add(this.lstOutput);
            this.Name = "NotaDePlata";
            this.Text = "NotaDePlata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.ComboBox cmbAperitive;
        private System.Windows.Forms.ComboBox cmbFeluriPrincipale;
        private System.Windows.Forms.ComboBox cmbDesert;
        private System.Windows.Forms.ComboBox cmbBauturi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textBox2;
    }
}