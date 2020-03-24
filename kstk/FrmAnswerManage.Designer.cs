namespace kstk
{
    partial class FrmAnswerManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnswerManage));
            this.listv = new System.Windows.Forms.ListView();
            this.colsel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btadd = new System.Windows.Forms.Button();
            this.btdel = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.btdui = new System.Windows.Forms.Button();
            this.btcuo = new System.Windows.Forms.Button();
            this.cBallsel = new System.Windows.Forms.CheckBox();
            this.tCa = new System.Windows.Forms.TabControl();
            this.tP1 = new System.Windows.Forms.TabPage();
            this.ltmbt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ltkbt = new System.Windows.Forms.Label();
            this.lms = new System.Windows.Forms.Label();
            this.cBdc = new System.Windows.Forms.ComboBox();
            this.la1 = new System.Windows.Forms.Label();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btss = new System.Windows.Forms.Button();
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tCa.SuspendLayout();
            this.tP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listv
            // 
            this.listv.CheckBoxes = true;
            this.listv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colsel,
            this.colxh,
            this.col0,
            this.col1,
            this.col2});
            this.listv.FullRowSelect = true;
            this.listv.GridLines = true;
            this.listv.HideSelection = false;
            this.listv.Location = new System.Drawing.Point(1, 173);
            this.listv.MultiSelect = false;
            this.listv.Name = "listv";
            this.listv.Size = new System.Drawing.Size(980, 386);
            this.listv.TabIndex = 1;
            this.listv.UseCompatibleStateImageBehavior = false;
            this.listv.View = System.Windows.Forms.View.Details;
            // 
            // colsel
            // 
            this.colsel.Text = "选择";
            this.colsel.Width = 40;
            // 
            // colxh
            // 
            this.colxh.Text = "序号";
            this.colxh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // col0
            // 
            this.col0.Text = "答案";
            this.col0.Width = 688;
            // 
            // col1
            // 
            this.col1.Text = "对错";
            this.col1.Width = 103;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(784, 147);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 2;
            this.btadd.Text = "新增";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // btdel
            // 
            this.btdel.Location = new System.Drawing.Point(80, 147);
            this.btdel.Name = "btdel";
            this.btdel.Size = new System.Drawing.Size(75, 23);
            this.btdel.TabIndex = 3;
            this.btdel.Text = "删除";
            this.btdel.UseVisualStyleBackColor = true;
            this.btdel.Click += new System.EventHandler(this.btdel_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(890, 147);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(75, 23);
            this.btedit.TabIndex = 6;
            this.btedit.Text = "编辑";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // btdui
            // 
            this.btdui.Location = new System.Drawing.Point(177, 147);
            this.btdui.Name = "btdui";
            this.btdui.Size = new System.Drawing.Size(75, 23);
            this.btdui.TabIndex = 7;
            this.btdui.Text = "对";
            this.btdui.UseVisualStyleBackColor = true;
            this.btdui.Click += new System.EventHandler(this.btdui_Click);
            // 
            // btcuo
            // 
            this.btcuo.Location = new System.Drawing.Point(274, 147);
            this.btcuo.Name = "btcuo";
            this.btcuo.Size = new System.Drawing.Size(75, 23);
            this.btcuo.TabIndex = 8;
            this.btcuo.Text = "错";
            this.btcuo.UseVisualStyleBackColor = true;
            this.btcuo.Click += new System.EventHandler(this.btcuo_Click);
            // 
            // cBallsel
            // 
            this.cBallsel.AutoSize = true;
            this.cBallsel.Location = new System.Drawing.Point(12, 150);
            this.cBallsel.Name = "cBallsel";
            this.cBallsel.Size = new System.Drawing.Size(48, 16);
            this.cBallsel.TabIndex = 30;
            this.cBallsel.Text = "全选";
            this.cBallsel.UseVisualStyleBackColor = true;
            this.cBallsel.Click += new System.EventHandler(this.cBallsel_Click);
            // 
            // tCa
            // 
            this.tCa.Controls.Add(this.tP1);
            this.tCa.Location = new System.Drawing.Point(3, 2);
            this.tCa.Name = "tCa";
            this.tCa.SelectedIndex = 0;
            this.tCa.Size = new System.Drawing.Size(980, 137);
            this.tCa.TabIndex = 31;
            // 
            // tP1
            // 
            this.tP1.Controls.Add(this.ltmbt);
            this.tP1.Controls.Add(this.label3);
            this.tP1.Controls.Add(this.ltkbt);
            this.tP1.Controls.Add(this.lms);
            this.tP1.Controls.Add(this.cBdc);
            this.tP1.Controls.Add(this.la1);
            this.tP1.Controls.Add(this.tBName);
            this.tP1.Controls.Add(this.label1);
            this.tP1.Controls.Add(this.btss);
            this.tP1.Location = new System.Drawing.Point(4, 22);
            this.tP1.Name = "tP1";
            this.tP1.Padding = new System.Windows.Forms.Padding(3);
            this.tP1.Size = new System.Drawing.Size(972, 111);
            this.tP1.TabIndex = 0;
            this.tP1.Text = "基本设置";
            this.tP1.UseVisualStyleBackColor = true;
            // 
            // ltmbt
            // 
            this.ltmbt.AutoSize = true;
            this.ltmbt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltmbt.ForeColor = System.Drawing.Color.Brown;
            this.ltmbt.Location = new System.Drawing.Point(63, 83);
            this.ltmbt.Name = "ltmbt";
            this.ltmbt.Size = new System.Drawing.Size(38, 12);
            this.ltmbt.TabIndex = 27;
            this.ltmbt.Text = "题目1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(24, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "题目：";
            // 
            // ltkbt
            // 
            this.ltkbt.AutoSize = true;
            this.ltkbt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltkbt.ForeColor = System.Drawing.Color.Brown;
            this.ltkbt.Location = new System.Drawing.Point(64, 56);
            this.ltkbt.Name = "ltkbt";
            this.ltkbt.Size = new System.Drawing.Size(38, 12);
            this.ltkbt.TabIndex = 25;
            this.ltkbt.Text = "题库1";
            // 
            // lms
            // 
            this.lms.AutoSize = true;
            this.lms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lms.ForeColor = System.Drawing.Color.Blue;
            this.lms.Location = new System.Drawing.Point(24, 56);
            this.lms.Name = "lms";
            this.lms.Size = new System.Drawing.Size(44, 12);
            this.lms.TabIndex = 24;
            this.lms.Text = "题库：";
            // 
            // cBdc
            // 
            this.cBdc.FormattingEnabled = true;
            this.cBdc.Location = new System.Drawing.Point(59, 16);
            this.cBdc.Name = "cBdc";
            this.cBdc.Size = new System.Drawing.Size(121, 20);
            this.cBdc.TabIndex = 21;
            this.cBdc.SelectedIndexChanged += new System.EventHandler(this.cBdc_SelectedIndexChanged);
            // 
            // la1
            // 
            this.la1.AutoSize = true;
            this.la1.Location = new System.Drawing.Point(27, 20);
            this.la1.Name = "la1";
            this.la1.Size = new System.Drawing.Size(29, 12);
            this.la1.TabIndex = 20;
            this.la1.Text = "对错";
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(252, 16);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(229, 21);
            this.tBName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "答案";
            // 
            // btss
            // 
            this.btss.Location = new System.Drawing.Point(488, 15);
            this.btss.Name = "btss";
            this.btss.Size = new System.Drawing.Size(49, 23);
            this.btss.TabIndex = 14;
            this.btss.Text = "搜索";
            this.btss.UseVisualStyleBackColor = true;
            // 
            // col2
            // 
            this.col2.Text = "排序";
            // 
            // FrmAnswerManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tCa);
            this.Controls.Add(this.cBallsel);
            this.Controls.Add(this.btcuo);
            this.Controls.Add(this.btdui);
            this.Controls.Add(this.btedit);
            this.Controls.Add(this.btdel);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.listv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmAnswerManage";
            this.Text = "答案管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tCa.ResumeLayout(false);
            this.tP1.ResumeLayout(false);
            this.tP1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listv;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btdel;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.Button btdui;
        private System.Windows.Forms.Button btcuo;
        private System.Windows.Forms.CheckBox cBallsel;
        private System.Windows.Forms.TabControl tCa;
        private System.Windows.Forms.TabPage tP1;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btss;
        private System.Windows.Forms.ColumnHeader colsel;
        private System.Windows.Forms.ColumnHeader colxh;
        private System.Windows.Forms.ComboBox cBdc;
        private System.Windows.Forms.Label la1;
        private System.Windows.Forms.Label ltmbt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ltkbt;
        private System.Windows.Forms.Label lms;
        private System.Windows.Forms.ColumnHeader col2;
    }
}

