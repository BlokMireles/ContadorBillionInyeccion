namespace Contador
{
    partial class Alerta1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnStart = new System.Windows.Forms.PictureBox();
            this.lblcharola = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblcontadorcaja = new System.Windows.Forms.Label();
            this.lblcontadorcaja2 = new System.Windows.Forms.Label();
            this.lblcharola2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caja RH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "¡Completa!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Contador.Properties.Resources.alerta;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 169);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnStart.BackgroundImage = global::Contador.Properties.Resources.boton5;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStart.Location = new System.Drawing.Point(254, 190);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(199, 79);
            this.BtnStart.TabIndex = 31;
            this.BtnStart.TabStop = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblcharola
            // 
            this.lblcharola.AutoSize = true;
            this.lblcharola.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblcharola.Location = new System.Drawing.Point(518, 9);
            this.lblcharola.Name = "lblcharola";
            this.lblcharola.Size = new System.Drawing.Size(32, 33);
            this.lblcharola.TabIndex = 33;
            this.lblcharola.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblcontadorcaja
            // 
            this.lblcontadorcaja.AutoSize = true;
            this.lblcontadorcaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblcontadorcaja.Location = new System.Drawing.Point(405, 76);
            this.lblcontadorcaja.Name = "lblcontadorcaja";
            this.lblcontadorcaja.Size = new System.Drawing.Size(32, 33);
            this.lblcontadorcaja.TabIndex = 34;
            this.lblcontadorcaja.Text = "0";
            // 
            // lblcontadorcaja2
            // 
            this.lblcontadorcaja2.AutoSize = true;
            this.lblcontadorcaja2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblcontadorcaja2.Location = new System.Drawing.Point(405, 24);
            this.lblcontadorcaja2.Name = "lblcontadorcaja2";
            this.lblcontadorcaja2.Size = new System.Drawing.Size(32, 33);
            this.lblcontadorcaja2.TabIndex = 36;
            this.lblcontadorcaja2.Text = "0";
            // 
            // lblcharola2
            // 
            this.lblcharola2.AutoSize = true;
            this.lblcharola2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblcharola2.Location = new System.Drawing.Point(518, 42);
            this.lblcharola2.Name = "lblcharola2";
            this.lblcharola2.Size = new System.Drawing.Size(32, 33);
            this.lblcharola2.TabIndex = 35;
            this.lblcharola2.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(260, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 33);
            this.label5.TabIndex = 37;
            this.label5.Text = "Caja LH";
            // 
            // Alerta1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(562, 299);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblcontadorcaja2);
            this.Controls.Add(this.lblcharola2);
            this.Controls.Add(this.lblcontadorcaja);
            this.Controls.Add(this.lblcharola);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alerta1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alerta1";
            this.Load += new System.EventHandler(this.Alerta1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BtnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblcharola;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblcontadorcaja;
        public System.Windows.Forms.Label lblcontadorcaja2;
        public System.Windows.Forms.Label lblcharola2;
        private System.Windows.Forms.Label label5;
    }
}