using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("All fields are required");
                    return;
                }
                StreamReader srCheck = new StreamReader("Data.txt");
                string strCheck = srCheck.ReadToEnd();
                srCheck.Close();
                if (strCheck.Contains(textBox1.Text + ";"))
                {
                    MessageBox.Show("This ID is already exists, Please change it and try again");
                    textBox1.Focus();
                    textBox1.SelectAll();

                }
                else
                {

                    StreamWriter sw = new StreamWriter("Data.txt", true);
                    string strPerson = textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text;
                    sw.WriteLine(strPerson);
                    sw.Close();

                    MessageBox.Show("Person is added");

                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                    }
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    StreamReader srCheck2 = new StreamReader("Data.txt");
                    string line = "";
                    bool found = false;
                    do
                    {
                        line = srCheck2.ReadLine();
                        if (line != null)
                        {
                            string[] arrData = line.Split(';');
                            if (arrData[0] == textBox1.Text)
                            {
                                textBox1.Text = arrData[0];
                                textBox2.Text = arrData[1];
                                textBox3.Text = arrData[2];
                                found = true;
                            }

                        }


                    } while (line != null);
                    srCheck2.Close();
                    if (found == false)
                    {
                        MessageBox.Show("ID not Found");
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }

                }
                else
                {
                    MessageBox.Show("Please enter the ID of the person you wish to find");
                    textBox1.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form frmShow = new Form();
            TextBox txtShow = new TextBox();
            frmShow.StartPosition = FormStartPosition.CenterScreen;
            frmShow.Icon = this.Icon;
            frmShow.Font = this.Font;
            frmShow.Size = this.Size;
            frmShow.Text = "All Data";
            txtShow.Multiline = true;
            txtShow.Dock = DockStyle.Fill;

            frmShow.Controls.Add(txtShow);
            try
            {
                StreamReader x = new StreamReader("Data.txt");
                string y = x.ReadToEnd();
                x.Close();
                txtShow.Text = y;
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            frmShow.ShowDialog();





        }
    }
}
