namespace LibraryManagementSystem.UI
{
    partial class MainboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dgvMembers = new DataGridView();
            dgvBooks = new DataGridView();
            lblMembers = new Label();
            label2 = new Label();
            btnAddBook = new Button();
            btnAddMember = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(319, 9);
            label1.Margin = new Padding(10, 0, 10, 0);
            label1.Name = "label1";
            label1.Size = new Size(619, 62);
            label1.TabIndex = 0;
            label1.Text = "Library Management System";
            // 
            // dgvMembers
            // 
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(52, 187);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.Size = new Size(1169, 283);
            dgvMembers.TabIndex = 1;
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(52, 551);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(1169, 283);
            dgvBooks.TabIndex = 2;
            // 
            // lblMembers
            // 
            lblMembers.AutoSize = true;
            lblMembers.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMembers.Location = new Point(563, 132);
            lblMembers.Name = "lblMembers";
            lblMembers.Size = new Size(134, 38);
            lblMembers.TabIndex = 3;
            lblMembers.Text = "Members";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(576, 490);
            label2.Name = "label2";
            label2.Size = new Size(91, 38);
            label2.TabIndex = 4;
            label2.Text = "Books";
            // 
            // btnAddBook
            // 
            btnAddBook.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddBook.Location = new Point(991, 840);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(230, 55);
            btnAddBook.TabIndex = 5;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnAddMember
            // 
            btnAddMember.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddMember.Location = new Point(991, 481);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(230, 55);
            btnAddMember.TabIndex = 6;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // MainboardForm
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 907);
            Controls.Add(btnAddMember);
            Controls.Add(btnAddBook);
            Controls.Add(label2);
            Controls.Add(lblMembers);
            Controls.Add(dgvBooks);
            Controls.Add(dgvMembers);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(10, 9, 10, 9);
            Name = "MainboardForm";
            Text = "MainBoard";
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvMembers;
        private DataGridView dgvBooks;
        private Label lblMembers;
        private Label label2;
        private Button btnAddBook;
        private Button btnAddMember;
    }
}
