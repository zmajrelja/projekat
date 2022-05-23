using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Knjizara
{
    public partial class log_in : Form
    {
        public log_in()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox2.PasswordChar = '\0';
            else textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form forma = new sign_up();
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter($"select top 1 id, uloga, ime, prezime from osoba where username = '{textBox1.Text}' and pass = '{textBox2.Text}'", Konekcija.konekcija());
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            if (tabela.Rows.Count == 0)
            {
                textBox2.Text = "";
                MessageBox.Show("pogresan username ili password");
            }
            else
            {
                Program.ime = tabela.Rows[0]["ime"].ToString();
                Program.prezime = tabela.Rows[0]["prezime"].ToString();
                Program.uloga = (int)tabela.Rows[0]["uloga"];
                Program.korisnik = (int)tabela.Rows[0]["id"];
                this.Close();
            }

        }

    }
}
