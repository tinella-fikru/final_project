using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.model
{
    internal class booking
    {
        static private List<booking> Aclass = new List<booking>();


        public int id { get; set; }
        public string groomName { get; set; }
        public string brideName { get; set; }
        public DateTime weddingDate { get; set; }
        public string Payment { get; set; }
        public int guests { get; set; }



        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;";

      
        public void save()
        {
            Aclass.Add(this);
         
        }
        static public List<booking> GetAllProducts()
        {
            List<booking> Bclass = new List<booking>();
            
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                string Query = "select * from booked;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    booking ac = new booking();

                    ac.id = (int)sdr["id"];
                    ac.groomName = (string)sdr["groomName"];
                    ac.brideName = (string)sdr["brideName"];
                    ac.guests = (int)sdr["guests"];
                    ac.weddingDate = (DateTime)sdr["Weddingdate"];
                    ac.Payment=(string) sdr["payment"];


                    Bclass.Add(ac);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };
            return Bclass;
        }
        public static booking findOne(int id)
        {
            List<booking> Bclass = new List<booking>();
            SqlConnection connection;
            connection = new SqlConnection(connectionString);
            string Query = "select * from booked where id='"+id+"'";
            try
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    
                    booking bo = new booking();
                    
                    bo.id = (int)sdr["id"];
                    bo.groomName = (string)sdr["groomName"];
                    bo.brideName = (string)sdr["brideName"];
                    bo.guests = (int)sdr["guests"];
                    bo.weddingDate = (DateTime)sdr["WeddingDate"];
                    bo.Payment = (string)sdr["payment"];
                    

                    Bclass.Add(bo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            };
            
            return Bclass.Find(bo => bo.id == id);
        }
        public static void update( int id,string gn,string bn,int guests,string cb,DateTime wd)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string Query = "exec UPDATEBOOK @gn,@bn,@wd,@payment,@guests,@id;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@gn", gn);
                cmd.Parameters.AddWithValue("@bn", bn);
                cmd.Parameters.AddWithValue("@guests", guests);
                cmd.Parameters.AddWithValue("@payment", cb);
                cmd.Parameters.AddWithValue("@wd", wd);
                cmd.Parameters.AddWithValue("@id", id);


                 cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Updated!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };



        }

        public static void delete(string id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {

                connection.Open();
                string Query = "exec DB @id;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                cmd.Parameters.AddWithValue("@id", id);

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted!!!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };
        }

    }
}
