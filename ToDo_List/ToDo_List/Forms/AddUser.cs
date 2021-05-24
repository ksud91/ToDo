using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDo_List.Persistence;

namespace ToDo_List.Forms
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string forename = this.textBoxForename.Text;
            string surname = this.textBoxSurname.Text;

            if(forename != "" && surname != "")
            {
                if (forename.All(char.IsLetter) && surname.All(char.IsLetter))
                {
                    using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
                    {
                        string username = BusinessLogic.AddUser(forename, surname, u.Users);

                        try
                        {
                            u.Save();
                            this.Close();
                            MessageBox.Show("User " + forename + " " + surname +" added, username;" + username, "Add User Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Add user operation exception", "Add User Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("First name and surname may only contain letters", "Add User Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("First name and surname are required fields", "Add User Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
