namespace LibraryManagementSystem.UI.Forms
{
    partial class UpdateBookForm
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
            txtId = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtGenre = new TextBox();
            txtPublishedYear = new TextBox();
            lblGenre = new Label();
            lblAuthor = new Label();
            lblId = new Label();
            lblPublishedYear = new Label();
            lblTitle = new Label();
            btnUpdateBook = new Button();
            lblUpdateBook = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(25, 136);
            txtId.Multiline = true;
            txtId.Name = "txtId";
            txtId.Size = new Size(438, 46);
            txtId.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(25, 244);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(438, 46);
            txtTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthor.Location = new Point(25, 345);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(438, 46);
            txtAuthor.TabIndex = 3;
            // 
            // txtGenre
            // 
            txtGenre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGenre.Location = new Point(25, 442);
            txtGenre.Multiline = true;
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(438, 46);
            txtGenre.TabIndex = 4;
            // 
            // txtPublishedYear
            // 
            txtPublishedYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPublishedYear.Location = new Point(25, 557);
            txtPublishedYear.Multiline = true;
            txtPublishedYear.Name = "txtPublishedYear";
            txtPublishedYear.Size = new Size(438, 46);
            txtPublishedYear.TabIndex = 5;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(25, 401);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(92, 38);
            lblGenre.TabIndex = 14;
            lblGenre.Text = "Genre";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(25, 304);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(102, 38);
            lblAuthor.TabIndex = 15;
            lblAuthor.Text = "Author";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblId.Location = new Point(25, 95);
            lblId.Name = "lblId";
            lblId.Size = new Size(40, 38);
            lblId.TabIndex = 16;
            lblId.Text = "Id";
            // 
            // lblPublishedYear
            // 
            lblPublishedYear.AutoSize = true;
            lblPublishedYear.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublishedYear.Location = new Point(25, 516);
            lblPublishedYear.Name = "lblPublishedYear";
            lblPublishedYear.Size = new Size(198, 38);
            lblPublishedYear.TabIndex = 17;
            lblPublishedYear.Text = "Published Year";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(25, 203);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(70, 38);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Title";
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateBook.Location = new Point(122, 621);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(230, 55);
            btnUpdateBook.TabIndex = 19;
            btnUpdateBook.Text = "Update";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // lblUpdateBook
            // 
            lblUpdateBook.AutoSize = true;
            lblUpdateBook.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUpdateBook.Location = new Point(19, 9);
            lblUpdateBook.Margin = new Padding(10, 0, 10, 0);
            lblUpdateBook.Name = "lblUpdateBook";
            lblUpdateBook.Size = new Size(299, 62);
            lblUpdateBook.TabIndex = 20;
            lblUpdateBook.Text = "Update Book";
            // 
            // UpdateBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 688);
            Controls.Add(lblUpdateBook);
            Controls.Add(btnUpdateBook);
            Controls.Add(lblTitle);
            Controls.Add(lblPublishedYear);
            Controls.Add(lblId);
            Controls.Add(lblAuthor);
            Controls.Add(lblGenre);
            Controls.Add(txtPublishedYear);
            Controls.Add(txtGenre);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(txtId);
            Name = "UpdateBookForm";
            Text = "BookDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtGenre;
        private TextBox txtPublishedYear;
        private Label lblGenre;
        private Label lblAuthor;
        private Label lblId;
        private Label lblPublishedYear;
        private Label lblTitle;
        private Button btnUpdateBook;
        private Label lblUpdateBook;
    }
}