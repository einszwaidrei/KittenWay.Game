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
    public partial class MenuPanel : Form
    {
        Thread th;
        public MenuPanel()
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
            Application.Run(new Form1());
        }

        public void Open1(object obj)
        {
            Application.Run(new Control());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
