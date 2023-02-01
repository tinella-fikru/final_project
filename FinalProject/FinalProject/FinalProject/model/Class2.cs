using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.model
{
    internal class Class2
    {
        public int Id { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public string PackageName { get; set; }

        public int price { get; set; }
        public int GuestNumber { get; set; }
        public DateTime weddingDate { get; set; }
        

        static private List<Class2> class2 = new List<Class2>();

        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;";


        public void save()
        {

            class2.Add(this);

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();

                string Query = "exec spInsert @gn,@bf, @pn, @price, @ng,@wd,@id; ";
             
                SqlCommand cmd = new SqlCommand(Query, connection);
               cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@bf", this.BrideName);
                cmd.Parameters.AddWithValue("@gn", this.GroomName);
                cmd.Parameters.AddWithValue("@pn", this.PackageName);
                cmd.Parameters.AddWithValue("@price", this.price);
                cmd.Parameters.AddWithValue("@ng", this.GuestNumber);
                cmd.Parameters.AddWithValue("@wd", this.weddingDate);



                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Booked!!!");



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

        public void displayBooked(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query1 = "Exec sp_loadsinglebooked @id";
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    id = (int)sdr["id"];
                    GroomName = (string)sdr["groomName"];
                    BrideName = (string)sdr["brideName"];
                    PackageName = (string)sdr["packageName"];
                    price = (int)sdr["price"];
                    GuestNumber = (int)sdr["guests"];
                    weddingDate = (DateTime)sdr["Weddingdate"];

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            };
        }


        public void selected(int id, CheckedListBox checkedListBox1)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
          
            try
            {
                connection.Open();
                string query1 = "Exec sp_cust @id,@BeautyService,@PhotographyService,@Catering ,@DJ ,@Decor,@VenueBooking ";
                string query2 = "Select dbo.priceCalc (@id)";

                SqlCommand cmd=new SqlCommand(query1, connection);
               SqlCommand cmd2 = new SqlCommand(query2, connection);


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@BeautyService", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(0);
                cmd.Parameters.AddWithValue("@PhotographyService", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(1);
                cmd.Parameters.AddWithValue("@Catering", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(2);
                cmd.Parameters.AddWithValue("@DJ", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(3);
                cmd.Parameters.AddWithValue("@Decor", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(4);
                cmd.Parameters.AddWithValue("@VenueBooking", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(5);

                cmd2.Parameters.AddWithValue("@id", id);
             
                cmd.ExecuteNonQuery();
               // int p = Convert.ToInt32(cmd2.ExecuteScalar());
                Class2 c = new Class2();
               // c.price =p;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            };

        }
        public string Price(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select dbo.priceCalc(@id)";
            SqlCommand cmd3 = new SqlCommand(Query, con);
            cmd3.Parameters.AddWithValue("@id", id);
            string t = cmd3.ExecuteScalar().ToString();

            con.Close();
            return t;

        }
      
        }

        }
    

