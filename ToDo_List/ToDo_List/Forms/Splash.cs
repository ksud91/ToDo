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
using ToDo_List.Core.Models;

namespace ToDo_List
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            this.VersionLabel.Text = "Version " + Application.ProductVersion;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();
            splashTimer.Enabled = false;

            var u = new UnitOfWork(new ToDoContext());
            u.Dispose();

            this.Close();
        }

    }
}
