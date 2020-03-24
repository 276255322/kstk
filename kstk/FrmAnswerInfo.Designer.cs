namespace kstk
{
    partial class FrmAnswerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnswerInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.gB = new System.Windows.Forms.GroupBox();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.btsave = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.rTextName = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ltkbt = new System.Windows.Forms.Label();
            this.ltmbt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lms = new System.Windows.Forms.Label();
            this.ppx = new System.Windows.Forms.Panel();
            this.cBpx = new System.Windows.Forms.CheckBox();
            this.tBpx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ppx.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "答案内容";
            // 
            // gB
            // 
            this.gB.Controls.Add(this.rB2);
            this.gB.Controls.Add(this.rB1);
            this.gB.Location = new System.Drawing.Point(115, 145);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(423, 52);
            this.gB.TabIndex = 2;
            this.gB.TabStop = false;
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Location = new System.Drawing.Point(97, 21);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(47, 16);
            this.rB2.TabIndex = 1;
            this.rB2.Text = "错误";
            this.rB2.UseVisualStyleBackColor = true;
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Location = new System.Drawing.Point(22, 21);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(47, 16);
            this.rB1.TabIndex = 0;
            this.rB1.Text = "正确";
            this.rB1.UseVisualStyleBackColor = true;
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(292, 273);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 3;
            this.btsave.Text = "保存";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(451, 273);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 4;
            this.btclose.Text = "关闭";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // rTextName
            // 
            this.rTextName.Location = new System.Drawing.Point(115, 89);
            this.rTextName.Name = "rTextName";
            this.rTextName.Size = new System.Drawing.Size(423, 53);
            this.rTextName.TabIndex = 5;
            this.rTextName.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ltkbt);
            this.panel1.Controls.Add(this.ltmbt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lms);
            this.panel1.Location = new System.Drawing.Point(13, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 63);
            this.panel1.TabIndex = 33;
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
            // ltmbt
            // 
            this.ltmbt.AutoSize = true;
            this.ltmbt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltmbt.ForeColor = System.Drawing.Color.Brown;
            this.ltmbt.Location = new System.Drawing.Point(59, 38);
            this.ltmbt.Name = "ltmbt";
            this.ltmbt.Size = new System.Drawing.Size(38, 12);
            this.ltmbt.TabIndex = 31;
            this.ltmbt.Text = "题目1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(20, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "题目：";
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
            // ppx
            // 
            this.ppx.Controls.Add(this.label2);
            this.ppx.Controls.Add(this.tBpx);
            this.ppx.Location = new System.Drawing.Point(115, 204);
            this.ppx.Name = "ppx";
            this.ppx.Size = new System.Drawing.Size(423, 52);
            this.ppx.TabIndex = 34;
            // 
            // cBpx
            // 
            this.cBpx.AutoSize = true;
            this.cBpx.Location = new System.Drawing.Point(36, 223);
            this.cBpx.Name = "cBpx";
            this.cBpx.Size = new System.Drawing.Size(72, 16);
            this.cBpx.TabIndex = 35;
            this.cBpx.Text = "强制排序";
            this.cBpx.UseVisualStyleBackColor = true;
            this.cBpx.Click += new System.EventHandler(this.cBpx_Click);
            // 
            // tBpx
            // 
            this.tBpx.Location = new System.Drawing.Point(77, 16);
            this.tBpx.MaxLength = 5;
            this.tBpx.Name = "tBpx";
            this.tBpx.Size = new System.Drawing.Size(67, 21);
            this.tBpx.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "排序位置";
            // 
            // FrmAnswerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 318);
            this.Controls.Add(this.cBpx);
            this.Controls.Add(this.ppx);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rTextName);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAnswerInfo";
            this.Text = "答案";
            this.Load += new System.EventHandler(this.FrmAnswerInfo_Load);
            this.gB.ResumeLayout(false);
            this.gB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ppx.ResumeLayout(false);
            this.ppx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gB;
        private System.Windows.Forms.RadioButton rB2;
        private System.Windows.Forms.RadioButton rB1;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.RichTextBox rTextName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ltkbt;
        private System.Windows.Forms.Label ltmbt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lms;
        private System.Windows.Forms.Panel ppx;
        private System.Windows.Forms.CheckBox cBpx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBpx;
    }
}