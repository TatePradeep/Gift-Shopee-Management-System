using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GiftShopee
{
    class Class1
    {
        public string ProductID;
        public string ProductName;
        public string Price;
        public string Category;
        public string newprice;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QQ7FMUC;Initial Catalog=Register_info;Integrated Security=True");
        SqlCommand cmd;
        public int add_data(string ProductID, string ProductName, string Price, string Category)
        {
            string str = "insert into GiftShop values(" + ProductID + ",'" + ProductName + "'," + Price + ",'" + Category + "')";
            con.Open();
            cmd = new SqlCommand(str, con);
            int no = cmd.ExecuteNonQuery();
            return no;
        }


        public DataTable display_info()
        {
            string str = "select * from GiftShop";
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmb = new SqlCommandBuilder(adpt);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return (dt);
        }
        public int delete_data(string ProductID)
        {
            string str = "delete from GiftShop where ProductID='" + ProductID + "'";
            con.Open();
            cmd = new SqlCommand(str, con);
            cmd.CommandText = str;
            int no = cmd.ExecuteNonQuery();
            return no;
        }
        public int update_data(string ProductID, string newprice)
        {

            string str = "update GiftShop set Price='" + newprice + "' where ProductID='" + ProductID + "'";
            con.Open();

            cmd = new SqlCommand(str, con);
            cmd.CommandText = str;
            int no = cmd.ExecuteNonQuery();
            return no;
           /// con.Close();
        }
    }
}
