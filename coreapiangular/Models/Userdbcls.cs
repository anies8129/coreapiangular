using System.Data.SqlClient;
using System.Data;


namespace coreapiangular.Models
{
    public class Userdbcls
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-TFPFI5HG\SQLEXPRESS;database=angularapi;integrated security=true");

        public string insertdb(Usercls obj)
        {
            SqlCommand cmd = new SqlCommand("sp_userinsert",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@na", obj.name);
            cmd.Parameters.AddWithValue("@ag", obj.age);
            cmd.Parameters.AddWithValue("@addr", obj.addr);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@photo", obj.photo);
            cmd.Parameters.AddWithValue("@una", obj.uname);
            cmd.Parameters.AddWithValue("@pw", obj.password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return ("Inserted Sucessfully");
        }
        public string logindb(Usercls objcls)
        {
            try
            {
                string cid = "";
                SqlCommand cmd = new SqlCommand("sp_login",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.uname);
                cmd.Parameters.AddWithValue("@pw", objcls.password);
                con.Open();
                cid = cmd.ExecuteScalar().ToString();
                con.Close();
                return cid;
            }
            catch (Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }        
        }
        public string getuserid(Usercls objcls)
        {
            try
            {
                string id = "";
                SqlCommand cmd = new SqlCommand("sp_getid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.uname);
                cmd.Parameters.AddWithValue("@pw", objcls.password);
                con.Open();
                id=cmd.ExecuteScalar().ToString();
                con.Close();
                return id;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public Usercls selectprofiledb(int id)
        {
            var getdata = new Usercls();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectprofile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    getdata = new Usercls
                    {
                        uid = Convert.ToInt32(sdr["userid"]),
                        name = sdr["name"].ToString(),
                        age = Convert.ToInt32(sdr["age"]),
                        addr = sdr["address"].ToString(),
                        email = sdr["email"].ToString(),
                        photo = sdr["photo"].ToString(),
                    };
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}
