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
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Management;
using System.Drawing.Imaging;
using Excel = Microsoft.Office.Interop.Excel;
using WMPLib;
using System.Data.OleDb;
using Contador.Properties;

namespace Contador
{
    public partial class Form1 : Form
    {
        ValidacionOrden validacionOrden = new ValidacionOrden();
        ImpScrap impScrap = new ImpScrap();
        ImpScrap2 impScrap2 = new ImpScrap2();
        int estadoBotonMenu = 0;

        Alerta1 alerta1 = new Alerta1();
        Alerta2 alerta2 = new Alerta2();
        Alerta3 alerta3 = new Alerta3();
        Alerta4 alerta4 = new Alerta4();
        WindowsMediaPlayer sonidoP;
        WindowsMediaPlayer sonidoP2;

        int ciclos = 0;

        int count = 0;
        int countca = 0;
        int countca2 = 0;
        int ContadorSRH = 0;
        int ContadorSLH = 0;
        int ContadorCVRH = 0;
        int ContadorCVLH = 0;
        int CajaRH2 = 0;
        int CajaLH2 = 0;
        int CajaRH3 = 0;
        int CajaLH3 = 0;
        public int scrap = 0;
        public int scrap2 = 0;

        public int pztotal = 0;
        public int pztotal2 = 0;

        public SerialPort SerialPort1;
        string line;
        int z;
        int[] negativos = new int[0];
        int[] positivos = new int[0];
        string[] Pillar = { "V2178070", "V2177241", "V2178687", "V2178690" };
        string[] PillarMTP = { "P104501", "P104502" };
        string[] Audi = { "2176968" };
        string[] AudiMTP = { "P104231", "P104232" };
        public Form1()
        {
            //Código para inicializar la conexión con Arduino

            #region "Arduino"
            InitializeComponent();
            SerialPort1 = new SerialPort();
            SerialPort1.PortName = "COM6";
            SerialPort1.BaudRate = 9600;
            SerialPort1.DtrEnable = true;
            SerialPort1.ReadTimeout = 500;
            // SerialPort1.Open();
            SerialPort1.DataReceived += SerialPort1_DataReceived;
            validacionOrden = new ValidacionOrden();

            #endregion
        }

        #region Metodos
        //
        public void sonidoplay()
        {
            try
            {
                sonido.Enabled = true;
                sonido.Start();

                if (sonidoP == null)
                {
                    sonidoP = new WindowsMediaPlayer();
                    sonidoP.URL = @"C:\Program Files (x86)\Default Company Name\InstaladorContador\mp3\Sonido.mp3";
                    sonidoP.controls.play();
                }
            }
            catch (Exception)
            {

            }

        }
        public void sonidostop()
        {
            try
            {
                if (sonidoP != null)
                {
                    sonidoP.controls.stop();
                    sonidoP = null;
                }
            }
            catch (Exception)
            {

            }


        }
        public void sonidoplay2()
        {
            try
            {
                Sonido2.Start();
                Sonido2.Enabled = true;
                if (sonidoP2 == null)
                {
                    sonidoP2 = new WindowsMediaPlayer();
                    sonidoP2.URL = @"C:\Program Files (x86)\Default Company Name\InstaladorContador\mp3\SonidoCaja.mp3";
                    sonidoP2.controls.play();
                }
            }
            catch (Exception)
            {

            }

        }
        public void sonidostop2()
        {
            try
            {
                if (sonidoP2 != null)
                {
                    sonidoP2.controls.stop();
                    sonidoP2 = null;
                    Sonido2.Stop();
                }

            }
            catch (Exception)
            {


            }


        }
        public void iniciarContadores()
        {
            SerialPort1.Close();
            SerialPort1.Open();
            countca = 0;
            countca2 = 0;
            lblCjas.Text = "0";
            lblCjas2.Text = "0";
            alerta1.lblcharola.Text = "0";
            alerta1.lblcharola2.Text = "0";
            CajasCount.Text = "0";
            CajasCount2.Text = "0";
            lblContadorOK.Text = "0";
            lblNotOk.Text = "0";
            ContadorSRH = 0;
            ContadorSLH = 0;
            ContadorCVRH = 0;
            ContadorCVLH = 0;
            LblContadorCVLH.Text = "0";
            LblContadorCVRH.Text = "0";
            LblContadorSLH.Text = "0";
            LblContadorSRH.Text = "0";
            impScrap.contador1 = 0;
            impScrap.contador2 = 0;
            impScrap.contador3 = 0;
            impScrap.contador4 = 0;
            impScrap.contador5 = 0;
            impScrap.contador6 = 0;
            impScrap.CadS1.Text = "0";
            impScrap.CadS2.Text = "0";
            impScrap.CadS3.Text = "0";
            impScrap.CadS4.Text = "0";
            impScrap.CadS5.Text = "0";
            impScrap.CadS6.Text = "0";
            impScrap2.CadS1.Text = "0";
            impScrap2.CadS2.Text = "0";
            impScrap2.CadS3.Text = "0";
            impScrap2.CadS4.Text = "0";
            impScrap2.CadS5.Text = "0";
            impScrap2.CadS6.Text = "0";
            lblpru.Text = "0";
            lblpru2.Text = "0";
        }
        //recopilamos y mandamos la informacion a EXCEL
        public void AbrirExcel()
        {
           DtgCiclos.DataSource = importar(@"Z:\Mantenimiento\Moldes Inyeccion\TIROS TOTALES X MOLDE.xlsx");
        }
        DataView importar(string nombreArchivo)

        {

            string conexion = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 12.0 Xml; HDR = YES';", nombreArchivo);

            OleDbConnection conector = new OleDbConnection(conexion);

            conector.Open();

            OleDbCommand consulta = new OleDbCommand("Select * from [" + TxtMolde.Text + "$]", conector);

            OleDbDataAdapter adaptador = new OleDbDataAdapter

            {

                SelectCommand = consulta

            };

            DataSet ds = new DataSet();

            adaptador.Fill(ds);



            conector.Close();

            return ds.Tables[0].DefaultView;

        }
        public void GuardarExcels() 
        {
            try
            {
                ExcelCiclos();
                Excel();
                if (TxtSupervisor.Text != "")
                {
                    ExcelSUPERVISOR();
                }
                else
                {

                }
            }
            catch (Exception)
            {


            }
        }
        public void ExcelCiclos()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(@"Z:\Mantenimiento\Moldes Inyeccion\TIROS TOTALES X MOLDE.xlsx");

                Microsoft.Office.Interop.Excel.Worksheet x = null;

                x = sheet.Sheets[TxtMolde.Text];

