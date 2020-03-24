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
    public partial class FrmAnswerInfo : Form
    {
        public bool IsOper = false;

        public string tkid = "";

        public string tmid = "";

        public string daid = "";

        public bool IsEdit = false;

        public DataTable tkdt;

        public DataTable tmdt;

        public DataTable dadt;


        public FrmAnswerInfo()
        {
            InitializeComponent();
        }

        private void FrmAnswerInfo_Load(object sender, EventArgs e)
        {
            cBpx.Checked = false;
            ppx.Enabled = false;
            tBpx.Text = "";
            tkdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
            ltkbt.Text = DataOften.GetStr(tkdt, "bt");
            tmdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where zid=?", tmid);
            ltmbt.Text = DataOften.GetStr(tmdt, "tm");
            if (daid != "")
            {
                DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where zid=?", daid);
                if (dadt != null && dadt.Rows.Count > 0)
                {
                    rTextName.Text = App.DataOften.GetStr(dadt, "dan");
                    string dc = App.DataOften.GetStr(dadt, "dc");
                    if (dc == "1")
                    {
                        rB1.Checked = true;
                    }
                    else
                    {
                        rB2.Checked = true;
                    }
                    gB.Enabled = false;
                    int px = App.Often.GetInt(App.DataOften.GetStr(dadt, "px"), "0");
                    if (px > 0)
                    {
                        cBpx.Checked = true;
                        ppx.Enabled = true;
                        tBpx.Text = px.ToString();
                    }
                    IsEdit = true;
                }
            }
            if (IsEdit)
            {
                this.Text = "编辑答案";
            }
            else
            {
                this.Text = "新增答案";
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            string dan = rTextName.Text.Trim();
            if (dan == "")
            {
                wapp.MessageBoxEx.Show(this, "请填写答案内容！", "系统提示");
                return;
            }
            if (dan.Length > 1000)
            {
                wapp.MessageBoxEx.Show(this, "答案内容字符数量不能超过1000字符！", "系统提示");
                return;
            }
            int dc = -1;
            if (rB1.Checked)
            {
                dc = 1;
            }
            else if (rB2.Checked)
            {
                dc = 0;
            }
            if (dc == -1)
            {
                wapp.MessageBoxEx.Show(this, "请选择答案是否正确！", "系统提示");
                return;
            }
            int px = 0;
            if (cBpx.Checked)
            {
                px = App.Often.GetInt(tBpx.Text, "0");
                if (px < 1)
                {
                    wapp.MessageBoxEx.Show(this, "勾选强制排序，排序位置不能小于或等于0！", "系统提示");
                    return;
                }
                int sl = 0;
                if (IsEdit)
                {
                    sl = App.Often.GetInt(wapp.SQLiteConn.Sqllite.GetES("select count(0) from dalb where tmid=? and px=? and zid<>?", tmid, px.ToString(), daid), "0");
                }
                else
                {
                    sl = App.Often.GetInt(wapp.SQLiteConn.Sqllite.GetES("select count(0) from dalb where tmid=? and px=?", tmid, px.ToString()), "0");
                }
                if (sl > 0)
                {
                    wapp.MessageBoxEx.Show(this, "强制排序值已存在！", "系统提示");
                    return;
                }
            }
            if (IsEdit)
            {
                wapp.SQLiteConn.Sqllite.UP("update dalb set dan=?,px=? where zid=?", dan, px.ToString(), daid);
            }
            else
            {
                wapp.SQLiteConn.Sqllite.UP("insert into dalb(tkid,tmid,dan,dc,px)values(?,?,?,?,?)", tkid, tmid, dan, dc.ToString(), px.ToString());
                wapp.pub.updateSubject(tmid);
            }
            IsOper = true;
            this.Close();
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBpx_Click(object sender, EventArgs e)
        {
            if (cBpx.Checked)
            {
                ppx.Enabled = true;
            }
            else
            {
                ppx.Enabled = false;
            }
        }
    }
}
