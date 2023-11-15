using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Windows.Forms;

namespace ReadingAFile
{
    public partial class frmRegistration : Form
    {
        public static string SetFileName;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfPrograms = new string[]
          {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
          };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfPrograms[i].ToString());
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

            string[] details =
            {
                $"Student Number: {txtboxStudNo.Text}",
                $"Full Name: {txtboxLast.Text}, {txtboxFirst.Text} {txtboxMI.Text}",
                $"Program: {cbPrograms.Text}",
                $"Gender: {cbGender.Text}",
                $"Age: {txtboxAge.Text}",
                $"Birthday: {dateTimePickerBirthday.Value.ToString("yyyy-MM-dd")}",
                $"Contact Number: {txtboxContact.Text}"
            };
            SetFileName = txtboxStudNo.Text + ".txt";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, frmRegistration.SetFileName)))
            {
                foreach (string info in details)
                {
                    outputFile.WriteLine(info);
                    Console.WriteLine(info);
                }         
            }
        }
        private void btnRecords_Click(object sender, EventArgs e)
        {
            new frmStudentRecord().ShowDialog();
        }
    }
}
