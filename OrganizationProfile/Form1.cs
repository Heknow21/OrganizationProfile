using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
                if (studNum == "")
                {
                    throw new ArgumentNullException(MessageBox.Show("Please complete the Student Number.").ToString());
                }
            } catch (Exception ex)
            {

            } finally
            {
                Console.WriteLine("Leaving Student Number empty will be a problem.");
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else if (Contact == "")
                {
                    throw new ArgumentNullException(MessageBox.Show("Please complete the Contact Number.").ToString());
                }
                else
                {
                    throw new IndexOutOfRangeException(MessageBox.Show("Your Contact Number input is out of range.").ToString());
                }
            } catch (Exception ex)
            {

            } finally
            {
                Console.WriteLine("Contact Number should be range of 11 input of numbers");
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new FormatException(MessageBox.Show("Please Complete your Full Name.").ToString());
                    }
            } catch(Exception ex)
            {

            } finally
            {
                Console.WriteLine("Always Complete Name.");
            }
            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else if (age == "")
                {
                    throw new ArgumentNullException(MessageBox.Show("Please fill-up your Age.").ToString());
                }
                else
                {
                    throw new OverflowException(MessageBox.Show("Invalid Input.").ToString());
                }
            } catch (Exception ex)
            {

            } finally
            {
                Console.WriteLine("String inputs are not valid.");
            }
            return _Age;
        }

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new String[]{
                "Male",
                "Female"
            };
            for (int j = 0; j < 2; j++)
            {
                cbGender.Items.Add(ListOfGender[j].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePicketBirthday.Value.ToString("yyyy-MM-dd");

            frmConfirm frm = new frmConfirm();
            frm.ShowDialog();
        }
    }
}
