using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using App;

namespace kstk
{
    public partial class FrmAnswerManage : Form
    {

        public bool IsOper = false;

        public string tkid = "";

        public string tmid = "";

        public DataTable tkdt;

        public DataTable tmdt;

        public DataTable dadt;

        private bool isLoad = false;

        public FrmAnswerManage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            App.Win.Utils.SetComboBoxItems(cBdc, "|全部||" + wapp.AppList.AnswerResult(), "");
            cBdc.SelectedIndex = 0;
            tkdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
            ltkbt.Text = DataOften.GetStr(tkdt, "bt");
            tmdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where zid=?", tmid);
            ltmbt.Text = DataOften.GetStr(tmdt, "tm");
            LoadList();
            isLoad = true;
        }

        public void LoadList()
        {
            StringBuilder sb = new StringBuilder();
            List<string> li = new List<string>();
            DataOften.SqlAddArr("tmid=?", tmid, ref sb, ref li);
            string cname = tBName.Text.Trim();
            if (cname != "")
            {
                DataOften.SqlAddArr("dan like ?", "%" + cname + "%", ref sb, ref li);
            }
            string dc = App.Win.Utils.GetComboBoxValue(cBdc);
            if (dc != "")
            {
                DataOften.SqlAddArr("dc = ?", dc, ref sb, ref li);
            }
            DataOften.SqlAddWhere(ref sb);
            string sql = "select * from dalb " + sb.ToString();
            dadt = wapp.SQLiteConn.Sqllite.GetDT(sql, li);
            int xh = 1;
            listv.Items.Clear();
            for (int i = 0; i < dadt.Rows.Count; i++)
            {
                string zid = dadt.Rows[i]["zid"].ToString().Trim();
                ListViewItem itema = new ListViewItem("", 0);
                itema.UseItemStyleForSubItems = false;
                itema.Name = zid;
                itema.SubItems.Add((xh + i).ToString());
                itema.SubItems.Add(dadt.Rows[i]["dan"].ToString().Trim());
                string dcs = dadt.Rows[i]["dc"].ToString().Trim();
                itema.SubItems.Add(App.Web.WebOften.GetListVal(wapp.AppList.AnswerResult(), dcs));
                wapp.pub.setResultColor(itema.SubItems[itema.SubItems.Count - 1], dcs);
                itema.SubItems.Add(dadt.Rows[i]["px"].ToString().Trim());
                listv.Items.AddRange(new ListViewItem[] { itema });
            }
            cBallsel.Checked = false;
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            using (FrmAnswerInfo form = new FrmAnswerInfo())
            {
                form.tkid = tkid;
                form.tmid = tmid;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.IsOper)
                {
                    IsOper = true;
                    LoadList();
                }
            }
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (listv.SelectedItems.Count > 0)
            {
                string ids = listv.SelectedItems[0].Name.Trim();
                if (ids != "")
                {
                    using (FrmAnswerInfo form = new FrmAnswerInfo())
                    {
                        form.tkid = tkid;
                        form.tmid = tmid;
                        form.daid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            IsOper = true;
                            LoadList();
                        }
                    }
                }
            }
            else
            {
                wapp.MessageBoxEx.Show(this, "请选择需要编辑的答案！", "系统提示");
            }
        }

        private void btdui_Click(object sender, EventArgs e)
        {
            bool isOper = false;
            int finishCount = 0;
            for (int ii = 0; ii < listv.Items.Count; ii++)
            {
                if (listv.Items[ii].Checked)
                {
                    isOper = true;
                    string ids = listv.Items[ii].Name;
                    string xh = listv.Items[ii].SubItems[1].Text.Trim();
                    if (ids != "")
                    {
                        wapp.SQLiteConn.Sqllite.UP("update dalb set dc=? where zid=?", "1", ids);
                        wapp.pub.updateSubject(tmid);
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList();
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要标记正确的答案！", "系统提示");
            }
        }

        private void btcuo_Click(object sender, EventArgs e)
        {
            bool isOper = false;
            int finishCount = 0;
            for (int ii = 0; ii < listv.Items.Count; ii++)
            {
                if (listv.Items[ii].Checked)
                {
                    isOper = true;
                    string ids = listv.Items[ii].Name;
                    string xh = listv.Items[ii].SubItems[1].Text.Trim();
                    if (ids != "")
                    {
                        wapp.SQLiteConn.Sqllite.UP("update dalb set dc=? where zid=?", "0", ids);
                        wapp.pub.updateSubject(tmid);
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList();
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要标记错误的答案！", "系统提示");
            }
        }

        private void btdel_Click(object sender, EventArgs e)
        {
            DialogResult result = wapp.MessageBoxEx.Show(this, "确认删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            bool isOper = false;
            int finishCount = 0;
            for (int ii = 0; ii < listv.Items.Count; ii++)
            {
                if (listv.Items[ii].Checked)
                {
                    isOper = true;
                    string ids = listv.Items[ii].Name;
                    string xh = listv.Items[ii].SubItems[1].Text.Trim();
                    if (ids != "")
                    {
                        wapp.SQLiteConn.Sqllite.UP("delete from dalb where zid=?", ids);
                        wapp.pub.updateSubject(tmid);
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList();
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要删除的答案！", "系统提示");
            }
        }

        private void cBdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                LoadList();
            }
        }

        private void cBallsel_Click(object sender, EventArgs e)
        {
            allSetCheck();
        }

        private void allSetCheck()
        {
            for (int i = 0; i < listv.Items.Count; i++)
            {
                listv.Items[i].Checked = cBallsel.Checked;
            }
        }
    }
}
