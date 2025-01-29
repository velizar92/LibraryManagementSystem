namespace LibraryManagementSystem.UI
{
    partial class AddMemberForm
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
            txtFirstName = new TextBox();
            lblAddMember = new Label();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            lblPhoneNumber = new Label();
            btnAddMember = new Button();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(25, 150);
            txtFirstName.Multiline = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(438, 46);
            txtFirstName.TabIndex = 0;
            // 
            // lblAddMember
            // 
            lblAddMember.AutoSize = true;
            lblAddMember.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddMember.Location = new Point(25, 19);
            lblAddMember.Margin = new Padding(10, 0, 10, 0);
            lblAddMember.Name = "lblAddMember";
            lblAddMember.Size = new Size(302, 62);
            lblAddMember.TabIndex = 1;
            lblAddMember.Text = "Add Member";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(25, 260);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(438, 46);
            txtLastName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(25, 367);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(438, 46);
            txtEmail.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(25, 478);
            txtPhoneNumber.Multiline = true;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(438, 46);
            txtPhoneNumber.TabIndex = 4;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(25, 109);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(151, 38);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(25, 219);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(147, 38);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Last Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(25, 326);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(83, 38);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(25, 437);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(206, 38);
            lblPhoneNumber.TabIndex = 8;
            lblPhoneNumber.Text = "Phone Number";
            // 
            // btnAddMember
            // 
            btnAddMember.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddMember.Location = new Point(123, 565);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(230, 55);
            btnAddMember.TabIndex = 9;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // AddMemberForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 647);
            Controls.Add(btnAddMember);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(lblAddMember);
            Controls.Add(txtFirstName);
            Name = "AddMemberForm";
            Text = "AddMemberForm";
            Load += AddMemberForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstName;
        private Label lblAddMember;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblPhoneNumber;
        private Button btnAddMember;
    }
}