using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AttendanceApplication.Controllers
{
    public class ClassAttendanceApiController : ApiController
    {

       [HttpGet]

       public DataTable AllClassAttendances()
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ClassAttendance", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }

        [HttpGet]

        public String valueAt(int index)
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT AttendanceDate FROM ClassAttendance Where id = "+index, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            var date = "";
            try {
                date = dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception) { }
            return date;
        }
    }
}
