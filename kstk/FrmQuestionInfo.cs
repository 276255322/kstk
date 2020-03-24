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
    public partial class FrmQuestionInfo : Form
    {
        public bool IsOper = false;

        public string tkid = "";

        public bool IsEdit = false;

        public FrmQuestionInfo()
        {
            InitializeComponent();
        }

        private void FrmQuestionInfo_Load(object sender, EventArgs e)
        {
            if (tkid != "")
            {
                DataTable dt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rTextName.Text = App.DataOften.GetStr(dt, "bt");
                    rTextDesc.Text = App.DataOften.GetStr(dt, "ms");
                    IsEdit = true;
                }
            }
            if (IsEdit)
            {
                this.Text = "编辑题库";
            }
            else
            {
                this.Text = "新增题库";
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            string bt = rTextName.Text.Trim();
            string ms = rTextDesc.Text.Trim();
            if (bt == "")
            {
                wapp.MessageBoxEx.Show(this, "请填写题库名称！", "系统提示");
                return;
            }
            if (bt.Length > 1000)
            {
                wapp.MessageBoxEx.Show(this, "题库名称字符数量不能超过1000字符！", "系统提示");
                return;
            }
            if (ms.Length > 10000)
            {
                wapp.MessageBoxEx.Show(this, "描述字符数量不能超过10000字符！", "系统提示");
                return;
            }
            if (IsEdit)
            {
                wapp.SQLiteConn.Sqllite.UP("update tklb set bt=?, ms=? where zid=?", bt, ms, tkid);
            }
            else
            {
                wapp.SQLiteConn.Sqllite.UP("insert into tklb(bt,ms,sl,yxsl,wxsl,px)values(?,?,?,?,?,?)", bt, ms, "0", "0", "0", "0");
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
