using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.WriteToFile;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string filter = "CSV Files (*.csv)|*.csv";
            sfd.Filter = filter;
            sfd.DefaultExt = ".csv";
            sfd.InitialDirectory = Environment.CurrentDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    foreach (var x in users)
                    {
                        sw.Write("ID");
                        sw.Write(";");
                        sw.Write("FullName");
                        sw.WriteLine();
                        sw.Write(x.ID);
                        sw.Write(";");
                        sw.Write(x.FullName);
                        sw.WriteLine();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

                User toBeDeleted = (User)listBox1.SelectedItem;
                users.Remove(toBeDeleted);

        }
    }
}
