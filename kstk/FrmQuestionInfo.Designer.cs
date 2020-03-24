namespace kstk
{
    partial class FrmQuestionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuestionInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.btsave = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.rTextName = new System.Windows.Forms.RichTextBox();
            this.rTextDesc = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "题库名称";
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(296, 213);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 3;
            this.btsave.Text = "保存";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(455, 213);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 4;
            this.btclose.Text = "关闭";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // rTextName
            // 
            this.rTextName.Location = new System.Drawing.Point(107, 19);
            this.rTextName.Name = "rTextName";
            this.rTextName.Size = new System.Drawing.Size(423, 53);
            this.rTextName.TabIndex = 5;
            this.rTextName.Text = "";
            // 
            // rTextDesc
            // 
            this.rTextDesc.Location = new System.Drawing.Point(107, 83);
            this.rTextDesc.Name = "rTextDesc";
            this.rTextDesc.Size = new System.Drawing.Size(423, 114);
            this.rTextDesc.TabIndex = 6;
            this.rTextDesc.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "描述";
            // 
            // FrmQuestionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rTextDesc);
            this.Controls.Add(this.rTextName);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FrmQuestionInfo";
            this.Text = "题库";
            this.Load += new System.EventHandler(this.FrmQuestionInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.RichTextBox rTextName;
        private System.Windows.Forms.RichTextBox rTextDesc;
        private System.Windows.Forms.Label label2;
    }
}