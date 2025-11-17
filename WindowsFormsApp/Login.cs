using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Server=localhost;Database=studentis;Uid=root;Pwd=";
            string sql = "SELECT COUNT(1) FROM naudotojas WHERE vardas=@Vardas AND pass=@Pass";
            string sqlRole = "SELECT role FROM naudotojas WHERE vardas=@Vardas AND pass=@Pass";


            using (var con = new MySqlConnection(connStr))
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Vardas", MySqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = textBox2.Text;

                con.Open();
                int found = Convert.ToInt32(cmd.ExecuteScalar());
                if (found > 0)
                {

                    using (var cmdRole = new MySqlCommand(sqlRole, con))
                    {

                        cmdRole.Parameters.Add("@Vardas", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmdRole.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = textBox2.Text;

                        if (cmdRole.ExecuteScalar().ToString() == "admin")
                        {
                            MessageBox.Show("Successfully logged in");
                            var adminForm = new AdminView();
                            adminForm.Show();
                            return;
                        }
                        else if (cmdRole.ExecuteScalar().ToString() == "destytojas")
                        {
                            MessageBox.Show("Successfully logged in");
                            var destytojasForm = new DestytojoView();
                            destytojasForm.Show();
                            return;
                        }
                        else if (cmdRole.ExecuteScalar().ToString() == "studentas")
                        {
                            MessageBox.Show("Successfully logged in");
                            var studentasForm = new StudentoView();
                            studentasForm.Show();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Role not recognized");

                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
    interface IRole
    {
        void Prisijungti();
        void Atsijungti();
        void KeistiSlaptazodi();
    }
    class Naudotojas
    {
        private
            string vardas;
            string pavarde;
            string pass;
            int role;
        public
             string Vardas { get; set; }
             string Pavarde { get; set; }
             string Pass { get; set; }
             int Role { get; set; }

    }
    class Studentas : Naudotojas
    {
        private
            int studentID;
            string grupe;

        public
            int StudentID { get; set; }
            string Grupe { get; set; }
    }
    class Destytojas : Naudotojas
    {
        private
            int destytojasID;
            string dalykas;
        public
            int DestytojasID { get; set; }
            string Dalykas { get; set; }
    }
    class Administratorius : Naudotojas
    {
        private
            int adminID;
        public
            int AdminID { get; set; }
    }
}














