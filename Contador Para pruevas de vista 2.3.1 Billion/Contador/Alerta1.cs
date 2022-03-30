using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contador
{
    public partial class Alerta1 : Form
    {
        public Alerta1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.Close();
            timer1.Stop();

        }

        private void Alerta1_Load(object sender, EventArgs e)
        {
           timer1.Start();
        }
    }
}
