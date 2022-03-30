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
using Excel = Microsoft.Office.Interop.Excel;

namespace Contador
{
    public partial class ParosProgramados : Form
    {
        public ParosProgramados()
        {
            InitializeComponent();
        }
        Form1 form = new Form1();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void Excel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\Hoja de produccion diaria\\Paros de produccion.xlsx");

            Microsoft.Office.Interop.Excel.Worksheet x = null;

            x = sheet.Sheets["BILLION"];

            Excel.Range userRange = x.UsedRange;
            int contRow = userRange.Rows.Count;
            int add = contRow + 1;
            x.Cells[add, 1] = LblFecha.Text;
            x.Cells[add, 2] = TxtInicio.Text;
            x.Cells[add, 3] = TxtFin.Text;
            x.Cells[add, 5] = CmbMotivos.Text;
            x.Cells[add, 6] = form.LblMaquina.Text;
            sheet.Close(true);
            excel.Quit();

        }
        private void ParosProgramados_Load(object sender, EventArgs e)
        {
            HoraFecha.Enabled = true;
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            TxtInicio.Text = LblHora.Text;
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            TxtFin.Text = LblHora.Text;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea Guardar los datos?", "Archivo de excel", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Excel();
                MessageBox.Show("Datos guardados");
                this.Close();
            }
            if (result == DialogResult.Cancel)
            {

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos no se guardaran ¿Desea cerrar la vetana?", "Cerrar", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            if (result == DialogResult.Cancel)
            {

            }
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BarrraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
