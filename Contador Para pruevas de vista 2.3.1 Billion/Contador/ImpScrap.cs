using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Contador.Properties;

namespace Contador
{
    public partial class ImpScrap : Form
    {
       public int contador1 = 0;
        public int contador2 = 0;
        public int contador3 = 0;
        public int contador4 = 0;
        public int contador5 = 0;
        public int contador6 = 0;
        public int suma = 0;
        public ImpScrap()
        {
            InitializeComponent();
        }
        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                CmbImpresoras.Items.Add(pkInstalledPrinters);
            }
        }
        public void voyimprimir()
        {
            txtVacioCDB();
            //CADA VEZ QUE LE DEMOS IMPRIMIR SE CREE EL OBJETO
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += imprimirP;
            printDocument1.PrinterSettings.PrinterName = CmbImpresoras.Text;
            printDocument1.Print();
        }
        private void imprimirP(object sender, PrintPageEventArgs e)
        {
            try
            {
                generar_codigo_barras();

                Font fontT = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
                Font fontN = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

                e.Graphics.DrawString("ELDISY", fontN, Brushes.Black, new RectangleF(40, 35, 300, 500));
                e.Graphics.DrawString("MEXICO", fontN, Brushes.Black, new RectangleF(40, 60, 300, 500));

                if (CadS1.Text != "0")
                {
                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 80, 300, 500));
                    e.Graphics.DrawString(TpS1.Text, fontN, Brushes.Black, new RectangleF(250, 80, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS1.BackgroundImage, new Rectangle(30, 110, 350, 40));
                    e.Graphics.DrawImage(CantidadS1.BackgroundImage, new Rectangle(400, 110, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 110, 250, 40));
                }
                if (CadS2.Text != "0")
                {
                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 160, 300, 500));
                    e.Graphics.DrawString(TpS2.Text, fontN, Brushes.Black, new RectangleF(250, 160, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS2.BackgroundImage, new Rectangle(30, 190, 350, 40));
                    e.Graphics.DrawImage(CantidadS2.BackgroundImage, new Rectangle(400, 190, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 190, 250, 40));
                }
                if (CadS3.Text != "0")
                {

                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 240, 300, 500));
                    e.Graphics.DrawString(TpS3.Text, fontN, Brushes.Black, new RectangleF(250, 240, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS3.BackgroundImage, new Rectangle(30, 270, 350, 40));
                    e.Graphics.DrawImage(CantidadS3.BackgroundImage, new Rectangle(400, 270, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 270, 250, 40));

                }
                if (CadS4.Text != "0")
                {
                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 320, 300, 500));
                    e.Graphics.DrawString(TpS4.Text, fontN, Brushes.Black, new RectangleF(250, 320, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS4.BackgroundImage, new Rectangle(30, 350, 350, 40));
                    e.Graphics.DrawImage(CantidadS4.BackgroundImage, new Rectangle(400, 350, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 350, 250, 40));
                }

                if (CadS5.Text != "0")
                {
                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 390, 300, 500));
                    e.Graphics.DrawString(TpS5.Text, fontN, Brushes.Black, new RectangleF(250, 390, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS5.BackgroundImage, new Rectangle(30, 420, 350, 40));
                    e.Graphics.DrawImage(CantidadS5.BackgroundImage, new Rectangle(400, 420, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 420, 250, 40));
                }
                if (CadS6.Text != "0")
                {
                    e.Graphics.DrawString("Tipo de SCRAP", fontT, Brushes.Black, new RectangleF(50, 460, 300, 500));
                    e.Graphics.DrawString(TpS6.Text, fontN, Brushes.Black, new RectangleF(250, 460, 1200, 1200));
                    e.Graphics.DrawImage(CodBTpS5.BackgroundImage, new Rectangle(30, 490, 350, 40));
                    e.Graphics.DrawImage(CantidadS6.BackgroundImage, new Rectangle(400, 490, 250, 40));
                }
                else
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(40, 490, 250, 40));
                }
                #region


                // Create string to draw.
                String drawString = "_____________________________________________";
                String Horizontal = "______________________________________________________________";


                // Create font and brush.
                Font drawFont = new Font("Arial", 16);

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 20, 5, drawFormat);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 788, 5, drawFormat);
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 520, 1200, 100));
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 5, 1200, 100));

                #endregion

            }
            catch (Exception)
            {


            }


        }
        public void generar_codigo_barras()
        {
            try
            {
                txtVacioCDB();
                BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
                codigoBarras.IncludeLabel = true;
                if (TpS1.Text != "")
                {
                    CodBTpS1.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS1.Text, Color.Black, Color.White, 800, 800);
                    CantidadS1.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS1.Text, Color.Black, Color.White, 500, 200);

                }
                if (TpS2.Text != "")
                {
                    CodBTpS2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS2.Text, Color.Black, Color.White, 800, 800);
                    CantidadS2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS2.Text, Color.Black, Color.White, 500, 200);

                }
                if (TpS3.Text != "")
                {
                    CodBTpS3.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS3.Text, Color.Black, Color.White, 800, 800);
                    CantidadS3.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS3.Text, Color.Black, Color.White, 500, 200);

                }
                if (TpS4.Text != "")
                {
                    CodBTpS4.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS4.Text, Color.Black, Color.White, 1000, 1000);
                    CantidadS4.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS4.Text, Color.Black, Color.White, 500, 200);

                }
                if (TpS5.Text != "")
                {
                    CodBTpS5.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS4.Text, Color.Black, Color.White, 800, 800);
                    CantidadS5.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS4.Text, Color.Black, Color.White, 500, 200);
                }
                if (TpS6.Text != "")
                {
                    CodBTpS6.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TpS4.Text, Color.Black, Color.White, 800, 800);
                    CantidadS6.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, CadS4.Text, Color.Black, Color.White, 500, 200);
                }

                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void txtVacioCDB()
        {
            if (TpS1.Text.Length == 0)
            {
                TpS1.Text = "0";
            }

            if (TpS2.Text.Length == 0)
            {
                TpS2.Text = "0";
            }

            if (TpS3.Text.Length == 0)
            {
                TpS3.Text = "0";
            }
            if (TpS4.Text.Length == 0)
            {
                TpS4.Text = "0";
            }
            if (TpS5.Text.Length == 0)
            {
                TpS5.Text = "0";
            }

            if (TpS6.Text.Length == 0)
            {
                TpS6.Text = "0";
            }
            if (CadS1.Text.Length == 0)
            {
                CadS1.Text = "0";
            }

            if (CadS2.Text.Length == 0)
            {
                CadS2.Text = "0";
            }

            if (CadS3.Text.Length == 0)
            {
                CadS3.Text = "0";
            }

            if (CadS4.Text.Length == 0)
            {
                CadS4.Text = "0";
            }
            if (CadS5.Text.Length == 0)
            {
                CadS5.Text = "0";
            }
            if (CadS6.Text.Length == 0)
            {
                CadS6.Text = "0";
            }
            else
            {

            }


        }
        public void ValidarTxt()
        {
            if (CmbImpresoras.Text == string.Empty)
            {
                Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            }
        }
        public void nomas()
        {
            int scraptotal = contador1 + contador2 + contador3 + contador4 + contador5 + contador6;

            if (scraptotal != 0)
            {
                if (suma == scraptotal)
                {
                    BtnContadorMas.Enabled = false;
                    BtnContadorMas2.Enabled = false;
                    BtnContadorMas3.Enabled = false;
                    BtnContadorMas4.Enabled = false;
                    BtnContadorMas5.Enabled = false;
                    BtnContadorMas6.Enabled = false;
                }
                else
                {
                    BtnContadorMas.Enabled = true;
                    BtnContadorMas2.Enabled = true;
                    BtnContadorMas3.Enabled = true;
                    BtnContadorMas4.Enabled = true;
                    BtnContadorMas5.Enabled = true;
                    BtnContadorMas6.Enabled = true;
                }
            }
            else
            {

            }

        }
        public void Excel()
        {
            Form1 form1 = new Form1();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\Hoja de produccion diaria\\Scrap.xlsx");

            Microsoft.Office.Interop.Excel.Worksheet x = null;

            x = sheet.Sheets["BILLION"];

            Excel.Range userRange = x.UsedRange;
            int contRow = userRange.Rows.Count;
            int contColums = userRange.Columns.Count;
            int add = contRow + 1;
            x.Cells[add, 1] = LblFecha.Text;
            x.Cells[add, 2] = LblHora.Text;
            x.Cells[add, 3] = form1.LblMaquina.Text;
            x.Cells[add, 4] = form1.LblPieza.Text;
            if (CadS1.Text != "0")
            {

                x.Cells[add, 5] = TpS1.Text;
                x.Cells[add, 6] = CadS1.Text;
            }
            if (CadS2.Text != "0")
            {
                x.Cells[add, 7] = TpS2.Text;
                x.Cells[add, 8] = CadS2.Text;
            }
            if (CadS3.Text != "0")
            {
                x.Cells[add, 9] = TpS3.Text;
                x.Cells[add, 10] = CadS3.Text;
            }
            if (CadS4.Text != "0")
            {
                x.Cells[add, 11] = TpS4.Text;
                x.Cells[add, 12] = CadS4.Text;
            }
            if (CadS5.Text != "0")
            {
                x.Cells[add, 13] = TpS5.Text;
                x.Cells[add, 14] = CadS5.Text;
            }
            if (CadS6.Text != "0")
            {
                x.Cells[add, 15] = TpS6.Text;
                x.Cells[add, 16] = CadS6.Text;
            }
            sheet.Close(true);
            excel.Quit();


        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void BtnContadorMas5_Click(object sender, EventArgs e)
        {

        }

        private void ImpScrap_Load(object sender, EventArgs e)
        {

        }

        private void ImpScrap_Load_1(object sender, EventArgs e)
        {
            CadS1.Text = (string)Settings.Default["CadS1"];
            CadS2.Text = (string)Settings.Default["CadS2"];
            CadS3.Text = (string)Settings.Default["CadS3"];
            CadS4.Text = (string)Settings.Default["CadS4"];
            CadS5.Text = (string)Settings.Default["CadS5"];
            CadS6.Text = (string)Settings.Default["CadS6"];
            TpS1.Text = (string)Settings.Default["TpS1"];
            TpS2.Text = (string)Settings.Default["TpS2"];
            TpS3.Text = (string)Settings.Default["TpS3"];
            TpS4.Text = (string)Settings.Default["TpS4"];
            TpS5.Text = (string)Settings.Default["TpS5"];
            TpS6.Text = (string)Settings.Default["TpS6"];
            Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            ValidarTxt();
            PopulateInstalledPrintersCombo();
            HoraFecha.Enabled = true;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("¿Los tipo de SCRAP son correctos?", "Verificar", MessageBoxButtons.OKCancel);
            if (resulta == DialogResult.OK)
            {

                if (CmbImpresoras.Text != "")
                {
                    Excel();
                    voyimprimir();

                }
                else
                {
                    MessageBox.Show("Elegir impresora");
                }

            }
            if (resulta == DialogResult.Cancel)
            {

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Settings.Default.Save();
        }

        private void BtnContadorMas_Click(object sender, EventArgs e)
        {
            contador1++;
            CadS1.Text = Convert.ToString(contador1);
            nomas();
        }

        private void BtnContadorMas2_Click(object sender, EventArgs e)
        {
            contador2++;
            CadS2.Text = Convert.ToString(contador2);
            nomas();
        }

        private void BtnContadorMas3_Click(object sender, EventArgs e)
        {
            contador3++;
            CadS3.Text = Convert.ToString(contador3);
            nomas();
        }

        private void BtnContadorMas4_Click(object sender, EventArgs e)
        {
            contador4++;
            CadS4.Text = Convert.ToString(contador4);
            nomas();
        }

        private void BtnContadorMas5_Click_1(object sender, EventArgs e)
        {
            contador5++;
            CadS5.Text = Convert.ToString(contador5);
            nomas();
        }

        private void BtnContadorMas6_Click(object sender, EventArgs e)
        {
            contador6++;
            CadS6.Text = Convert.ToString(contador6);
            nomas();
        }

        private void BtnContadormenos_Click(object sender, EventArgs e)
        {
            contador1--;
            CadS1.Text = Convert.ToString(contador1);
            nomas();
        }

        private void BtnContadormenos2_Click(object sender, EventArgs e)
        {
            contador2--;
            CadS2.Text = Convert.ToString(contador2);
            nomas();
        }

        private void BtnContadormenos3_Click(object sender, EventArgs e)
        {
            contador3--;
            CadS3.Text = Convert.ToString(contador3);
            nomas();
        }

        private void BtnContadormenos4_Click(object sender, EventArgs e)
        {
            contador4--;
            CadS4.Text = Convert.ToString(contador4);
            nomas();
        }

        private void BtnContadormenos5_Click(object sender, EventArgs e)
        {
            contador5--;
            CadS5.Text = Convert.ToString(contador5);
            nomas();
        }

        private void BtnContadormenos6_Click(object sender, EventArgs e)
        {
            contador6--;
            CadS6.Text = Convert.ToString(contador6);
            nomas();
        }

        private void CadS1_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS1"] = CadS1.Text;
            contador1 = int.Parse(CadS1.Text);
            if (CadS1.Text == "0")
            {
                BtnContadormenos.Enabled = false;
            }
            else
            {
                BtnContadormenos.Enabled = true;
            }
        }

        private void CadS2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS2"] = CadS2.Text;
            contador2 = int.Parse(CadS2.Text);
            if (CadS2.Text == "0")
            {
                BtnContadormenos2.Enabled = false;
            }
            else
            {
                BtnContadormenos2.Enabled = true;
            }
        }

        private void CadS3_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS3"] = CadS3.Text;
            contador3 = int.Parse(CadS3.Text);
            if (CadS2.Text == "0")
            {
                BtnContadormenos3.Enabled = false;
            }
            else
            {
                BtnContadormenos3.Enabled = true;
            }
        }

        private void CadS4_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS4"] = CadS4.Text;
            contador4 = int.Parse(CadS4.Text);
            if (CadS4.Text == "0")
            {
                BtnContadormenos4.Enabled = false;
            }
            else
            {
                BtnContadormenos4.Enabled = true;
            }
        }

        private void CadS5_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS5"] = CadS5.Text;
            contador5 = int.Parse(CadS5.Text);
            if (CadS5.Text == "0")
            {
                BtnContadormenos5.Enabled = false;
            }
            else
            {
                BtnContadormenos5.Enabled = true;
            }
        }

        private void CadS6_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["CadS6"] = CadS6.Text;
            contador6 = int.Parse(CadS6.Text);
            if (CadS6.Text == "0")
            {
                BtnContadormenos6.Enabled = false;
            }
            else
            {
                BtnContadormenos6.Enabled = true;
            }
        }

        private void CmbImpresoras_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }

        private void TpS1_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS1"] = TpS1.Text;
        }

        private void TpS2_TextUpdate(object sender, EventArgs e)
        {

        }

        private void TpS2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS2"] = TpS2.Text;
        }

        private void TpS3_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS3"] = TpS3.Text;
        }

        private void TpS4_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS4"] = TpS4.Text;
        }

        private void TpS5_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS5"] = TpS5.Text;
        }

        private void TpS6_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["TpS6"] = TpS6.Text;
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Excel();
        }
    }
}
