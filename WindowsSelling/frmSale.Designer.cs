namespace WindowsSelling
{
    partial class frmSale
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
            this.cmbcustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductIGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductIGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saledetailid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttotalitemcount = new System.Windows.Forms.TextBox();
            this.txttotalCGSTAmount = new System.Windows.Forms.TextBox();
            this.txttotalSGSTAmount = new System.Windows.Forms.TextBox();
            this.txtTotalTaxAmount = new System.Windows.Forms.TextBox();
            this.txttotalIGSTAmount = new System.Windows.Forms.TextBox();
            this.txtfinalAmount = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnsaveprint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmobilenumber = new System.Windows.Forms.TextBox();
            this.txtdiscountamount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtpaidamount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPaymentModeDetails = new System.Windows.Forms.TextBox();
            this.cmbpaymentmode = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // cmbcustomer
            // 
            this.cmbcustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcustomer.FormattingEnabled = true;
            this.cmbcustomer.Location = new System.Drawing.Point(83, 7);
            this.cmbcustomer.Name = "cmbcustomer";
            this.cmbcustomer.Size = new System.Drawing.Size(449, 25);
            this.cmbcustomer.TabIndex = 1;
            this.cmbcustomer.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(699, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.ProductRate,
            this.ProductQuantity,
            this.ProductTotal,
            this.Discount,
            this.DiscountAmount,
            this.ProductCGST,
            this.ProductCGSTAmount,
            this.ProductSGST,
            this.ProductSGSTAmount,
            this.ProductIGST,
            this.ProductIGSTAmount,
            this.TotalTax,
            this.FinalTotal,
            this.saledetailid});
            this.dataGridView1.Location = new System.Drawing.Point(10, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1340, 404);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "Item Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductRate
            // 
            this.ProductRate.HeaderText = "Rate";
            this.ProductRate.Name = "ProductRate";
            this.ProductRate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductRate.Width = 60;
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.HeaderText = "Quantity";
            this.ProductQuantity.Name = "ProductQuantity";
            this.ProductQuantity.Width = 60;
            // 
            // ProductTotal
            // 
            this.ProductTotal.HeaderText = "Total";
            this.ProductTotal.Name = "ProductTotal";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.Width = 60;
            // 
            // DiscountAmount
            // 
            this.DiscountAmount.HeaderText = "Discount Amount";
            this.DiscountAmount.Name = "DiscountAmount";
            // 
            // ProductCGST
            // 
            this.ProductCGST.HeaderText = "CGST";
            this.ProductCGST.Name = "ProductCGST";
            this.ProductCGST.Width = 60;
            // 
            // ProductCGSTAmount
            // 
            this.ProductCGSTAmount.HeaderText = "CGST Amount";
            this.ProductCGSTAmount.Name = "ProductCGSTAmount";
            // 
            // ProductSGST
            // 
            this.ProductSGST.HeaderText = "SGST";
            this.ProductSGST.Name = "ProductSGST";
            this.ProductSGST.Width = 60;
            // 
            // ProductSGSTAmount
            // 
            this.ProductSGSTAmount.HeaderText = "SGST Amount";
            this.ProductSGSTAmount.Name = "ProductSGSTAmount";
            // 
            // ProductIGST
            // 
            this.ProductIGST.HeaderText = "IGST";
            this.ProductIGST.Name = "ProductIGST";
            this.ProductIGST.Width = 60;
            // 
            // ProductIGSTAmount
            // 
            this.ProductIGSTAmount.HeaderText = "IGST Amount";
            this.ProductIGSTAmount.Name = "ProductIGSTAmount";
            // 
            // TotalTax
            // 
            this.TotalTax.HeaderText = "Total Tax";
            this.TotalTax.Name = "TotalTax";
            // 
            // FinalTotal
            // 
            this.FinalTotal.HeaderText = "Final Total";
            this.FinalTotal.Name = "FinalTotal";
            // 
            // saledetailid
            // 
            this.saledetailid.HeaderText = "Sale Detail Id";
            this.saledetailid.Name = "saledetailid";
            this.saledetailid.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total CGST Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 583);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total SGST Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total Final Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 610);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total IGST Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 528);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Total Tax Amount";
            // 
            // txttotalitemcount
            // 
            this.txttotalitemcount.Location = new System.Drawing.Point(132, 525);
            this.txttotalitemcount.Name = "txttotalitemcount";
            this.txttotalitemcount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttotalitemcount.Size = new System.Drawing.Size(167, 22);
            this.txttotalitemcount.TabIndex = 11;
            // 
            // txttotalCGSTAmount
            // 
            this.txttotalCGSTAmount.Location = new System.Drawing.Point(132, 555);
            this.txttotalCGSTAmount.Name = "txttotalCGSTAmount";
            this.txttotalCGSTAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttotalCGSTAmount.Size = new System.Drawing.Size(167, 22);
            this.txttotalCGSTAmount.TabIndex = 12;
            // 
            // txttotalSGSTAmount
            // 
            this.txttotalSGSTAmount.Location = new System.Drawing.Point(132, 583);
            this.txttotalSGSTAmount.Name = "txttotalSGSTAmount";
            this.txttotalSGSTAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttotalSGSTAmount.Size = new System.Drawing.Size(167, 22);
            this.txttotalSGSTAmount.TabIndex = 13;
            // 
            // txtTotalTaxAmount
            // 
            this.txtTotalTaxAmount.Location = new System.Drawing.Point(439, 528);
            this.txtTotalTaxAmount.Name = "txtTotalTaxAmount";
            this.txtTotalTaxAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalTaxAmount.Size = new System.Drawing.Size(167, 22);
            this.txtTotalTaxAmount.TabIndex = 14;
            // 
            // txttotalIGSTAmount
            // 
            this.txttotalIGSTAmount.Location = new System.Drawing.Point(132, 610);
            this.txttotalIGSTAmount.Name = "txttotalIGSTAmount";
            this.txttotalIGSTAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttotalIGSTAmount.Size = new System.Drawing.Size(167, 22);
            this.txttotalIGSTAmount.TabIndex = 15;
            // 
            // txtfinalAmount
            // 
            this.txtfinalAmount.Location = new System.Drawing.Point(439, 556);
            this.txtfinalAmount.Name = "txtfinalAmount";
            this.txtfinalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfinalAmount.Size = new System.Drawing.Size(167, 22);
            this.txtfinalAmount.TabIndex = 16;
            this.txtfinalAmount.TextChanged += new System.EventHandler(this.txtfinalAmount_TextChanged);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(1038, 528);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(74, 36);
            this.btnsave.TabIndex = 17;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnsaveprint
            // 
            this.btnsaveprint.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsaveprint.Location = new System.Drawing.Point(1118, 528);
            this.btnsaveprint.Name = "btnsaveprint";
            this.btnsaveprint.Size = new System.Drawing.Size(144, 36);
            this.btnsaveprint.TabIndex = 18;
            this.btnsaveprint.Text = "Save and &Print";
            this.btnsaveprint.UseVisualStyleBackColor = true;
            this.btnsaveprint.Click += new System.EventHandler(this.btnsaveprint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1268, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 36);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Address";
            // 
            // txtaddress
            // 
            this.txtaddress.Enabled = false;
            this.txtaddress.Location = new System.Drawing.Point(83, 47);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(449, 56);
            this.txtaddress.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(539, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Mobile Number";
            // 
            // txtmobilenumber
            // 
            this.txtmobilenumber.Enabled = false;
            this.txtmobilenumber.Location = new System.Drawing.Point(645, 50);
            this.txtmobilenumber.Name = "txtmobilenumber";
            this.txtmobilenumber.Size = new System.Drawing.Size(193, 22);
            this.txtmobilenumber.TabIndex = 23;
            // 
            // txtdiscountamount
            // 
            this.txtdiscountamount.Location = new System.Drawing.Point(132, 638);
            this.txtdiscountamount.Name = "txtdiscountamount";
            this.txtdiscountamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdiscountamount.Size = new System.Drawing.Size(167, 22);
            this.txtdiscountamount.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 638);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Total Disc Amount";
            // 
            // txtpaidamount
            // 
            this.txtpaidamount.Location = new System.Drawing.Point(439, 585);
            this.txtpaidamount.Name = "txtpaidamount";
            this.txtpaidamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtpaidamount.Size = new System.Drawing.Size(167, 22);
            this.txtpaidamount.TabIndex = 27;
            this.txtpaidamount.TextChanged += new System.EventHandler(this.txtpaidamount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(316, 585);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 17);
            this.label12.TabIndex = 26;
            this.label12.Text = "Paid Amount";
            // 
            // txtRemaining
            // 
            this.txtRemaining.Location = new System.Drawing.Point(439, 613);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemaining.Size = new System.Drawing.Size(167, 22);
            this.txtRemaining.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(316, 613);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Remaining";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(316, 641);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Payment Mode";
            // 
            // txtPaymentModeDetails
            // 
            this.txtPaymentModeDetails.Location = new System.Drawing.Point(615, 616);
            this.txtPaymentModeDetails.Multiline = true;
            this.txtPaymentModeDetails.Name = "txtPaymentModeDetails";
            this.txtPaymentModeDetails.Size = new System.Drawing.Size(253, 50);
            this.txtPaymentModeDetails.TabIndex = 32;
            // 
            // cmbpaymentmode
            // 
            this.cmbpaymentmode.FormattingEnabled = true;
            this.cmbpaymentmode.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "NEFT"});
            this.cmbpaymentmode.Location = new System.Drawing.Point(439, 641);
            this.cmbpaymentmode.Name = "cmbpaymentmode";
            this.cmbpaymentmode.Size = new System.Drawing.Size(167, 25);
            this.cmbpaymentmode.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(612, 590);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "Payment Mode Details ";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(538, 7);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(109, 23);
            this.btnAddCustomer.TabIndex = 35;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(542, 78);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(109, 23);
            this.btnProductAdd.TabIndex = 36;
            this.btnProductAdd.Text = "Add Product";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(744, 75);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(94, 22);
            this.txtInvoiceNo.TabIndex = 38;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(664, 78);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 17);
            this.label16.TabIndex = 37;
            this.label16.Text = "Invoice No";
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 686);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnProductAdd);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbpaymentmode);
            this.Controls.Add(this.txtPaymentModeDetails);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRemaining);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtpaidamount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtdiscountamount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtmobilenumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnsaveprint);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtfinalAmount);
            this.Controls.Add(this.txttotalIGSTAmount);
            this.Controls.Add(this.txtTotalTaxAmount);
            this.Controls.Add(this.txttotalSGSTAmount);
            this.Controls.Add(this.txttotalCGSTAmount);
            this.Controls.Add(this.txttotalitemcount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcustomer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbcustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttotalitemcount;
        private System.Windows.Forms.TextBox txttotalCGSTAmount;
        private System.Windows.Forms.TextBox txttotalSGSTAmount;
        private System.Windows.Forms.TextBox txtTotalTaxAmount;
        private System.Windows.Forms.TextBox txttotalIGSTAmount;
        private System.Windows.Forms.TextBox txtfinalAmount;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnsaveprint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtmobilenumber;
        private System.Windows.Forms.TextBox txtdiscountamount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtpaidamount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemaining;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPaymentModeDetails;
        private System.Windows.Forms.ComboBox cmbpaymentmode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn saledetailid;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label16;
    }
}