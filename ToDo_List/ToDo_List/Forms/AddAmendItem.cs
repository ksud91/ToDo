using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDo_List.Core.Models;
using ToDo_List.Persistence;

namespace ToDo_List.Forms
{
    public partial class AddAmendItem : Form
    {
        private readonly List<string> users;

        public AddAmendItem(int? issueID)
        {
            InitializeComponent();
            users = new List<string>();
            ListItem item = null;

            users.Add("");

            using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
            {
                users.AddRange(BusinessLogic.GetAllUsers(u.Users).Select(user => user.Username).ToList());

                if(issueID != null)
                {
                    item = BusinessLogic.GetListItem((int)issueID, u.ListItems);
                }
            }

            this.comboBoxAsignee.DataSource = users;

            if (item != null)
            {
                this.Text = "Amend Item Entry";
                this.textBoxIssueID.Text = item.Id.ToString();
                this.textBoxTitle.Text = item.Title;

                if(item.Description != null)
                {
                    this.textBoxDesc.Text = item.Description;
                }

                if(item.DueDate != null)
                {
                    this.textBoxDueDate.Text = ((DateTime)(item.DueDate)).ToString("dd/MM/yyyy");
                }

                if(item.DueTime != null)
                {
                    this.textBoxDueTimehh.Text = ((TimeSpan)item.DueTime).ToString("hh");
                    this.textBoxDueTimemm.Text = ((TimeSpan)item.DueTime).ToString("mm");
                }

                if (item.CompletedDateTime != null)
                {
                    this.textBoxCompDateTime.Text = ((DateTime)(item.DueDate)).ToString("dd/MM/yyyy hh:mm");
                    this.checkBoxComplete.Checked = true;
                    this.checkBoxComplete.Enabled = false;
                    this.saveButton.Enabled = false;
                }

                if (item.UserId != null)
                {
                    this.comboBoxAsignee.Text = item.Asignee.Username;
                }



            }
            else
            {
                this.Text = "Add An Item Entry";
                this.checkBoxComplete.Checked = false;
                this.checkBoxComplete.Enabled = false;
            }


        }

        private void textBoxDueDate_Click(object sender, EventArgs e)
        {

            using (var dp = new DatePicker())
            {
                var result = dp.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    this.textBoxDueDate.Text = dp.Selection.ToString("dd/MM/yyyy");
                }
            }
                       
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool valError = false;

            if (!String.IsNullOrEmpty(this.textBoxTitle.Text))
            {

                ListItem item = new ListItem();

                item.Title = this.textBoxTitle.Text;
                item.Description = this.textBoxDesc.Text;
                item.CompletedDateTime = null;

                if (!String.IsNullOrEmpty(this.textBoxDueDate.Text))
                {
                    item.DueDate = DateTime.Parse(this.textBoxDueDate.Text);
                }
                else
                {
                    item.DueDate = null;
                }

                
                if(!String.IsNullOrEmpty(this.textBoxDueTimehh.Text) && !String.IsNullOrEmpty(this.textBoxDueTimemm.Text))
                {
                    //need validation to ensure digits
                    string dt = (this.textBoxDueTimehh.Text + this.textBoxDueTimemm.Text);

                    if(dt.All(char.IsDigit))
                    {
                        try
                        {
                            item.DueTime = TimeSpan.Parse(this.textBoxDueTimehh.Text + ":" + this.textBoxDueTimemm.Text);
                        }
                        catch
                        {
                            valError = true;
                            MessageBox.Show("Due Time is not in an acceptable 24 hour format (hh:mm)", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                    else
                    {
                        if (dt == "hhmm")
                        {
                            item.DueTime = null;
                        }
                        else
                        {
                            valError = true;
                            MessageBox.Show("Due Time is not in an acceptable 24 hour format (hh:mm)", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                else
                {
                    item.DueTime = null;
                }

                if(valError == false)
                {
                    if (this.textBoxIssueID.Text == "")
                    {
                        using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
                        {
                            if (!String.IsNullOrEmpty(this.comboBoxAsignee.Text))
                            {
                                User user = BusinessLogic.GetUser(this.comboBoxAsignee.Text, u.Users);
                                item.Asignee = user;
                            }

                            BusinessLogic.AddListItem(item, u.ListItems);

                            try
                            {
                                u.Save();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Add Item action failed", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        item.Id = int.Parse(this.textBoxIssueID.Text);

                        if(this.checkBoxComplete.Checked == true)
                        {
                            item.CompletedDateTime = DateTime.Now;
                        }

                        using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
                        {
                            if (!String.IsNullOrEmpty(this.comboBoxAsignee.Text))
                            {
                                User user = BusinessLogic.GetUser(this.comboBoxAsignee.Text, u.Users);
                                item.Asignee = user;
                            }

                            BusinessLogic.UpdateListItem(item.Id, item, u.ListItems);

                            try
                            {
                                u.Save();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Add Item action failed", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Title is a required field", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
