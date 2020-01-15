using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SergeresISIS
{
    class udbc
    {
        SqlConnection sqlConnection;

        public void OpenConnect()
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //DESKTOP-9TGS6MT\SQLEXPRESS
            sqlConnection = new SqlConnection(conStr);
            sqlConnection.Open();
        }

        public void CloseConnect()
        {
            sqlConnection.Close();
        }

        public bool Auth(string logo, string pass)
        {
            OpenConnect();
            bool answer = false;
            try
            {
                SqlCommand enterDBID = new SqlCommand("select [Password] from [dbo].[Table] where [Login] = @Login and [Password] = @Password", sqlConnection);
                enterDBID.Parameters.AddWithValue("@Login", logo);
                enterDBID.Parameters.AddWithValue("@Password", pass);
                string passans = (string)enterDBID.ExecuteScalar();
                if (passans == pass)
                {
                    answer = true;
                    return answer;
                }
                else
                {
                    answer = false;
                    return answer;
                }
            }
            catch
            {
                answer = false;
                
            }
            CloseConnect();
            return answer;
        }

        public string Auth2(string logo, string pass)
        {
            OpenConnect();
            string answer = "";
            try
            {
                SqlCommand enterDBID = new SqlCommand("select [Role] from [dbo].[Table] where [Login] = @Login and [Password] = @Password", sqlConnection);
                enterDBID.Parameters.AddWithValue("@Login", logo);
                enterDBID.Parameters.AddWithValue("@Password", pass);
                string passans = (string)enterDBID.ExecuteScalar();

                answer = passans;
                CloseConnect();
                return answer;

                
            }
            catch { return answer; }
        }

        public string DUDAdd()
        {
            OpenConnect();
            string SItems = "";
            SqlDataReader sqlReaderT = null;
            SqlCommand shoSIR = new SqlCommand("Select name from Books ", sqlConnection);
            try
            {

                sqlReaderT = shoSIR.ExecuteReader();
                while (sqlReaderT.Read())
                {
                    SItems += String.Format("{0}", sqlReaderT[0]) + ";";
                }
            }
            finally
            {
                if (sqlReaderT != null)
                    sqlReaderT.Close();
            }
            CloseConnect();
            return SItems;
        }

        public string OpenText(string name)
        {
            OpenConnect();
            string strtext = "";
            SqlCommand loadtxt = new SqlCommand("select content from Books where name = @name", sqlConnection);
            loadtxt.Parameters.AddWithValue("name", name);
            strtext = (string)loadtxt.ExecuteScalar();
            CloseConnect();
            return strtext;
        }

        public void IniAdd(int wSize, int hSize, int tVal, string lText)
        {
            OpenConnect();
            SqlCommand Widthcom = new SqlCommand("update IniProp set value = @valueW where name = @Width", sqlConnection);
            Widthcom.Parameters.AddWithValue("Width", "Width");
            Widthcom.Parameters.AddWithValue("valueW", wSize);
            Widthcom.ExecuteScalar();

            SqlCommand Heightcom = new SqlCommand("update IniProp set value = @valueH where name = @Height", sqlConnection);
            Heightcom.Parameters.AddWithValue("Height", "Height");
            Heightcom.Parameters.AddWithValue("valueH", hSize);
            Heightcom.ExecuteScalar();

            SqlCommand tvalue = new SqlCommand("update IniProp set value = @valueT where name = @LengthWord", sqlConnection);
            tvalue.Parameters.AddWithValue("LengthWord", "LengthWord");
            tvalue.Parameters.AddWithValue("valueT", tVal);
            tvalue.ExecuteScalar();

            SqlCommand loadtext = new SqlCommand("update IniProp set value = @valueL where name = @LastText", sqlConnection);
            loadtext.Parameters.AddWithValue("LastText", "LastText");
            loadtext.Parameters.AddWithValue("valueL", lText);
            loadtext.ExecuteScalar();
            CloseConnect();
        }

        public int ReadWidth()
        {
            OpenConnect();
            SqlCommand Widthcom = new SqlCommand("select value from IniProp where name = @Width", sqlConnection);
            Widthcom.Parameters.AddWithValue("Width", "Width");
            int Width = Convert.ToInt32(Widthcom.ExecuteScalar());
            CloseConnect();
            return Width;
        }

        public int ReadHeight()
        {
            OpenConnect();
            SqlCommand Heightcom = new SqlCommand("select value from IniProp where name = @Height", sqlConnection);
            Heightcom.Parameters.AddWithValue("Height", "Height");
            int Height = Convert.ToInt32(Heightcom.ExecuteScalar());
            CloseConnect();
            return Height;
        }

        public int ReadLen()
        {
            OpenConnect();
            SqlCommand LengthWordcom = new SqlCommand("select value from IniProp where name = @LengthWord", sqlConnection);
            LengthWordcom.Parameters.AddWithValue("LengthWord", "LengthWord");
            int Len = Convert.ToInt32(LengthWordcom.ExecuteScalar());
            CloseConnect();
            return Len;
        }

        public string ReadText()
        {
            OpenConnect();
            SqlCommand LastTextcom = new SqlCommand("select value from IniProp where name = @LastText", sqlConnection);
            LastTextcom.Parameters.AddWithValue("LastText", "LastText");
            string Text = Convert.ToString(LastTextcom.ExecuteScalar());
            CloseConnect();
            return Text;
        }
    }
}
