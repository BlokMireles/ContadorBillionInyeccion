using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Contador
{
    public partial class ValidacionOrden : Form
    {

        public ValidacionOrden()
        {
           
            InitializeComponent();
           
          
        }
        public void limpiartxt()
        {
            CmbMarca.Clear();
            CmbNumPar.Clear();
            CmbMarca2.Clear();
            CmbNumPar2.Clear();
            PIDLH.Clear();
            PIDRH.Clear();
        }

        private void ValidacionOrden_Load(object sender, EventArgs e)
        {
            BtnStart.Visible = false;
            label5.Visible = false;
            limpiartxt();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
            
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
      
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.Close();
            CmbMarca.Clear();
            CmbNumPar.Clear();
         
        }

        private void CmbNumPar_TextChanged(object sender, EventArgs e)
        {
            validar1();
            
               
        }
        public void validar1()
        {
            if (label4.Text == CmbNumPar.Text && label3.Text == CmbMarca.Text)
            {
                if (label9.Text == CmbNumPar2.Text && label10.Text == CmbMarca2.Text)
                {
                    if (PIDRH.Text != "" && PIDLH.Text != "")
                    {
                        BtnStart.Visible = true;
                        label5.Visible = false;
                    }
                    else
                    {
                        label5.Visible =true;
                        label5.Text = "Revisar PID's";
                    }


                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "Revisar Pieza LH";
                }

            }
            else
            {
                label5.Visible = true;
                label5.Text = "Revisar Pieza RH";
            }
        }
        private void label3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CmbNumPar_DoubleClick(object sender, EventArgs e)
        {
            CmbNumPar.Clear();
        }

        private void BarrraTitulo_Paint(object sender, PaintEventArgs e)
        {

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

        private void CmbMarca_DoubleClick(object sender, EventArgs e)
        {
            CmbMarca.Clear();
        }

        private void BtnComezar_Click(object sender, EventArgs e)
        {
            this.Close();
            CmbMarca.Clear();
            CmbNumPar.Clear();
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbMarca_TextChanged(object sender, EventArgs e)
        {
            validar1();
        }

        private void CmbMarca2_TextChanged(object sender, EventArgs e)
        {
            validar1();
        }

        private void CmbNumPar2_TextChanged(object sender, EventArgs e)
        {
            validar1();
        }

        private void PIDLH_TextChanged(object sender, EventArgs e)
        {
            validar1();
        }

        private void PIDRH_TextChanged(object sender, EventArgs e)
        {
            validar1();
        }

        private void CmbMarca2_DoubleClick(object sender, EventArgs e)
        {
            CmbMarca2.Clear();
        }

        private void CmbNumPar2_DoubleClick(object sender, EventArgs e)
        {
            CmbNumPar2.Clear();
        }

        private void PIDLH_DoubleClick(object sender, EventArgs e)
        {
            PIDLH.Clear();
        }

        private void PIDRH_DoubleClick(object sender, EventArgs e)
        {
            PIDRH.Clear();
        }
    }
}
