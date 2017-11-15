namespace WindowsSelling
{
    partial class frmCustomerAdd
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtmobilenumber = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtGSTNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mobile Number";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(160, 6);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(391, 23);
            this.txtname.TabIndex = 8;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(160, 40);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(391, 61);
            this.txtaddress.TabIndex = 9;
            // 
            // txtmobilenumber
            // 
            this.txtmobilenumber.Location = new System.Drawing.Point(160, 111);
            this.txtmobilenumber.MaxLength = 10;
            this.txtmobilenumber.Name = "txtmobilenumber";
            this.txtmobilenumber.Size = new System.Drawing.Size(256, 23);
            this.txtmobilenumber.TabIndex = 10;
            this.txtmobilenumber.TextChanged += new System.EventHandler(this.txtmobilenumber_TextChanged);
            this.txtmobilenumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmobilenumber_KeyPress);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(375, 181);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(85, 36);
            this.btnsave.TabIndex = 12;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(466, 181);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(85, 36);
            this.btnclose.TabIndex = 13;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtGSTNumber
            // 
            this.txtGSTNumber.Location = new System.Drawing.Point(160, 148);
            this.txtGSTNumber.Name = "txtGSTNumber";
            this.txtGSTNumber.Size = new System.Drawing.Size(256, 23);
            this.txtGSTNumber.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "GST Number(Optional)";
            // 
            // frmCustomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 224);
            this.Controls.Add(this.txtGSTNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtmobilenumber);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a New Customer";
            this.Load += new System.EventHandler(this.frmCustomerAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtmobilenumber;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtGSTNumber;
        private System.Windows.Forms.Label label3;
    }
}