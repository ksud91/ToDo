using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_List.Forms
{
    public partial class DatePicker : Form
    {
        public DateTime Selection { get; set; }

        public DatePicker()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.Selection = monthCalendar1.SelectionStart;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
