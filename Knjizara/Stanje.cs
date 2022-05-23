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
    public partial class Stanje : Form
    {
        public Stanje()
        {
            InitializeComponent();
        }
        DataTable tabela;
        SqlDataAdapter adapter;
        private void Stanje_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from stanje",Konekcija.konekcija());
            tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            adapter = new SqlDataAdapter("select * from knjigamagacin", Konekcija.konekcija());
            DataTable tabela2 = new DataTable();
            adapter.Fill(tabela2);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {

                tabela2.Rows[i]["kolicina"] = tabela.Rows[i]["kolicina"];

            }

            DataTable promena = tabela2.GetChanges();
            adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
            if (promena != null)
                adapter.Update(promena);

        }


        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.ColumnIndex != 3)
                dataGridView1.ReadOnly = true;
            else
                dataGridView1.ReadOnly = false;
        }
    }
}
