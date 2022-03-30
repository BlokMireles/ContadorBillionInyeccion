
namespace Contador
{
    partial class TpOrdenes
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
            this.BarrraTitulo = new System.Windows.Forms.Panel();
            this.BtnRestaurar = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.BtnMax = new System.Windows.Forms.PictureBox();
            this.BtnMinimizar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbMarca = new System.Windows.Forms.TextBox();
            this.CmbNumPar = new System.Windows.Forms.TextBox();
            this.CmbMaquina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnOrparcial = new System.Windows.Forms.PictureBox();
            this.BtnNueOrd = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CmbNumPar2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPzAll = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPzAll2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbOpc = new System.Windows.Forms.ComboBox();
            this.lblempaque = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbMarca2 = new System.Windows.Forms.TextBox();
            this.TxtPID2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtPID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BarrraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnOrparcial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNueOrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(409, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estacion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BarrraTitulo
            // 
            this.BarrraTitulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BarrraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.BarrraTitulo.Controls.Add(this.BtnRestaurar);
            this.BarrraTitulo.Controls.Add(this.BtnClose);
            this.BarrraTitulo.Controls.Add(this.BtnMax);
            this.BarrraTitulo.Controls.Add(this.BtnMinimizar);
            this.BarrraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarrraTitulo.Name = "BarrraTitulo";
            this.BarrraTitulo.Size = new System.Drawing.Size(1052, 40);
            this.BarrraTitulo.TabIndex = 6;
            this.BarrraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.BarrraTitulo_Paint);
            this.BarrraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarrraTitulo_MouseDown);
            // 
            // BtnRestaurar
            // 
            this.BtnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRestaurar.BackColor = System.Drawing.Color.White;
            this.BtnRestaurar.BackgroundImage = global::Contador.Properties.Resources.icons8_restaurar_ventana_50;
            this.BtnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRestaurar.Location = new System.Drawing.Point(952, 3);
            this.BtnRestaurar.Name = "BtnRestaurar";
            this.BtnRestaurar.Size = new System.Drawing.Size(32, 34);
            this.BtnRestaurar.TabIndex = 10;
            this.BtnRestaurar.TabStop = false;
            this.BtnRestaurar.Visible = false;
            this.BtnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.White;
            this.BtnClose.BackgroundImage = global::Contador.Properties.Resources.icons8_cerrar_ventana_50;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnClose.Location = new System.Drawing.Point(1008, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(32, 34);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnMax
            // 
            this.BtnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMax.BackColor = System.Drawing.Color.White;
            this.BtnMax.BackgroundImage = global::Contador.Properties.Resources.icons8_maximizar_la_ventana_50;
            this.BtnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMax.Location = new System.Drawing.Point(952, 3);
            this.BtnMax.Name = "BtnMax";
            this.BtnMax.Size = new System.Drawing.Size(32, 34);
            this.BtnMax.TabIndex = 8;
            this.BtnMax.TabStop = false;
            this.BtnMax.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimizar.BackColor = System.Drawing.Color.White;
            this.BtnMinimizar.BackgroundImage = global::Contador.Properties.Resources.icons8_minimizar_la_ventana_50;
            this.BtnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMinimizar.Location = new System.Drawing.Point(894, 3);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(32, 34);
            this.BtnMinimizar.TabIndex = 7;
            this.BtnMinimizar.TabStop = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(449, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Maquina";
            // 
            // CmbMarca
            // 
            this.CmbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbMarca.Location = new System.Drawing.Point(198, 262);
            this.CmbMarca.Name = "CmbMarca";
            this.CmbMarca.Size = new System.Drawing.Size(277, 31);
            this.CmbMarca.TabIndex = 9;
            this.CmbMarca.TextChanged += new System.EventHandler(this.CmbMarca_TextChanged);
            this.CmbMarca.DoubleClick += new System.EventHandler(this.CmbMarca_DoubleClick);
            // 
            // CmbNumPar
            // 
            this.CmbNumPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbNumPar.Location = new System.Drawing.Point(196, 328);
            this.CmbNumPar.Name = "CmbNumPar";
            this.CmbNumPar.Size = new System.Drawing.Size(277, 31);
            this.CmbNumPar.TabIndex = 10;
            this.CmbNumPar.TextChanged += new System.EventHandler(this.CmbNumPar_TextChanged);
            this.CmbNumPar.DoubleClick += new System.EventHandler(this.CmbNumPar_DoubleClick);
            // 
            // CmbMaquina
            // 
            this.CmbMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMaquina.Location = new System.Drawing.Point(378, 183);
            this.CmbMaquina.Name = "CmbMaquina";
            this.CmbMaquina.Size = new System.Drawing.Size(277, 31);
            this.CmbMaquina.TabIndex = 11;
            this.CmbMaquina.Click += new System.EventHandler(this.CmbMaquina_Click);
            this.CmbMaquina.TextChanged += new System.EventHandler(this.CmbMaquina_TextChanged);
            this.CmbMaquina.DoubleClick += new System.EventHandler(this.CmbMaquina_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(214, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Numero de orden RH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(319, 539);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(398, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "El numero de parte o el de la maquina es incorrecto";
            this.label5.Visible = false;
            // 
            // BtnOrparcial
            // 
            this.BtnOrparcial.BackColor = System.Drawing.Color.Transparent;
            this.BtnOrparcial.BackgroundImage = global::Contador.Properties.Resources.boton2;
            this.BtnOrparcial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOrparcial.Location = new System.Drawing.Point(614, 570);
            this.BtnOrparcial.Name = "BtnOrparcial";
            this.BtnOrparcial.Size = new System.Drawing.Size(286, 116);
            this.BtnOrparcial.TabIndex = 20;
            this.BtnOrparcial.TabStop = false;
            this.BtnOrparcial.Click += new System.EventHandler(this.BtnOrparcial_Click);
            // 
            // BtnNueOrd
            // 
            this.BtnNueOrd.BackColor = System.Drawing.Color.Transparent;
            this.BtnNueOrd.BackgroundImage = global::Contador.Properties.Resources.boton1;
            this.BtnNueOrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnNueOrd.Location = new System.Drawing.Point(93, 570);
            this.BtnNueOrd.Name = "BtnNueOrd";
            this.BtnNueOrd.Size = new System.Drawing.Size(286, 116);
            this.BtnNueOrd.TabIndex = 19;
            this.BtnNueOrd.TabStop = false;
            this.BtnNueOrd.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contador.Properties.Resources.logELDISY2;
            this.pictureBox1.Location = new System.Drawing.Point(2, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // CmbNumPar2
            // 
            this.CmbNumPar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbNumPar2.Location = new System.Drawing.Point(546, 328);
            this.CmbNumPar2.Name = "CmbNumPar2";
            this.CmbNumPar2.Size = new System.Drawing.Size(277, 31);
            this.CmbNumPar2.TabIndex = 44;
            this.CmbNumPar2.TextChanged += new System.EventHandler(this.CmbNumPar2_TextChanged);
            this.CmbNumPar2.DoubleClick += new System.EventHandler(this.CmbNumPar2_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(561, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Numero de parte LH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(214, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "Numero de parte RH";
            // 
            // TxtPzAll
            // 
            this.TxtPzAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtPzAll.Location = new System.Drawing.Point(196, 396);
            this.TxtPzAll.MaxLength = 8;
            this.TxtPzAll.Name = "TxtPzAll";
            this.TxtPzAll.Size = new System.Drawing.Size(277, 31);
            this.TxtPzAll.TabIndex = 48;
            this.TxtPzAll.TextChanged += new System.EventHandler(this.TxtPzAll_TextChanged);
            this.TxtPzAll.DoubleClick += new System.EventHandler(this.TxtPzAll_DoubleClick);
            this.TxtPzAll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPzAll_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(214, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 29);
            this.label7.TabIndex = 47;
            this.label7.Text = "Piezas a producir RH";
            // 
            // TxtPzAll2
            // 
            this.TxtPzAll2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtPzAll2.Location = new System.Drawing.Point(546, 396);
            this.TxtPzAll2.MaxLength = 8;
            this.TxtPzAll2.Name = "TxtPzAll2";
            this.TxtPzAll2.Size = new System.Drawing.Size(277, 31);
            this.TxtPzAll2.TabIndex = 50;
            this.TxtPzAll2.TextChanged += new System.EventHandler(this.TxtPzAll2_TextChanged);
            this.TxtPzAll2.DoubleClick += new System.EventHandler(this.TxtPzAll2_DoubleClick);
            this.TxtPzAll2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPzAll2_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(561, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 29);
            this.label8.TabIndex = 49;
            this.label8.Text = "Piezas a producir LH";
            // 
            // CmbOpc
            // 
            this.CmbOpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbOpc.FormattingEnabled = true;
            this.CmbOpc.Items.AddRange(new object[] {
            "Empaque 18 pz",
            "Empaque 15 pz",
            "Empaque 9 pz"});
            this.CmbOpc.Location = new System.Drawing.Point(707, 183);
            this.CmbOpc.Name = "CmbOpc";
            this.CmbOpc.Size = new System.Drawing.Size(277, 33);
            this.CmbOpc.TabIndex = 51;
            this.CmbOpc.Visible = false;
            this.CmbOpc.TextChanged += new System.EventHandler(this.CmbOpc_TextChanged);
            // 
            // lblempaque
            // 
            this.lblempaque.AutoSize = true;
            this.lblempaque.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempaque.ForeColor = System.Drawing.Color.Black;
            this.lblempaque.Location = new System.Drawing.Point(737, 142);
            this.lblempaque.Name = "lblempaque";
            this.lblempaque.Size = new System.Drawing.Size(212, 29);
            this.lblempaque.TabIndex = 52;
            this.lblempaque.Text = "Tipo de empaque";
            this.lblempaque.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(561, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 29);
            this.label9.TabIndex = 54;
            this.label9.Text = "Numero de orden LH";
            // 
            // CmbMarca2
            // 
            this.CmbMarca2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbMarca2.Location = new System.Drawing.Point(546, 262);
            this.CmbMarca2.Name = "CmbMarca2";
            this.CmbMarca2.Size = new System.Drawing.Size(277, 31);
            this.CmbMarca2.TabIndex = 53;
            this.CmbMarca2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.CmbMarca2.DoubleClick += new System.EventHandler(this.CmbMarca2_DoubleClick);
            // 
            // TxtPID2
            // 
            this.TxtPID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtPID2.Location = new System.Drawing.Point(546, 462);
            this.TxtPID2.MaxLength = 8;
            this.TxtPID2.Name = "TxtPID2";
            this.TxtPID2.Size = new System.Drawing.Size(277, 31);
            this.TxtPID2.TabIndex = 58;
            this.TxtPID2.TextChanged += new System.EventHandler(this.TxtPID2_TextChanged);
            this.TxtPID2.DoubleClick += new System.EventHandler(this.TxtPID2_DoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(561, 430);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 29);
            this.label10.TabIndex = 57;
            this.label10.Text = "PID LH";
            // 
            // TxtPID
            // 
            this.TxtPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtPID.Location = new System.Drawing.Point(196, 462);
            this.TxtPID.MaxLength = 8;
            this.TxtPID.Name = "TxtPID";
            this.TxtPID.Size = new System.Drawing.Size(277, 31);
            this.TxtPID.TabIndex = 56;
            this.TxtPID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.TxtPID.DoubleClick += new System.EventHandler(this.TxtPID_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(214, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 29);
            this.label11.TabIndex = 55;
            this.label11.Text = "PID RH";
            // 
            // TpOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1045, 713);
            this.Controls.Add(this.TxtPID2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtPID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbMarca2);
            this.Controls.Add(this.lblempaque);
            this.Controls.Add(this.CmbOpc);
            this.Controls.Add(this.TxtPzAll2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtPzAll);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbNumPar2);
            this.Controls.Add(this.BtnOrparcial);
            this.Controls.Add(this.BtnNueOrd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbMaquina);
            this.Controls.Add(this.CmbNumPar);
            this.Controls.Add(this.CmbMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarrraTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TpOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TpOrdenes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TpOrdenes_FormClosing);
            this.Load += new System.EventHandler(this.TpOrdenes_Load);
            this.BarrraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnOrparcial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNueOrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel BarrraTitulo;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.PictureBox BtnMax;
        private System.Windows.Forms.PictureBox BtnMinimizar;
        private System.Windows.Forms.PictureBox BtnRestaurar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CmbMarca;
        private System.Windows.Forms.TextBox CmbNumPar;
        private System.Windows.Forms.TextBox CmbMaquina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox BtnNueOrd;
        private System.Windows.Forms.PictureBox BtnOrparcial;
        private System.Windows.Forms.TextBox CmbNumPar2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPzAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPzAll2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbOpc;
        private System.Windows.Forms.Label lblempaque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CmbMarca2;
        private System.Windows.Forms.TextBox TxtPID2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtPID;
        private System.Windows.Forms.Label label11;
    }
}