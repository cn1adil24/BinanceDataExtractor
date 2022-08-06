namespace DataVisualizer
{
    partial class FormBase
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
            this.groupBoxRecordCount = new System.Windows.Forms.GroupBox();
            this.numericUpDownRecordCount = new System.Windows.Forms.NumericUpDown();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxReadBottom = new System.Windows.Forms.CheckBox();
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.groupBoxRecordCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecordCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRecordCount
            // 
            this.groupBoxRecordCount.Controls.Add(this.numericUpDownRecordCount);
            this.groupBoxRecordCount.Controls.Add(this.buttonApply);
            this.groupBoxRecordCount.Controls.Add(this.checkBoxReadBottom);
            this.groupBoxRecordCount.Controls.Add(this.labelRecordCount);
            this.groupBoxRecordCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRecordCount.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRecordCount.Name = "groupBoxRecordCount";
            this.groupBoxRecordCount.Size = new System.Drawing.Size(800, 39);
            this.groupBoxRecordCount.TabIndex = 0;
            this.groupBoxRecordCount.TabStop = false;
            // 
            // numericUpDownRecordCount
            // 
            this.numericUpDownRecordCount.Location = new System.Drawing.Point(94, 14);
            this.numericUpDownRecordCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRecordCount.Name = "numericUpDownRecordCount";
            this.numericUpDownRecordCount.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownRecordCount.TabIndex = 1;
            this.numericUpDownRecordCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(200, 12);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonApply.Size = new System.Drawing.Size(53, 23);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadBottom
            // 
            this.checkBoxReadBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxReadBottom.AutoSize = true;
            this.checkBoxReadBottom.Location = new System.Drawing.Point(678, 15);
            this.checkBoxReadBottom.Name = "checkBoxReadBottom";
            this.checkBoxReadBottom.Size = new System.Drawing.Size(110, 17);
            this.checkBoxReadBottom.TabIndex = 2;
            this.checkBoxReadBottom.Text = "Read from bottom";
            this.checkBoxReadBottom.UseVisualStyleBackColor = true;
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.AutoSize = true;
            this.labelRecordCount.Location = new System.Drawing.Point(12, 16);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(76, 13);
            this.labelRecordCount.TabIndex = 0;
            this.labelRecordCount.Text = "Record Count:";
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxRecordCount);
            this.Name = "FormBase";
            this.Text = "FormBase";
            this.groupBoxRecordCount.ResumeLayout(false);
            this.groupBoxRecordCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecordCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBoxRecordCount;
        private System.Windows.Forms.CheckBox checkBoxReadBottom;
        private System.Windows.Forms.Label labelRecordCount;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.NumericUpDown numericUpDownRecordCount;
    }
}