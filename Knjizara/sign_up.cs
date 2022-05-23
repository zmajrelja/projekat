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
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox2.PasswordChar = '\0';
            else textBox2.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) textBox3.PasswordChar = '\0';
            else textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text && textBox1.Text.Length * textBox2.Text.Length * textBox4.Text.Length * textBox5.Text.Length > 0)
            {

                try
                {
                    SqlConnection konekcija = Konekcija.konekcija();
                    SqlCommand komanda = new SqlCommand($"insert into osoba (ime, prezime, username, pass, uloga) values" +
                        $"('{textBox4.Text}','{textBox5.Text}','{textBox1.Text}','{textBox2.Text}', 1)", konekcija);
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    konekcija.Close();

                    this.Close();
                }
                catch
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Username postoji");
                }
            }
            else if (textBox4.Text.Length == 0)
                MessageBox.Show("Unesite ime");
            else if (textBox5.Text.Length == 0)
                MessageBox.Show("Unesite prezime");
            else if (textBox1.Text.Length == 0)
                MessageBox.Show("Unesite username");
            else if (textBox2.Text.Length == 0)
                MessageBox.Show("Unesite password");
            else if (textBox2.Text != textBox3.Text)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Pogresan password");
            }
        }
    }
}
