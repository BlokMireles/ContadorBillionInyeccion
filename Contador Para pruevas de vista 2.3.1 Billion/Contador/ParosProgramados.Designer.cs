
namespace Contador
{
    partial class ParosProgramados
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
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblHora = new System.Windows.Forms.Label();
            this.BtnFin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbMotivos = new System.Windows.Forms.ComboBox();
            this.TxtFin = new System.Windows.Forms.TextBox();
            this.TxtInicio = new System.Windows.Forms.TextBox();
            this.BtnInicio = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.BarrraTitulo = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.BarrraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFecha.Location = new System.Drawing.Point(48, 141);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(65, 22);
            this.LblFecha.TabIndex = 63;
            this.LblFecha.Text = "label2";
            // 
            // LblHora
            // 
            this.LblHora.AutoSize = true;
            this.LblHora.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHora.Location = new System.Drawing.Point(48, 86);
            this.LblHora.Name = "LblHora";
            this.LblHora.Size = new System.Drawing.Size(65, 22);
            this.LblHora.TabIndex = 62;
            this.LblHora.Text = "label1";
            // 
            // BtnFin
            // 
            this.BtnFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFin.BackgroundImage = global::Contador.Properties.Resources.icons8_última_hora_96;
            this.BtnFin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFin.FlatAppearance.BorderSize = 0;
            this.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFin.Location = new System.Drawing.Point(347, 385);
            this.BtnFin.Name = "BtnFin";
            this.BtnFin.Size = new System.Drawing.Size(56, 52);
            this.BtnFin.TabIndex = 61;
            this.BtnFin.UseVisualStyleBackColor = true;
            this.BtnFin.Click += new System.EventHandler(this.BtnFin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(144, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 58;
            this.label3.Text = "Motivo de paro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(118, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 57;
            this.label2.Text = "Hora Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(122, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 22);
            this.label1.TabIndex = 56;
            this.label1.Text = "Hora Inicio";
            // 
            // CmbMotivos
            // 
            this.CmbMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMotivos.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMotivos.FormattingEnabled = true;
            this.CmbMotivos.Items.AddRange(new object[] {
            "Preparacion de maqina",
            "Fin de programa",
            "Cambio de Numero de Parte",
            "Falta de Material",
            "Limpieza de Molde",
            "Falla de Molde",
            "Comida",
            "Otras actividades"});
            this.CmbMotivos.Location = new System.Drawing.Point(122, 224);
            this.CmbMotivos.Name = "CmbMotivos";
            this.CmbMotivos.Size = new System.Drawing.Size(201, 30);
            this.CmbMotivos.TabIndex = 55;
            // 
            // TxtFin
            // 
            this.TxtFin.Enabled = false;
            this.TxtFin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtFin.Location = new System.Drawing.Point(122, 397);
            this.TxtFin.Name = "TxtFin";
            this.TxtFin.Size = new System.Drawing.Size(201, 29);
            this.TxtFin.TabIndex = 54;
            // 
            // TxtInicio
            // 
            this.TxtInicio.Enabled = false;
            this.TxtInicio.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtInicio.Location = new System.Drawing.Point(122, 304);
            this.TxtInicio.Name = "TxtInicio";
            this.TxtInicio.Size = new System.Drawing.Size(201, 29);
            this.TxtInicio.TabIndex = 53;
            // 
            // BtnInicio
            // 
            this.BtnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnInicio.BackgroundImage = global::Contador.Properties.Resources.icons8_última_hora_96;
            this.BtnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnInicio.FlatAppearance.BorderSize = 0;
            this.BtnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInicio.Location = new System.Drawing.Point(347, 292);
            this.BtnInicio.Name = "BtnInicio";
            this.BtnInicio.Size = new System.Drawing.Size(56, 52);
            this.BtnInicio.TabIndex = 60;
            this.BtnInicio.UseVisualStyleBackColor = true;
            this.BtnInicio.Click += new System.EventHandler(this.BtnInicio_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExcel.BackgroundImage = global::Contador.Properties.Resources.icons8_microsoft_excel_2019_96;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.FlatAppearance.BorderSize = 0;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Location = new System.Drawing.Point(191, 463);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(84, 81);
            this.BtnExcel.TabIndex = 59;
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // HoraFecha
            // 
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // BarrraTitulo
            // 
            this.BarrraTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarrraTitulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BarrraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.BarrraTitulo.Controls.Add(this.BtnClose);
            this.BarrraTitulo.Location = new System.Drawing.Point(0, -1);
            this.BarrraTitulo.Name = "BarrraTitulo";
            this.BarrraTitulo.Size = new System.Drawing.Size(481, 48);
            this.BarrraTitulo.TabIndex = 64;
            this.BarrraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarrraTitulo_MouseDown);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.White;
            this.BtnClose.BackgroundImage = global::Contador.Properties.Resources.icons8_cerrar_ventana_50;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnClose.Location = new System.Drawing.Point(428, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(41, 42);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ParosProgramados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 556);
            this.Controls.Add(this.BarrraTitulo);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.LblHora);
            this.Controls.Add(this.BtnFin);
            this.Controls.Add(this.BtnInicio);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbMotivos);
            this.Controls.Add(this.TxtFin);
            this.Controls.Add(this.TxtInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParosProgramados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParosProgramados";
            this.Load += new System.EventHandler(this.ParosProgramados_Load);
            this.BarrraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblHora;
        public System.Windows.Forms.Button BtnFin;
        public System.Windows.Forms.Button BtnInicio;
        public System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbMotivos;
        private System.Windows.Forms.TextBox TxtFin;
        private System.Windows.Forms.TextBox TxtInicio;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Panel BarrraTitulo;
        private System.Windows.Forms.PictureBox BtnClose;
    }
}