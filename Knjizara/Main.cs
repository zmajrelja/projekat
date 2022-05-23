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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapter;
        DataTable tabela;
        DataTable tabelak;
        private void Main_Load(object sender, EventArgs e)
        {
            
            adapter = new SqlDataAdapter("select * from stanje", Konekcija.konekcija());
            tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            
            tabelak = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "knjigamagacinid";
            dc.DataType = typeof(int);
            tabelak.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "kolicina";
            dc.DataType = typeof(int);
            tabelak.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "fakturahid";
            dc.DataType = typeof(int);
            tabelak.Columns.Add(dc);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index > -1)
            {

                DataRow dr = tabelak.NewRow();
                dr["knjigamagacinid"] = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                dr["kolicina"] = Convert.ToInt32(textBox1.Text);
                tabelak.Rows.Add(dr);

                listBox1.Items.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["naziv"].Value + " - " + textBox1.Text);
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int br;

            try
            {
                SqlConnection veza = Konekcija.konekcija();
                SqlCommand naredba = new SqlCommand($"insert into FakturaH values ({Program.korisnik}, 0, GETDATE())", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

                adapter = new SqlDataAdapter("select top 1 * from fakturah order by datum desc", Konekcija.konekcija());
                DataTable pomocna = new DataTable();
                adapter.Fill(pomocna);

                br = Convert.ToInt32(pomocna.Rows[0]["id"]);

                for (int i = 0; i < tabelak.Rows.Count; i++)
                {
                    tabelak.Rows[i]["fakturahid"] = br;
                }

                
                adapter = new SqlDataAdapter("select * from fakturaB", Konekcija.konekcija());
                adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetInsertCommand();
                if (tabelak != null)
                    adapter.Update(tabelak);

            }
            catch
            {

                SqlConnection veza = Konekcija.konekcija();

                adapter = new SqlDataAdapter("select top 1 * from fakturah order by datum desc", Konekcija.konekcija());
                DataTable pomocna = new DataTable();
                adapter.Fill(pomocna);

                br = Convert.ToInt32(pomocna.Rows[0]["id"]);

                SqlCommand naredba = new SqlCommand($"delete from fakturah where id = {br}", veza);

                veza.Open();
                naredba.ExecuteNonQuery();
                veza.Close();

            }

            tabelak.Clear();

            listBox1.DataSource = tabelak;

            adapter = new SqlDataAdapter("select * from stanje", Konekcija.konekcija());
            tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
        }
    }
}
