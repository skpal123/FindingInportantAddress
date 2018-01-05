using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FindingAddress.Models;
namespace FindingAddress.DataAccessLayer
{
    public class CategoryGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", category.Name);
                cmd.Parameters.AddWithValue("@Description", category.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Category> getAllCategories()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Category> categories = new List<Category>();
                SqlCommand cmd = new SqlCommand("select * from tblCategory", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Category category = new Category();
                    category.Id = rdr["Id"].ToString();
                    category.Name = rdr["Name"].ToString();
                    category.Description = rdr["Description"].ToString();
                    categories.Add(category);
                }
                return categories;
            }
        }
        public Category getCategoryById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                Category category = new Category();
                SqlCommand cmd = new SqlCommand("select * from tblCategory where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.Id = rdr["Id"].ToString();
                    category.Name = rdr["Name"].ToString();
                    category.Description = rdr["Description"].ToString();
                }
                return category;
            }
        }
        public int UpdateCategoryByCategoryId(Category category)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("updateCategoryByCategoryId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@Name", category.Name);
                cmd.Parameters.AddWithValue("@Description", category.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}