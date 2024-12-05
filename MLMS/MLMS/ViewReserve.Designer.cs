namespace MLMS
{
    partial class ViewReserve
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReserve));
            this.currentReserveButton = new System.Windows.Forms.Button();
            this.memberNameLabel = new System.Windows.Forms.Label();
            this.memberNameTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.libraryDataSet = new MLMS.LibraryDataSet();
            this.reserveBooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reserveBooksTableAdapter = new MLMS.LibraryDataSetTableAdapters.ReserveBooksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserveBooksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // currentReserveButton
            // 
            this.currentReserveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentReserveButton.Location = new System.Drawing.Point(522, 41);
            this.currentReserveButton.Name = "currentReserveButton";
            this.currentReserveButton.Size = new System.Drawing.Size(313, 41);
            this.currentReserveButton.TabIndex = 0;
            this.currentReserveButton.Text = "View Current Reservations";
            this.currentReserveButton.UseVisualStyleBackColor = true;
            this.currentReserveButton.Click += new System.EventHandler(this.currentReserveButton_Click);
            // 
            // memberNameLabel
            // 
            this.memberNameLabel.AutoSize = true;
            this.memberNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberNameLabel.Location = new System.Drawing.Point(78, 31);
            this.memberNameLabel.Name = "memberNameLabel";
            this.memberNameLabel.Size = new System.Drawing.Size(174, 29);
            this.memberNameLabel.TabIndex = 1;
            this.memberNameLabel.Text = "Member Name";
            // 
            // memberNameTextBox
            // 
            this.memberNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberNameTextBox.Location = new System.Drawing.Point(258, 31);
            this.memberNameTextBox.Name = "memberNameTextBox";
            this.memberNameTextBox.Size = new System.Drawing.Size(158, 34);
            this.memberNameTextBox.TabIndex = 2;
            this.memberNameTextBox.TextChanged += new System.EventHandler(this.memberNameTextBob_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 338);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // libraryDataSet
            // 
            this.libraryDataSet.DataSetName = "LibraryDataSet";
            this.libraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reserveBooksBindingSource
            // 
            this.reserveBooksBindingSource.DataMember = "ReserveBooks";
            this.reserveBooksBindingSource.DataSource = this.libraryDataSet;
            // 
            // reserveBooksTableAdapter
            // 
            this.reserveBooksTableAdapter.ClearBeforeFill = true;
            // 
            // ViewReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.memberNameTextBox);
            this.Controls.Add(this.memberNameLabel);
            this.Controls.Add(this.currentReserveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewReserve";
            this.Text = "View Reserve";
            this.Load += new System.EventHandler(this.ViewReserve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserveBooksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button currentReserveButton;
        private System.Windows.Forms.Label memberNameLabel;
        private System.Windows.Forms.TextBox memberNameTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private LibraryDataSet libraryDataSet;
        private System.Windows.Forms.BindingSource reserveBooksBindingSource;
        private LibraryDataSetTableAdapters.ReserveBooksTableAdapter reserveBooksTableAdapter;
    }
}