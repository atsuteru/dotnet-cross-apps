namespace MyApp.WinForms
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OrganizationTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(827, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello WinForms(.Net Core)!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OrganizationTextBox);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 184);
            this.panel1.TabIndex = 1;
            // 
            // OrganizationTextBox
            // 
            this.OrganizationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrganizationTextBox.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OrganizationTextBox.Location = new System.Drawing.Point(205, 105);
            this.OrganizationTextBox.Name = "OrganizationTextBox";
            this.OrganizationTextBox.Size = new System.Drawing.Size(502, 39);
            this.OrganizationTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameTextBox.Location = new System.Drawing.Point(205, 29);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(502, 39);
            this.NameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(120, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "組織";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(120, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "氏名";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenerateButton.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GenerateButton.Location = new System.Drawing.Point(120, 10);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(10);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(587, 59);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "ビジネスカードを作成します";
            this.GenerateButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GenerateButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 252);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(120, 10, 120, 10);
            this.panel2.Size = new System.Drawing.Size(827, 79);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ResultTextBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 331);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 100);
            this.panel3.TabIndex = 4;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResultTextBox.Location = new System.Drawing.Point(205, 31);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(502, 39);
            this.ResultTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(120, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "結果";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 460);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox OrganizationTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label4;
    }
}

