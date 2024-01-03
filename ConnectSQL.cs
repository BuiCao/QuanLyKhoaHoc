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
                string con_str = @"Data Source=LAPTOP-M5TUKMA4;Initial Catalog=HocTiengAnh;User ID=sa;Password=123456";
            SqlConnection conn = new SqlConnection(con_str);
                return conn;
            }
        
  

       

        
    }
}