                Excel.Range userRange = x.UsedRange;
                int contRow = userRange.Rows.Count;
                int add = 2;
                x.Cells[add, 1] = LblCiclos.Text;
                sheet.Close(true);
                excel.Quit();


            }
            catch (Exception)
            {

            }


        }
        public void ExcelSUPERVISOR()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(@"Z:\Hoja de produccion diaria\"+TxtSupervisor.Text+".xlsx");

                Microsoft.Office.Interop.Excel.Worksheet x = null;

                x = sheet.Sheets["BILLION"];

                Excel.Range userRange = x.UsedRange;
                int contRow = userRange.Rows.Count;
                int add = contRow + 1;
                x.Cells[add, 1] = LblFecha.Text;
                x.Cells[add, 2] = LblHora.Text;
                x.Cells[add, 3] = TxtSupervisor.Text;
                x.Cells[add, 4] = Lbldescripcion.Text;
                x.Cells[add, 5] = LblMaquina.Text;
                x.Cells[add, 6] = LblPieza.Text;
                x.Cells[add, 7] = LblMarca.Text;
                x.Cells[add, 8] = TxtPID.Text;
                x.Cells[add, 9] = TxtSap1.Text;
                x.Cells[add, 10] = TxtSap2.Text;
                x.Cells[add, 11] = TxtBatch1.Text;
                x.Cells[add, 12] = TxtBatch1_2.Text;
                x.Cells[add, 13] = TxtBatch2.Text;
                x.Cells[add, 14] = TxtBatch2_2.Text;
                x.Cells[add, 15] = LblOK.Text;
                x.Cells[add, 16] = LblContadorSRH.Text;
                x.Cells[add, 17] = lblCjas.Text;
                sheet.Close(true);
                excel.Quit();


            }
            catch (Exception)
            {

            }


        }
        public void ExcelSUPERVISOR2()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(@"Z:\Hoja de produccion diaria\" + TxtSupervisor.Text + ".xlsx");

                Microsoft.Office.Interop.Excel.Worksheet x = null;

                x = sheet.Sheets["BILLION"];

                Excel.Range userRange = x.UsedRange;
                int contRow = userRange.Rows.Count;
                int add = contRow + 1;
                x.Cells[add, 1] = LblFecha.Text;
                x.Cells[add, 2] = LblHora.Text;
                x.Cells[add, 3] = TxtSupervisor.Text;
                x.Cells[add, 4] = Lbldescripcion.Text;
                x.Cells[add, 5] = LblMaquina.Text;
                x.Cells[add, 6] = LblPieza.Text;
                x.Cells[add, 7] = LblMarca.Text;
                x.Cells[add, 8] = TxtPID.Text;
                x.Cells[add, 9] = TxtSap1.Text;
                x.Cells[add, 10] = TxtSap2.Text;
                x.Cells[add, 11] = TxtBatch1.Text;
                x.Cells[add, 12] = TxtBatch1_2.Text;
                x.Cells[add, 13] = TxtBatch2.Text;
                x.Cells[add, 14] = TxtBatch2_2.Text;
                x.Cells[add, 15] = LblOK.Text;
                x.Cells[add, 16] = LblContadorSRH.Text;
                x.Cells[add, 17] = lblCjas.Text;
                sheet.Close(true);
                excel.Quit();


            }
            catch (Exception)
            {

            }


        }
        public void Excel()
        {
            
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\Hoja de produccion diaria\\Hoja de produccion diaria.xlsx");

            Microsoft.Office.Interop.Excel.Worksheet x = null;

            x = sheet.Sheets["BILLION"];


            Excel.Range userRange = x.UsedRange;
            int contRow = userRange.Rows.Count;
            int add = contRow + 1;
            x.Cells[add, 1] = LblFecha.Text;
            x.Cells[add, 2] = LblHora.Text;
            x.Cells[add, 3] = Lbldescripcion.Text;
            x.Cells[add, 4] = LblMaquina.Text;
            x.Cells[add, 5] = LblPieza.Text;
            x.Cells[add, 6] = LblMarca.Text;
            x.Cells[add, 7] = TxtPID.Text;
            x.Cells[add, 8] = TxtSap1.Text;
            x.Cells[add, 9] = TxtSap2.Text;
            x.Cells[add, 10] = TxtBatch1.Text;
            x.Cells[add, 11] = TxtBatch1_2.Text;
            x.Cells[add, 12] = TxtBatch2.Text;
            x.Cells[add, 13] = TxtBatch2_2.Text;
            x.Cells[add, 14] = LblOK.Text;
            x.Cells[add, 15] = LblContadorSRH.Text;
            x.Cells[add, 16] = lblCjas.Text;
            sheet.Close(true);
            excel.Quit();
           
        }
        public void Excel2()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\Hoja de produccion diaria\\Hoja de produccion diaria.xlsx");

            Microsoft.Office.Interop.Excel.Worksheet x = null;

            x = sheet.Sheets["BILLION"];

            Excel.Range userRange = x.UsedRange;
            int contRow = userRange.Rows.Count;
            int add = contRow + 1;
            x.Cells[add, 1] = LblFecha.Text;
            x.Cells[add, 2] = LblHora.Text;
            x.Cells[add, 3] = Lbldescripcion2.Text;
            x.Cells[add, 4] = LblMaquina2.Text;
            x.Cells[add, 5] = LblPieza2.Text;
            x.Cells[add, 6] = LblMarca2.Text;
            x.Cells[add, 7] = TxtPID2.Text;
            x.Cells[add, 8] = TxtSap1.Text;
            x.Cells[add, 9] = TxtSap2.Text;
            x.Cells[add, 10] = TxtBatch1.Text;
            x.Cells[add, 11] = TxtBatch1_2.Text;
            x.Cells[add, 12] = TxtBatch2.Text;
            x.Cells[add, 13] = TxtBatch2_2.Text;
            x.Cells[add, 14] = LblOK.Text;
            x.Cells[add, 15] = LblContadorSRH.Text;
            x.Cells[add, 16] = lblCjas.Text;
            sheet.Close(true);
            excel.Quit();

        }
        //La descripcion de cada proyecto que aparecera en pantalla
        public void Tiros()
        {
            try
            {
                LblCiclos.Text = DtgCiclos.Rows[0].Cells["CICLOS TOTALES"].Value.ToString();
                Settings.Default["CiclosMantenimiento"] = int.Parse(LblCiclos.Text);
                ciclos = int.Parse(LblCiclos.Text);
            }
            catch (Exception)
            {
            }
   

        }
        public void Descripcion()
        {
            try
            {
                if (LblPieza2.Text == "2176967")
                {
                    Lbldescripcion2.Text = "Audi Q5 Water drain strip LH";
                   
                }
                if (LblPieza.Text == "2176968")
                {
                    Lbldescripcion.Text = "Audi Q5 Water drain strip RH";
                    TxtMolde.Text = "AUDI Q5";
                }
                if (LblPieza2.Text == "V2178069")
                {
                    Lbldescripcion2.Text = "BMW G05/G07/G18-A-LH";
                }
                if (LblPieza.Text == "V2178070")
                {
                    Lbldescripcion.Text = "BMW G05/G07/G18-A-RH";
                    TxtMolde.Text = "G-05 A PILLAR G-07-G-18";
                }
                if (LblPieza2.Text == "V2177240")
                {
                    Lbldescripcion2.Text = "BMW G05/G07/G18-B-LH";
                }
                if (LblPieza.Text == "V2177241")
                {
                    Lbldescripcion.Text = "BMW G05/G07/G18-B-RH";
                    TxtMolde.Text = "G-05 B PILLAR G-07-G-18";
                }
                if (LblPieza2.Text == "V2178686")
                {
                    Lbldescripcion2.Text = "BMW G06-A-LH";
                }
                if (LblPieza.Text == "V2178687")
                {
                    Lbldescripcion.Text = "BMW G06-A-RH";
                    TxtMolde.Text = "G-06 A PILLAR";
                }
                if (LblPieza2.Text == "V2178689")
                {
                    Lbldescripcion2.Text = "BMW G06-B-LH";
                }
                if (LblPieza.Text == "V2178690")
                {
                    Lbldescripcion.Text = "BMW G06-B-RH";
                    TxtMolde.Text = "G-06 B PILLAR";
                }
                if (LblPieza2.Text == "V2179466")
                {
                    Lbldescripcion2.Text = "BMW G05-A-LH";
                }
                if (LblPieza.Text == "V2179467")
                {
                    Lbldescripcion.Text = "A pillar G05-A-RH ";
                    TxtMolde.Text = "VW 316 WATER DRAIN STRIP";
                }

                if (LblPieza2.Text == "2178928")
                {
                    Lbldescripcion2.Text = "Cd- enhancing sill cover LH";
                }
                if (LblPieza.Text == "2178929")
                {
                    Lbldescripcion.Text = "Cd- enhancing sill cover RH ";
                    TxtMolde.Text = "CD ENHANCING SILL COVER";
                }

                if (LblPieza2.Text == "2178930")
                {
                    Lbldescripcion2.Text = "Water Drain Strip LH";
                }
                if (LblPieza.Text == "2178931")
                {
                    Lbldescripcion.Text = "Water Drain Strip RH";
                    TxtMolde.Text = "WATER DRAIN STRIP";
                }

                try
                {
                    AbrirExcel();
                    Tiros();
                }
                catch (Exception)
                {

             
                }
       
            }
            catch (Exception)
            {

                throw;
            }
        }
        //el borde alerta cambiara de color en la cajas de texto 
        public void ValidarTxt()
        {
            if (CmbImpresoras.Text == "")
            {
                Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            }
            if (TxtPID.Text == string.Empty)
            {
                Validacion.SetHighlightColor(TxtPID, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                Validacion.SetHighlightColor(TxtPID, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            }
            if (CmbImpresoras2.Text == "")
            {
                Validacion.SetHighlightColor(CmbImpresoras2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                Validacion.SetHighlightColor(CmbImpresoras2, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            }
            if (TxtPID2.Text == string.Empty)
            {
                Validacion.SetHighlightColor(TxtPID2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                Validacion.SetHighlightColor(TxtPID2, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            }

        }
        //Limpiar cajas de texto
        public void limpiarTxt()
        {
            TxtBatch1.Clear();
            TxtBatch2.Clear();
            TxtBatch3.Clear();
            Txtcuantas.Clear();
            TxtSap1.Clear();
            TxtSap2.Clear();
            TxtSap3.Clear();
            CmbImpresoras.Items.Clear();
            CmbImpresoras2.Items.Clear();
            TxtcuantasNOK.Clear();
            CajasCount.Clear();
            CajasCount2.Clear();


        }
        //Validar la Materia prima sea  la correcta para el proyecto
        public void materiaPrima()
        {
            if (TxtSap1.Text != "")
            {


                if (Pillar[0] == LblPieza.Text || Pillar[1] == LblPieza.Text || Pillar[2] == LblPieza.Text || Pillar[3] == LblPieza.Text)
                {
                    if (PillarMTP[0] != TxtSap1.Text)
                    {
                        MessageBox.Show("Materia prima incorrecta");
                        TxtSap1.Clear();
                    }
                }
            }
            if (TxtSap2.Text != "")
            {


                if (Pillar[0] == LblPieza.Text || Pillar[1] == LblPieza.Text || Pillar[2] == LblPieza.Text || Pillar[3] == LblPieza.Text)
                {
                    if (PillarMTP[1] != TxtSap2.Text)
                    {
                        MessageBox.Show("Materia prima incorrecta");
                        TxtSap2.Clear();
                    }
                }
            }
            if (TxtSap1.Text != "")
            {


                if (Audi[0] == LblPieza.Text)
                {
                    if (AudiMTP[0] != TxtSap1.Text)
                    {
                        MessageBox.Show("Materia prima incorrecta");
                        TxtSap1.Clear();
                    }
                }
            }
            if (TxtSap2.Text != "")
            {


                if (Audi[0] == LblPieza.Text)
                {
                    if (AudiMTP[1] != TxtSap2.Text)
                    {
                        MessageBox.Show("Materia prima incorrecta");
                        TxtSap2.Clear();
                    }
                }
            }
        }
        //Validamos el pallet completo por pieza
        public void ValidarImp()
        {
            //
            try
            {


                int CajaRH = int.Parse(LblOK.Text);
                int CajaLH = int.Parse(LblNOK.Text);
                int R4 = int.Parse(lblpztotal.Text);



                if (R4 != 0)
                {
                    if (LblPieza.Text == "2176968" && LblPieza2.Text == "2176967")
                    {
                        if (CajaRH >= 270 && CajaLH >= 270)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }
                    else if (LblPieza.Text == "V2178070" && LblPieza2.Text == "V2178069")
                    {
                        if (CajaRH >= 1224 && CajaLH >= 1224)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();

                        }
                    }
                    else if (LblPieza.Text == "V2177241" && LblPieza2.Text == "V2177240")
                    {
                        if (CajaRH >= 986 && CajaLH >= 986)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
    
                    }
                    else if (LblPieza.Text == "V2178687" && LblPieza2.Text == "V2178686")
                    {
                        if (CajaRH >= 700 && CajaLH >= 700)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }

                    }
                    else if (LblPieza.Text == "V2178690" && LblPieza2.Text == "V2178689")
                    {
                        if (CajaRH >= 986 && CajaLH >= 986)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                        
                    }
                    else if (LblPieza.Text == "V2179467" && LblPieza2.Text == "V2179466")
                    {
                        if (CajaRH >= 1224 && CajaLH >= 1224)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }

                    else if (LblPieza.Text == "2178929" && LblPieza2.Text == "2178928")
                    {
                        if (CajaRH >= 480 && CajaLH >= 480)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }
                    else if (LblPieza.Text == "2178931" && LblPieza2.Text == "2178930")
                    {
                        if (CajaRH >= 560 && CajaLH >= 560)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }

                    else if (LblPieza.Text == "V2178070" && LblPieza2.Text == "V2178069")
                    {
                        if (CajaRH >= 1224 && CajaLH >= 1224)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }

                    else if (LblPieza.Text == "V2177241" && LblPieza2.Text == "V2177240")
                    {
                        if (CajaRH >= 986 && CajaLH >= 986)
                        {
                            voyimprimirTarima();
                            iniciarContadores();
                            sonidoplay();
                        }
                    }
                }
            } 
            catch (Exception)
            {

                
            }
}
        //Se muestra el nombre de sap de las impresoras
        public void impSap()
        {
            if (LblMaquina.Text == "Billion2 RH" && LblMaquina2.Text == "Billion2 LH")
            {
                LblimpSap.Text = "BnAudi RH";
                LblimpSap2.Text = "BnAudi LH";
            }
            else if (LblMaquina.Text == "Billion3 RH" && LblMaquina2.Text == "Billion3 LH")
            {
                LblimpSap.Text = "BnG06";
                LblimpSap2.Text = "BnG07";
            }
        }
        //Metodo para imprimir cuando una tarima esta completa
        public void voyimprimirTarima()
        {
            
            voyimprimir();
            voyimprimir2();
            GuardarExcels();
            ValorReal();
            countca = 0;
            countca2 = 0;
            pztotal = int.Parse(lblpztotal.Text);
            pztotal2 = int.Parse(lblpztotal2.Text);
            alerta1.lblcharola.Text = "0";
            alerta1.lblcontadorcaja.Text = "0";
            alerta1.lblcharola2.Text = "0";
            alerta1.lblcontadorcaja2.Text = "0";
            lblContadorOK.Text = "0";
            lblNotOk.Text = "0";
            lblCjas.Text = "0";
            lblCjas2.Text = "0";
            ContadorSLH = 0;
            ContadorSRH = 0;
            LblContadorSLH.Text = "0";
            LblContadorSRH.Text = "0";
            ContadorCVLH = 0;
            ContadorCVRH = 0;
            LblContadorCVLH.Text = "0";
            LblContadorCVRH.Text = "0";
            VaciarArreglo();
            SerialPort1.Close();
            SerialPort1.Open();

        }
        //Imprimir una etiqueta 
        public void voyimprimir()
        {
            try
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
            catch (Exception)
            {


            }


        }
        public void voyimprimir2()
        {
            try
            {
                try
                {
                    Excel2();
                }
                catch (Exception)
                {

                  
                }
                
                txtVacioCDB();
                //CADA VEZ QUE LE DEMOS IMPRIMIR SE CREE EL OBJETO
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += imprimirP2;
                printDocument1.PrinterSettings.PrinterName = CmbImpresoras2.Text;
                printDocument1.Print();
            }
            catch (Exception)
            {
            }

        }
        //validamos el numero de piezas para comenzar una orden parcial no sea mayor al permitido
        public bool ValidarNumDPz()
        {

            bool validar = true;

            int R = int.Parse(Txtcuantas.Text);

            if (R > 270 && LblPieza2.Text == "2176967" || R > 270 && LblPieza.Text == "2176968")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (R > 1224 && LblPieza2.Text == "V2178069" || R > 1224 && LblPieza.Text == "V2178070")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (R > 986 && LblPieza2.Text == "V2177240" || R > 986 && LblPieza.Text == "V2177241")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (R > 700 && LblPieza2.Text == "V2178686" || R > 700 && LblPieza.Text == "V2178687")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (R > 986 && LblPieza2.Text == "V2178689" || R > 986 && LblPieza.Text == "V2178690")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (R > 1224 && LblPieza2.Text == "V2179466" || R > 1224 && LblPieza.Text == "V2179467")
            {
                validar = false;
                MessageBox.Show("El Numero de piezas OK para comenzar son mayor al permitido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return validar;
        }
       //Metodo para el conteo de las cajas completas
        public void Validarcharola()
        {
            try
            {

                int caja = int.Parse(LblOK.Text);
                int caja2 = int.Parse(LblNOK.Text);

                if (LblPieza.Text == "2176968")
                    {
                        if (CmbOpc.Text == "Empaque 18 pz")
                        {

                            int mult = 18;
                            if (caja != 0)
                            {
                                if (caja % mult == 0)
                                {
                                    if (caja > int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca++;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo();
                                        //alerta1.ShowDialog();

                                    }
                                    else if (caja == int.Parse(alerta1.lblcharola.Text))
                                    {

                                        lblCjas.Text = Convert.ToString(countca);
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                    }
                                    else if (caja < int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca--;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                    }
                                    else
                                    {

                                    }
                                sonidoplay2();
                                }




                            }

                            else
                            {

                            }
                        }
                        else if (CmbOpc.Text == "Empaque 15 pz")
                        {

                            int mult = 15;
                            if (caja != 0)
                            {
                                if (caja % mult == 0)
                                {
                                    if (caja > int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca++;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo();
                                        //alerta1.ShowDialog();

                                    }
                                    else if (caja == int.Parse(alerta1.lblcharola.Text))
                                    {

                                        lblCjas.Text = Convert.ToString(countca);
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                    }
                                    else if (caja < int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca--;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                    }

                                    else
                                    {

                                    }
                                sonidoplay2();
                            }




                            }

                            else
                            {

                            }


                        }
                        else if (CmbOpc.Text == "Empaque 9 pz")
                        {

                            int mult = 9;

                            if (caja != 0)
                            {
                                if (caja % mult == 0)
                                {

                                    if (caja > int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca++;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo();
                                        //alerta1.ShowDialog();

                                    }
                                    else if (caja == int.Parse(alerta1.lblcharola.Text))
                                    {

                                        lblCjas.Text = Convert.ToString(countca);
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                    }
                                    else if (caja < int.Parse(alerta1.lblcharola.Text))
                                    {
                                        countca--;
                                        alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                        lblCjas.Text = Convert.ToString(countca);
                                        if (lblContadorOK.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo();
                                        alerta1.ShowDialog();
                                        alerta1.lblcharola.Text = Convert.ToString(caja);
                                    }

                                    else
                                    {

                                    }
                                sonidoplay2();
                            }




                            }

                            else
                            {

                            }
                        }

                    }
                    else if (LblPieza.Text == "V2178070")
                    {

                        int mult = 36;
                        if (caja != 0)
                        {
                            if (caja % mult == 0)
                            {
                                if (caja > int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca++;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo();
                                    //alerta1.ShowDialog();

                                }
                                else if (caja == int.Parse(alerta1.lblcharola.Text))
                                {

                                    lblCjas.Text = Convert.ToString(countca);
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                }
                                else if (caja < int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca--;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                }

                                else
                                {

                                }
                            sonidoplay2();
                        }




                        }
                        else
                        {

                        }
                    }
                    else if (LblPieza.Text == "V2177241")
                    {

                        int mult = 29;
                        if (caja != 0)
                        {
                            if (caja % mult == 0)
                            {

                                if (caja > int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca++;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo();
                                    //alerta1.ShowDialog();

                                }
                                else if (caja == int.Parse(alerta1.lblcharola.Text))
                                {

                                    lblCjas.Text = Convert.ToString(countca);
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                }
                                else if (caja < int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca--;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                }

                                else
                                {

                                }
                            sonidoplay2();
                        }




                        }

                        else
                        {

                        }

                    }
                    else if (LblPieza.Text == "V2178687")
                    {


                        int mult = 25;
                        if (caja != 0)
                        {
                            if (caja % mult == 0)
                            {
                                if (caja > int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca++;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo();
                                    //alerta1.ShowDialog();

                                }
                                else if (caja == int.Parse(alerta1.lblcharola.Text))
                                {

                                    lblCjas.Text = Convert.ToString(countca);
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                }
                                else if (caja < int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca--;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                }

                                else
                                {

                                }
                            sonidoplay2();
                        }




                        }

                        else
                        {

                        }
                    }
                    else if (LblPieza.Text == "V2178690")
                    {

                        int mult = 29;
                        if (caja != 0)
                        {
                            if (caja % mult == 0)
                            {

                                if (caja > int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca++;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo();
                                    //alerta1.ShowDialog();

                                }
                                else if (caja == int.Parse(alerta1.lblcharola.Text))
                                {

                                    lblCjas.Text = Convert.ToString(countca);
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                }
                                else if (caja < int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca--;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                }

                                else
                                {

                                }
                            sonidoplay2();
                        }




                        }

                        else
                        {

                        }
                    }
                    else if (LblPieza.Text == "V2179467")
                    {

                        int mult = 36;
                        if (caja != 0)
                        {
                            if (caja % mult == 0)
                            {

                                if (caja > int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca++;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo();
                                    //alerta1.ShowDialog();

                                }
                                else if (caja == int.Parse(alerta1.lblcharola.Text))
                                {

                                    lblCjas.Text = Convert.ToString(countca);
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                }
                                else if (caja < int.Parse(alerta1.lblcharola.Text))
                                {
                                    countca--;
                                    alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                    lblCjas.Text = Convert.ToString(countca);
                                    if (lblContadorOK.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo();
                                    alerta1.ShowDialog();
                                    alerta1.lblcharola.Text = Convert.ToString(caja);
                                }

                                else
                                {

                                }
                            sonidoplay2();
                        }




                        }

                        else
                        {

                        }
                    }

                else if (LblPieza.Text == "2178929")
                {

                    int mult = 32;
                    if (caja != 0)
                    {
                        if (caja % mult == 0)
                        {

                            if (caja > int.Parse(alerta1.lblcharola.Text))
                            {
                                countca++;
                                alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                lblCjas.Text = Convert.ToString(countca);
                                alerta1.lblcharola.Text = Convert.ToString(caja);
                                if (lblContadorOK.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                //VaciarArreglopositivo();
                                //alerta1.ShowDialog();

                            }
                            else if (caja == int.Parse(alerta1.lblcharola.Text))
                            {

                                lblCjas.Text = Convert.ToString(countca);
                                VaciarArreglopositivo();
                                alerta1.ShowDialog();
                            }
                            else if (caja < int.Parse(alerta1.lblcharola.Text))
                            {
                                countca--;
                                alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                lblCjas.Text = Convert.ToString(countca);
                                if (lblContadorOK.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                VaciarArreglopositivo();
                                alerta1.ShowDialog();
                                alerta1.lblcharola.Text = Convert.ToString(caja);
                            }

                            else
                            {

                            }
                            sonidoplay2();
                        }




                    }

                    else
                    {

                    }
                }

                else if (LblPieza.Text == "2178931")
                {

                    int mult = 14;
                    if (caja != 0)
                    {
                        if (caja % mult == 0)
                        {

                            if (caja > int.Parse(alerta1.lblcharola.Text))
                            {
                                countca++;
                                alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                lblCjas.Text = Convert.ToString(countca);
                                alerta1.lblcharola.Text = Convert.ToString(caja);
                                if (lblContadorOK.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                //VaciarArreglopositivo();
                                //alerta1.ShowDialog();

                            }
                            else if (caja == int.Parse(alerta1.lblcharola.Text))
                            {

                                lblCjas.Text = Convert.ToString(countca);
                                VaciarArreglopositivo();
                                alerta1.ShowDialog();
                            }
                            else if (caja < int.Parse(alerta1.lblcharola.Text))
                            {
                                countca--;
                                alerta1.lblcontadorcaja.Text = Convert.ToString(countca);
                                lblCjas.Text = Convert.ToString(countca);
                                if (lblContadorOK.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                VaciarArreglopositivo();
                                alerta1.ShowDialog();
                                alerta1.lblcharola.Text = Convert.ToString(caja);
                            }

                            else
                            {

                            }
                            sonidoplay2();
                        }




                    }

                    else
                    {

                    }
                }


                ValidarImp();
               
            }
            catch (Exception)
            {

                MessageBox.Show("Error al imprimir automatico");
            }
        }
        public void Validarcharola2()
        {
            try
            {
                int caja = int.Parse(LblOK.Text);
                int caja2 = int.Parse(LblNOK.Text);
                
                    if (LblPieza2.Text == "2176967")
                    {
                        if (CmbOpc.Text == "Empaque 18 pz")
                        {
                            int mult = 18;
                            if (caja2 != 0)
                            {
                                if (caja2 % mult == 0)
                                {
                                    if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2++;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo2();

                                    }
                                    else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                    {

                                        lblCjas2.Text = Convert.ToString(countca2);
                                        VaciarArreglopositivo2();
                                        //alerta4.ShowDialog();
                                    }
                                    else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2--;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo2();
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        //alerta4.ShowDialog();
                                    }
                                    else
                                    {

                                    }

                                }
                            }
                            else
                            {

                            }

                        }
                        else if (CmbOpc.Text == "Empaque 15 pz")
                        {

                            int mult = 15;
                            if (caja2 != 0)
                            {
                                if (caja2 % mult == 0)
                                {
                                    if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2++;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo2();

                                    }
                                    else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                    {

                                        lblCjas2.Text = Convert.ToString(countca2);
                                        VaciarArreglopositivo2();
                                        //alerta4.ShowDialog();
                                    }
                                    else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2--;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo2();
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        //alerta4.ShowDialog();
                                    }
                                    else
                                    {

                                    }

                                }
                            }
                            else
                            {

                            }
                        }
                        else if (CmbOpc.Text == "Empaque 9 pz")
                        {

                            int mult = 9;
                            if (caja2 != 0)
                            {
                                if (caja2 % mult == 0)
                                {
                                    if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2++;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        //VaciarArreglopositivo2();

                                    }
                                    else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                    {

                                        lblCjas2.Text = Convert.ToString(countca2);
                                        VaciarArreglopositivo2();
                                        //alerta4.ShowDialog();
                                    }
                                    else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                    {
                                        countca2--;
                                        alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        if (lblNotOk.Text != "0")
                                        {
                                            lblpru2.Text = Convert.ToString(caja2);
                                            lblpru.Text = Convert.ToString(caja);
                                        }
                                        VaciarArreglopositivo2();
                                        alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                        //alerta4.ShowDialog();
                                    }
                                    else
                                    {

                                    }

                                }
                            }
                            else
                            {

                            }
                        }

                    }
                    else if (LblPieza2.Text == "V2178069")
                    {

                        int mult = 36;
                        if (caja2 != 0)
                        {
                            if (caja2 % mult == 0)
                            {
                                if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2++;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo2();

                                }
                                else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                {

                                    lblCjas2.Text = Convert.ToString(countca2);
                                    VaciarArreglopositivo2();
                                    //alerta4.ShowDialog();
                                }
                                else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2--;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo2();
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    //alerta4.ShowDialog();
                                }
                                else
                                {

                                }

                            }
                        }
                        else
                        {

                        }
                    }
                    else if (LblPieza2.Text == "V2177240")
                    {

                        int mult = 29;
                        if (caja2 != 0)
                        {
                            if (caja2 % mult == 0)
                            {
                                if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2++;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo2();

                                }
                                else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                {

                                    lblCjas2.Text = Convert.ToString(countca2);
                                    VaciarArreglopositivo2();
                                    //alerta4.ShowDialog();
                                }
                                else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2--;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo2();
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    ////alerta4.ShowDialog();
                                }
                                else
                                {

                                }

                            }
                        }
                        else
                        {

                        }
                    }
                    else if (LblPieza2.Text == "V2178686")
                    {
                        int mult = 25;
                        if (caja2 != 0)
                        {
                            if (caja2 % mult == 0)
                            {
                                if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2++;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo2();

                                }
                                else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                {

                                    lblCjas2.Text = Convert.ToString(countca2);
                                    VaciarArreglopositivo2();
                                    //alerta4.ShowDialog();
                                }
                                else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2--;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo2();
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    //alerta4.ShowDialog();
                                }
                                else
                                {

                                }

                            }
                        }
                        else
                        {

                        }
                    }
                    else if (LblPieza2.Text == "V2178689")
                    {
                        int mult = 29;
                        if (caja2 != 0)
                        {
                            if (caja2 % mult == 0)
                            {
                                if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2++;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo2();

                                }
                                else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                {

                                    lblCjas2.Text = Convert.ToString(countca2);
                                    VaciarArreglopositivo2();
                                    //alerta4.ShowDialog();
                                }
                                else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2--;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo2();
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    //alerta4.ShowDialog();
                                }
                                else
                                {

                                }

                            }
                        }
                        else
                        {

                        }
                    }
                    else if (LblPieza2.Text == "V2179466")
                    {

                        int mult = 36;
                        if (caja2 != 0)
                        {
                            if (caja2 % mult == 0)
                            {
                                if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2++;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    //VaciarArreglopositivo2();

                                }
                                else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                                {

                                    lblCjas2.Text = Convert.ToString(countca2);
                                    VaciarArreglopositivo2();
                                    //alerta4.ShowDialog();
                                }
                                else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                                {
                                    countca2--;
                                    alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                    lblCjas2.Text = Convert.ToString(countca2);
                                    if (lblNotOk.Text != "0")
                                    {
                                        lblpru2.Text = Convert.ToString(caja2);
                                        lblpru.Text = Convert.ToString(caja);
                                    }
                                    VaciarArreglopositivo2();
                                    alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                    //alerta4.ShowDialog();
                                }
                                else
                                {

                                }

                            }
                        }
                        else
                        {

                        }
                    }

                else if (LblPieza2.Text == "2178928")
                {

                    int mult = 32;
                    if (caja2 != 0)
                    {
                        if (caja2 % mult == 0)
                        {
                            if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                            {
                                countca2++;
                                alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                lblCjas2.Text = Convert.ToString(countca2);
                                alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                if (lblNotOk.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                //VaciarArreglopositivo2();

                            }
                            else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                            {

                                lblCjas2.Text = Convert.ToString(countca2);
                                VaciarArreglopositivo2();
                                //alerta4.ShowDialog();
                            }
                            else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                            {
                                countca2--;
                                alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                lblCjas2.Text = Convert.ToString(countca2);
                                if (lblNotOk.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                VaciarArreglopositivo2();
                                alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                //alerta4.ShowDialog();
                            }
                            else
                            {

                            }

                        }
                    }
                    else
                    {

                    }
                }
                else if (LblPieza2.Text == "2178930")
                {

                    int mult = 14;
                    if (caja2 != 0)
                    {
                        if (caja2 % mult == 0)
                        {
                            if (caja2 > int.Parse(alerta1.lblcharola2.Text))
                            {
                                countca2++;
                                alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                lblCjas2.Text = Convert.ToString(countca2);
                                alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                if (lblNotOk.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                //VaciarArreglopositivo2();

                            }
                            else if (caja2 == int.Parse(alerta1.lblcharola2.Text))
                            {

                                lblCjas2.Text = Convert.ToString(countca2);
                                VaciarArreglopositivo2();
                                //alerta4.ShowDialog();
                            }
                            else if (caja2 < int.Parse(alerta1.lblcharola2.Text))
                            {
                                countca2--;
                                alerta1.lblcontadorcaja2.Text = Convert.ToString(countca2);
                                lblCjas2.Text = Convert.ToString(countca2);
                                if (lblNotOk.Text != "0")
                                {
                                    lblpru2.Text = Convert.ToString(caja2);
                                    lblpru.Text = Convert.ToString(caja);
                                }
                                VaciarArreglopositivo2();
                                alerta1.lblcharola2.Text = Convert.ToString(caja2);
                                //alerta4.ShowDialog();
                            }
                            else
                            {

                            }

                        }
                    }
                    else
                    {

                    }
                }

                ValidarImp();
            }
            catch (Exception)
            {

                //MessageBox.Show("Error al imprimir charola");
            }
        }
       
        //Limpiamos el arreglo de los datos recibidos
        public void VaciarArreglo()
        {
            for (int i = 0; i < negativos.Length; i++)
            {
                negativos[i] = Convert.ToInt32(null);

            }
            for (int i = 0; i < positivos.Length; i++)
            {
                positivos[i] = Convert.ToInt32(null);

            }
        }
        public void VaciarArreglopositivo()
        {

            for (int i = 0; i < positivos.Length; i++)
            {
                positivos[i] = Convert.ToInt32(null);

            }
        }
        public void VaciarArreglopositivo2()
        {

            for (int i = 0; i < negativos.Length; i++)
            {
                negativos[i] = Convert.ToInt32(null);

            }
        }
     //obtenemos el valor de los tiros menos el scrap y los tiros vacios
        public void ValorReal()
        {

            int R = int.Parse(lblContadorOK.Text);
            int R2 = ContadorSRH;
            int R3 = ContadorCVRH;
            int L = int.Parse(lblNotOk.Text);
            int L2 = ContadorSLH;
            int L3 = ContadorCVLH;

            if (R > 271)
            {
                CajaRH3 = R + R2 + R3;

                CajaLH3 = L - L2 - L3;
                lblpru.Text = Convert.ToString(CajaRH3);
            }
            else if (R < 270)
            {
                CajaRH3 = 1 + R - R2 - R3;

                CajaLH3 = L - L2 - L3;
            }
            {

            }

        }
        //Verificamos que los campos esten llenados
        public bool ValidarDatos()
        {

            bool validar = true;

            /* if (TxtBatch4.Text.Length == 0)
             {
                 validar = false;
                 MessageBox.Show("Batchs 4 Vacio favor de llenarlo");
             }*/
            if (TxtPID.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("PID Vacio favor de llenarlo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (CmbImpresoras.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Elegir impresora", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return validar;
        }
        public bool ValidarDatos2()
        {

            bool validar = true;

            /* if (TxtBatch4.Text.Length == 0)
             {
                 validar = false;
                 MessageBox.Show("Batchs 4 Vacio favor de llenarlo");
             }*/
            if (TxtPID2.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("PID LH Vacio favor de llenarlo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (CmbImpresoras2.Text.Length == 0)
            {
                validar = false;
                MessageBox.Show("Elegir impresora LH", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return validar;
        }
        //Diseño de las etiquetas
        private void imprimirP(object sender, PrintPageEventArgs e)
        {
            try
            {

                string PZOK = LblOK.Text;
                generar_codigo_barras();


                Font fontT = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
                Font fontN = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
                Font fontM = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);

                e.Graphics.DrawString("Proyecto ", fontN, Brushes.Black, new RectangleF(40, 60, 300, 500));
                e.Graphics.DrawString(Lbldescripcion.Text, fontN, Brushes.Black, new RectangleF(140, 60, 300, 500));

                e.Graphics.DrawString(LblFecha.Text, fontM, Brushes.Black, new RectangleF(40, 47, 300, 500));
                e.Graphics.DrawString(LblHora.Text, fontM, Brushes.Black, new RectangleF(250, 47, 300, 500));

                e.Graphics.DrawString("Etiqueta Interna", fontT, Brushes.Black, new RectangleF(400, 30, 300, 500));
                e.Graphics.DrawString("Piezas a producir", fontT, Brushes.Black, new RectangleF(40, 30, 300, 500));
                e.Graphics.DrawString(lblpztotal.Text, fontT, Brushes.Black, new RectangleF(180, 30, 300, 500));
                e.Graphics.DrawString(CmbImpresoras.Text, fontT, Brushes.Black, new RectangleF(550, 30, 300, 500));
                //Numero de orden
                e.Graphics.DrawString("Numero de Orden", fontT, Brushes.Black, new RectangleF(50, 80, 300, 500));
                e.Graphics.DrawString(LblMarca.Text, fontN, Brushes.Black, new RectangleF(250, 80, 400, 500));
                e.Graphics.DrawImage(PanelCodBMar.BackgroundImage, new Rectangle(40, 110, 250, 40));
                //Total de Piezas
                e.Graphics.DrawString("Total de piezas OK", fontT, Brushes.Black, new RectangleF(50, 160, 300, 500));
                e.Graphics.DrawString(PZOK, fontN, Brushes.Black, new RectangleF(250, 160, 300, 500));
                e.Graphics.DrawImage(panelCodBPz.BackgroundImage, new Rectangle(40, 190, 250, 40));

                e.Graphics.DrawString("Total de Piezas NOK", fontT, Brushes.Black, new RectangleF(50, 240, 300, 500));
                e.Graphics.DrawString(LblContadorSRH.Text, fontN, Brushes.Black, new RectangleF(250, 240, 300, 600));
                e.Graphics.DrawImage(PanelContadorSRH.BackgroundImage, new Rectangle(40, 270, 250, 40));

                //Nuemro de pieza
                e.Graphics.DrawString("Numero de pieza", fontT, Brushes.Black, new RectangleF(50, 320, 300, 500));
                e.Graphics.DrawString(LblPieza.Text, fontN, Brushes.Black, new RectangleF(250, 320, 300, 600));
                e.Graphics.DrawImage(PanelCodB.BackgroundImage, new Rectangle(40, 350, 250, 40));
                //Codigo cajas
                e.Graphics.DrawString("Numero de cajas", fontT, Brushes.Black, new RectangleF(50, 390, 300, 500));
                e.Graphics.DrawString(alerta1.lblcontadorcaja.Text, fontN, Brushes.Black, new RectangleF(250, 390, 300, 600));
                e.Graphics.DrawImage(PanelCodBPID.BackgroundImage, new Rectangle(40, 420, 250, 40));
                //Codigo PID
                e.Graphics.DrawString("PID", fontT, Brushes.Black, new RectangleF(50, 460, 300, 500));
                e.Graphics.DrawString(TxtPID.Text, fontN, Brushes.Black, new RectangleF(250, 460, 300, 600));
                e.Graphics.DrawImage(PanelCodBPID2.BackgroundImage, new Rectangle(40, 490, 250, 40));
                //Numero de maquina
                e.Graphics.DrawString("Numero de maquina", fontT, Brushes.Black, new RectangleF(450, 50, 300, 500));
                e.Graphics.DrawString(LblMaquina.Text, fontN, Brushes.Black, new RectangleF(450, 70, 300, 1000));
                e.Graphics.DrawImage(panelCodBMQ.BackgroundImage, new Rectangle(440, 100, 320, 70));
                //Numero de Batchs
                if (TxtBatch1.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 220, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap1.Text, fontT, Brushes.Black, new RectangleF(410, 190, 300, 500));
                    e.Graphics.DrawString(TxtBatch1.Text, fontN, Brushes.Black, new RectangleF(510, 190, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat1.BackgroundImage, new Rectangle(390, 220, 220, 50));
                }
                if (TxtBatch1_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 220, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch1_2.Text, fontN, Brushes.Black, new RectangleF(650, 190, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat1_2.BackgroundImage, new Rectangle(580, 220, 220, 50));
                }
                if (TxtBatch2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 320, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap2.Text, fontT, Brushes.Black, new RectangleF(410, 290, 300, 500));
                    e.Graphics.DrawString(TxtBatch2.Text, fontN, Brushes.Black, new RectangleF(510, 290, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat2.BackgroundImage, new Rectangle(390, 320, 220, 50));

                }
                if (TxtBatch2_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 320, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch2_2.Text, fontN, Brushes.Black, new RectangleF(650, 290, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat2_2.BackgroundImage, new Rectangle(580, 320, 220, 50));
                }

                if (TxtBatch3.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 400, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap3.Text, fontT, Brushes.Black, new RectangleF(410, 380, 300, 500));
                    e.Graphics.DrawString(TxtBatch3.Text, fontN, Brushes.Black, new RectangleF(510, 380, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat3.BackgroundImage, new Rectangle(390, 400, 220, 50));
                }
                if (TxtBatch3_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 400, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch3_2.Text, fontN, Brushes.Black, new RectangleF(650, 380, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat3_2.BackgroundImage, new Rectangle(580, 400, 220, 50));
                }
                if (TxtBatch4.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 480, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap4.Text, fontT, Brushes.Black, new RectangleF(410, 460, 300, 500));
                    e.Graphics.DrawString(TxtBatch4.Text, fontN, Brushes.Black, new RectangleF(510, 460, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat4.BackgroundImage, new Rectangle(390, 480, 220, 50));
                }
                if (TxtBatch4_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 480, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch4_2.Text, fontN, Brushes.Black, new RectangleF(650, 460, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat4_2.BackgroundImage, new Rectangle(580, 480, 220, 50));
                }


                // Create string to draw.
                String drawString = "_____________________________________________";
                String drawString2 = "_____________________________";
                String Horizontal = "______________________________________________________________";
                String Horizontal2 = "__________________________________";
                String textHoriz = "Materia Prima Utilizada";


                // Create font and brush.
                Font drawFont = new Font("Arial", 16);

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 20, 5, drawFormat);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 788, 5, drawFormat);
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 520, 1200, 100));
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 5, 1200, 100));

                e.Graphics.DrawString(Horizontal2, drawFont, drawBrush, new RectangleF(370, 160, 1200, 100));
                e.Graphics.DrawString(drawString2, drawFont, drawBrush, 370, 180, drawFormat);
                e.Graphics.DrawString(textHoriz, drawFont, drawBrush, 375, 200, drawFormat);

            }
            catch (Exception)
            {

                throw;
            }


        }
        private void imprimirP2(object sender, PrintPageEventArgs e)
        {
            try
            {
                int R = int.Parse(lblNotOk.Text);
                int R2 = ContadorSLH;
                int R3 = ContadorCVLH;
                string PZOK = LblNOK.Text;
                generar_codigo_barras2();

                Font fontT = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
                Font fontN = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
                Font fontM = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);

                e.Graphics.DrawString("Proyecto ", fontN, Brushes.Black, new RectangleF(40, 60, 300, 500));
                e.Graphics.DrawString(Lbldescripcion2.Text, fontN, Brushes.Black, new RectangleF(140, 60, 300, 500));

                e.Graphics.DrawString(LblFecha.Text, fontM, Brushes.Black, new RectangleF(40, 47, 300, 500));
                e.Graphics.DrawString(LblHora.Text, fontM, Brushes.Black, new RectangleF(250, 47, 300, 500));

                e.Graphics.DrawString("Etiqueta Interna", fontT, Brushes.Black, new RectangleF(400, 30, 300, 500));
                e.Graphics.DrawString("Piezas a producir", fontT, Brushes.Black, new RectangleF(40, 30, 300, 500));
                e.Graphics.DrawString(lblpztotal2.Text, fontT, Brushes.Black, new RectangleF(180, 30, 300, 500));
                e.Graphics.DrawString(CmbImpresoras2.Text, fontT, Brushes.Black, new RectangleF(550, 30, 300, 500));
                //Numero de orden
                e.Graphics.DrawString("Numero de Orden", fontT, Brushes.Black, new RectangleF(50, 80, 300, 500));
                e.Graphics.DrawString(LblMarca2.Text, fontN, Brushes.Black, new RectangleF(250, 80, 400, 500));
                e.Graphics.DrawImage(PanelCodBMar2.BackgroundImage, new Rectangle(40, 110, 250, 40));
                //Total de Piezas
                e.Graphics.DrawString("Total de piezas OK", fontT, Brushes.Black, new RectangleF(50, 160, 300, 500));
                e.Graphics.DrawString(PZOK, fontN, Brushes.Black, new RectangleF(250, 160, 300, 500));
                e.Graphics.DrawImage(panelCodBPzNOK.BackgroundImage, new Rectangle(40, 190, 250, 40));

                e.Graphics.DrawString("Total de Piezas NOK", fontT, Brushes.Black, new RectangleF(50, 240, 300, 500));
                e.Graphics.DrawString(LblContadorSLH.Text, fontN, Brushes.Black, new RectangleF(250, 240, 300, 600));
                e.Graphics.DrawImage(PanelContadorSLH.BackgroundImage, new Rectangle(40, 270, 250, 40));

                //Nuemro de pieza
                e.Graphics.DrawString("Numero de pieza", fontT, Brushes.Black, new RectangleF(50, 320, 300, 500));
                e.Graphics.DrawString(LblPieza2.Text, fontN, Brushes.Black, new RectangleF(250, 320, 300, 600));
                e.Graphics.DrawImage(panelCodBPz2.BackgroundImage, new Rectangle(40, 350, 250, 40));
                //Codigo cajas
                e.Graphics.DrawString("Numero de cajas", fontT, Brushes.Black, new RectangleF(50, 390, 300, 500));
                e.Graphics.DrawString(alerta1.lblcontadorcaja2.Text, fontN, Brushes.Black, new RectangleF(250, 390, 300, 600));
                e.Graphics.DrawImage(PanelCodBPID2.BackgroundImage, new Rectangle(40, 420, 250, 40));
                //Codigo PID
                e.Graphics.DrawString("PID", fontT, Brushes.Black, new RectangleF(50, 460, 300, 500));
                e.Graphics.DrawString(TxtPID2.Text, fontN, Brushes.Black, new RectangleF(250, 460, 300, 600));
                e.Graphics.DrawImage(PanelCodBPID3.BackgroundImage, new Rectangle(40, 490, 250, 40));
                //Numero de maquina
                e.Graphics.DrawString("Numero de maquina", fontT, Brushes.Black, new RectangleF(450, 50, 300, 500));
                e.Graphics.DrawString(LblMaquina2.Text, fontN, Brushes.Black, new RectangleF(450, 70, 300, 1000));
                e.Graphics.DrawImage(panelCodBMQ.BackgroundImage, new Rectangle(440, 100, 320, 70));
                //Numero de Batchs
                if (TxtBatch1.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 220, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap1.Text, fontT, Brushes.Black, new RectangleF(410, 190, 300, 500));
                    e.Graphics.DrawString(TxtBatch1.Text, fontN, Brushes.Black, new RectangleF(510, 190, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat1.BackgroundImage, new Rectangle(390, 220, 220, 50));
                }
                if (TxtBatch1_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 220, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch1_2.Text, fontN, Brushes.Black, new RectangleF(650, 190, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat1_2.BackgroundImage, new Rectangle(580, 220, 220, 50));
                }
                if (TxtBatch2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 320, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap2.Text, fontT, Brushes.Black, new RectangleF(410, 290, 300, 500));
                    e.Graphics.DrawString(TxtBatch2.Text, fontN, Brushes.Black, new RectangleF(510, 290, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat2.BackgroundImage, new Rectangle(390, 320, 220, 50));

                }
                if (TxtBatch2_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 320, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch2_2.Text, fontN, Brushes.Black, new RectangleF(650, 290, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat2_2.BackgroundImage, new Rectangle(580, 320, 220, 50));
                }

                if (TxtBatch3.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 400, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap3.Text, fontT, Brushes.Black, new RectangleF(410, 380, 300, 500));
                    e.Graphics.DrawString(TxtBatch3.Text, fontN, Brushes.Black, new RectangleF(510, 380, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat3.BackgroundImage, new Rectangle(390, 400, 220, 50));
                }
                if (TxtBatch3_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 400, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch3_2.Text, fontN, Brushes.Black, new RectangleF(650, 380, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat3_2.BackgroundImage, new Rectangle(580, 400, 220, 50));
                }
                if (TxtBatch4.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(410, 480, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtSap4.Text, fontT, Brushes.Black, new RectangleF(410, 460, 300, 500));
                    e.Graphics.DrawString(TxtBatch4.Text, fontN, Brushes.Black, new RectangleF(510, 460, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat4.BackgroundImage, new Rectangle(390, 480, 220, 50));
                }
                if (TxtBatch4_2.Text == ".")
                {
                    e.Graphics.DrawString("-----", fontT, Brushes.Black, new Rectangle(680, 480, 220, 50));
                }
                else
                {
                    e.Graphics.DrawString(TxtBatch4_2.Text, fontN, Brushes.Black, new RectangleF(650, 460, 300, 1000));
                    e.Graphics.DrawImage(panelCodBBat4_2.BackgroundImage, new Rectangle(580, 480, 220, 50));
                }


                // Create string to draw.
                String drawString = "_____________________________________________";
                String drawString2 = "_____________________________";
                String Horizontal = "______________________________________________________________";
                String Horizontal2 = "__________________________________";
                String textHoriz = "Materia Prima Utilizada";


                // Create font and brush.
                Font drawFont = new Font("Arial", 16);

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 20, 5, drawFormat);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 788, 5, drawFormat);
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 520, 1200, 100));
                e.Graphics.DrawString(Horizontal, drawFont, drawBrush, new RectangleF(20, 5, 1200, 100));

                e.Graphics.DrawString(Horizontal2, drawFont, drawBrush, new RectangleF(370, 160, 1200, 100));
                e.Graphics.DrawString(drawString2, drawFont, drawBrush, 370, 180, drawFormat);
                e.Graphics.DrawString(textHoriz, drawFont, drawBrush, 375, 200, drawFormat);
            }
            catch (Exception)
            {

                throw;
            }


        }
       //Cambiamos los datos vacios en las cajas de texto para validarlos e imprimir si se requieren
        public void txtVacioCDB()
        {
            if (TxtBatch1.Text.Length == 0)
            {
                TxtBatch1.Text = ".";
            }

            if (TxtBatch2.Text.Length == 0)
            {
                TxtBatch2.Text = ".";
            }

            if (TxtBatch3.Text.Length == 0)
            {
                TxtBatch3.Text = ".";
            }
            if (TxtBatch4.Text.Length == 0)
            {
                TxtBatch4.Text = ".";
            }
            if (TxtBatch1_2.Text.Length == 0)
            {
                TxtBatch1_2.Text = ".";
            }

            if (TxtBatch2_2.Text.Length == 0)
            {
                TxtBatch2_2.Text = ".";
            }

            if (TxtBatch3_2.Text.Length == 0)
            {
                TxtBatch3_2.Text = ".";
            }
            else
            {

            }
            if (TxtBatch4_2.Text.Length == 0)
            {
                TxtBatch4_2.Text = ".";
            }
            else
            {

            }


        }
        //Generador de codigo de barras
        public void generar_codigo_barras()
        {
            try
            {
                txtVacioCDB();
   
                string PZOK = LblOK.Text;
                BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
                codigoBarras.IncludeLabel = true;

                PanelCodB.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblPieza.Text, Color.Black, Color.White, 500, 100);
                PanelContadorSRH.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblContadorSRH.Text, Color.Black, Color.White, 500, 100);
                panelCodBPz.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, PZOK, Color.Black, Color.White, 500, 100);
                PanelCodBMar.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblMarca.Text, Color.Black, Color.White, 500, 100);
                panelCodBMQ.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblimpSap.Text, Color.Black, Color.White, 500, 100);
                PanelCodBPID.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, lblCjas.Text, Color.Black, Color.White, 500, 100);
                PanelCodBPID2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtPID.Text, Color.Black, Color.White, 500, 100);

                panelCodBBat1.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch1.Text, Color.Black, Color.White, 300, 100);
                panelCodBBat1_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch1_2.Text, Color.Black, Color.White, 300, 100);

                panelCodBBat2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch2.Text, Color.Black, Color.White, 300, 100);
                panelCodBBat2_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch2_2.Text, Color.Black, Color.White, 300, 100);

                #region
                //    panelCodBBat3.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch3.Text, Color.Black, Color.White, 300, 100);
                //    panelCodBBat3_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch3_2.Text, Color.Black, Color.White, 300, 100);

                //    panelCodBBat4.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch4.Text, Color.Black, Color.White, 300, 100);
                //    panelCodBBat4_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch4_2.Text, Color.Black, Color.White, 300, 100);
            }
            #endregion
            catch (Exception)
            {

                throw;
            }

        }
        public void generar_codigo_barras2()
        {
            try
            {
                txtVacioCDB();

                string PZOK = LblNOK.Text;
                BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
                codigoBarras.IncludeLabel = true;

                panelCodBPz2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblPieza2.Text, Color.Black, Color.White, 500, 100);

                PanelCodBMar2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblMarca2.Text, Color.Black, Color.White, 500, 100);
                panelCodBPzNOK.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, PZOK, Color.Black, Color.White, 500, 100);
                PanelContadorSLH.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblContadorSLH.Text, Color.Black, Color.White, 500, 100);
                panelCodBMQ.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, LblimpSap2.Text, Color.Black, Color.White, 500, 100);
                PanelCodBPID2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, lblCjas2.Text, Color.Black, Color.White, 500, 100);
                PanelCodBPID3.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtPID2.Text, Color.Black, Color.White, 500, 100);

                panelCodBBat1.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch1.Text, Color.Black, Color.White, 300, 100);
                panelCodBBat1_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch1_2.Text, Color.Black, Color.White, 300, 100);

                panelCodBBat2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch2.Text, Color.Black, Color.White, 300, 100);
                panelCodBBat2_2.BackgroundImage = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, TxtBatch2_2.Text, Color.Black, Color.White, 300, 100);
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                impSap();
                SerialPort1.Open();
                Validacion.SetHighlightColor(TxtPID, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                Validacion.SetHighlightColor(CmbImpresoras, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                Validacion.SetHighlightColor(TxtPID2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                Validacion.SetHighlightColor(CmbImpresoras2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                ValidarTxt();
                HoraFecha.Enabled = true;
                pictureBox3.Visible = true;
                limpiarTxt();
                lblContadorOK.Text = "0";
                lblCjas.Text = "0";
                lblCjas2.Text = "0";
                lblNotOk.Text = "0";
                LblContadorCVRH.Text = "0";
                LblContadorCVLH.Text = "0";
                alerta1.lblcharola.Text = "0";
                alerta1.lblcharola2.Text = "0";
                GrpImprimir.Visible = false;
                Descripcion();
                PopulateInstalledPrintersCombo();
                VaciarArreglo();
                scrap = 0;
                scrap2 = 0;
                labelPieza.Text = Convert.ToString(pztotal);
            }
            catch (Exception)
            {

                MessageBox.Show("Arduino esta desconectado");
            }



        }
        
        //aqui se reciben los datos
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

            
            //Código para leer lo que tiene el puerto serie
            string[] line = SerialPort1.ReadLine().Split(' ');
            int ok = Convert.ToInt32(line[0]);
            if (ok <= 0)
            {
                Array.Resize(ref negativos, negativos.Length + 1);
                negativos[negativos.Length - 1] = ok;
            }
            else
            {
                Array.Resize(ref positivos, positivos.Length + 1);
                positivos[positivos.Length - 1] = ok;
            }
            //line = SerialPort1.ReadLine();
            // line2 = SerialPort1.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en el contador de arduino revisar conexion o reiniciar programa");
            }
        }
        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)

        {
            //Código para mandar imprimir cada vez que el puerto serie llegue a "n" cantidad

            for (int i = 0; i < negativos.Length; i++)
            {
                lblNotOk.Text = Convert.ToString(negativos[i]).Trim('-');
                CajaLH2 = negativos[i];
            }
            for (int i = 0; i < positivos.Length; i++)
            {
                lblContadorOK.Text = Convert.ToString(positivos[i]);
                CajaRH2 = positivos[i];
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        //Lo que hara al darle Click a los botones
        private void BtnComOP_Click(object sender, EventArgs e)
        {


            try
            {
                int value1, value2, valor, valor2;
                bool rst = Int32.TryParse(Txtcuantas.Text, out value1);
                bool rst2 = Int32.TryParse(TxtcuantasNOK.Text, out value2);
                valor = int.Parse(Txtcuantas.Text);
                valor2 = int.Parse(TxtcuantasNOK.Text);
                if (valor >= 0)
                {
                    if (valor >= 0)
                    {
                        if (rst == true && value1 >= 0)
                        {

                            if (rst2 == true && value2 >= 0)
                            {
                                validacionOrden.ShowDialog();
                                SerialPort1.WriteLine(value1.ToString());
                                lblContadorOK.Text = Txtcuantas.Text;
                                Txtcuantas.Clear();
                                SerialPort1.WriteLine(value2.ToString());
                                lblNotOk.Text = TxtcuantasNOK.Text;
                                for (int i = 0; i < negativos.Length; i++)
                                {
                                    negativos[i] = Convert.ToInt32("-" + TxtcuantasNOK.Text);

                                }
                                TxtcuantasNOK.Clear();
                                GpOrdenP.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Piezas NOK incorrectas");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Piezas OK incorrectas");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas NOK");
                    }
                }
                else
                {
                    MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas OK");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al enviar los datos a arduino");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidarDatos() == true)
                {
                    DialogResult result = MessageBox.Show("¿Desea imprimir una etiqueta Parcial?", "Imprimir", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        txtVacioCDB();
                        //CADA VEZ QUE LE DEMOS IMPRIMIR SE CREE EL OBJETO
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += imprimirP;
                        printDocument1.Print();
                        SerialPort1.Close();
                        this.Close();
                        countca = 0;
                        lblContadorOK.Text = "0";
                        lblNotOk.Text = "0";
                    }
                    if (result == DialogResult.Cancel)
                    {

                    }


                }



            }
            catch (Exception)
            {

                MessageBox.Show("Error en el boton imprimir parcial");
            }


        }

        private void LblPieza_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resulta = MessageBox.Show("¿Desea Cerrar la ventana?", "Cerrar", MessageBoxButtons.OKCancel);
                if (resulta == DialogResult.OK)
                {
                    VaciarArreglo();
                    this.Close();
                  
                    countca = 0;
                    countca2 = 0;
                    ContadorSLH = 0;
                    ContadorSRH = 0;
                    ContadorCVLH = 0;
                    ContadorCVRH = 0;
                    pztotal = 1;
                    pztotal2 = 1;
                    alerta1.lblcharola.Text = "0";
                    alerta1.lblcontadorcaja.Text = "0";
                    alerta1.lblcharola2.Text = "0";
                    alerta1.lblcontadorcaja2.Text = "0";
                    LblContadorSRH.Text = "0";
                    LblContadorSLH.Text = "0";
                    LblContadorCVRH.Text = "0";
                    LblContadorCVLH.Text = "0";
                    lblContadorOK.Text = "0";
                    lblNotOk.Text = "0";
                    ValidarTxt();
                    SerialPort1.Close();
                }
                if (resulta == DialogResult.Cancel)
                {

                }


            }
            catch (Exception)
            {

               
            }
            

        }

        private void BtnMax_Click(object sender, EventArgs e)
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarrraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Txtcuantas_TextChanged(object sender, EventArgs e)
        {

        }
        //Solo aceptara numeros enteros
        private void Txtcuantas_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }
        //Mandar imprimir automaticamente cuando se llega al pallet completo
        private void LblMarca_TextChanged(object sender, EventArgs e)
        {

            validacionOrden.label3.Text = LblMarca.Text;
        }

        private void LblPieza_TextChanged(object sender, EventArgs e)
        {
            validacionOrden.label4.Text = LblPieza.Text;
            if (LblPieza.Text != "2176968")
            {
                CmbOpc.Visible = false;
            }
            else
            {
                CmbOpc.Visible = true;
            }
        }

        private void BarrraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
        // se vacia al darle doble click
        private void Txtcuantas_DoubleClick(object sender, EventArgs e)
        {
            Txtcuantas.Clear();
        }
        //lectura para la impresion automatica dependiendo del numero de parte y de la pieza
        private void lblContadorOK_TextChanged(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblContadorOK.Text) - ContadorCVRH - ContadorSRH;
            LblOK.Text = Convert.ToString(resultado);

            int A = int.Parse(LblOK.Text);
            int b = pztotal;
            int R2 = ContadorSRH;
            int R3 = ContadorCVRH;

            lblpztotal.Text = Convert.ToString(b - A);
        }

        private void lblContadorOK_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBatch1.Text) && TxtBatch1.Text[0] == 'H')
            {
                String texto = TxtBatch1.Text;
                TxtBatch1.Text = texto.Trim('H');
            }
        }

        private void TxtBatch1_DoubleClick(object sender, EventArgs e)
        {
            TxtBatch1.Clear();
        }

        private void TxtBatch2_DoubleClick(object sender, EventArgs e)
        {
            TxtBatch2.Clear();
        }

        private void TxtBatch3_DoubleClick(object sender, EventArgs e)
        {
            TxtBatch3.Clear();
        }

       

        private void TxtPID_DoubleClick(object sender, EventArgs e)
        {
            TxtPID.Clear();
        }

        private void Txtcuantas_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TxtcuantasNOK_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtcuantasNOK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void TxtBatch2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBatch2.Text) && TxtBatch2.Text[0] == 'H')
            {
                String texto = TxtBatch2.Text;
                TxtBatch2.Text = texto.Trim('H');
            }
        }

        private void TxtBatch3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBatch4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPID_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }
 

        private void TxtcuantasNOK_DoubleClick(object sender, EventArgs e)
        {
            TxtcuantasNOK.Clear();
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
                CmbImpresoras2.Items.Add(pkInstalledPrinters);
            }
        }


        private void CmbImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Set the printer to a printer in the combo box when the selection changes.

            if (CmbImpresoras.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                printDocument1.PrinterSettings.PrinterName = CmbImpresoras.Text;


            }
            if (CmbImpresoras.Text != LblMaquina.Text)
            {
                DialogResult resulta = MessageBox.Show("El nombre de la impresora no corresponde con la etiqueta RH", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (resulta == DialogResult.OK)
                {
                    CmbImpresoras.Text = LblMaquina.Text;
                }


            }
            else
            {

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblNotOk_TextChanged(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblNotOk.Text) - ContadorCVLH - ContadorSLH;
            LblNOK.Text = Convert.ToString(resultado);

            int A = int.Parse(LblNOK.Text);
            int b = pztotal2;
            lblpztotal2.Text = Convert.ToString(b - A);
        }

        private void TxtSap1_DoubleClick(object sender, EventArgs e)
        {
            TxtSap1.Clear();
        }

        private void TxtSap2_DoubleClick(object sender, EventArgs e)
        {
            TxtSap2.Clear();
        }

        private void TxtSap3_DoubleClick(object sender, EventArgs e)
        {
            TxtSap3.Clear();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidarNumDPz() == true)
                {
                    int value1, value2, valor, valor2;
                    bool rst = Int32.TryParse(Txtcuantas.Text, out value1);
                    bool rst2 = Int32.TryParse(TxtcuantasNOK.Text, out value2);
                    valor = int.Parse(Txtcuantas.Text);
                    valor2 = int.Parse(TxtcuantasNOK.Text);


                    if (valor >= 0)
                    {
                        if (valor >= 0)
                        {
                            if (rst == true && value1 >= 0)
                            {

                                if (rst2 == true && value2 >= 0)
                                {
                                    if (int.Parse(CajasCount.Text) >= 0)
                                    {

                                        validacionOrden.ShowDialog();
                                        SerialPort1.WriteLine(value1.ToString());
                                        lblContadorOK.Text = Txtcuantas.Text;
                                        SerialPort1.WriteLine(value2.ToString());
                                        lblNotOk.Text = TxtcuantasNOK.Text;
                                        for (int i = 0; i < negativos.Length; i++)
                                        {
                                            negativos[i] = Convert.ToInt32("-" + TxtcuantasNOK.Text);

                                        }
                                        GpOrdenP.Visible = false;
                                        countca = int.Parse(CajasCount.Text);
                                        countca2 = int.Parse(CajasCount2.Text);
                                        lblCjas.Text = Convert.ToString(countca);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        ContadorSRH = int.Parse(TxtScRH.Text);
                                        ContadorSLH = int.Parse(TxtScLH.Text);
                                        LblContadorSRH.Text = Convert.ToString(ContadorSRH);
                                        LblContadorSLH.Text = Convert.ToString(ContadorSLH);
                                        alerta1.lblcharola.Text = "0";
                                        alerta1.lblcharola2.Text = "0";
                                        TxtcuantasNOK.Clear();
                                        Txtcuantas.Clear();
                                        CajasCount.Clear();
                                        CajasCount2.Clear();
                                        GrbSracp.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Numero de cajas incorrecto");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Piezas NOK incorrectas");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Piezas OK incorrectas");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas NOK");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas OK");
                    }

                }
            }
            catch (Exception)
            {
               
                MessageBox.Show("Error al enviar los datos a arduino");
            }

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidarDatos() == true)
                {
                    DialogResult resulta = MessageBox.Show("¿El numero de Sap y los Batchs son correctos?", "Verificar", MessageBoxButtons.OKCancel);
                    if (resulta == DialogResult.OK)
                    {
                        DialogResult result = MessageBox.Show("¿Desea imprimir una etiqueta Parcial?", "Imprimir", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            voyimprimir();
                       
                        }
                        if (result == DialogResult.Cancel)
                        {

                        }


                    }
                    if (resulta == DialogResult.Cancel)
                    {

                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error en el boton imprimir parcial");
            }

        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            count = int.Parse(lblContadorOK.Text);
            count++;
            lblContadorOK.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = int.Parse(lblContadorOK.Text);
            count--;
            lblContadorOK.Text = count.ToString();
        }

        private void lblpru_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblpru_Click(object sender, EventArgs e)
        {

        }

        private void lblpru_TextChanged_1(object sender, EventArgs e)
        {
            //Validarcharola();
            //ValidarImp();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GpOrdenP_Enter(object sender, EventArgs e)
        {

        }

        private void CajasCount_DoubleClick(object sender, EventArgs e)
        {
            CajasCount.Clear();
        }

        private void TxtSap1_TextChanged(object sender, EventArgs e)
        {
            //materiaPrima();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (ValidarDatos2() == true)
                {
                    DialogResult resulta = MessageBox.Show("¿El numero de Sap y los Batchs son correctos?", "Verificar", MessageBoxButtons.OKCancel);
                    if (resulta == DialogResult.OK)
                    {
                        DialogResult result = MessageBox.Show("¿Desea imprimir una etiqueta Parcial?", "Imprimir", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            voyimprimir2();

                        }
                        if (result == DialogResult.Cancel)
                        {

                        }


                    }
                    if (resulta == DialogResult.Cancel)
                    {

                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error en el boton imprimir parcial");
            }
        }

        private void CmbImpresoras2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the printer to a printer in the combo box when the selection changes.

            if (CmbImpresoras2.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                printDocument1.PrinterSettings.PrinterName = CmbImpresoras2.Text;


            }
            if (CmbImpresoras2.Text != LblMaquina2.Text)
            {
                DialogResult resulta = MessageBox.Show("El nombre de la impresora no corresponde con la etiqueta LH", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (resulta == DialogResult.OK)
                {
                    CmbImpresoras2.Text = LblMaquina2.Text;
                }


            }
            else
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GrpImprimir.Visible = false;
            GrbSracp.Visible = true;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GrpImprimir.Visible = true;
            GrpImprimir.Location = new Point(98, 526);
            GrbSracp.Visible = false;
            pictureBox3.Visible = false;
        }

        private void BtnScrapRH_Click(object sender, EventArgs e)
        {
            ContadorSRH++;
            //pztotal++;
            //int a = int.Parse(lblpztotal.Text);
            //int b = 1;
            //lblpztotal.Text = Convert.ToString(a+b);
            LblContadorSRH.Text = Convert.ToString(ContadorSRH);
            int resultado = int.Parse(LblOK.Text) - ContadorCVRH - ContadorSRH;
            LblOK.Text = Convert.ToString(resultado);
        }

        private void BtnScrapLH_Click(object sender, EventArgs e)
        {
            ContadorSLH++;
            //pztotal2++;
            //int a = int.Parse(lblpztotal2.Text);
            //int b = 1;
            //lblpztotal2.Text = Convert.ToString(a + b);
            LblContadorSLH.Text = Convert.ToString(ContadorSLH);
            int resultado = int.Parse(lblNotOk.Text) - ContadorCVLH - ContadorSLH;
            LblNOK.Text = Convert.ToString(resultado);
        }

        private void lblCjas_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblpztotal_TextChanged(object sender, EventArgs e)
        {
            //Validarcharola();
            //ValidarImp();
        }

        private void LblMarca2_TextChanged(object sender, EventArgs e)
        {
            validacionOrden.label10.Text = LblMarca2.Text;
        }

        private void LblPieza2_TextChanged(object sender, EventArgs e)
        {
            validacionOrden.label9.Text = LblPieza2.Text;
        }

        private void TxtPID2_DoubleClick(object sender, EventArgs e)
        {
            TxtPID2.Clear();
        }

        private void TxtBatch1_2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBatch1_2.Text) && TxtBatch1_2.Text[0] == 'H')
            {
                String texto = TxtBatch1_2.Text;
                TxtBatch1_2.Text = texto.Trim('H');
            }
        }

        private void TxtBatch2_2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBatch2_2.Text) && TxtBatch2_2.Text[0] == 'H')
            {
                String texto = TxtBatch2_2.Text;
                TxtBatch2_2.Text = texto.Trim('H');
            }
        }

        private void TxtBatch2_2_DoubleClick(object sender, EventArgs e)
        {
            TxtBatch2_2.Clear();
        }

        private void TxtBatch1_2_DoubleClick(object sender, EventArgs e)
        {
            TxtBatch1_2.Clear();
        }

        private void CmbImpresoras_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }
      
        private void LblMaquina_TextChanged(object sender, EventArgs e)
        {
            impSap();
        }

        private void BtnCVRH_Click(object sender, EventArgs e)
        {
            GpbCiclos.Visible = true;
            BtnCVLH.Enabled = false;
            BtnCVRH.Enabled = false;
        }

        private void BtnCVLH_Click(object sender, EventArgs e)
        {
            ContadorCVLH++;
            pztotal2++;
            //int a = int.Parse(lblpztotal2.Text);
            
            //lblpztotal2.Text = Convert.ToString(a + b);
            LblContadorCVLH.Text = Convert.ToString(ContadorCVLH);
        }

        private void lblpztotal_Click(object sender, EventArgs e)
        {

        }

        private void LblMarca_TextChanged_1(object sender, EventArgs e)
        {
            validacionOrden.label3.Text = LblMarca.Text;
        }

        private void LblMarca2_TextChanged_1(object sender, EventArgs e)
        {
            validacionOrden.label10.Text = LblMarca2.Text;
        }

        private void TxtScRH_DoubleClick(object sender, EventArgs e)
        {
            TxtScRH.Clear();
        }

        private void TxtScLH_DoubleClick(object sender, EventArgs e)
        {
            TxtScLH.Clear();
        }

        private void CajasCount2_DoubleClick(object sender, EventArgs e)
        {
            CajasCount2.Clear();
        }

        private void CmbImpresoras2_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }

        private void TxtPID2_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }

        private void GrbSracp_Enter(object sender, EventArgs e)
        {

        }

        private void BtnEnvArd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarNumDPz() == true)
                {
                    int value1, value2, valor, valor2;
                    bool rst = Int32.TryParse(Txtcuantas.Text, out value1);
                    bool rst2 = Int32.TryParse(TxtcuantasNOK.Text, out value2);
                    valor = int.Parse(Txtcuantas.Text);
                    valor2 = int.Parse(TxtcuantasNOK.Text);


                    if (valor >= 0)
                    {
                        if (valor >= 0)
                        {
                            if (rst == true && value1 >= 0)
                            {

                                if (rst2 == true && value2 >= 0)
                                {
                                    if (int.Parse(CajasCount.Text) >= 0)
                                    {
                                        SerialPort1.WriteLine(value1.ToString());
                                        lblContadorOK.Text = Txtcuantas.Text;
                                        SerialPort1.WriteLine(value2.ToString());
                                        lblNotOk.Text = TxtcuantasNOK.Text;
                                        for (int i = 0; i < negativos.Length; i++)
                                        {
                                            negativos[i] = Convert.ToInt32("-" + TxtcuantasNOK.Text);

                                        }
                                        GpOrdenP.Visible = false;
                                        countca = int.Parse(CajasCount.Text);
                                        countca2 = int.Parse(CajasCount2.Text);
                                        lblCjas.Text = Convert.ToString(countca);
                                        lblCjas2.Text = Convert.ToString(countca2);
                                        ContadorSRH = int.Parse(TxtScRH.Text);
                                        ContadorSLH = int.Parse(TxtScLH.Text);
                                        LblContadorSRH.Text = Convert.ToString(ContadorSRH);
                                        LblContadorSLH.Text = Convert.ToString(ContadorSLH);
                                        alerta1.lblcharola.Text = "0";
                                        alerta1.lblcharola2.Text = "0";
                                        TxtcuantasNOK.Clear();
                                        Txtcuantas.Clear();
                                        CajasCount.Clear();
                                        CajasCount2.Clear();
                                        GrbSracp.Visible = true;
                                        BtnEnvArd.Visible = false;
                                        BtnEnvArd.Enabled = false;
                                        BtnComezar.Visible = true;
                                        BtnComezar.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Numero de cajas incorrecto");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Piezas NOK incorrectas");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Piezas OK incorrectas");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas NOK");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Numero incorrecto no puedes empezar con 0 piezas OK");
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al enviar los datos a arduino");
            }
        }


        private void BtnCVLH_Click_2(object sender, EventArgs e)
        {
            GpbCiclos2.Visible = true;
            BtnCVLH.Enabled = false;
            BtnCVRH.Enabled = false;
        }

        private void LblContadorSRH_TextChanged(object sender, EventArgs e)
        {
            if (scrap < int.Parse(LblContadorSRH.Text))
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ImpScrap);

                if (frm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    frm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                frm = new ImpScrap();
                frm.Show();
                scrap = int.Parse(LblContadorSRH.Text);
            }
        }

        private void LblContadorSLH_TextChanged(object sender, EventArgs e)
        {
            if (scrap2 < int.Parse(LblContadorSLH.Text))
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ImpScrap2);

                if (frm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    frm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                frm = new ImpScrap2();
                frm.Show();
                scrap2 = int.Parse(LblContadorSLH.Text);
            }
        }

        private void LblContadorCVRH_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void LblContadorCVLH_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnImpScrap2_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ImpScrap2);

                if (frm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    frm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                frm = new ImpScrap2();
                frm.Show();
                scrap2 = int.Parse(LblContadorSLH.Text);
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ImpScrap);

                if (frm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    frm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                frm = new ImpScrap();
                frm.Show();
                scrap = int.Parse(LblContadorSRH.Text);
            }
            catch (Exception)
            {

                
            }
        }

        private void TxtSap2_TextChanged(object sender, EventArgs e)
        {
            //materiaPrima();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void LblOK_TextChanged(object sender, EventArgs e)
        {
            Validarcharola();
            LblCiclos.Text = Convert.ToString( ciclos - int.Parse(LblOK.Text));
        }

        private void LblNOK_TextChanged(object sender, EventArgs e)
        {
            Validarcharola2();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           int promediocajas = int.Parse(LblOK.Text);
           
            if (LblOK.Text !="0")
            {
                if (CmbOpc.Text == "Empaque 18 pz")
                {
                    double promedio = promediocajas / 18;
                    countca =Convert.ToInt32( Math.Round(promedio));
                    lblCjas.Text = Convert.ToString(countca);
                    countca2 = Convert.ToInt32(Math.Round(promedio));
                    lblCjas2.Text = Convert.ToString(countca);
                }
                else if (CmbOpc.Text == "Empaque 15 pz")
                {
                    double promedio = promediocajas / 15;
                    countca = Convert.ToInt32(Math.Round(promedio));
                    lblCjas.Text = Convert.ToString(countca);
                    countca2 = Convert.ToInt32(Math.Round(promedio));
                    lblCjas2.Text = Convert.ToString(countca);
                }
                else if (CmbOpc.Text == "Empaque 9 pz")
                {
                    double promedio = promediocajas / 9;
                    countca = Convert.ToInt32(Math.Round(promedio));
                    lblCjas.Text = Convert.ToString( countca);
                    countca2 = Convert.ToInt32(Math.Round(promedio));
                    lblCjas2.Text = Convert.ToString(countca);
                }

            }
        }


        private void BtnTCiclos_Click(object sender, EventArgs e)
        {
            
            ContadorCVRH = int.Parse(TxtCiclosRH.Text);
            int total = ContadorCVRH + int.Parse(labelPieza.Text) ;
            int totalR = total- ContadorCVRH;
            pztotal = totalR;
            LblContadorCVRH.Text = Convert.ToString(ContadorCVRH);
            int resultado = int.Parse(LblOK.Text) - ContadorCVRH - ContadorSRH;
            LblOK.Text = Convert.ToString(resultado);

            GpbCiclos.Visible = false;
            BtnCVLH.Enabled = true;
            BtnCVRH.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ContadorCVLH = int.Parse(TxtCiclosLH.Text);
            int total = ContadorCVLH + int.Parse(labelPieza.Text);
            int totalR = total - ContadorCVLH;
            pztotal2 = totalR;
            LblContadorCVLH.Text = Convert.ToString(ContadorCVLH);
            int resultado = int.Parse(LblNOK.Text) - ContadorCVLH - ContadorSLH;
            LblNOK.Text = Convert.ToString(resultado);
            lblpztotal2.Text = Convert.ToString(pztotal2);
            GpbCiclos2.Visible = false;
            BtnCVLH.Enabled = true;
            BtnCVRH.Enabled = true;
        }

        private void sonido_Tick(object sender, EventArgs e)
        {
            sonidostop();
        }

        private void Sonido2_Tick(object sender, EventArgs e)
        {
            sonidostop2();
        }

        private void TxtCiclosLH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtCiclosRH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LblCiclos_TextChanged(object sender, EventArgs e)
        {
            if (LblCiclos.Text == "10000")
            {
                try
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AlertaMantenimiento);

                    if (frm != null)
                    {
                        //si la instancia existe la pongo en primer plano
                        frm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    frm = new AlertaMantenimiento();
                    frm.Show();
                    sonidoplay2();
                }
                catch (Exception)
                {


                }
            }
           else if (LblCiclos.Text == "5000")
            {
                try
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AlertaMantenimiento);

                    if (frm != null)
                    {
                        //si la instancia existe la pongo en primer plano
                        frm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    frm = new AlertaMantenimiento();
                    frm.Show();
                    sonidoplay2();
                }
                catch (Exception)
                {


                }
            }
            else if (LblCiclos.Text == "2500")
            {
                try
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AlertaMantenimiento);

                    if (frm != null)
                    {
                        //si la instancia existe la pongo en primer plano
                        frm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    frm = new AlertaMantenimiento();
                    frm.Show();
                }
                catch (Exception)
                {


                }
            }
            else if(LblCiclos.Text == "1000")
            {
                try
                {
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AlertaMantenimiento);

                    if (frm != null)
                    {
                        //si la instancia existe la pongo en primer plano
                        frm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    frm = new AlertaMantenimiento();
                    frm.Show();
                    sonidoplay2();
                }
                catch (Exception)
                {


                }
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelCiclos();
                Excel();
                Excel2();
                if (TxtSupervisor.Text != "")
                {
                    ExcelSUPERVISOR();
                }
                else
                {

                }
                MessageBox.Show("Datos Guardados");
            }
            catch (Exception)
            {

            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
 
            if (estadoBotonMenu == 0)
            {
                GrpMenu.Location = new Point(1, 42);
                GrpMenu.Visible = true;
                estadoBotonMenu = 1;
            }
            else if (estadoBotonMenu == 1)
            {
                GrpMenu.Visible = false;
                estadoBotonMenu = 0;
            }
          
          
        }

        private void BtnParosProd_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ParosProgramados);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new ParosProgramados();
            frm.Show();
        }
    }
}
