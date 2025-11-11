using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Naudotojas
{
    private
        string vardas;
        string pass;
        int RoleID;
    public
    string Vardas { get; set; }
    string Pass { get; set; }

}

class Studentas : Naudotojas
{
    private
        int studentID;
        string pavarde;
    public
        int StudentID { get; set; }
        string Pavarde { get; set; }
}

namespace WindowsFormsApp

{
    public partial class Form1 : Form
    {
        string server = "localhost";
        string uid = "rooot";
        string password = "";
        string database = "StudentIS";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
