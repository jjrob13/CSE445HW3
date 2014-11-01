namespace RequiredServicesClientForm
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.storageServiceInputField = new System.Windows.Forms.TextBox();
            this.newsServiceSearchField = new System.Windows.Forms.TextBox();
            this.storageServiceUploadButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.storageServiceOutputField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.newsServiceSearchButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.newsServiceURLs = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "StorageService";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "NewsService";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "input: local file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "output: url of uploaded file";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "input: keyword";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "output: array of urls that lead to news about the keyword";
            // 
            // storageServiceInputField
            // 
            this.storageServiceInputField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.storageServiceInputField.Location = new System.Drawing.Point(129, 149);
            this.storageServiceInputField.Name = "storageServiceInputField";
            this.storageServiceInputField.Size = new System.Drawing.Size(167, 20);
            this.storageServiceInputField.TabIndex = 6;
            this.storageServiceInputField.TextChanged += new System.EventHandler(this.storageServiceInputField_TextChanged);
            // 
            // newsServiceSearchField
            // 
            this.newsServiceSearchField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newsServiceSearchField.Location = new System.Drawing.Point(155, 364);
            this.newsServiceSearchField.Name = "newsServiceSearchField";
            this.newsServiceSearchField.Size = new System.Drawing.Size(194, 20);
            this.newsServiceSearchField.TabIndex = 7;
            this.newsServiceSearchField.TextChanged += new System.EventHandler(this.newsServiceSearchField_TextChanged);
            // 
            // storageServiceUploadButton
            // 
            this.storageServiceUploadButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.storageServiceUploadButton.Location = new System.Drawing.Point(302, 146);
            this.storageServiceUploadButton.Name = "storageServiceUploadButton";
            this.storageServiceUploadButton.Size = new System.Drawing.Size(75, 23);
            this.storageServiceUploadButton.TabIndex = 8;
            this.storageServiceUploadButton.Text = "Upload";
            this.storageServiceUploadButton.UseVisualStyleBackColor = true;
            this.storageServiceUploadButton.Click += new System.EventHandler(this.storageServiceUploadButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "File to Upload:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(418, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Remote Location:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // storageServiceOutputField
            // 
            this.storageServiceOutputField.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.storageServiceOutputField.Location = new System.Drawing.Point(559, 149);
            this.storageServiceOutputField.Name = "storageServiceOutputField";
            this.storageServiceOutputField.Size = new System.Drawing.Size(255, 20);
            this.storageServiceOutputField.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(76, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Keyword:";
            // 
            // newsServiceSearchButton
            // 
            this.newsServiceSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newsServiceSearchButton.Location = new System.Drawing.Point(355, 361);
            this.newsServiceSearchButton.Name = "newsServiceSearchButton";
            this.newsServiceSearchButton.Size = new System.Drawing.Size(75, 23);
            this.newsServiceSearchButton.TabIndex = 13;
            this.newsServiceSearchButton.Text = "Search";
            this.newsServiceSearchButton.UseVisualStyleBackColor = true;
            this.newsServiceSearchButton.Click += new System.EventHandler(this.newsServiceSearchButton_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(594, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Output URLs";
            // 
            // newsServiceURLs
            // 
            this.newsServiceURLs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newsServiceURLs.Location = new System.Drawing.Point(469, 328);
            this.newsServiceURLs.Name = "newsServiceURLs";
            this.newsServiceURLs.Size = new System.Drawing.Size(345, 130);
            this.newsServiceURLs.TabIndex = 15;
            this.newsServiceURLs.UseCompatibleStateImageBehavior = false;
            this.newsServiceURLs.View = System.Windows.Forms.View.List;
            this.newsServiceURLs.SelectedIndexChanged += new System.EventHandler(this.newsServiceSearchButton_Click);
            this.newsServiceURLs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.newsServiceURLs_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 470);
            this.Controls.Add(this.newsServiceURLs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.newsServiceSearchButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.storageServiceOutputField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.storageServiceUploadButton);
            this.Controls.Add(this.newsServiceSearchField);
            this.Controls.Add(this.storageServiceInputField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox storageServiceInputField;
        private System.Windows.Forms.TextBox newsServiceSearchField;
        private System.Windows.Forms.Button storageServiceUploadButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox storageServiceOutputField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button newsServiceSearchButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView newsServiceURLs;
    }
}

