using App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kstk
{
    public partial class FrmSubjectInfo : Form
    {
        public bool IsOper = false;

        public string tkid = "";

        public string tmid = "";

        public bool IsEdit = false;

        public DataTable tkdt;

        public DataTable tmdt;

        public FrmSubjectInfo()
        {
            InitializeComponent();
        }

        private void FrmSubjectInfo_Load(object sender, EventArgs e)
        {
            tkdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
            ltkbt.Text = DataOften.GetStr(tkdt, "bt");
            if (tmid != "")
            {
                tmdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where zid=?", tmid);
                if (tmdt != null && tmdt.Rows.Count > 0)
                {
                    rTextName.Text = App.DataOften.GetStr(tmdt, "tm");
                    rTBdajx.Text = App.DataOften.GetStr(tmdt, "dajx");
                    string lx = App.DataOften.GetStr(tmdt, "lx");
                    if (lx == "1")
                    {
                        rB2.Checked = true;
                    }
                    else if (lx == "2")
                    {
                        rB3.Checked = true;
                    }
                    else
                    {
                        rB1.Checked = true;
                    }
                    gB.Enabled = false;
                    IsEdit = true;
                }
            }
            if (IsEdit)
            {
                this.Text = "编辑题目";
            }
            else
            {
                this.Text = "新增题目";
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            string tm = rTextName.Text.Trim();
            if (tm == "")
            {
                wapp.MessageBoxEx.Show(this, "请填写题目内容！", "系统提示");
                return;
            }
            if (tm.Length > 1000)
            {
                wapp.MessageBoxEx.Show(this, "题目内容字符数量不能超过1000字符！", "系统提示");
                return;
            }
            string dajx = rTBdajx.Text.Trim();
            if (dajx.Length > 20000)
            {
                wapp.MessageBoxEx.Show(this, "答案解析字符数量不能超过20000字符！", "系统提示");
                return;
            }
            int lx = -1;
            if (rB1.Checked)
            {
                lx = 0;
            }
            else if (rB2.Checked)
            {
                lx = 1;
            }
            else if (rB3.Checked)
            {
                lx = 2;
            }
            if (lx == -1)
            {
                wapp.MessageBoxEx.Show(this, "请选择类型！", "系统提示");
                return;
            }
            if (IsEdit)
            {
                wapp.SQLiteConn.Sqllite.UP("update tmlb set tm=?, dajx=? where zid=?", tm, dajx, tmid);
            }
            else
            {
                wapp.SQLiteConn.Sqllite.UP("insert into tmlb(tkid,tm,dajx,lx,sl,px,qy)values(?,?,?,?,?,?,?)", tkid, tm, dajx, lx.ToString(), "0", "0", "0");
                wapp.pub.updateQuestion(tkid);
            }
            IsOper = true;
            this.Close();
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
