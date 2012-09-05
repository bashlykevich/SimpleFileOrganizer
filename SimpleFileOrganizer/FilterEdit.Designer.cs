namespace SimpleFileOrganizer
{
    partial class FilterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterEdit));
            this.edtExt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edtFilename = new System.Windows.Forms.TextBox();
            this.edtDirectory = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // edtExt
            // 
            this.edtExt.Location = new System.Drawing.Point(102, 9);
            this.edtExt.Name = "edtExt";
            this.edtExt.Size = new System.Drawing.Size(149, 20);
            this.edtExt.TabIndex = 0;
            this.edtExt.TextChanged += new System.EventHandler(this.edtExt_TextChanged);
            this.edtExt.MouseEnter += new System.EventHandler(this.edtExt_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Extension";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "FileName mask";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Output Directory";
            // 
            // edtFilename
            // 
            this.edtFilename.Enabled = false;
            this.edtFilename.Location = new System.Drawing.Point(102, 33);
            this.edtFilename.Name = "edtFilename";
            this.edtFilename.Size = new System.Drawing.Size(149, 20);
            this.edtFilename.TabIndex = 4;
            // 
            // edtDirectory
            // 
            this.edtDirectory.Location = new System.Drawing.Point(102, 60);
            this.edtDirectory.Name = "edtDirectory";
            this.edtDirectory.Size = new System.Drawing.Size(149, 20);
            this.edtDirectory.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(254, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 71);
            this.button1.TabIndex = 6;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Checked = true;
            this.rbCopy.Location = new System.Drawing.Point(102, 86);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(49, 17);
            this.rbCopy.TabIndex = 7;
            this.rbCopy.TabStop = true;
            this.rbCopy.Text = "Copy";
            this.rbCopy.UseVisualStyleBackColor = true;
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Location = new System.Drawing.Point(157, 86);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(52, 17);
            this.rbMove.TabIndex = 8;
            this.rbMove.TabStop = true;
            this.rbMove.Text = "Move";
            this.rbMove.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1000;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 200;
            // 
            // FilterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 112);
            this.Controls.Add(this.rbMove);
            this.Controls.Add(this.rbCopy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.edtDirectory);
            this.Controls.Add(this.edtFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtExt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FilterEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter edit - Bashlykevich.net";
            this.Load += new System.EventHandler(this.FilterEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtExt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtFilename;
        private System.Windows.Forms.TextBox edtDirectory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbCopy;
        private System.Windows.Forms.RadioButton rbMove;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}