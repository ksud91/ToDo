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
using ToDo_List.Forms;
using ToDo_List.Persistence;

namespace ToDo_List
{
    public partial class Home : Form
    {
        public List<ListItem> items;

        private readonly Icon[] icons = new Icon[] { new Icon("Icons\\complete.ico"), new Icon("Icons\\unknown.ico"), new Icon("Icons\\pending.ico"), new Icon("Icons\\overdue.ico") };

        public Home()
        {
            InitializeComponent();            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            FirstLoadSequence();
        }

        private void FirstLoadSequence()
        {
            GetItems();

            ItemGridView.DataSource = this.items;

            AmendDisplayColumns();

            ApplyStatusIcons();
        }

        private void RefreshSequence()
        {
            GetItems();

            ItemGridView.DataSource = this.items;

            ApplyStatusIcons();
        }

        private void GetItems()
        {
            using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
            {
                items = BusinessLogic.GetAllListItems(u.ListItems).ToList();
            }
        }

        private void AmendDisplayColumns()
        {
            ItemGridView.Columns["CompletedDateTime"].Visible = false;
            ItemGridView.Columns["Asignee"].Visible = false;
            ItemGridView.Columns["UserId"].Visible = false;

            ItemGridView.Columns.Add(new DataGridViewImageColumn());
            ItemGridView.Columns[8].Name = "Status";
            ItemGridView.Columns["Status"].DisplayIndex = 0;
        }

        private void ApplyStatusIcons()
        {
            int iconCol = ItemGridView.Columns["Status"].Index;

            foreach (DataGridViewRow r in this.ItemGridView.Rows)
            {

                if (r.Cells[ItemGridView.Columns["CompletedDateTime"].Index].Value != null)
                {
                    ((DataGridViewImageCell)r.Cells[iconCol]).Value = icons[(int)Status.Complete];
                }
                else if (r.Cells[ItemGridView.Columns["DueDate"].Index].Value is null)
                {
                    ((DataGridViewImageCell)r.Cells[iconCol]).Value = icons[(int)Status.Unknown];
                }
                else
                {
                    DateTime dueDate;
                    TimeSpan dueTime;
                    DateTime.TryParse(r.Cells[ItemGridView.Columns["DueDate"].Index].Value.ToString(), out dueDate);


                    if (r.Cells[ItemGridView.Columns["DueTime"].Index].Value is null)
                    {
                        dueTime = new TimeSpan(23, 59, 59);
                    }
                    else
                    {
                        TimeSpan.TryParse(r.Cells[ItemGridView.Columns["DueTime"].Index].Value.ToString(), out dueTime);
                    }

                    DateTime dueDateTime = dueDate + dueTime;

                    if (dueDateTime < DateTime.Now)
                    {
                        ((DataGridViewImageCell)r.Cells[iconCol]).Value = icons[(int)Status.Overdue];
                    }
                    else
                    {
                        ((DataGridViewImageCell)r.Cells[iconCol]).Value = icons[(int)Status.Pending];
                    }

                }
            }
        }

        
        private void ItemGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            using (var f = new AddAmendItem(e.RowIndex + 1))
            {
                var result = f.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    RefreshSequence();
                }
            }

        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmDelete = MessageBox.Show("Do you want to remove this item from the database?", "Confirm Item Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmDelete == DialogResult.Yes)
            {

                int i = (int)ItemGridView.SelectedRows.Cast<DataGridViewRow>().First().Cells[ItemGridView.Columns["Id"].Index].Value;

                using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
                {
                    var x = BusinessLogic.GetListItem(i, u.ListItems);
                    BusinessLogic.RemoveListItem(x, u.ListItems);

                    u.Save();
                }

                RefreshSequence();

            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            (new AddUser()).ShowDialog(this);
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            using (var f = new AddAmendItem(null))
            {
                var result = f.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    RefreshSequence();
                }
            }
        }

        private enum Status
        {
            Complete,
            Unknown,
            Pending,
            Overdue,
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int id;

            if (this.textBoxSearch.Text.All(char.IsDigit))
            {
                using (UnitOfWork u = new UnitOfWork(new ToDoContext()))
                {
                    try
                    {
                        id = BusinessLogic.GetListItem(int.Parse(this.textBoxSearch.Text), u.ListItems).Id;
                    }
                    catch
                    {
                        id = 0;
                    }
                }

                if (id != 0)
                {
                    using (var f = new AddAmendItem(id))
                    {
                        var result = f.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            RefreshSequence();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Search ID not found", "No Result Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Search ID must be formed only of digits", "No Result Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}
