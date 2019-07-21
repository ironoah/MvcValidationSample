using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ValidationTest.Models
{
    public class ValidationTestContext 
    {

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ValidationTestContext"].ToString();
            con = new SqlConnection(constring);
        }



        // ********** VIEW STUDENT DETAILS ********************
        public List<Member> getMembers()
        {
            connection();
            List<Member> studentlist = new List<Member>();

            //SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlCommand cmd = new SqlCommand("select * from Members", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new Member
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        email = Convert.ToString(dr["email"]),
                        memo = Convert.ToString(dr["memo"])
                    });
            }
            return studentlist;
        }
    }
}
