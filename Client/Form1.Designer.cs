
namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDB = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "1 Указываем строку подключения к базе данных";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(552, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Server=(localdb)\\MSSQLLocalDB;Database=AdressForLabWork;Trusted_Connection=true;";
            // 
            // buttonDB
            // 
            this.buttonDB.Location = new System.Drawing.Point(611, 31);
            this.buttonDB.Name = "buttonDB";
            this.buttonDB.Size = new System.Drawing.Size(129, 23);
            this.buttonDB.TabIndex = 2;
            this.buttonDB.Text = "Развернуть базу данных";
            this.buttonDB.UseVisualStyleBackColor = true;
            this.buttonDB.Click += new System.EventHandler(this.buttonDB_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 252);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(552, 109);
            this.textBox2.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(28, 86);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(552, 94);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Список индексов.Выберите индекс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Список адрессов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonDB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDB;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

