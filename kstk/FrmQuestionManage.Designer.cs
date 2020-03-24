namespace kstk
{
    partial class FrmQuestionManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuestionManage));
            this.listv = new System.Windows.Forms.ListView();
            this.colsel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btadd = new System.Windows.Forms.Button();
            this.btdel = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.btbuild = new System.Windows.Forms.Button();
            this.tCa = new System.Windows.Forms.TabControl();
            this.tP1 = new System.Windows.Forms.TabPage();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btss = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cBhs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBallsel = new System.Windows.Forms.CheckBox();
            this.centPage = new App.Win.FormCentShow();
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
            this.col2,
            this.col3,
            this.col4});
            this.listv.FullRowSelect = true;
            this.listv.GridLines = true;
            this.listv.HideSelection = false;
            this.listv.Location = new System.Drawing.Point(1, 138);
            this.listv.MultiSelect = false;
            this.listv.Name = "listv";
            this.listv.Size = new System.Drawing.Size(980, 380);
            this.listv.TabIndex = 1;
            this.listv.UseCompatibleStateImageBehavior = false;
            this.listv.View = System.Windows.Forms.View.Details;
            this.listv.DoubleClick += new System.EventHandler(this.listv_DoubleClick);
            // 
            // colsel
            // 
            this.colsel.Text = "选择";
            this.colsel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colsel.Width = 40;
            // 
            // colxh
            // 
            this.colxh.Text = "序号";
            this.colxh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // col0
            // 
            this.col0.Text = "题库名称";
            this.col0.Width = 382;
            // 
            // col1
            // 
            this.col1.Text = "题目总数";
            this.col1.Width = 70;
            // 
            // col2
            // 
            this.col2.Text = "有效题目";
            this.col2.Width = 70;
            // 
            // col3
            // 
            this.col3.Text = "无效题目";
            this.col3.Width = 70;
            // 
            // col4
            // 
            this.col4.Text = "描述";
            this.col4.Width = 258;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(696, 111);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 2;
            this.btadd.Text = "新增";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // btdel
            // 
            this.btdel.Location = new System.Drawing.Point(75, 111);
            this.btdel.Name = "btdel";
            this.btdel.Size = new System.Drawing.Size(75, 23);
            this.btdel.TabIndex = 3;
            this.btdel.Text = "删除";
            this.btdel.UseVisualStyleBackColor = true;
            this.btdel.Click += new System.EventHandler(this.btdel_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(793, 111);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(75, 23);
            this.btedit.TabIndex = 4;
            this.btedit.Text = "编辑";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // btbuild
            // 
            this.btbuild.Location = new System.Drawing.Point(890, 111);
            this.btbuild.Name = "btbuild";
            this.btbuild.Size = new System.Drawing.Size(75, 23);
            this.btbuild.TabIndex = 5;
            this.btbuild.Text = "生成试卷";
            this.btbuild.UseVisualStyleBackColor = true;
            this.btbuild.Click += new System.EventHandler(this.btbuild_Click);
            // 
            // tCa
            // 
            this.tCa.Controls.Add(this.tP1);
            this.tCa.Location = new System.Drawing.Point(2, 0);
            this.tCa.Name = "tCa";
            this.tCa.SelectedIndex = 0;
            this.tCa.Size = new System.Drawing.Size(980, 102);
            this.tCa.TabIndex = 22;
            // 
            // tP1
            // 
            this.tP1.Controls.Add(this.tBName);
            this.tP1.Controls.Add(this.label1);
            this.tP1.Controls.Add(this.btss);
            this.tP1.Location = new System.Drawing.Point(4, 22);
            this.tP1.Name = "tP1";
            this.tP1.Padding = new System.Windows.Forms.Padding(3);
            this.tP1.Size = new System.Drawing.Size(972, 76);
            this.tP1.TabIndex = 0;
            this.tP1.Text = "基本设置";
            this.tP1.UseVisualStyleBackColor = true;
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(87, 28);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(229, 21);
            this.tBName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "题库名称";
            // 
            // btss
            // 
            this.btss.Location = new System.Drawing.Point(322, 27);
            this.btss.Name = "btss";
            this.btss.Size = new System.Drawing.Size(49, 23);
            this.btss.TabIndex = 14;
            this.btss.Text = "搜索";
            this.btss.UseVisualStyleBackColor = true;
            this.btss.Click += new System.EventHandler(this.btss_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "行";
            // 
            // cBhs
            // 
            this.cBhs.FormattingEnabled = true;
            this.cBhs.Location = new System.Drawing.Point(64, 527);
            this.cBhs.Name = "cBhs";
            this.cBhs.Size = new System.Drawing.Size(64, 20);
            this.cBhs.TabIndex = 27;
            this.cBhs.SelectedIndexChanged += new System.EventHandler(this.cBhs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "每页显示";
            // 
            // cBallsel
            // 
            this.cBallsel.AutoSize = true;
            this.cBallsel.Location = new System.Drawing.Point(14, 114);
            this.cBallsel.Name = "cBallsel";
            this.cBallsel.Size = new System.Drawing.Size(48, 16);
            this.cBallsel.TabIndex = 29;
            this.cBallsel.Text = "全选";
            this.cBallsel.UseVisualStyleBackColor = true;
            this.cBallsel.Click += new System.EventHandler(this.cBallsel_Click);
            // 
            // centPage
            // 
            this.centPage.CentCount = 0;
            this.centPage.DataCount = 0;
            this.centPage.EachCount = 20;
            this.centPage.Location = new System.Drawing.Point(425, 523);
            this.centPage.Name = "centPage";
            this.centPage.PageNum = 1;
            this.centPage.Size = new System.Drawing.Size(550, 30);
            this.centPage.StartData = 0;
            this.centPage.TabIndex = 25;
            this.centPage.LinkTop_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkTop_LinkClicked);
            this.centPage.LinkPro_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkPro_LinkClicked);
            this.centPage.LinkNext_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkNext_LinkClicked);
            this.centPage.LinkLast_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkLast_LinkClicked);
            this.centPage.btnJump_Click += new System.EventHandler(this.centPage_btnJump_Click);
            // 
            // FrmQuestionManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.cBallsel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBhs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.centPage);
            this.Controls.Add(this.tCa);
            this.Controls.Add(this.btbuild);
            this.Controls.Add(this.btedit);
            this.Controls.Add(this.btdel);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.listv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmQuestionManage";
            this.Text = "题库管理";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tCa.ResumeLayout(false);
            this.tP1.ResumeLayout(false);
            this.tP1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listv;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btdel;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.ColumnHeader col4;
        private System.Windows.Forms.Button btbuild;
        private System.Windows.Forms.TabControl tCa;
        private System.Windows.Forms.TabPage tP1;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btss;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBhs;
        private System.Windows.Forms.Label label3;
        private App.Win.FormCentShow centPage;
        private System.Windows.Forms.CheckBox cBallsel;
        private System.Windows.Forms.ColumnHeader colsel;
        private System.Windows.Forms.ColumnHeader colxh;
    }
}

