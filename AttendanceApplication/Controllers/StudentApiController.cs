using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AttendanceApplication.Controllers
{
    public class StudentApiController : ApiController
    {
        // GET: StudentApi

        [HttpGet]

        public DataTable AllStudents()
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //foreach (DataRow row in dt.Rows)
            //{

            //    s.RegistrationNumber = row["RegistrationNumber"].ToString();
            //    s.FirstName = row["FirstName"].ToString();
            //    s.LastName = row["LastName"].ToString();
            //    s.Section = Int32.Parse(row["Section"].ToString());
            //    std.Add(s);
            //}
            adpt.Fill(dt);
            return dt;
        }

        [HttpGet]
        public DataTable AllAttendace()
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentAttendance", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }

        [HttpPost]

        public bool AddAttendance(Object obj)
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus,SectionId) VALUES()", con);

            return true;
        }

        [HttpGet]
        public String IndexAt(String RegNo)
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=Attendance;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Student WHERE RegistrationNumber = '"+RegNo+"'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            String index = "-1";
            if(dt.Rows.Count != 0)
            {
                index = dt.Rows[0].ItemArray[0].ToString();
            }
            
            return index;
        }

    }
}