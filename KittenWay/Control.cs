using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KittenWay
{
    public partial class Control : Form
    {
        Thread th;
        public Control()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Open);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void Open(object obj)
        {
            Application.Run(new MenuPanel());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
