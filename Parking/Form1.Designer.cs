namespace Parking
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
            this.CarIn = new System.Windows.Forms.Button();
            this.CarOut = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AvailableSpots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carId = new System.Windows.Forms.TextBox();
            this.CarLeavesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvParkId = new System.Windows.Forms.ListView();
            this.ParkId = new System.Windows.Forms.TextBox();
            this.btnParkId = new System.Windows.Forms.Button();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Floor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CarIn
            // 
            this.CarIn.Location = new System.Drawing.Point(42, 119);
            this.CarIn.Name = "CarIn";
            this.CarIn.Size = new System.Drawing.Size(75, 23);
            this.CarIn.TabIndex = 1;
            this.CarIn.Text = "Car Enters";
            this.CarIn.UseVisualStyleBackColor = true;
            this.CarIn.Click += new System.EventHandler(this.CarIn_Click);
            // 
            // CarOut
            // 
            this.CarOut.Location = new System.Drawing.Point(42, 174);
            this.CarOut.Name = "CarOut";
            this.CarOut.Size = new System.Drawing.Size(75, 23);
            this.CarOut.TabIndex = 7;
            this.CarOut.Text = "Car Leaves";
            this.CarOut.UseVisualStyleBackColor = true;
            this.CarOut.Click += new System.EventHandler(this.CarOut_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 73);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AvailableSpots,
            this.NextAvailable,
            this.TotalRevenue,
            this.Last30});
            this.dataGridView1.Location = new System.Drawing.Point(42, 236);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 58);
            this.dataGridView1.TabIndex = 9;
            // 
            // AvailableSpots
            // 
            this.AvailableSpots.HeaderText = "AvailableSpots";
            this.AvailableSpots.Name = "AvailableSpots";
            // 
            // NextAvailable
            // 
            this.NextAvailable.HeaderText = "Next available spot";
            this.NextAvailable.Name = "NextAvailable";
            // 
            // TotalRevenue
            // 
            this.TotalRevenue.HeaderText = "Total Revenue";
            this.TotalRevenue.Name = "TotalRevenue";
            // 
            // Last30
            // 
            this.Last30.HeaderText = "Last 30 Days revenue";
            this.Last30.Name = "Last30";
            // 
            // carId
            // 
            this.carId.Location = new System.Drawing.Point(42, 102);
            this.carId.Name = "carId";
            this.carId.Size = new System.Drawing.Size(100, 20);
            this.carId.TabIndex = 10;
            this.carId.Text = "Enter Car ID";
            this.carId.Click += new System.EventHandler(this.emptyText);
            // 
            // CarLeavesBox
            // 
            this.CarLeavesBox.Location = new System.Drawing.Point(42, 155);
            this.CarLeavesBox.Name = "CarLeavesBox";
            this.CarLeavesBox.Size = new System.Drawing.Size(100, 20);
            this.CarLeavesBox.TabIndex = 11;
            this.CarLeavesBox.Text = "Enter Car ID";
            this.CarLeavesBox.Click += new System.EventHandler(this.emptyText);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(142, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 30);
            this.label1.TabIndex = 12;
            this.label1.Visible = false;
            // 
            // lvParkId
            // 
            this.lvParkId.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.Floor});
            this.lvParkId.Location = new System.Drawing.Point(339, 119);
            this.lvParkId.Name = "lvParkId";
            this.lvParkId.Size = new System.Drawing.Size(112, 56);
            this.lvParkId.TabIndex = 13;
            this.lvParkId.UseCompatibleStateImageBehavior = false;
            this.lvParkId.View = System.Windows.Forms.View.Details;
            // 
            // ParkId
            // 
            this.ParkId.Location = new System.Drawing.Point(339, 99);
            this.ParkId.Name = "ParkId";
            this.ParkId.Size = new System.Drawing.Size(112, 20);
            this.ParkId.TabIndex = 15;
            this.ParkId.Text = "Enter Parking ID";
            this.ParkId.Click += new System.EventHandler(this.emptyText);
            // 
            // btnParkId
            // 
            this.btnParkId.Location = new System.Drawing.Point(339, 175);
            this.btnParkId.Name = "btnParkId";
            this.btnParkId.Size = new System.Drawing.Size(112, 21);
            this.btnParkId.TabIndex = 14;
            this.btnParkId.Text = "Check Status";
            this.btnParkId.UseVisualStyleBackColor = true;
            this.btnParkId.Click += new System.EventHandler(this.btnParkId_Click);
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 68;
            // 
            // Floor
            // 
            this.Floor.Text = "Floor";
            this.Floor.Width = 40;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(195, 119);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(111, 28);
            this.btnFill.TabIndex = 16;
            this.btnFill.Text = "Fill Parking-lot";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(195, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 28);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear Parking-lot";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(384, 294);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 23);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset Revenue";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 329);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.ParkId);
            this.Controls.Add(this.btnParkId);
            this.Controls.Add(this.lvParkId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarLeavesBox);
            this.Controls.Add(this.carId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.CarOut);
            this.Controls.Add(this.CarIn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CarIn;
        private System.Windows.Forms.Button CarOut;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableSpots;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRevenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last30;
        private System.Windows.Forms.TextBox carId;
        private System.Windows.Forms.TextBox CarLeavesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvParkId;
        private System.Windows.Forms.TextBox ParkId;
        private System.Windows.Forms.Button btnParkId;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Floor;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReset;
    }
}

