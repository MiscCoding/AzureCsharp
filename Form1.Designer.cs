namespace WinFormApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtBxResourceGroupName = new System.Windows.Forms.TextBox();
            this.txtBxVMName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxVMUserName = new System.Windows.Forms.TextBox();
            this.txtBxVMPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxPublicIPName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBxRegionData = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxVnetwork = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxAddressSpace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBxSubnetName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBxSubnetValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBxNICDefinition = new System.Windows.Forms.TextBox();
            this.cmbBxPublisher = new System.Windows.Forms.ComboBox();
            this.cmbBxOffer = new System.Windows.Forms.ComboBox();
            this.cmbBxSku = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBlobInfoGet = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBxBlobContainerName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBxSnapshotName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Azure VM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBxResourceGroupName
            // 
            this.txtBxResourceGroupName.Location = new System.Drawing.Point(181, 34);
            this.txtBxResourceGroupName.Name = "txtBxResourceGroupName";
            this.txtBxResourceGroupName.Size = new System.Drawing.Size(179, 20);
            this.txtBxResourceGroupName.TabIndex = 1;
            // 
            // txtBxVMName
            // 
            this.txtBxVMName.Location = new System.Drawing.Point(569, 34);
            this.txtBxVMName.Name = "txtBxVMName";
            this.txtBxVMName.Size = new System.Drawing.Size(179, 20);
            this.txtBxVMName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resource Group Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Virtual Machine Name";
            // 
            // txtBxVMUserName
            // 
            this.txtBxVMUserName.Location = new System.Drawing.Point(569, 60);
            this.txtBxVMUserName.Name = "txtBxVMUserName";
            this.txtBxVMUserName.Size = new System.Drawing.Size(179, 20);
            this.txtBxVMUserName.TabIndex = 5;
            // 
            // txtBxVMPasswd
            // 
            this.txtBxVMPasswd.Location = new System.Drawing.Point(569, 90);
            this.txtBxVMPasswd.Name = "txtBxVMPasswd";
            this.txtBxVMPasswd.Size = new System.Drawing.Size(179, 20);
            this.txtBxVMPasswd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "VM Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "VM Password";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(178, 9);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(77, 13);
            this.lblCurrentStatus.TabIndex = 9;
            this.lblCurrentStatus.Text = "Current Status ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Public IP name";
            // 
            // txtBxPublicIPName
            // 
            this.txtBxPublicIPName.Location = new System.Drawing.Point(181, 64);
            this.txtBxPublicIPName.Name = "txtBxPublicIPName";
            this.txtBxPublicIPName.Size = new System.Drawing.Size(179, 20);
            this.txtBxPublicIPName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Region";
            // 
            // cmbBxRegionData
            // 
            this.cmbBxRegionData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRegionData.FormattingEnabled = true;
            this.cmbBxRegionData.Location = new System.Drawing.Point(181, 95);
            this.cmbBxRegionData.Name = "cmbBxRegionData";
            this.cmbBxRegionData.Size = new System.Drawing.Size(179, 21);
            this.cmbBxRegionData.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Virtual network name";
            // 
            // txtBxVnetwork
            // 
            this.txtBxVnetwork.Location = new System.Drawing.Point(181, 129);
            this.txtBxVnetwork.Name = "txtBxVnetwork";
            this.txtBxVnetwork.Size = new System.Drawing.Size(179, 20);
            this.txtBxVnetwork.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Address space";
            // 
            // txtBxAddressSpace
            // 
            this.txtBxAddressSpace.Location = new System.Drawing.Point(181, 163);
            this.txtBxAddressSpace.Name = "txtBxAddressSpace";
            this.txtBxAddressSpace.Size = new System.Drawing.Size(179, 20);
            this.txtBxAddressSpace.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Subnet name";
            // 
            // txtBxSubnetName
            // 
            this.txtBxSubnetName.Location = new System.Drawing.Point(181, 197);
            this.txtBxSubnetName.Name = "txtBxSubnetName";
            this.txtBxSubnetName.Size = new System.Drawing.Size(179, 20);
            this.txtBxSubnetName.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Subnet";
            // 
            // txtBxSubnetValue
            // 
            this.txtBxSubnetValue.Location = new System.Drawing.Point(181, 223);
            this.txtBxSubnetValue.Name = "txtBxSubnetValue";
            this.txtBxSubnetValue.Size = new System.Drawing.Size(179, 20);
            this.txtBxSubnetValue.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "NIC definition";
            // 
            // txtBxNICDefinition
            // 
            this.txtBxNICDefinition.Location = new System.Drawing.Point(181, 255);
            this.txtBxNICDefinition.Name = "txtBxNICDefinition";
            this.txtBxNICDefinition.Size = new System.Drawing.Size(179, 20);
            this.txtBxNICDefinition.TabIndex = 24;
            // 
            // cmbBxPublisher
            // 
            this.cmbBxPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxPublisher.FormattingEnabled = true;
            this.cmbBxPublisher.Location = new System.Drawing.Point(569, 124);
            this.cmbBxPublisher.Name = "cmbBxPublisher";
            this.cmbBxPublisher.Size = new System.Drawing.Size(121, 21);
            this.cmbBxPublisher.TabIndex = 25;
            // 
            // cmbBxOffer
            // 
            this.cmbBxOffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxOffer.FormattingEnabled = true;
            this.cmbBxOffer.Location = new System.Drawing.Point(569, 158);
            this.cmbBxOffer.Name = "cmbBxOffer";
            this.cmbBxOffer.Size = new System.Drawing.Size(121, 21);
            this.cmbBxOffer.TabIndex = 26;
            // 
            // cmbBxSku
            // 
            this.cmbBxSku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxSku.FormattingEnabled = true;
            this.cmbBxSku.Location = new System.Drawing.Point(569, 189);
            this.cmbBxSku.Name = "cmbBxSku";
            this.cmbBxSku.Size = new System.Drawing.Size(121, 21);
            this.cmbBxSku.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(484, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Publisher";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(484, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Offer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(484, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Sku";
            // 
            // btnBlobInfoGet
            // 
            this.btnBlobInfoGet.Location = new System.Drawing.Point(198, 415);
            this.btnBlobInfoGet.Name = "btnBlobInfoGet";
            this.btnBlobInfoGet.Size = new System.Drawing.Size(144, 23);
            this.btnBlobInfoGet.TabIndex = 31;
            this.btnBlobInfoGet.Text = "VMBlobInfoGet";
            this.btnBlobInfoGet.UseVisualStyleBackColor = true;
            this.btnBlobInfoGet.Click += new System.EventHandler(this.btnBlobInfoGet_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(446, 258);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Blob Container Name ";
            // 
            // txtBxBlobContainerName
            // 
            this.txtBxBlobContainerName.Location = new System.Drawing.Point(567, 254);
            this.txtBxBlobContainerName.Name = "txtBxBlobContainerName";
            this.txtBxBlobContainerName.Size = new System.Drawing.Size(179, 20);
            this.txtBxBlobContainerName.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(446, 228);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "SnapshotName ";
            // 
            // txtBxSnapshotName
            // 
            this.txtBxSnapshotName.Location = new System.Drawing.Point(567, 225);
            this.txtBxSnapshotName.Name = "txtBxSnapshotName";
            this.txtBxSnapshotName.Size = new System.Drawing.Size(179, 20);
            this.txtBxSnapshotName.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 450);
            this.Controls.Add(this.txtBxSnapshotName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtBxBlobContainerName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnBlobInfoGet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBxSku);
            this.Controls.Add(this.cmbBxOffer);
            this.Controls.Add(this.cmbBxPublisher);
            this.Controls.Add(this.txtBxNICDefinition);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBxSubnetValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBxSubnetName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBxAddressSpace);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBxVnetwork);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBxRegionData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBxPublicIPName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxVMPasswd);
            this.Controls.Add(this.txtBxVMUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxVMName);
            this.Controls.Add(this.txtBxResourceGroupName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Azure VM Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBxResourceGroupName;
        private System.Windows.Forms.TextBox txtBxVMName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxVMUserName;
        private System.Windows.Forms.TextBox txtBxVMPasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxPublicIPName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBxRegionData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxVnetwork;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxAddressSpace;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBxSubnetName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBxSubnetValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBxNICDefinition;
        private System.Windows.Forms.ComboBox cmbBxPublisher;
        private System.Windows.Forms.ComboBox cmbBxOffer;
        private System.Windows.Forms.ComboBox cmbBxSku;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnBlobInfoGet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBxBlobContainerName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBxSnapshotName;
    }
}

