namespace WindowsSelling
{
    partial class frmProductAdd
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.txtcgst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmaterialtype = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(99, 6);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(216, 23);
            this.txtname.TabIndex = 1;
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(99, 66);
            this.txtrate.Name = "txtrate";
            this.txtrate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtrate.Size = new System.Drawing.Size(164, 23);
            this.txtrate.TabIndex = 3;
            this.txtrate.Text = "0.00";
            this.txtrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrate_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(137, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(228, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSGST
            // 
            this.txtSGST.Location = new System.Drawing.Point(97, 128);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSGST.Size = new System.Drawing.Size(165, 23);
            this.txtSGST.TabIndex = 5;
            this.txtSGST.Text = "0.00";
            this.txtSGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSGST_KeyPress);
            // 
            // txtcgst
            // 
            this.txtcgst.Location = new System.Drawing.Point(98, 98);
            this.txtcgst.Name = "txtcgst";
            this.txtcgst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcgst.Size = new System.Drawing.Size(165, 23);
            this.txtcgst.TabIndex = 4;
            this.txtcgst.Text = "0.00";
            this.txtcgst.TextChanged += new System.EventHandler(this.txtcgst_TextChanged);
            this.txtcgst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcgst_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "SGST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "CGST";
            // 
            // txtIGST
            // 
            this.txtIGST.Location = new System.Drawing.Point(98, 157);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIGST.Size = new System.Drawing.Size(165, 23);
            this.txtIGST.TabIndex = 6;
            this.txtIGST.Text = "0.00";
            this.txtIGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIGST_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "IGST";
            // 
            // txtmaterialtype
            // 
            this.txtmaterialtype.Location = new System.Drawing.Point(99, 36);
            this.txtmaterialtype.Name = "txtmaterialtype";
            this.txtmaterialtype.Size = new System.Drawing.Size(214, 23);
            this.txtmaterialtype.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Material Type";
            // 
            // frmProductAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 251);
            this.Controls.Add(this.txtmaterialtype);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIGST);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSGST);
            this.Controls.Add(this.txtcgst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtrate);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a New Product";
            this.Load += new System.EventHandler(this.frmProductAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.TextBox txtcgst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmaterialtype;
        private System.Windows.Forms.Label label6;
    }
}