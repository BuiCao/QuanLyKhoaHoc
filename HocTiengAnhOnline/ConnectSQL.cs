using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HocTiengAnhOnline
{
    public class ConnectSQL
    {
            public SqlConnection connection()
            {
                // của gsu
                // string con_str = @"Data Source=DESKTOP-859KE90;Initial Catalog=HocTiengAnh;Integrated Security=True";
                // của huy
                string con_str = @"Data Source=ADMIN;Initial Catalog=HocTiengAnh1;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                return conn;
            }
        
  

       

        
    }
}
