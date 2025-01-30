namespace LibraryManagementSystem.UI
{
    partial class AddBookForm
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
            lblTitle = new Label();
            lblAddBook = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblGenre = new Label();
            txtGenre = new TextBox();
            lblPublishedYear = new Label();
            txtPublishedYear = new TextBox();
            btnAddBook = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(24, 121);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(70, 38);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Title";
            // 
            // lblAddBook
            // 
            lblAddBook.AutoSize = true;
            lblAddBook.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddBook.Location = new Point(24, 18);
            lblAddBook.Margin = new Padding(10, 0, 10, 0);
            lblAddBook.Name = "lblAddBook";
            lblAddBook.Size = new Size(232, 62);
            lblAddBook.TabIndex = 7;
            lblAddBook.Text = "Add Book";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(24, 162);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(438, 46);
            txtTitle.TabIndex = 6;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(24, 235);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(102, 38);
            lblAuthor.TabIndex = 10;
            lblAuthor.Text = "Author";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthor.Location = new Point(24, 276);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(438, 46);
            txtAuthor.TabIndex = 9;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(24, 350);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(92, 38);
            lblGenre.TabIndex = 12;
            lblGenre.Text = "Genre";
            // 
            // txtGenre
            // 
            txtGenre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGenre.Location = new Point(24, 391);
            txtGenre.Multiline = true;
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(438, 46);
            txtGenre.TabIndex = 11;
            // 
            // lblPublishedYear
            // 
            lblPublishedYear.AutoSize = true;
            lblPublishedYear.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublishedYear.Location = new Point(24, 467);
            lblPublishedYear.Name = "lblPublishedYear";
            lblPublishedYear.Size = new Size(198, 38);
            lblPublishedYear.TabIndex = 14;
            lblPublishedYear.Text = "Published Year";
            // 
            // txtPublishedYear
            // 
            txtPublishedYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPublishedYear.Location = new Point(24, 508);
            txtPublishedYear.Multiline = true;
            txtPublishedYear.Name = "txtPublishedYear";
            txtPublishedYear.Size = new Size(438, 46);
            txtPublishedYear.TabIndex = 13;
            // 
            // btnAddBook
            // 
            btnAddBook.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddBook.Location = new Point(119, 580);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(230, 55);
            btnAddBook.TabIndex = 15;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 647);
            Controls.Add(btnAddBook);
            Controls.Add(lblPublishedYear);
            Controls.Add(txtPublishedYear);
            Controls.Add(lblGenre);
            Controls.Add(txtGenre);
            Controls.Add(lblAuthor);
            Controls.Add(txtAuthor);
            Controls.Add(lblTitle);
            Controls.Add(lblAddBook);
            Controls.Add(txtTitle);
            Name = "AddBookForm";
            Text = "AddBookForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAddBook;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblGenre;
        private TextBox txtGenre;
        private Label lblPublishedYear;
        private TextBox txtPublishedYear;
        private Button btnAddBook;
    }
}