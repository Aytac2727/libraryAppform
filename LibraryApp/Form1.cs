using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
     

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstname.Text;
          
            string phones = txtPhone.Text;

            labelError.Visible = false;
            if(firstname !=string.Empty && phones != string.Empty)
            {
                    if (long.TryParse(phones, out long phone))
                {
                    SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-8H1VV76\AYTACMSSQL;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    string myCom =
                    string.Format("Insert Into Students Values('{0}','{1}',3)", firstname, phones);
                    SqlCommand sCom = new SqlCommand(myCom, con);
                    con.Open();
                    int res = sCom.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show(firstname + " "  + " was created succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
                    {
                        Console.WriteLine("warning");
                    }
                    con.Close();
                }
                else
                {
                    labelError.Text = "Please, write numeric number!";
                    labelError.Visible = true;
                }
            }
            else
            {
                labelError.Text = "Please true write!";
                labelError.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-8H1VV76\AYTACMSSQL;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            string myCom = string.Format("Select Name from Faculties");
            using (SqlCommand com = new SqlCommand(myCom, con))
            {
                con.Open();
               var rd = com.ExecuteReader();
                while (rd.Read())
                {
                    cmbFaculties.Items.Add(rd["Name"].ToString());
                }
            }
        }
    }
}
