using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BlogsManagement.Models;
using System.Data;
using System.Configuration;

namespace BlogsManagement.DataAccess
{
    public class DataAccessLayer
    {
        public const int insertBlog = 1;
        public const int updateBlog = 2;
        public const int deleteBlog = 3;
        public const int showAllBlogs = 4;
        public const int showBlogById = 5;
        public string InsertBlog(Blog blog)
        {
            
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usq_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Des", blog.Des);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@IsPublished", blog.IsPublished);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                cmd.Parameters.AddWithValue("@Position", blog.Position);
                cmd.Parameters.AddWithValue("@Thumb", blog.Thumb);
                cmd.Parameters.AddWithValue("@Query", insertBlog);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public string UpdateBlog(Blog blog)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usq_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blog.Id);
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Des", blog.Des);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@IsPublished", blog.IsPublished);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                cmd.Parameters.AddWithValue("@Position", blog.Position);
                cmd.Parameters.AddWithValue("@Thumb", blog.Thumb);
                cmd.Parameters.AddWithValue("@Query", updateBlog);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int DeleteBlog(string blogId)
        {
            SqlConnection con = new SqlConnection();
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usq_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blogId);
                cmd.Parameters.AddWithValue("@Title", null);
                cmd.Parameters.AddWithValue("@Des", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@IsPublished", null);
                cmd.Parameters.AddWithValue("@DatePublic", null);
                cmd.Parameters.AddWithValue("@Position", null);
                cmd.Parameters.AddWithValue("@Thumb", null);
                cmd.Parameters.AddWithValue("@Query", deleteBlog);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Blog> ShowallBlogs()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = null;
            List<Blog> blogList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usq_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", null);
                cmd.Parameters.AddWithValue("@Title", null);
                cmd.Parameters.AddWithValue("@Des", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@IsPublished", null);
                cmd.Parameters.AddWithValue("@DatePublic", null);
                cmd.Parameters.AddWithValue("@Position", null);
                cmd.Parameters.AddWithValue("@Thumb", null);
                cmd.Parameters.AddWithValue("@Query", showAllBlogs);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                blogList = new List<Blog>();
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog blog = new Blog();
                    blog.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    blog.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    blog.Des = ds.Tables[0].Rows[i]["Des"].ToString();
                    blog.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    blog.Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString());
                    blog.IsPublished = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPulished"].ToString());
                    blog.DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DatePublic"].ToString());
                    blog.Position = ds.Tables[0].Rows[i]["Position"].ToString();
                    blog.Thumb = ds.Tables[0].Rows[i]["Thumb"].ToString();
                    blogList.Add(blog);
                }
                return blogList;
            }
            catch
            {
                return blogList;
            }
            finally
            {
                con.Close();
            }
        }
        public Blog ShowBlogById(string blogId)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = null;
            Blog blog = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usq_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blogId);
                cmd.Parameters.AddWithValue("@Title", null);
                cmd.Parameters.AddWithValue("@Des", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@IsPublished", null);
                cmd.Parameters.AddWithValue("@DatePublic", null);
                cmd.Parameters.AddWithValue("@Position", null);
                cmd.Parameters.AddWithValue("@Thumb", null);
                cmd.Parameters.AddWithValue("@Query", showBlogById);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    blog = new Blog();
                    blog.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    blog.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    blog.Des = ds.Tables[0].Rows[i]["Des"].ToString();
                    blog.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    blog.Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString());
                    blog.IsPublished = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPulished"].ToString());
                    blog.DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DatePublic"].ToString());
                    blog.Position = ds.Tables[0].Rows[i]["Position"].ToString();
                    blog.Thumb = ds.Tables[0].Rows[i]["Thumb"].ToString();
                }
                return blog;
            }
            catch
            {
                return blog;
            }
            finally
            {
                con.Close();
            }
        }
    }
}