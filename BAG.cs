using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BagSale
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BAG : IBAG
    {
        public List<Transaksi> Transaksi()
        {
            List<Transaksi> transaksis = new List<Transaksi>(); // proses utk mendeclare nama list yang sudah dibuat
            try
            {
                string sql = " select ID_reservasi, Nama_customer, No_telpon, " + "Jumlah_pemesanan, Nama_lokasi from dbo.Pemesanan p join dbo.Lokasi l on p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    /*nama class*/
                    Transaksi data = new Transaksi(); // deklarasi data, mengambil 1persatu dari database
                    //bentuk array
                    data.id= reader.GetString(0);
                    data.nama = reader.GetString(1);
                    data.noTelp = reader.GetString(2);
                    data.jumlah = reader.GetInt32(3);

                    transaksis.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return transaksis;
        }
        string constring = "Data Source=DESKTOP-AS5OAOK;Initial Catalog=WCFReservasi;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection connection;
        SqlCommand com; //untuk mengkoneksikan database ke visual studio

        public string id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string noTelp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NoTelpon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Transaksi(string ID, string Nama, string NoTelp, int Jumlah)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.transaksi values ('" + ID + "', '" + Nama + "', '" + NoTelp + "', "
                    + "" + Jumlah + ")";
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }





        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string editTransaksi(string idPemesanan, string namaCustomer, string noTelepon)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.transaksi set Nama_customer = '" + namaCustomer + "', No_telpon = '" + noTelepon + "'" + " where ID_reservasi = '" + idPemesanan + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string deleteTransaksi(string id)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.transaksi where ID_reservasi = '" + id + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string Login(string username, string password)
        {
            string kategori = "";

            string sql = "select Kategori from Login where Username='" + username + "' and Password='" + password + "'";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }
            return kategori;
        }


        public string Register(string username, string password, string kategori)
        {
            try
            {
                string sql = "insert into Login values('" + username + "', '" + password + "', '" + kategori + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string updateRegister(string username, string password, string kategori, int id)
        {
            try
            {
                string sql2 = "update Login SET Username='" + username + "', Password='" + password + "', Kategori='" + kategori + "'" + " where ID_Login = " + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string deleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select ID_Login from dbo.Login where Username = '" + username + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();
                string sql2 = "delete from Login where ID_Login=" + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<DataRegister> dataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_Login, Username, Password, Kategori from Login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }

        
    }
}
