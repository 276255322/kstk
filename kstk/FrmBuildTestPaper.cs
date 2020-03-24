using App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kstk
{
    public partial class BuildTestPaper : Form
    {
        public string tkid = "";

        private int dxtsl = 0;

        private int oxtsl = 0;

        private int pdtsl = 0;

        private double dxtmtf = 2;

        private double oxtmtf = 2;

        private double pdtmtf = 2;

        private int dxtcsl = 0;

        private int oxtcsl = 0;

        private int pdtcsl = 0;

        private double dxtzf = 0;

        private double oxtzf = 0;

        private double pdtzf = 0;

        private double sjzf = 0;

        private DataTable tkdt;
        private DataTable dxtdt;
        private DataTable oxtdt;
        private DataTable pdtdt;

        /// <summary>文件编码名称</summary>
        public string becode = "";

        /// <summary>文件编码类</summary>
        private ByteEncode be = new ByteEncode();

        Random ran = new Random();

        public BuildTestPaper()
        {
            InitializeComponent();
        }

        private void FrmAnswerInfo_Load(object sender, EventArgs e)
        {
            tkdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tklb where zid=?", tkid);
            if (tkdt != null && tkdt.Rows.Count > 0)
            {
                ltkbt.Text = App.DataOften.GetStr(tkdt, "bt");
                tBtitle.Text = App.DataOften.GetStr(tkdt, "bt");
                dxtdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where qy=? and tkid=? and lx=?", "1", tkid, "0");
                oxtdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where qy=? and tkid=? and lx=?", "1", tkid, "1");
                pdtdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where qy=? and tkid=? and lx=?", "1", tkid, "2");
                dxtsl = dxtdt.Rows.Count;
                oxtsl = oxtdt.Rows.Count;
                pdtsl = pdtdt.Rows.Count;
                ldxtzj.Text = dxtsl.ToString();
                loxtzj.Text = oxtsl.ToString();
                lpdtzj.Text = pdtsl.ToString();

            }
            tBdxtf.Text = dxtmtf.ToString();
            dxtcsl = dxtsl;
            if (dxtcsl > 20)
            {
                dxtcsl = 20;
            }
            tBdxtsl.Text = dxtcsl.ToString();
            dxtzf = App.Often.GetHoldDigit(dxtmtf * dxtcsl, 2);
            ldxtmf.Text = dxtzf.ToString() + "分";

            tBoxtf.Text = oxtmtf.ToString();
            oxtcsl = oxtsl;
            if (oxtcsl > 20)
            {
                oxtcsl = 20;
            }
            tBoxtsl.Text = oxtcsl.ToString();
            oxtzf = App.Often.GetHoldDigit(oxtmtf * oxtcsl, 2);
            loxtmf.Text = oxtzf.ToString() + "分";

            tBpdtf.Text = pdtmtf.ToString();
            pdtcsl = pdtsl;
            if (pdtcsl > 10)
            {
                pdtcsl = 10;
            }
            tBpdtsl.Text = pdtcsl.ToString();
            pdtzf = App.Often.GetHoldDigit(pdtmtf * pdtcsl, 2);
            lpdtmf.Text = pdtzf.ToString() + "分";

            sjzf = dxtzf + oxtzf + pdtzf;
            lsjzf.Text = sjzf.ToString() + "分";

        }

        private void UpdateShowData()
        {
            if (cBdxt.Checked)
            {
                dxtmtf = App.Often.GetInt(tBdxtf.Text);
                dxtcsl = App.Often.GetInt(tBdxtsl.Text);
            }
            else
            {
                dxtmtf = 0;
                dxtcsl = 0;
            }
            
            if (dxtmtf < 0)
            {
                dxtmtf = 0;
            }
            tBdxtf.Text = dxtmtf.ToString(); 
            if (dxtcsl > dxtsl)
            {
                dxtcsl = dxtsl;
            }
            tBdxtsl.Text = dxtcsl.ToString();
            dxtzf = App.Often.GetHoldDigit(dxtmtf * dxtcsl, 2);
            ldxtmf.Text = dxtzf.ToString() + "分";

            if (cBoxt.Checked)
            {
                oxtmtf = App.Often.GetInt(tBoxtf.Text);
                oxtcsl = App.Often.GetInt(tBoxtsl.Text);
            }
            else
            {
                oxtmtf = 0;
                oxtcsl = 0;
            }
            if (oxtmtf < 0)
            {
                oxtmtf = 0;
            }
            tBoxtf.Text = oxtmtf.ToString();
            if (oxtcsl > oxtsl)
            {
                oxtcsl = oxtsl;
            }
            tBoxtsl.Text = oxtcsl.ToString();
            oxtzf = App.Often.GetHoldDigit(oxtmtf * oxtcsl, 2);
            loxtmf.Text = oxtzf.ToString() + "分";

            if (cBpdt.Checked)
            {
                pdtmtf = App.Often.GetInt(tBpdtf.Text);
                pdtcsl = App.Often.GetInt(tBpdtsl.Text);
            }
            else
            {
                pdtmtf = 0;
                pdtcsl = 0;
            }
            if (pdtmtf < 0)
            {
                pdtmtf = 0;
            }
            tBpdtf.Text = pdtmtf.ToString();
            if (pdtcsl > pdtsl)
            {
                pdtcsl = pdtsl;
            }
            tBpdtsl.Text = pdtcsl.ToString();
            pdtzf = App.Often.GetHoldDigit(pdtmtf * pdtcsl, 2);
            lpdtmf.Text = pdtzf.ToString() + "分";

            sjzf = dxtzf + oxtzf + pdtzf;
            lsjzf.Text = sjzf.ToString() + "分";

        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbuild_Click(object sender, EventArgs e)
        {
            UpdateShowData();
            string sjbt = tBtitle.Text.Trim();
            if (sjbt == "")
            {
                wapp.MessageBoxEx.Show(this, "请填写试卷标题！", "系统提示");
                return;
            }
            int tmzs = 0;
            double tmzf = 0;

            if (cBdxt.Checked)
            {
                dxtcsl = App.Often.GetInt(tBdxtsl.Text.Trim(), "-1");
                if (dxtcsl < 0)
                {
                    wapp.MessageBoxEx.Show(this, "生成单选题的数量必须大于或等于0！", "系统提示");
                    return;
                }
                if (dxtcsl > dxtsl)
                {
                    wapp.MessageBoxEx.Show(this, "生成单选题的数量必须小于或等于单选题总数！", "系统提示");
                    return;
                }
                tmzs += dxtcsl;

                dxtmtf = App.Often.GetNumber(tBdxtf.Text);
                if (dxtmtf < 0)
                {
                    wapp.MessageBoxEx.Show(this, "单选题每题得分不能小于0！", "系统提示");
                    return;
                }
                dxtzf = App.Often.GetHoldDigit(dxtmtf * dxtcsl, 2);
                tmzf += dxtzf;
            }

            if (cBoxt.Checked)
            {
                oxtcsl = App.Often.GetInt(tBoxtsl.Text.Trim(), "-1");
                if (oxtcsl < 0)
                {
                    wapp.MessageBoxEx.Show(this, "生成多选题的数量必须大于或等于0！", "系统提示");
                    return;
                }
                if (oxtcsl > oxtsl)
                {
                    wapp.MessageBoxEx.Show(this, "生成多选题的数量必须小于或等于多选题总数！", "系统提示");
                    return;
                }
                tmzs += oxtcsl;

                oxtmtf = App.Often.GetNumber(tBoxtf.Text);
                if (oxtmtf < 0)
                {
                    wapp.MessageBoxEx.Show(this, "多选题每题得分不能小于0！", "系统提示");
                    return;
                }
                oxtzf = App.Often.GetHoldDigit(oxtmtf * oxtcsl, 2);
                tmzf += oxtzf;
            }

            if (cBpdt.Checked)
            {
                pdtcsl = App.Often.GetInt(tBpdtsl.Text.Trim(), "-1");
                if (pdtcsl < 0)
                {
                    wapp.MessageBoxEx.Show(this, "生成判断题的数量必须大于或等于0！", "系统提示");
                    return;
                }
                if (pdtcsl > pdtsl)
                {
                    wapp.MessageBoxEx.Show(this, "生成判断题的数量必须小于或等于判断题总数！", "系统提示");
                    return;
                }
                tmzs += pdtcsl;

                pdtmtf = App.Often.GetNumber(tBpdtf.Text);
                if (pdtmtf < 0)
                {
                    wapp.MessageBoxEx.Show(this, "判断题每题得分不能小于0！", "系统提示");
                    return;
                }
                pdtzf = App.Often.GetHoldDigit(pdtmtf * pdtcsl, 2);
                tmzf += pdtzf;
            }

            if (tmzs < 1)
            {
                wapp.MessageBoxEx.Show(this, "至少需要生成一个题目！", "系统提示");
                return;
            }

            if (tmzf <= 0)
            {
                wapp.MessageBoxEx.Show(this, "生成的题目总分必须大于0！", "系统提示");
                return;
            }

            string tempPath = wapp.AppPub.getQuestionTemplatePath();
            LoadFileEncoding(tempPath);
            Encoding encoding = Encoding.GetEncoding(becode);
            FileStream fs = new FileStream(tempPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, encoding);
            string tempText = sr.ReadToEnd();
            tempText = tempText.Replace("{$PAPER_TITLE}", App.Often.CodeHtml(sjbt, 2));
            tempText = tempText.Replace("{$TEST_PAPER_TITLE}", App.Often.CodeHtml(sjbt, 2));

            string sjsm = "（试卷满分" + tmzf.ToString() + "分）";
            tempText = tempText.Replace("{$TEST_PAPER_DESC}", "<br/>" + App.Often.CodeHtml(sjsm, 2));

            if (!cBdxt.Checked)
            {
                dxtmtf = 0;
            }
            string dxtfssm = "（每小题" + dxtmtf.ToString() + "分）";
            tempText = tempText.Replace("{$SINGLE_FRACTION_DESC}", App.Often.CodeHtml(dxtfssm, 2));

            if (!cBoxt.Checked)
            {
                oxtmtf = 0;
            }
            string oxtfssm = "（每小题" + oxtmtf.ToString() + "分）";
            tempText = tempText.Replace("{$MULTIPLE_FRACTION_DESC}", App.Often.CodeHtml(oxtfssm, 2));

            if (!cBpdt.Checked)
            {
                pdtmtf = 0;
            }
            string pdtfssm = "（每小题" + pdtmtf.ToString() + "分）";
            tempText = tempText.Replace("{$JUDGE_FRACTION_DESC}", App.Often.CodeHtml(pdtfssm, 2));

            tempText = tempText.Replace("{$SINGLE_FRACTION}", dxtmtf.ToString());
            tempText = tempText.Replace("{$MULTIPLE_FRACTION}", oxtmtf.ToString());
            tempText = tempText.Replace("{$JUDGE_FRACTION}", pdtmtf.ToString());

            int tmxh = 0;
            if (cBdxt.Checked)
            {
                tmxh ++;
                string sslist = getSingleSelections();
                tempText = tempText.Replace("{$SINGLE_SELECTION_LIST}", sslist);
                tempText = tempText.Replace("{$SINGLE_FRACTION_NUMBER}", App.Often.CodeHtml(wapp.AppList.getChineseSerial(tmxh), 2));
                tempText = tempText.Replace("{$SINGLE_FRACTION_STYLE}", "");
            }
            else
            {
                tempText = tempText.Replace("{$SINGLE_SELECTION_LIST}", "");
                tempText = tempText.Replace("{$SINGLE_FRACTION_NUMBER}", "");
                tempText = tempText.Replace("{$SINGLE_FRACTION_STYLE}", "style=\"display: none; \"");
            }

            if (cBoxt.Checked)
            {
                tmxh++;
                string mslist = getMultipleSelections();
                tempText = tempText.Replace("{$MULTIPLE_SELECTION_LIST}", mslist);
                tempText = tempText.Replace("{$MULTIPLE_FRACTION_NUMBER}", App.Often.CodeHtml(wapp.AppList.getChineseSerial(tmxh), 2));
                tempText = tempText.Replace("{$MULTIPLE_FRACTION_STYLE}", "");
            }
            else
            {
                tempText = tempText.Replace("{$MULTIPLE_SELECTION_LIST}", "");
                tempText = tempText.Replace("{$MULTIPLE_FRACTION_NUMBER}", "");
                tempText = tempText.Replace("{$MULTIPLE_FRACTION_STYLE}", "style=\"display: none; \"");
            }

            if (cBtmran.Checked)
            {
                tempText = tempText.Replace("{$IS_SUBJECT_SORT}", "true");
                tempText = tempText.Replace("{$SORT_SUBJECT_MODE}", "checked=\"checked\"");
            }
            else
            {
                tempText = tempText.Replace("{$IS_SUBJECT_SORT}", "false");
                tempText = tempText.Replace("{$SORT_SUBJECT_MODE}", "");
            }

            if (cBdaran.Checked)
            {
                tempText = tempText.Replace("{$IS_ANSWER_SORT}", "true");
                tempText = tempText.Replace("{$SORT_ANSWER_MODE}", "checked=\"checked\"");
            }
            else
            {
                tempText = tempText.Replace("{$IS_ANSWER_SORT}", "false");
                tempText = tempText.Replace("{$SORT_ANSWER_MODE}", "");
            }

            if (rBlxms.Checked)
            {
                tempText = tempText.Replace("{$TEST_PRACTICE_MODE}", "checked=\"checked\"");
                tempText = tempText.Replace("{$TEST_EXAMINATION_MODE}", "");
            }
            else
            {
                tempText = tempText.Replace("{$TEST_PRACTICE_MODE}", "");
                tempText = tempText.Replace("{$TEST_EXAMINATION_MODE}", "checked=\"checked\"");
            }

            if (cBpdt.Checked)
            {
                tmxh++;
                string jslist = getJudgeSelections();
                tempText = tempText.Replace("{$JUDGE_SELECTION_LIST}", jslist);
                tempText = tempText.Replace("{$JUDGE_FRACTION_NUMBER}", App.Often.CodeHtml(wapp.AppList.getChineseSerial(tmxh), 2));
                tempText = tempText.Replace("{$JUDGE_FRACTION_STYLE}", "");
            }
            else
            {
                tempText = tempText.Replace("{$JUDGE_SELECTION_LIST}", "");
                tempText = tempText.Replace("{$JUDGE_FRACTION_NUMBER}", "");
                tempText = tempText.Replace("{$JUDGE_FRACTION_STYLE}", "style=\"display: none; \"");
            }

            string savePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "网页（*.htm）|*.htm";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = sjbt;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                savePath = sfd.FileName.ToString();
                System.IO.File.WriteAllText(savePath, tempText, encoding);
                wapp.MessageBoxEx.Show(this, "生成试卷操作成功！", "系统提示");
            }
        }

        private List<string> getRandomIdList(DataTable rdt, int sl, bool isRan)
        {
            List<string> li = new List<string>();
            if (sl > rdt.Rows.Count)
            {
                sl = rdt.Rows.Count;
            }
            if (!isRan)
            {
                for (int ix = 0; ix < rdt.Rows.Count; ix++)
                {
                    if (li.Count >= sl)
                    {
                        break;
                    }
                    li.Add(rdt.Rows[ix]["zid"].ToString());
                }
                return li;
            }
            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                li.Add(rdt.Rows[i]["zid"].ToString());
            }
            while (li.Count > sl)
            {
                li.RemoveAt(ran.Next(0, li.Count));
            }
            List<string> lia = new List<string>();
            while (li.Count>0)
            {
                int index = 0;
                if (li.Count>1)
                {
                    index = ran.Next(0, li.Count);
                }
                lia.Add(li[index]);
                li.RemoveAt(index);
            }
            return lia;
        }

        private string getSingleSelections()
        {
            StringBuilder sb = new StringBuilder();
            List<string> li = getRandomIdList(dxtdt, dxtcsl, cBtmran.Checked);
            for (int i = 0; i < li.Count; i++)
            {
                string zid = li[i];
                DataRow[] drs = dxtdt.Select("zid=" + zid);
                if (drs.Length > 0)
                {
                    StringBuilder tmsb = new StringBuilder();
                    string tm = drs[0]["tm"].ToString().Trim();
                    DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", zid);
                    List<string> dli = getRandomIdList(dadt, dadt.Rows.Count, cBdaran.Checked);
                    for (int ii = 0; ii < dli.Count; ii++)
                    {
                        string dzid = dli[ii];
                        DataRow[] ddrs = dadt.Select("zid=" + dzid);
                        if (ddrs.Length > 0)
                        {
                            string dan = ddrs[0]["dan"].ToString();
                            string dc = ddrs[0]["dc"].ToString();
                            string px = ddrs[0]["px"].ToString();
                            if (tmsb.Length > 0)
                            {
                                tmsb.Append(",");
                            }
                            tmsb.Append("{\"ltext\": \"" + App.Often.CodeHtml(dan, 2) + "\",\"zt\": \"" + dc.ToString() + "\",\"px\": \"" + px.ToString() + "\"}");
                        }
                    }
                    if (tmsb.Length > 0)
                    {
                        string jsons = "{\"tmname\": \"" + App.Often.CodeHtml(tm, 2) + "\",\"tmlist\": [" + tmsb.ToString() + "]}";
                        if (sb.Length > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(jsons);
                    }
                }
            }
            return sb.ToString();
        }

        private string getMultipleSelections()
        {
            StringBuilder sb = new StringBuilder();
            List<string> li = getRandomIdList(oxtdt, oxtcsl, cBtmran.Checked);
            for (int i = 0; i < li.Count; i++)
            {
                string zid = li[i];
                DataRow[] drs = oxtdt.Select("zid=" + zid);
                if (drs.Length > 0)
                {
                    StringBuilder tmsb = new StringBuilder();
                    string tm = drs[0]["tm"].ToString().Trim();
                    DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", zid);
                    List<string> dli = getRandomIdList(dadt, dadt.Rows.Count, cBdaran.Checked);
                    for (int ii = 0; ii < dli.Count; ii++)
                    {
                        string dzid = dli[ii];
                        DataRow[] ddrs = dadt.Select("zid=" + dzid);
                        if (ddrs.Length > 0)
                        {
                            string dan = ddrs[0]["dan"].ToString();
                            string dc = ddrs[0]["dc"].ToString();
                            string px = ddrs[0]["px"].ToString();
                            if (tmsb.Length > 0)
                            {
                                tmsb.Append(",");
                            }
                            tmsb.Append("{\"ltext\": \"" + App.Often.CodeHtml(dan, 2) + "\",\"zt\": \"" + dc.ToString() + "\",\"px\": \"" + px.ToString() + "\"}");
                        }
                    }
                    if (tmsb.Length > 0)
                    {
                        string jsons = "{\"tmname\": \"" + App.Often.CodeHtml(tm, 2) + "\",\"tmlist\": [" + tmsb.ToString() + "]}";
                        if (sb.Length > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(jsons);
                    }
                }
            }
            return sb.ToString();
        }

        private string getJudgeSelections()
        {
            StringBuilder sb = new StringBuilder();
            List<string> li = getRandomIdList(pdtdt, pdtcsl, cBtmran.Checked);
            for (int i = 0; i < li.Count; i++)
            {
                string zid = li[i];
                DataRow[] drs = pdtdt.Select("zid=" + zid);
                if (drs.Length > 0)
                {
                    StringBuilder tmsb = new StringBuilder();
                    string tm = drs[0]["tm"].ToString().Trim();
                    DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", zid);
                    if (dadt.Rows.Count > 0)
                    {
                        string dan = dadt.Rows[0]["dan"].ToString();
                        string dc = dadt.Rows[0]["dc"].ToString();
                        string px = dadt.Rows[0]["px"].ToString();
                        if (dc == "1")
                        {
                            tmsb.Append("{\"ltext\": \"" + App.Often.CodeHtml("正确", 2) + "\",\"zt\": \"1\",\"px\": \"" + px.ToString() + "\"}, {\"ltext\": \"" + App.Often.CodeHtml("错误", 2) + "\",\"zt\": \"0\",\"px\": \"" + px.ToString() + "\"}");
                        }
                        else
                        {
                            tmsb.Append("{\"ltext\": \"" + App.Often.CodeHtml("正确", 2) + "\",\"zt\": \"0\",\"px\": \"" + px.ToString() + "\"}, {\"ltext\": \"" + App.Often.CodeHtml("错误", 2) + "\",\"zt\": \"1\",\"px\": \"" + px.ToString() + "\"}");
                        }
                    }
                    if (tmsb.Length > 0)
                    {
                        string jsons = "{\"tmname\": \"" + App.Often.CodeHtml(tm, 2) + "\",\"tmlist\": [" + tmsb.ToString() + "]}";
                        if (sb.Length > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(jsons);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>读取文件编码</summary>
        private void LoadFileEncoding(string fpath)
        {
            FileStream fs = new FileStream(fpath, FileMode.Open, FileAccess.Read);
            becode = be.GetByCode(fs);
            fs.Close();
        }

        private void tBdxtf_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void tBdxtsl_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void tBoxtf_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void tBoxtsl_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void tBpdtf_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void tBpdtsl_TextChanged(object sender, EventArgs e)
        {
            UpdateShowData();
        }

        private void cBdxt_Click(object sender, EventArgs e)
        {
            SetCheck();
        }

        private void cBoxt_Click(object sender, EventArgs e)
        {
            SetCheck();
        }

        private void cBpdt_Click(object sender, EventArgs e)
        {
            SetCheck();
        }

        private void SetCheck()
        {
            if (cBdxt.Checked)
            {
                pdxt.Enabled = true;
            }
            else
            {
                pdxt.Enabled = false;
            }
            if (cBoxt.Checked)
            {
                poxt.Enabled = true;
            }
            else
            {
                poxt.Enabled = false;
            }
            if (cBpdt.Checked)
            {
                ppdt.Enabled = true;
            }
            else
            {
                ppdt.Enabled = false;
            }

            if (cBdxt.Checked)
            {
                dxtmtf = App.Often.GetInt(tBdxtf.Text);
                dxtcsl = App.Often.GetInt(tBdxtsl.Text);
                if (dxtmtf==0 && dxtmtf==0)
                {
                    tBdxtf.Text = "2";
                    tBdxtsl.Text = "20";
                }
            }
            if (cBoxt.Checked)
            {
                oxtmtf = App.Often.GetInt(tBoxtf.Text);
                oxtcsl = App.Often.GetInt(tBoxtsl.Text);
                if (oxtmtf == 0 && oxtcsl == 0)
                {
                    tBoxtf.Text = "2";
                    tBoxtsl.Text = "20";
                }
            }

            if (cBpdt.Checked)
            {
                pdtmtf = App.Often.GetInt(tBpdtf.Text);
                pdtcsl = App.Often.GetInt(tBpdtsl.Text);
                if (pdtmtf == 0 && pdtcsl == 0)
                {
                    tBpdtf.Text = "2";
                    tBpdtsl.Text = "10";
                }
            }
           
            UpdateShowData();
        }

    }
}
