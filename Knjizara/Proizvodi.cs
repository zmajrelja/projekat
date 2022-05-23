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
    public partial class Proizvodi : Form
    {
        public Proizvodi()
        {
            InitializeComponent();
        }

        private void Proizvodi_Load(object sender, EventArgs e)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, naziv from magacin", Konekcija.konekcija());
            adapter.Fill(tabela);
            comboBox1.DataSource = tabela;
            comboBox1.DisplayMember = "naziv";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = -1;

            adapter = new SqlDataAdapter($"select id, ime + ' ' + prezime 'naziv' from autor", Konekcija.konekcija());
            tabela = new DataTable();
            adapter.Fill(tabela);
            comboBox3.DataSource = tabela;
            comboBox3.DisplayMember = "naziv";
            comboBox3.ValueMember = "id";

            adapter = new SqlDataAdapter($"select id, naziv from zanr", Konekcija.konekcija());
            tabela = new DataTable();
            adapter.Fill(tabela);
            comboBox4.DataSource = tabela;
            comboBox4.DisplayMember = "naziv";
            comboBox4.ValueMember = "id";

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.IsHandleCreated && comboBox1.Focused)
            {

                comboBox2.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button2.Enabled = true;

                DataTable tabela = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("select id, naziv from knjiga", Konekcija.konekcija());
                adapter.Fill(tabela);
                comboBox2.DataSource = tabela;
                comboBox2.DisplayMember = "naziv";
                comboBox2.ValueMember = "id";
                comboBox2.SelectedIndex = -1;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.konekcija();

            SqlCommand naredba = new SqlCommand($"insert into knjigamagacin values ({comboBox2.SelectedValue}, {comboBox1.SelectedValue}, {textBox2.Text}, {textBox3.Text})", veza);

            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();

            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1)
            {
                
                SqlConnection veza = Konekcija.konekcija();

                SqlCommand naredba = new SqlCommand($"insert into knjiga values ('{textBox1.Text}', {comboBox3.SelectedValue}, {comboBox4.SelectedValue})", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

                textBox1.Text = "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text))
            {

                SqlConnection veza = Konekcija.konekcija();

                SqlCommand naredba = new SqlCommand($"insert into autor values ('{textBox4.Text}', '{textBox5.Text}')", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

                textBox5.Text = "";
                textBox4.Text = "";

                SqlDataAdapter adapter = new SqlDataAdapter($"select id, ime + ' ' + prezime 'naziv' from autor", Konekcija.konekcija());

                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                comboBox3.DataSource = tabela;
                comboBox3.DisplayMember = "naziv";
                comboBox3.ValueMember = "id";

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) || !string.IsNullOrEmpty(textBox5.Text))
            {

                SqlConnection veza = Konekcija.konekcija();

                SqlCommand naredba = new SqlCommand($"insert into zanr values ('{textBox6.Text}')", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

                textBox6.Text = "";

                SqlDataAdapter adapter = new SqlDataAdapter($"select id, naziv from zanr", Konekcija.konekcija());
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                comboBox4.DataSource = tabela;
                comboBox4.DisplayMember = "naziv";
                comboBox4.ValueMember = "id";

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) || !string.IsNullOrEmpty(textBox8.Text))
            {

                SqlConnection veza = Konekcija.konekcija();

                SqlCommand naredba = new SqlCommand($"insert into magacin values ('{textBox7.Text}', '{textBox8.Text}')", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

                textBox7.Text = "";
                textBox8.Text = "";

                SqlDataAdapter adapter = new SqlDataAdapter($"select id, naziv from magacin", Konekcija.konekcija());

                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                comboBox1.DataSource = tabela;
                comboBox1.DisplayMember = "naziv";
                comboBox1.ValueMember = "id";

            }
        }
    }
}
