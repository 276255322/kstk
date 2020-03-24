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
    public partial class FrmSubjectManage : Form
    {
        public bool IsOper = false;

        public string tkid = "";

        public DataTable tkdt;

        public DataTable tmdt;

        public int index = -1;

        private bool isLoad = false;

        public FrmSubjectManage()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            bW.WorkerSupportsCancellation = true;
            App.Win.Utils.SetComboBoxItems(cBlx, "|全部||" + wapp.AppList.SubjectType(), "");
            cBlx.SelectedIndex = 0;
            App.Win.Utils.SetComboBoxItems(cBuse, "|全部||" + wapp.AppList.IsUser(), "");
            cBuse.SelectedIndex = 0;
            App.Win.Utils.SetComboBoxItems(cBmb, wapp.AppList.SearchTarget(), "");
            cBmb.SelectedIndex = 0;
            App.Win.Utils.SetComboBoxItems(cBhs, wapp.AppList.RowNumbers(), "");
            cBhs.SelectedIndex = 0;
            tkdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
            ltkbt.Text = DataOften.GetStr(tkdt, "bt");
            LoadList(1);
            isLoad = true;
        }

        public void LoadList(int pageNum)
        {
            if (bW.IsBusy)
            {
                bW.CancelAsync();
            }       
            centPage.PageNum = pageNum;
            centPage.DataCount = 0;
            centPage.EachCount = App.Often.GetInt(App.Win.Utils.GetComboBoxValue(cBhs));
            StringBuilder sb = new StringBuilder();
            List<string> li = new List<string>();
            DataOften.SqlAddArr("tkid=?", tkid, ref sb, ref li);
            string cname = tBName.Text.Trim();
            if (cname != "")
            {
                string mb = App.Win.Utils.GetComboBoxValue(cBmb);
                if (mb == "0")
                {
                    DataOften.SqlAddArr("(tm like ? or zid in (select tmid from dalb where dan like ?) or dajx like ?)", ref sb, ref li, "%" + cname + "%", "%" + cname + "%", "%" + cname + "%");
                }
                else if (mb == "1")
                {
                    DataOften.SqlAddArr("tm like ?", "%" + cname + "%", ref sb, ref li);
                }
                else if (mb == "2")
                {
                    DataOften.SqlAddArr("zid in (select tmid from dalb where dan like ?)", ref sb, ref li, "%" + cname + "%");
                }
                else if (mb == "3")
                {
                    DataOften.SqlAddArr("tm like ? or dajx like ?", ref sb, ref li, "%" + cname + "%", "%" + cname + "%");
                }
            }
            string lx = App.Win.Utils.GetComboBoxValue(cBlx);
            if (lx != "")
            {
                DataOften.SqlAddArr("lx = ?", lx, ref sb, ref li);
            }
            string qy = App.Win.Utils.GetComboBoxValue(cBuse);
            if (qy != "")
            {
                DataOften.SqlAddArr("qy = ?", qy, ref sb, ref li);
            }
            DataOften.SqlAddWhere(ref sb);
            centPage.DataCount = App.Often.GetInt(wapp.SQLiteConn.Sqllite.GetES("select count(0) from tmlb " + sb.ToString(), li));
            centPage.SetCent();
            string sql = "select * from tmlb " + sb.ToString() + " limit " + centPage.EachCount.ToString() + " offset " + centPage.StartData.ToString();
            tmdt = wapp.SQLiteConn.Sqllite.GetDT(sql, li);
            int xh = centPage.StartData + 1;
            listv.Items.Clear();
            if (tmdt.Rows.Count > 0)
            {
                for (int i = 0; i < tmdt.Rows.Count; i++)
                {
                    string zid = tmdt.Rows[i]["zid"].ToString().Trim();
                    ListViewItem itema = new ListViewItem("", 0);
                    itema.UseItemStyleForSubItems = false;
                    itema.Name = zid;
                    itema.SubItems.Add((xh + i).ToString());
                    itema.SubItems.Add(tmdt.Rows[i]["tm"].ToString().Trim());
                    itema.SubItems.Add(tmdt.Rows[i]["dajx"].ToString().Trim());

                    string qys = tmdt.Rows[i]["qy"].ToString().Trim();
                    itema.SubItems.Add(App.Web.WebOften.GetListVal(wapp.AppList.IsUser(), qys));
                    wapp.pub.setUseColor(itema.SubItems[itema.SubItems.Count - 1], qys);

                    string lxs = tmdt.Rows[i]["lx"].ToString().Trim();
                    itema.SubItems.Add(App.Web.WebOften.GetListVal(wapp.AppList.SubjectType(), lxs));
                    wapp.pub.setSubjectTypeColor(itema.SubItems[itema.SubItems.Count - 1], lxs);

                    itema.SubItems.Add(tmdt.Rows[i]["sl"].ToString().Trim());
                    listv.Items.AddRange(new ListViewItem[] { itema });
                }
                index = listv.Items[0].SubItems.Count - 1;
                bW.RunWorkerAsync();
            }
            cBallsel.Checked = false;
        }

        /// <summary>列表线程委托方法</summary>
        public void SetListViewValue(int row, string val)
        {
            listv.Items[row].SubItems.Add(val);
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            using (FrmSubjectInfo form = new FrmSubjectInfo())
            {
                form.tkid = tkid;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.IsOper)
                {
                    IsOper = true;
                    LoadList(centPage.PageNum);
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
                    using (FrmSubjectInfo form = new FrmSubjectInfo())
                    {
                        form.tkid = tkid;
                        form.tmid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            IsOper = true;
                            LoadList(centPage.PageNum);
                        }
                    }
                }
            }
            else
            {
                wapp.MessageBoxEx.Show(this, "请选择需要编辑的题目！", "系统提示");
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
                        string sid = wapp.SQLiteConn.Sqllite.GetES("select * from dalb where tmid=?", ids);
                        if (sid != "")
                        {
                            wapp.MessageBoxEx.Show(this, "序号" + xh + "的题目包含答案不允许删除！", "系统提示");
                            return;
                        }
                        wapp.SQLiteConn.Sqllite.UP("delete from tmlb where zid=?", ids);
                        wapp.pub.updateQuestion(tkid);
                        IsOper = true;
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList(centPage.PageNum);
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要删除的题目！", "系统提示");
            }
        }

        private void listv_DoubleClick(object sender, EventArgs e)
        {
            if (listv.SelectedItems.Count > 0)
            {
                string ids = listv.SelectedItems[0].Name.Trim();
                if (ids != "")
                {
                    using (FrmAnswerManage form = new FrmAnswerManage())
                    {
                        form.tkid = tkid;
                        form.tmid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            IsOper = true;
                            LoadList(centPage.PageNum);
                        }
                    }
                }
            }
        }

        private void btuse_Click(object sender, EventArgs e)
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
                        DataTable tmdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where zid=?", ids);
                        if (tmdt == null || tmdt.Rows.Count <= 0)
                        {
                            continue;
                        }
                        DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", ids);
                        if (dadt == null || dadt.Rows.Count <= 0)
                        {
                            wapp.MessageBoxEx.Show(this, "序号" + xh + "的题目至少包含1个答案！", "系统提示");
                            continue;
                        }
                        int zqda = 0;
                        int dasl = dadt.Rows.Count;
                        for (int i = 0; i < dasl; i++)
                        {
                            string dc = App.DataOften.GetStr(dadt, "dc", i);
                            if (dc == "1")
                            {
                                zqda++;
                            }
                        }
                        string lx = App.DataOften.GetStr(tmdt, "lx");
                        if (lx == "1")
                        {
                            if (dasl == 1)
                            {
                                wapp.MessageBoxEx.Show(this, "序号" + xh + "是多选题至少有2个答案！", "系统提示");
                                continue;
                            }
                            if (zqda < 1)
                            {
                                wapp.MessageBoxEx.Show(this, "序号" + xh + "是多选题至少有一个正确答案！", "系统提示");
                                continue;
                            }
                        }
                        else if (lx == "2")
                        {
                            if (dasl > 1)
                            {
                                wapp.MessageBoxEx.Show(this, "序号" + xh + "是判断题只能有1个答案！", "系统提示");
                                continue;
                            }
                        }
                        else
                        {
                            if (dasl == 1)
                            {
                                wapp.MessageBoxEx.Show(this, "序号" + xh + "是单选题至少有2个答案！", "系统提示");
                                continue;
                            }
                            if (zqda < 1 || zqda > 1)
                            {
                                wapp.MessageBoxEx.Show(this, "序号" + xh + "是单选题只能有一个正确答案！", "系统提示");
                                continue;
                            }
                        }
                        wapp.SQLiteConn.Sqllite.UP("update tmlb set qy=? where zid=?", "1", ids);
                        wapp.pub.updateSubject(ids);
                        IsOper = true;
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList(centPage.PageNum);
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要启用的题目！", "系统提示");
            }
        }

        private void btstop_Click(object sender, EventArgs e)
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
                        wapp.SQLiteConn.Sqllite.UP("update tmlb set qy=? where zid=?", "0", ids);
                        wapp.pub.updateQuestion(tkid);
                        IsOper = true;
                        finishCount++;
                    }
                }
            }
            if (finishCount > 0)
            {
                LoadList(centPage.PageNum);
            }
            if (!isOper)
            {
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要停用的题目！", "系统提示");
            }
        }

        private void btss_Click(object sender, EventArgs e)
        {
            LoadList(1);
        }

        private void centPage_btnJump_Click(object sender, EventArgs e)
        {
            LoadList(centPage.GetJumpNum());
        }

        private void centPage_LinkLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadList(centPage.CentCount);
        }

        private void centPage_LinkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadList(centPage.PageNum + 1);
        }

        private void centPage_LinkPro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadList(centPage.PageNum - 1);
        }

        private void centPage_LinkTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadList(1);
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

        private void cBlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                LoadList(1);
            }
        }

        private void cBuse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                LoadList(1);
            }
        }

        private void cBhs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                LoadList(centPage.PageNum);
            }
        }

        private void bW_DoWork(object sender, DoWorkEventArgs e)
        {
            if (index < 0)
            {
                return;
            }
            for (int i = 0; i < tmdt.Rows.Count; i++)
            {
                if (bW.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                string zid = tmdt.Rows[i]["zid"].ToString().Trim();
                int lx = App.Often.GetInt(tmdt.Rows[i]["lx"].ToString());
                StringBuilder sb = new StringBuilder();
                DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", zid);
                for (int ii = 0; ii < dadt.Rows.Count; ii++)
                {
                    if (bW.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    int xh = ii + 1;
                    string dan = dadt.Rows[ii]["dan"].ToString().Trim();
                    int dc = App.Often.GetInt(dadt.Rows[ii]["dc"].ToString());
                    if (sb.Length > 0)
                    {
                        sb.Append("；");
                    }
                    if (dc == 1)
                    {
                        sb.Append(xh.ToString() + "、" + dan + " √");
                    }
                    else
                    {
                        sb.Append(xh.ToString() + "、" + dan + " ×");
                    }
                }
                object[] obj = new object[2];
                obj[0] = i;
                obj[1] = sb.ToString();
                listv.Invoke(new wapp.AppPub.DelegateSetListViewValue(SetListViewValue), obj);
            }
        }

        private void bW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
