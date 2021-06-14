using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication1.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("Select * from tbl_Books", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewBook(string Title, int aid, double price)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorID", aid);
            cmd.Parameters.AddWithValue("@Price", price);

            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable DisplayAuthor()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("Select * from tbl_Author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewAuthor(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            

            return cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}