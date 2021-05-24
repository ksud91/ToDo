namespace ToDo_List.Forms
{
    partial class AddAmendItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAmendItem));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxComplete = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.textBoxCompDateTime = new System.Windows.Forms.TextBox();
            this.comboBoxAsignee = new System.Windows.Forms.ComboBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.textBoxDueTimehh = new System.Windows.Forms.TextBox();
            this.textBoxDueTimemm = new System.Windows.Forms.TextBox();
            this.textBoxDueDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Due Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Due Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Assigned User";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Completed Date/Time";
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.AutoSize = true;
            this.checkBoxComplete.Location = new System.Drawing.Point(149, 266);
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size(15, 14);
            this.checkBoxComplete.TabIndex = 8;
            this.checkBoxComplete.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Mark as completed";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(424, 319);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // textBoxIssueID
            // 
            this.textBoxIssueID.Location = new System.Drawing.Point(149, 19);
            this.textBoxIssueID.Name = "textBoxIssueID";
            this.textBoxIssueID.ReadOnly = true;
            this.textBoxIssueID.Size = new System.Drawing.Size(100, 20);
            this.textBoxIssueID.TabIndex = 11;
            // 
            // textBoxCompDateTime
            // 
            this.textBoxCompDateTime.Location = new System.Drawing.Point(149, 295);
            this.textBoxCompDateTime.Name = "textBoxCompDateTime";
            this.textBoxCompDateTime.ReadOnly = true;
            this.textBoxCompDateTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxCompDateTime.TabIndex = 13;
            // 
            // comboBoxAsignee
            // 
            this.comboBoxAsignee.FormattingEnabled = true;
            this.comboBoxAsignee.Location = new System.Drawing.Point(149, 231);
            this.comboBoxAsignee.Name = "comboBoxAsignee";
            this.comboBoxAsignee.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAsignee.TabIndex = 14;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(149, 54);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(350, 20);
            this.textBoxTitle.TabIndex = 15;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(149, 86);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDesc.Size = new System.Drawing.Size(350, 75);
            this.textBoxDesc.TabIndex = 16;
            // 
            // textBoxDueTimehh
            // 
            this.textBoxDueTimehh.Location = new System.Drawing.Point(149, 199);
            this.textBoxDueTimehh.Name = "textBoxDueTimehh";
            this.textBoxDueTimehh.Size = new System.Drawing.Size(30, 20);
            this.textBoxDueTimehh.TabIndex = 18;
            this.textBoxDueTimehh.Text = "hh";
            this.textBoxDueTimehh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDueTimemm
            // 
            this.textBoxDueTimemm.Location = new System.Drawing.Point(183, 199);
            this.textBoxDueTimemm.Name = "textBoxDueTimemm";
            this.textBoxDueTimemm.Size = new System.Drawing.Size(26, 20);
            this.textBoxDueTimemm.TabIndex = 19;
            this.textBoxDueTimemm.Text = "mm";
            this.textBoxDueTimemm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDueDate
            // 
            this.textBoxDueDate.Location = new System.Drawing.Point(149, 167);
            this.textBoxDueDate.Name = "textBoxDueDate";
            this.textBoxDueDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxDueDate.TabIndex = 20;
            this.textBoxDueDate.Click += new System.EventHandler(this.textBoxDueDate_Click);
            // 
            // AddAmendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 358);
            this.Controls.Add(this.textBoxDueDate);
            this.Controls.Add(this.textBoxDueTimemm);
            this.Controls.Add(this.textBoxDueTimehh);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.comboBoxAsignee);
            this.Controls.Add(this.textBoxCompDateTime);
            this.Controls.Add(this.textBoxIssueID);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBoxComplete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAmendItem";
            this.Text = "Add/Amend To Do Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxComplete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.TextBox textBoxCompDateTime;
        private System.Windows.Forms.ComboBox comboBoxAsignee;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.TextBox textBoxDueTimehh;
        private System.Windows.Forms.TextBox textBoxDueTimemm;
        private System.Windows.Forms.TextBox textBoxDueDate;
    }
}