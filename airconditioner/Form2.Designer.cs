namespace Electric
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Origin = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtorigin = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.viewAir = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 349);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1098, 174);
            this.dataGridView1.TabIndex = 0;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(813, 64);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(104, 50);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(813, 243);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(104, 50);
            this.Update.TabIndex = 2;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(813, 156);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(104, 50);
            this.Remove.TabIndex = 3;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Supplier Company List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(36, 95);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(20, 16);
            this.ID.TabIndex = 5;
            this.ID.Text = "ID";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(36, 133);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(44, 16);
            this.Name.TabIndex = 6;
            this.Name.Text = "Name";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(36, 209);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(75, 16);
            this.Description.TabIndex = 7;
            this.Description.Text = "Description";
            // 
            // Origin
            // 
            this.Origin.AutoSize = true;
            this.Origin.Location = new System.Drawing.Point(36, 171);
            this.Origin.Name = "Origin";
            this.Origin.Size = new System.Drawing.Size(42, 16);
            this.Origin.TabIndex = 8;
            this.Origin.Text = "Origin";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(127, 92);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(341, 22);
            this.txtid.TabIndex = 9;
            // 
            // txtorigin
            // 
            this.txtorigin.Location = new System.Drawing.Point(127, 171);
            this.txtorigin.Name = "txtorigin";
            this.txtorigin.Size = new System.Drawing.Size(341, 22);
            this.txtorigin.TabIndex = 10;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(127, 133);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(341, 22);
            this.txtname.TabIndex = 11;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(127, 209);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(555, 103);
            this.txtdescription.TabIndex = 12;
            // 
            // viewAir
            // 
            this.viewAir.Location = new System.Drawing.Point(969, 157);
            this.viewAir.Name = "viewAir";
            this.viewAir.Size = new System.Drawing.Size(104, 50);
            this.viewAir.TabIndex = 13;
            this.viewAir.Text = "View devices";
            this.viewAir.UseVisualStyleBackColor = true;
            this.viewAir.Click += new System.EventHandler(this.viewAir_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(969, 243);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(104, 50);
            this.LogOut.TabIndex = 14;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 535);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.viewAir);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtorigin);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.Origin);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.dataGridView1);
            
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label Origin;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtorigin;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Button viewAir;
        private System.Windows.Forms.Button LogOut;
    }
}