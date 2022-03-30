using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contador
{
    public partial class TpOrdenes : Form
    {

        Form1 Ordenes = new Form1();
        string NumParte = "";
        string NumParte2 = "";
        string CodMaquina = "";

        public TpOrdenes()
        {
            InitializeComponent();

        }
        //dependiendo del click del boton mostrara el Group box del orden parcial
        private void button1_Click(object sender, EventArgs e)
        {
            VisibleGrp();
            Ordenes.lblContadorOK.Text = "0";
            Ordenes.lblNotOk.Text = "0";


            if (CmbMarca.Text == "")
            {
                MessageBox.Show("Introducir numero de orden");
            }
            if (CmbMarca.Text != "")
            {
                Ordenes.ShowDialog();

            }

        }

        private void BtnOParcial_Click(object sender, EventArgs e)
        {
            Ordenes.GpOrdenP.Visible = true;
            Ordenes.lblContadorOK.Text = "0";

            Ordenes.lblNotOk.Text = "0";

            if (CmbMarca.Text != "")
            {
                Ordenes.ShowDialog();

            }

        }

        private void TpOrdenes_Load(object sender, EventArgs e)
        {
            BtnNueOrd.Enabled = false;
            BtnOrparcial.Enabled = false;
            CmbMarca.Text = "";
            CmbMaquina.Text = "";
            CmbNumPar.Text = "";
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarrraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMax.Visible = false;

            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnMax.Visible = true;

            BtnRestaurar.Visible = false;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarrraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CmbMarca_TextChanged(object sender, EventArgs e)
        {
            Ordenes.LblMarca.Text = CmbMarca.Text;
           
        }
        // leemos y validamos si el codigo de la maquina y el numero de pieza coisiden en la estacion de trabajo
        private void CmbNumPar_TextChanged(object sender, EventArgs e)
        {
            Ordenes.LblPieza.Text = CmbNumPar.Text;
            Validar();
        }

        private void CmbMarca_DoubleClick(object sender, EventArgs e)
        {
            CmbMarca.Clear();
        }

        private void CmbNumPar_DoubleClick(object sender, EventArgs e)
        {
            CmbNumPar.Clear();
        }
        //Mandamos los datos de Cmb para el modulo de form1 en el label de maquina
        private void CmbMaquina_TextChanged(object sender, EventArgs e)
        {
            Ordenes.LblMaquina.Text = CmbMaquina.Text + " RH";
            Ordenes.LblMaquina2.Text = CmbMaquina.Text + " LH";
           
        }

        private void CmbMaquina_DoubleClick(object sender, EventArgs e)
        {
            CmbMaquina.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Creamos el metodo para validar que los codigos de maquina y el numero de parte hagan match
        public void Validar()
        {
            //RH Parte 
            NumParte = CmbNumPar.Text;
            NumParte2 = CmbNumPar2.Text;
            CodMaquina = CmbMaquina.Text;

           if (CodMaquina == "Billion1" || CodMaquina == "Billion2" || CodMaquina == "Billion3" || CodMaquina == "Billion4")
            {
                if (NumParte == "V2178070")
                {
                    if (NumParte2 == "V2178069")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;

                    }
                }
                else if (NumParte == "2176968")
                {
                    if (NumParte2 == "2176967")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                        lblempaque.Visible = true;
                        CmbOpc.Visible = true;
                    }
                }
                else if (NumParte == "V2177241")
                {
                    if (NumParte2 == "V2177240")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else if (NumParte == "V2178687")
                {
                    if (NumParte2 == "V2178686")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else if (NumParte == "V2178690")
                {
                    if (NumParte2 == "V2178689")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }

                else if (NumParte == "2178929")
                {
                    if (NumParte2 == "2178928")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }

                else if (NumParte == "2178931")
                {
                    if (NumParte2 == "2178930")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }


                else if (NumParte == "V2177241")
                {
                    if (NumParte2 == "V2177240")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }


                else if (NumParte == "V2179467")
                {
                    if (NumParte2 == "V2179466")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "El numero de pieza es incorrecto";
                    BtnNueOrd.Enabled = false;
                    BtnOrparcial.Enabled = false;
                    lblempaque.Visible = false;
                    CmbOpc.Visible = false;

                }
            }

            else
            {

            }
           
        }
        public void Validar2()
        {

            // PARTE LH
            NumParte = CmbNumPar2.Text;
            NumParte2 = CmbNumPar.Text;
            CodMaquina = CmbMaquina.Text;

            if (CodMaquina == "Billion1" || CodMaquina == "Billion2" || CodMaquina == "Billion3" || CodMaquina == "Billion4")
            {
                if (NumParte == "V2178069")
                {
                    if (NumParte2 == "V2178070")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else if (NumParte == "V2177240")
                {
                    if (NumParte2 == "V2177241")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else if (NumParte == "2176967")
                {
                    if (NumParte2 == "2176968")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                        lblempaque.Visible = true;
                        CmbOpc.Visible = true;
                    }
                   
                }
                else if (NumParte == "V2178686")
                {
                    if (NumParte2 == "V2178687")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else if (NumParte == "V2178689")
                {
                    if (NumParte2 == "V2178690")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }

                else if (NumParte == "2178928")
                {
                    if (NumParte2 == "2178929")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }

                else if (NumParte == "2178930")
                {
                    if (NumParte2 == "2178931")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }


                else if (NumParte == "V2179466")
                {
                    if (NumParte2 == "V2179467")
                    {
                        BtnNueOrd.Enabled = true;
                        BtnOrparcial.Enabled = true;
                        label5.Visible = false;
                    }
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "El numero de pieza es incorrecto";
                    BtnNueOrd.Enabled = false;
                    BtnOrparcial.Enabled = false;
                    lblempaque.Visible = false;
                    CmbOpc.Visible = false;
                }
            }

            else
            {

            }

        }

        private void CmbMaquina_Click(object sender, EventArgs e)
        {
            CmbNumPar.Text = "";

        }

        public void VisibleGrp()
        {
            if (CmbOpc.Visible == false)
            {
                Ordenes.CmbOpc.Text = "";
            }

            if (Ordenes.GpOrdenP.Visible == true)
            {
                Ordenes.GpOrdenP.Visible = false;
                Ordenes.GrbSracp.Visible = true;
            }
            else if (Ordenes.GpOrdenP.Visible != false)
            {
                Ordenes.GpOrdenP.Visible = false;
                Ordenes.GrbSracp.Visible = true;
            }

            else
            {
                Ordenes.GpOrdenP.Visible = false;
                Ordenes.GrbSracp.Visible = true;
            }
        }
        public bool ValidarDatos()
        {

            bool validar = true;

            /* if (TxtBatch4.Text.Length == 0)
             {
                 validar = false;
                 MessageBox.Show("Batchs 4 Vacio favor de llenarlo");
             }*/
            if (CmbMarca.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Introducir numero de orden RH", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (CmbMarca2.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Introducir numero de orden LH", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (TxtPID.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("PID RH Vacio favor de llenarlo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (TxtPID2.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("PID LH Vacio favor de llenarlo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (TxtPzAll.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Introducir Numero RH de piezas a producir ", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtPzAll2.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Introducir Numero LH de piezas a producir", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CmbOpc.Visible ==true && CmbOpc.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Elegir Tipo de empaque", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validar;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            VisibleGrp();
            Ordenes.lblContadorOK.Text = "0";
            Ordenes.lblNotOk.Text = "0";
            if (ValidarDatos() == true)
            {
                Ordenes.ShowDialog();
                Ordenes.pztotal = int.Parse(TxtPzAll.Text);
                Ordenes.pztotal2 = int.Parse(TxtPzAll2.Text);
                Ordenes.lblpztotal.Text = Convert.ToString(TxtPzAll.Text);
                Ordenes.lblpztotal2.Text = Convert.ToString(TxtPzAll2.Text);
                Ordenes.TxtPID2.Text = Convert.ToString(TxtPID2.Text);
                Ordenes.TxtPID.Text = Convert.ToString(TxtPID.Text);
                Ordenes.ValidarTxt();
            }
            else
            {

            }
        }

        private void BtnOrparcial_Click(object sender, EventArgs e)
        {
            Ordenes.GpOrdenP.Visible = true;
            Ordenes.GpOrdenP.Location = new Point(51, 517);
            Ordenes.GrbSracp.Visible = false; 
            Ordenes.lblContadorOK.Text = "0";

            Ordenes.lblNotOk.Text = "0";

            if (CmbMarca.Text == "")
            {
                MessageBox.Show("Introducir numero de orden");
            }
            if (CmbMarca.Text != "" && CmbNumPar2.Text != "")
            {
                Ordenes.ShowDialog();
                Ordenes.pztotal = int.Parse(TxtPzAll.Text);
                Ordenes.pztotal2 = int.Parse(TxtPzAll2.Text);
                Ordenes.lblpztotal.Text = Convert.ToString(TxtPzAll.Text);
                Ordenes.lblpztotal2.Text = Convert.ToString(TxtPzAll2.Text);
                Ordenes.TxtPID2.Text = Convert.ToString(TxtPID2.Text);
                Ordenes.TxtPID.Text = Convert.ToString(TxtPID.Text);
                Ordenes.ValidarTxt();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TpOrdenes_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CmbNumPar2_TextChanged(object sender, EventArgs e)
        {
            Ordenes.LblPieza2.Text = CmbNumPar2.Text;
            Validar2();
        }

        private void CmbNumPar2_DoubleClick(object sender, EventArgs e)
        {
            CmbNumPar2.Clear();
        }

        private void TxtPzAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                
            }
        }

        private void TxtPzAll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtPzAll.Text == "")
                {
                    Ordenes.pztotal = 0;
                }
                else
                {
                    Ordenes.pztotal = int.Parse(TxtPzAll.Text);
                    Ordenes.lblpztotal.Text = Convert.ToString(TxtPzAll.Text);
                }
            }
            catch (Exception)
            {


            }
           
        }

        private void TxtPzAll2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtPzAll2.Text == "")
                {
                    Ordenes.pztotal2 = 0;
                }
                else
                {
                    Ordenes.pztotal2 = int.Parse(TxtPzAll2.Text);
                    Ordenes.lblpztotal2.Text = Convert.ToString(TxtPzAll2.Text);
                }
            }
            catch (Exception)
            {

         
            }
           
        }

        private void TxtPzAll_DoubleClick(object sender, EventArgs e)
        {
            TxtPzAll.Clear();
        }

        private void TxtPzAll2_DoubleClick(object sender, EventArgs e)
        {
            TxtPzAll2.Clear();
        }

        private void CmbOpc_TextChanged(object sender, EventArgs e)
        {
            Ordenes.CmbOpc.Text = CmbOpc.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Ordenes.LblMarca2.Text = CmbMarca2.Text;
        }

        private void TxtPzAll2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Ordenes.TxtPID.Text = Convert.ToString(TxtPID.Text);
        }

        private void TxtPID2_TextChanged(object sender, EventArgs e)
        {
            Ordenes.TxtPID2.Text = Convert.ToString(TxtPID2.Text);
        }

        private void CmbMarca2_DoubleClick(object sender, EventArgs e)
        {
            CmbMarca2.Clear();
        }

        private void TxtPID_DoubleClick(object sender, EventArgs e)
        {
            TxtPID.Clear();
        }

        private void TxtPID2_DoubleClick(object sender, EventArgs e)
        {
            TxtPID2.Clear();
        }
    }
}
