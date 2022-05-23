using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjizara
{
    public partial class MainA : Form
    {
        public MainA()
        {
            InitializeComponent();
        }

        private void promeniKnjiguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form forma = new Proizvodi();
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }

        private void stanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form forma = new Stanje();
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }
    }
}
