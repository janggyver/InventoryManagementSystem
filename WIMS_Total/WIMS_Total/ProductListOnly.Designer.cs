namespace ProductListOnly
{
    partial class formProductListOnly
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
            this.dataGridViewProdLists = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdLists)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProdLists
            // 
            this.dataGridViewProdLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdLists.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewProdLists.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProdLists.Name = "dataGridViewProdLists";
            this.dataGridViewProdLists.Size = new System.Drawing.Size(1025, 94);
            this.dataGridViewProdLists.TabIndex = 0;
            this.dataGridViewProdLists.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProdLists_CellClick);
            // 
            // formProductListOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 106);
            this.Controls.Add(this.dataGridViewProdLists);
            this.Name = "formProductListOnly";
            this.Text = "Product List(s)";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formProductListOnly_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdLists)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProdLists;
    }
}