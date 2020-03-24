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
    public partial class FrmQuestionManage : Form
    {
        private bool isLoad = false;

        public FrmQuestionManage()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            App.Win.Utils.SetComboBoxItems(cBhs, wapp.AppList.RowNumbers(), "");
            cBhs.SelectedIndex = 0;
            LoadList(1);
            isLoad = true;
        }

        public void LoadList(int pageNum)
        {
            centPage.PageNum = pageNum;
            centPage.DataCount = 0;
            centPage.EachCount = App.Often.GetInt(App.Win.Utils.GetComboBoxValue(cBhs));
            StringBuilder sb = new StringBuilder();
            List<string> li = new List<string>();
            string cname = tBName.Text.Trim();
            if (cname != "")
            {
                DataOften.SqlAddArr("bt like ?", "%" + cname + "%", ref sb, ref li);
            }
            DataOften.SqlAddWhere(ref sb);
            centPage.DataCount = App.Often.GetInt(wapp.SQLiteConn.Sqllite.GetES("select count(0) from tklb " + sb.ToString(), li));
            centPage.SetCent();
            string sql = "select * from tklb " + sb.ToString() + " limit " + centPage.EachCount.ToString() + " offset " + centPage.StartData.ToString();
            DataTable dt = wapp.SQLiteConn.Sqllite.GetDT(sql, li);
            int xh = centPage.StartData + 1;
            listv.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string zid = dt.Rows[i]["zid"].ToString().Trim();
                ListViewItem itema = new ListViewItem("", 0);
                itema.Name = zid;
                itema.SubItems.Add((xh + i).ToString());
                itema.SubItems.Add(dt.Rows[i]["bt"].ToString().Trim());
                itema.SubItems.Add(dt.Rows[i]["sl"].ToString().Trim());
                itema.SubItems.Add(dt.Rows[i]["yxsl"].ToString().Trim());
                itema.SubItems.Add(dt.Rows[i]["wxsl"].ToString().Trim());
                itema.SubItems.Add(dt.Rows[i]["ms"].ToString().Trim());
                listv.Items.AddRange(new ListViewItem[] { itema });
            }
            cBallsel.Checked = false;     
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            using (FrmQuestionInfo form = new FrmQuestionInfo())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.IsOper)
                {
                    LoadList(centPage.PageNum);
                }
            }
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (listv.SelectedItems.Count > 0)
            {
                string ids = listv.SelectedItems[0].Name;
                if (ids != "")
                {
                    using (FrmQuestionInfo form = new FrmQuestionInfo())
                    {
                        form.tkid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            LoadList(centPage.PageNum);
                        }
                    }
                }
            }
            else
            {
                wapp.MessageBoxEx.Show(this, "请选择需要编辑的题库！", "系统提示");
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
                        string sid = wapp.SQLiteConn.Sqllite.GetES("select * from tmlb where tkid=?", ids);
                        if (sid != "")
                        {
                            wapp.MessageBoxEx.Show(this, "序号" + xh + "的题库包含题目不允许删除！", "系统提示");
                            return;
                        }
                        wapp.SQLiteConn.Sqllite.UP("delete from tklb where zid=?", ids);
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
                wapp.MessageBoxEx.Show(this, "至少勾选一个需要删除的题库！", "系统提示");
            }
        }

        private void listv_DoubleClick(object sender, EventArgs e)
        {
            if (listv.SelectedItems.Count > 0)
            {
                string ids = listv.SelectedItems[0].Name;
                if (ids != "")
                {
                    using (FrmSubjectManage form = new FrmSubjectManage())
                    {
                        form.tkid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            LoadList(centPage.PageNum);
                        }
                    }
                }
            }
        }

        private void btbuild_Click(object sender, EventArgs e)
        {
            if (listv.SelectedItems.Count > 0)
            {
                string ids = listv.SelectedItems[0].Name;
                if (ids != "")
                {
                    DataTable dt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", ids);
                    int yxsl = DataOften.GetInt(dt, "yxsl", "0");
                    if (yxsl<=0)
                    {
                        wapp.MessageBoxEx.Show(this, "该题库至少需要一条有效的题目！", "系统提示");
                        return;
                    }
                    using (BuildTestPaper form = new BuildTestPaper())
                    {
                        form.tkid = ids;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog(this);
                    }
                }
            }
            else
            {
                wapp.MessageBoxEx.Show(this, "请选择需要生成试卷的题库！", "系统提示");
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

        private void cBhs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                LoadList(centPage.PageNum);
            }
        }
    }
}
