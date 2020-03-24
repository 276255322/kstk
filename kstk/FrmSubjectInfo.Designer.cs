namespace kstk
{
    partial class FrmSubjectInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubjectInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.btsave = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.rTextName = new System.Windows.Forms.RichTextBox();
            this.gB = new System.Windows.Forms.GroupBox();
            this.rB3 = new System.Windows.Forms.RadioButton();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rTBdajx = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ltkbt = new System.Windows.Forms.Label();
            this.lms = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "题目";
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(294, 276);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 3;
            this.btsave.Text = "保存";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(453, 276);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 4;
            this.btclose.Text = "关闭";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // rTextName
            // 
            this.rTextName.Location = new System.Drawing.Point(105, 68);
            this.rTextName.Name = "rTextName";
            this.rTextName.Size = new System.Drawing.Size(423, 53);
            this.rTextName.TabIndex = 5;
            this.rTextName.Text = "";
            // 
            // gB
            // 
            this.gB.Controls.Add(this.rB3);
            this.gB.Controls.Add(this.rB2);
            this.gB.Controls.Add(this.rB1);
            this.gB.Location = new System.Drawing.Point(105, 212);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(423, 52);
            this.gB.TabIndex = 6;
            this.gB.TabStop = false;
            // 
            // rB3
            // 
            this.rB3.AutoSize = true;
            this.rB3.Location = new System.Drawing.Point(177, 21);
            this.rB3.Name = "rB3";
            this.rB3.Size = new System.Drawing.Size(47, 16);
            this.rB3.TabIndex = 2;
            this.rB3.TabStop = true;
            this.rB3.Text = "判断";
            this.rB3.UseVisualStyleBackColor = true;
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Location = new System.Drawing.Point(97, 21);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(47, 16);
            this.rB2.TabIndex = 1;
            this.rB2.TabStop = true;
            this.rB2.Text = "多选";
            this.rB2.UseVisualStyleBackColor = true;
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Location = new System.Drawing.Point(22, 21);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(47, 16);
            this.rB1.TabIndex = 0;
            this.rB1.TabStop = true;
            this.rB1.Text = "单选";
            this.rB1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "类型";
            // 
            // rTBdajx
            // 
            this.rTBdajx.Location = new System.Drawing.Point(105, 131);
            this.rTBdajx.Name = "rTBdajx";
            this.rTBdajx.Size = new System.Drawing.Size(423, 76);
            this.rTBdajx.TabIndex = 9;
            this.rTBdajx.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = " 答案解析";
            // 
            // ltkbt
            // 
            this.ltkbt.AutoSize = true;
            this.ltkbt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltkbt.ForeColor = System.Drawing.Color.Brown;
            this.ltkbt.Location = new System.Drawing.Point(59, 14);
            this.ltkbt.Name = "ltkbt";
            this.ltkbt.Size = new System.Drawing.Size(38, 12);
            this.ltkbt.TabIndex = 29;
            this.ltkbt.Text = "题库1";
            // 
            // lms
            // 
            this.lms.AutoSize = true;
            this.lms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lms.ForeColor = System.Drawing.Color.Blue;
            this.lms.Location = new System.Drawing.Point(19, 14);
            this.lms.Name = "lms";
            this.lms.Size = new System.Drawing.Size(44, 12);
            this.lms.TabIndex = 28;
            this.lms.Text = "题库：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ltkbt);
            this.panel1.Controls.Add(this.lms);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 42);
            this.panel1.TabIndex = 32;
            // 
            // FrmSubjectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rTBdajx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.rTextName);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "FrmSubjectInfo";
            this.Text = "题目";
            this.Load += new System.EventHandler(this.FrmSubjectInfo_Load);
            this.gB.ResumeLayout(false);
            this.gB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.RichTextBox rTextName;
        private System.Windows.Forms.GroupBox gB;
        private System.Windows.Forms.RadioButton rB3;
        private System.Windows.Forms.RadioButton rB2;
        private System.Windows.Forms.RadioButton rB1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTBdajx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ltkbt;
        private System.Windows.Forms.Label lms;
        private System.Windows.Forms.Panel panel1;
    }
}