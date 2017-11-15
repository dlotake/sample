namespace WindowsSelling
{
    partial class frmActivationWizard
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
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.txtActivateCode = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnactivation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Activation Code";
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineCode.Location = new System.Drawing.Point(145, 25);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMachineCode.Size = new System.Drawing.Size(357, 31);
            this.txtMachineCode.TabIndex = 2;
            // 
            // txtActivateCode
            // 
            this.txtActivateCode.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivateCode.Location = new System.Drawing.Point(145, 60);
            this.txtActivateCode.Name = "txtActivateCode";
            this.txtActivateCode.Size = new System.Drawing.Size(357, 31);
            this.txtActivateCode.TabIndex = 3;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(427, 100);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnactivation
            // 
            this.btnactivation.Location = new System.Drawing.Point(346, 100);
            this.btnactivation.Name = "btnactivation";
            this.btnactivation.Size = new System.Drawing.Size(75, 23);
            this.btnactivation.TabIndex = 5;
            this.btnactivation.Text = "Activate";
            this.btnactivation.UseVisualStyleBackColor = true;
            this.btnactivation.Click += new System.EventHandler(this.btnactivation_Click);
            // 
            // frmActivationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 131);
            this.Controls.Add(this.btnactivation);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.txtActivateCode);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmActivationWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation Wizard";
            this.Load += new System.EventHandler(this.frmActivationWizard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.TextBox txtActivateCode;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnactivation;
    }
}