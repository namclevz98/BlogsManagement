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
        public int InsertBlog(Blogs blog)
        {
            
            SqlConnection con = null;
            int result = 0;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertBlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Des", blog.Des);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@IsPublished", blog.IsPublished);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                //cmd.Parameters.AddWithValue("@Position", blog.Position);
                cmd.Parameters.AddWithValue("@Thumb", blog.Thumb);
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
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
        public string UpdatePostiton(int blogId, string position)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("UpdateBlogPosition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blogId);
                cmd.Parameters.AddWithValue("@Position", position);
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
        public string InsertPostiton(int blogId, int positionId)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertBlogPosition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogId", blogId);
                cmd.Parameters.AddWithValue("@PositionId", positionId);
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

        public int UpdateBlog(Blogs blog)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("UpdateBlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blog.Id);
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Des", blog.Des);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@IsPublished", blog.IsPublished);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                //cmd.Parameters.AddWithValue("@Position", blog.Position);
                cmd.Parameters.AddWithValue("@Thumb", blog.Thumb);
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public string DeleteBlog(int blogId)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("DeleteBlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blogId);
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
        public List<Blog> ShowAllBlogs()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blog> blogList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SelectAllBlogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
                    blog.IsPublished = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPublished"].ToString());
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
        public List<Blog> SearchBlog(string searchString)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blog> blogList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SearchBlog", con);
                cmd.Parameters.AddWithValue("@SearchString", searchString);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                blogList = new List<Blog>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog blog = new Blog();
                    blog.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    blog.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    blog.Des = ds.Tables[0].Rows[i]["Des"].ToString();
                    blog.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    blog.Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString());
                    blog.IsPublished = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPublished"].ToString());
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
        public Blog ShowBlogById(int blogId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Blog blog = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowBlogById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blogId);
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
                    blog.IsPublished = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPublished"].ToString());
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

        public List<Category> ShowAllCategories()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Category> categoryList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowAllCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                categoryList = new List<Category>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Category category = new Category();
                    category.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    category.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    categoryList.Add(category);
                }
                return categoryList;
            }
            catch
            {
                return categoryList;
            }
            finally
            {
                con.Close();
            }
        }

        public Category ShowCategoryByID(int categoryId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Category category = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowCategoryById", con);
                cmd.Parameters.AddWithValue("@Id", categoryId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    category = new Category();
                    category.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    category.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                }
                return category;
            }
            catch
            {
                return category;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Position> ShowAllPositions()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Position> positionList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowAllPositions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                positionList = new List<Position>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Position position = new Position();
                    position.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    position.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    positionList.Add(position);
                }
                return positionList;
            }
            catch
            {
                return positionList;
            }
            finally
            {
                con.Close();
            }
        }

        public Position ShowPositionByID(int positionId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Position position = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowPositionById", con);
                cmd.Parameters.AddWithValue("@Id", positionId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    position = new Position();
                    position.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    position.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                }
                return position;
            }
            catch
            {
                return position;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> ShowAllBlogPositions(int blogId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<string> blogPositionList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowAllBlogPositions", con);
                cmd.Parameters.AddWithValue("@Id", blogId); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                blogPositionList = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string BlogPosition = "";
                    BlogPosition = ds.Tables[0].Rows[i]["Name"].ToString();
                    blogPositionList.Add(BlogPosition);
                }
                return blogPositionList;
            }
            catch
            {
                return blogPositionList;
            }
            finally
            {
                con.Close();
            }
        }
    }
}