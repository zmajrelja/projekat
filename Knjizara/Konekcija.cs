using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Knjizara
{
    class Konekcija
    {

        static public SqlConnection konekcija()
        {

            return new SqlConnection("Data Source = DESKTOP-9OEBP15\\SQLEXPRESS;Initial Catalog = Knjizara; Integrated Security=true;");
        
        }

    }
}
