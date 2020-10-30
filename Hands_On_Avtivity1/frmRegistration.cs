using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hands_On_Avtivity1
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        public long _StudentNo;


        public frmRegistration()
        {
            InitializeComponent();


        }

        public void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }

            string[] Gender = new string[]
            {
                "Female",
                "Male"
            };
            for (int g = 0; g < 2; g++)
            {
                cbGender.Items.Add(Gender[g].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {
           
           _StudentNo = Int64.Parse(studNum);

                   return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = Int64.Parse(Contact);
            }
            else
            {
                throw new FormatException("Invalid Contact number");
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {

            if ((Regex.IsMatch(LastName, @"^[a-zA-Z]+$") && Regex.IsMatch(FirstName, @"^[a-zA-Z]+$")) || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new ArgumentNullException("Please fill in your name");
                throw new FormatException("Invalid Name input");
            }



            return _FullName;
        }

        public int Age(string age)
        {
         if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException("You enter invalid age");
}

            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                FrmConfirmation frm = new FrmConfirmation();
                frm.ShowDialog();
            }

           

            catch (FormatException fe)
            {
                MessageBox.Show("Error: " + fe.Message);
            }

            catch (ArgumentNullException an)
            {
                MessageBox.Show("Error: " + an.Message);
            }


            catch (OverflowException of)
            {
                MessageBox.Show("Error: " + of.Message);
            }

            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show("Error: " + io.Message);
            }


        }

      
    }
}
