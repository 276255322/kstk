namespace kstk
{
    partial class FrmSubjectManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubjectManage));
            this.listv = new System.Windows.Forms.ListView();
            this.colsel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btadd = new System.Windows.Forms.Button();
            this.btdel = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.btuse = new System.Windows.Forms.Button();
            this.btstop = new System.Windows.Forms.Button();
            this.cBallsel = new System.Windows.Forms.CheckBox();
            this.tCa = new System.Windows.Forms.TabControl();
            this.tP1 = new System.Windows.Forms.TabPage();
            this.cBmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ltkbt = new System.Windows.Forms.Label();
            this.lms = new System.Windows.Forms.Label();
            this.cBuse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBlx = new System.Windows.Forms.ComboBox();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btss = new System.Windows.Forms.Button();
            this.la1 = new System.Windows.Forms.Label();
            this.centPage = new App.Win.FormCentShow();
            this.cBhs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.col6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bW = new System.ComponentModel.BackgroundWorker();
            this.tCa.SuspendLayout();
            this.tP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listv
            // 
            this.listv.CheckBoxes = true;
            this.listv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colsel,
            this.col0,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
            this.listv.FullRowSelect = true;
            this.listv.GridLines = true;
            this.listv.HideSelection = false;
            this.listv.Location = new System.Drawing.Point(2, 138);
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
            this.colsel.Width = 40;
            // 
            // col0
            // 
            this.col0.Text = "序号";
            this.col0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // col1
            // 
            this.col1.Text = "名称";
            this.col1.Width = 443;
            // 
            // col2
            // 
            this.col2.Text = "答案解析";
            this.col2.Width = 158;
            // 
            // col3
            // 
            this.col3.Text = "启用";
            this.col3.Width = 65;
            // 
            // col4
            // 
            this.col4.Text = "类型";
            this.col4.Width = 62;
            // 
            // col5
            // 
            this.col5.Text = "答案数量";
            this.col5.Width = 66;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(803, 111);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 2;
            this.btadd.Text = "新增";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // btdel
            // 
            this.btdel.Location = new System.Drawing.Point(235, 111);
            this.btdel.Name = "btdel";
            this.btdel.Size = new System.Drawing.Size(75, 23);
            this.btdel.TabIndex = 3;
            this.btdel.Text = "删除";
            this.btdel.UseVisualStyleBackColor = true;
            this.btdel.Click += new System.EventHandler(this.btdel_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(891, 111);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(75, 23);
            this.btedit.TabIndex = 5;
            this.btedit.Text = "编辑";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // btuse
            // 
            this.btuse.Location = new System.Drawing.Point(59, 111);
            this.btuse.Name = "btuse";
            this.btuse.Size = new System.Drawing.Size(75, 23);
            this.btuse.TabIndex = 6;
            this.btuse.Text = "启用";
            this.btuse.UseVisualStyleBackColor = true;
            this.btuse.Click += new System.EventHandler(this.btuse_Click);
            // 
            // btstop
            // 
            this.btstop.Location = new System.Drawing.Point(147, 111);
            this.btstop.Name = "btstop";
            this.btstop.Size = new System.Drawing.Size(75, 23);
            this.btstop.TabIndex = 7;
            this.btstop.Text = "停用";
            this.btstop.UseVisualStyleBackColor = true;
            this.btstop.Click += new System.EventHandler(this.btstop_Click);
            // 
            // cBallsel
            // 
            this.cBallsel.AutoSize = true;
            this.cBallsel.Location = new System.Drawing.Point(8, 115);
            this.cBallsel.Name = "cBallsel";
            this.cBallsel.Size = new System.Drawing.Size(48, 16);
            this.cBallsel.TabIndex = 20;
            this.cBallsel.Text = "全选";
            this.cBallsel.UseVisualStyleBackColor = true;
            this.cBallsel.Click += new System.EventHandler(this.cBallsel_Click);
            // 
            // tCa
            // 
            this.tCa.Controls.Add(this.tP1);
            this.tCa.Location = new System.Drawing.Point(2, 2);
            this.tCa.Name = "tCa";
            this.tCa.SelectedIndex = 0;
            this.tCa.Size = new System.Drawing.Size(980, 102);
            this.tCa.TabIndex = 21;
            // 
            // tP1
            // 
            this.tP1.Controls.Add(this.cBmb);
            this.tP1.Controls.Add(this.label5);
            this.tP1.Controls.Add(this.ltkbt);
            this.tP1.Controls.Add(this.lms);
            this.tP1.Controls.Add(this.cBuse);
            this.tP1.Controls.Add(this.label2);
            this.tP1.Controls.Add(this.cBlx);
            this.tP1.Controls.Add(this.tBName);
            this.tP1.Controls.Add(this.label1);
            this.tP1.Controls.Add(this.btss);
            this.tP1.Controls.Add(this.la1);
            this.tP1.Location = new System.Drawing.Point(4, 22);
            this.tP1.Name = "tP1";
            this.tP1.Padding = new System.Windows.Forms.Padding(3);
            this.tP1.Size = new System.Drawing.Size(972, 76);
            this.tP1.TabIndex = 0;
            this.tP1.Text = "基本设置";
            this.tP1.UseVisualStyleBackColor = true;
            // 
            // cBmb
            // 
            this.cBmb.FormattingEnabled = true;
            this.cBmb.Location = new System.Drawing.Point(416, 17);
            this.cBmb.Name = "cBmb";
            this.cBmb.Size = new System.Drawing.Size(121, 20);
            this.cBmb.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "搜索目标";
            // 
            // ltkbt
            // 
            this.ltkbt.AutoSize = true;
            this.ltkbt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltkbt.ForeColor = System.Drawing.Color.Brown;
            this.ltkbt.Location = new System.Drawing.Point(58, 50);
            this.ltkbt.Name = "ltkbt";
            this.ltkbt.Size = new System.Drawing.Size(38, 12);
            this.ltkbt.TabIndex = 23;
            this.ltkbt.Text = "题库1";
            // 
            // lms
            // 
            this.lms.AutoSize = true;
            this.lms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lms.ForeColor = System.Drawing.Color.Blue;
            this.lms.Location = new System.Drawing.Point(18, 50);
            this.lms.Name = "lms";
            this.lms.Size = new System.Drawing.Size(44, 12);
            this.lms.TabIndex = 22;
            this.lms.Text = "题库：";
            // 
            // cBuse
            // 
            this.cBuse.FormattingEnabled = true;
            this.cBuse.Location = new System.Drawing.Point(218, 17);
            this.cBuse.Name = "cBuse";
            this.cBuse.Size = new System.Drawing.Size(121, 20);
            this.cBuse.TabIndex = 21;
            this.cBuse.SelectedIndexChanged += new System.EventHandler(this.cBuse_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "启用";
            // 
            // cBlx
            // 
            this.cBlx.FormattingEnabled = true;
            this.cBlx.Location = new System.Drawing.Point(51, 17);
            this.cBlx.Name = "cBlx";
            this.cBlx.Size = new System.Drawing.Size(121, 20);
            this.cBlx.TabIndex = 19;
            this.cBlx.SelectedIndexChanged += new System.EventHandler(this.cBlx_SelectedIndexChanged);
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(585, 17);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(229, 21);
            this.tBName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "关键字";
            // 
            // btss
            // 
            this.btss.Location = new System.Drawing.Point(820, 16);
            this.btss.Name = "btss";
            this.btss.Size = new System.Drawing.Size(49, 23);
            this.btss.TabIndex = 14;
            this.btss.Text = "搜索";
            this.btss.UseVisualStyleBackColor = true;
            this.btss.Click += new System.EventHandler(this.btss_Click);
            // 
            // la1
            // 
            this.la1.AutoSize = true;
            this.la1.Location = new System.Drawing.Point(19, 21);
            this.la1.Name = "la1";
            this.la1.Size = new System.Drawing.Size(29, 12);
            this.la1.TabIndex = 4;
            this.la1.Text = "类型";
            // 
            // centPage
            // 
            this.centPage.CentCount = 0;
            this.centPage.DataCount = 0;
            this.centPage.EachCount = 20;
            this.centPage.Location = new System.Drawing.Point(427, 524);
            this.centPage.Name = "centPage";
            this.centPage.PageNum = 1;
            this.centPage.Size = new System.Drawing.Size(550, 30);
            this.centPage.StartData = 0;
            this.centPage.TabIndex = 19;
            this.centPage.LinkTop_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkTop_LinkClicked);
            this.centPage.LinkPro_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkPro_LinkClicked);
            this.centPage.LinkNext_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkNext_LinkClicked);
            this.centPage.LinkLast_LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.centPage_LinkLast_LinkClicked);
            this.centPage.btnJump_Click += new System.EventHandler(this.centPage_btnJump_Click);
            // 
            // cBhs
            // 
            this.cBhs.FormattingEnabled = true;
            this.cBhs.Location = new System.Drawing.Point(65, 528);
            this.cBhs.Name = "cBhs";
            this.cBhs.Size = new System.Drawing.Size(64, 20);
            this.cBhs.TabIndex = 23;
            this.cBhs.SelectedIndexChanged += new System.EventHandler(this.cBhs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "每页显示";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "行";
            // 
            // col6
            // 
            this.col6.Text = "答案预览";
            // 
            // bW
            // 
            this.bW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bW_DoWork);
            this.bW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bW_ProgressChanged);
            this.bW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bW_RunWorkerCompleted);
            // 
            // FrmSubjectManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBhs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tCa);
            this.Controls.Add(this.cBallsel);
            this.Controls.Add(this.centPage);
            this.Controls.Add(this.btstop);
            this.Controls.Add(this.btuse);
            this.Controls.Add(this.btedit);
            this.Controls.Add(this.btdel);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.listv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmSubjectManage";
            this.Text = "题目管理";
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
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btdel;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.ColumnHeader col4;
        private System.Windows.Forms.Button btuse;
        private System.Windows.Forms.Button btstop;
        private App.Win.FormCentShow centPage;
        private System.Windows.Forms.ColumnHeader colsel;
        private System.Windows.Forms.CheckBox cBallsel;
        private System.Windows.Forms.TabControl tCa;
        private System.Windows.Forms.TabPage tP1;
        private System.Windows.Forms.ComboBox cBlx;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btss;
        private System.Windows.Forms.Label la1;
        private System.Windows.Forms.ComboBox cBuse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader col5;
        private System.Windows.Forms.ComboBox cBhs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lms;
        private System.Windows.Forms.Label ltkbt;
        private System.Windows.Forms.ComboBox cBmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader col6;
        private System.ComponentModel.BackgroundWorker bW;
    }
}

