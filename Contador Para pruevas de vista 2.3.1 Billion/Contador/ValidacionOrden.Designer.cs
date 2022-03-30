namespace Contador
{
    partial class ValidacionOrden
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
            this.BarrraTitulo = new System.Windows.Forms.Panel();
            this.CmbMarca = new System.Windows.Forms.TextBox();
            this.CmbNumPar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbNumPar2 = new System.Windows.Forms.TextBox();
            this.CmbMarca2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PIDLH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PIDRH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStart)).BeginInit();
            this.SuspendLayout();
            // 
            // BarrraTitulo
            // 
            this.BarrraTitulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BarrraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.BarrraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarrraTitulo.Name = "BarrraTitulo";
            this.BarrraTitulo.Size = new System.Drawing.Size(670, 40);
            this.BarrraTitulo.TabIndex = 9;
            this.BarrraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.BarrraTitulo_Paint);
            this.BarrraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarrraTitulo_MouseDown);
            // 
            // CmbMarca
            // 
            this.CmbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMarca.Location = new System.Drawing.Point(87, 126);
            this.CmbMarca.Name = "CmbMarca";
            this.CmbMarca.Size = new System.Drawing.Size(181, 26);
            this.CmbMarca.TabIndex = 10;
            this.CmbMarca.TextChanged += new System.EventHandler(this.CmbMarca_TextChanged);
            this.CmbMarca.DoubleClick += new System.EventHandler(this.CmbMarca_DoubleClick);
            // 
            // CmbNumPar
            // 
            this.CmbNumPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CmbNumPar.Location = new System.Drawing.Point(86, 222);
            this.CmbNumPar.Name = "CmbNumPar";
            this.CmbNumPar.Size = new System.Drawing.Size(181, 26);
            this.CmbNumPar.TabIndex = 11;
            this.CmbNumPar.TextChanged += new System.EventHandler(this.CmbNumPar_TextChanged);
            this.CmbNumPar.DoubleClick += new System.EventHandler(this.CmbNumPar_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(43, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Numero de Orden RH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(55, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Numero de parte RH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "..";
            this.label3.TextChanged += new System.EventHandler(this.label3_TextChanged);
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "..";
            this.label4.TextChanged += new System.EventHandler(this.label4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(175, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "El numero de parte es incorrecto";
            this.label5.Visible = false;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnStart.BackgroundImage = global::Contador.Properties.Resources.boton4;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStart.Location = new System.Drawing.Point(207, 392);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(199, 79);
            this.BtnStart.TabIndex = 30;
            this.BtnStart.TabStop = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnComezar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Location = new System.Drawing.Point(660, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 450);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel2.Location = new System.Drawing.Point(-6, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 447);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel3.Location = new System.Drawing.Point(0, 477);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 10);
            this.panel3.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(342, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 29);
            this.label7.TabIndex = 37;
            this.label7.Text = "Numero de parte LH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(343, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 29);
            this.label8.TabIndex = 36;
            this.label8.Text = "Numero de Orden LH";
            // 
            // CmbNumPar2
            // 
            this.CmbNumPar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CmbNumPar2.Location = new System.Drawing.Point(346, 222);
            this.CmbNumPar2.Name = "CmbNumPar2";
            this.CmbNumPar2.Size = new System.Drawing.Size(181, 26);
            this.CmbNumPar2.TabIndex = 35;
            this.CmbNumPar2.TextChanged += new System.EventHandler(this.CmbNumPar2_TextChanged);
            this.CmbNumPar2.DoubleClick += new System.EventHandler(this.CmbNumPar2_DoubleClick);
            // 
            // CmbMarca2
            // 
            this.CmbMarca2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMarca2.Location = new System.Drawing.Point(347, 126);
            this.CmbMarca2.Name = "CmbMarca2";
            this.CmbMarca2.Size = new System.Drawing.Size(181, 26);
            this.CmbMarca2.TabIndex = 34;
            this.CmbMarca2.TextChanged += new System.EventHandler(this.CmbMarca2_TextChanged);
            this.CmbMarca2.DoubleClick += new System.EventHandler(this.CmbMarca2_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(571, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "..";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(571, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "..";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(389, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 29);
            this.label6.TabIndex = 44;
            this.label6.Text = "PID LH";
            // 
            // PIDLH
            // 
            this.PIDLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.PIDLH.Location = new System.Drawing.Point(346, 307);
            this.PIDLH.Name = "PIDLH";
            this.PIDLH.Size = new System.Drawing.Size(181, 26);
            this.PIDLH.TabIndex = 43;
            this.PIDLH.TextChanged += new System.EventHandler(this.PIDLH_TextChanged);
            this.PIDLH.DoubleClick += new System.EventHandler(this.PIDLH_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(129, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 29);
            this.label11.TabIndex = 42;
            this.label11.Text = "PID RH";
            // 
            // PIDRH
            // 
            this.PIDRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.PIDRH.Location = new System.Drawing.Point(86, 307);
            this.PIDRH.Name = "PIDRH";
            this.PIDRH.Size = new System.Drawing.Size(181, 26);
            this.PIDRH.TabIndex = 41;
            this.PIDRH.TextChanged += new System.EventHandler(this.PIDRH_TextChanged);
            this.PIDRH.DoubleClick += new System.EventHandler(this.PIDRH_DoubleClick);
            // 
            // ValidacionOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(669, 485);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PIDLH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PIDRH);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbNumPar2);
            this.Controls.Add(this.CmbMarca2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbNumPar);
            this.Controls.Add(this.CmbMarca);
            this.Controls.Add(this.BarrraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValidacionOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValidacionOrden";
            this.Load += new System.EventHandler(this.ValidacionOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BarrraTitulo;
        private System.Windows.Forms.TextBox CmbMarca;
        private System.Windows.Forms.TextBox CmbNumPar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox BtnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CmbNumPar2;
        private System.Windows.Forms.TextBox CmbMarca2;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PIDLH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PIDRH;
    }
}