using App;
using App.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wapp
{
    public class pub
    {
        public static Color redColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
        public static Color greenColor = System.Drawing.ColorTranslator.FromHtml("#438B16");
        public static Color blueColor = System.Drawing.ColorTranslator.FromHtml("#0070C0");
        public static Color orangeColor = System.Drawing.ColorTranslator.FromHtml("#0070C0");

        public static void setResultColor(ListViewItem.ListViewSubItem lvs, string val)
        {

            if (val == "1")
            {
                lvs.ForeColor = greenColor;
            }
            else if (val == "0")
            {
                lvs.ForeColor = redColor;
            }  
        }

        public static void setSubjectTypeColor(ListViewItem.ListViewSubItem lvs, string val)
        {

            if (val == "0")
            {
                lvs.ForeColor = greenColor;
            }
            else if (val == "1")
            {
                lvs.ForeColor = blueColor;
            }
            else if (val == "2")
            {
                lvs.ForeColor = orangeColor;
            }
        }

        public static void setUseColor(ListViewItem.ListViewSubItem lvs, string val)
        {

            if (val == "0")
            {
                lvs.ForeColor = redColor;
            }
            else if (val == "1")
            {
                lvs.ForeColor = blueColor;
            }
        }

        public static void updateQuestion(string tkid)
        {
            string zsl = wapp.SQLiteConn.Sqllite.GetES("select count(0) from tmlb where tkid=?", tkid);
            string yxsl = wapp.SQLiteConn.Sqllite.GetES("select count(0) from tmlb where tkid=? and qy=?", tkid, "1");
            string wxsl = wapp.SQLiteConn.Sqllite.GetES("select count(0) from tmlb where tkid=? and qy=?", tkid, "0");
            wapp.SQLiteConn.Sqllite.UP("update tklb set sl=?, yxsl=?, wxsl=? where zid=?", zsl, yxsl, wxsl, tkid);
        }

        public static void updateSubject(string tmid)
        {
            DataTable tmdt = wapp.SQLiteConn.Sqllite.GetDT("select * from tmlb where zid=?", tmid);
            if (tmdt != null && tmdt.Rows.Count > 0)
            {
                string tkid = App.DataOften.GetStr(tmdt, "tkid");
                DataTable dadt = wapp.SQLiteConn.Sqllite.GetDT("select * from dalb where tmid=?", tmid);
                int zqda = 0;
                int dasl = 0;
                int qy = 0;
                if (dadt != null && dadt.Rows.Count > 0)
                {
                    dasl = dadt.Rows.Count;
                    for (int i = 0; i < dasl; i++)
                    {
                        string dc = App.DataOften.GetStr(dadt, "dc", i);
                        if (dc == "1")
                        {
                            zqda++;
                        }
                    }
                }
                string lx = App.DataOften.GetStr(tmdt, "lx");
                if (lx == "1")
                {
                    if (dasl > 1 && zqda > 0)
                    {
                        qy = 1;
                    }
                }
                else if (lx == "2")
                {
                    if (dasl == 1)
                    {
                        qy = 1;
                    }
                }
                else
                {
                    if (dasl > 1 && zqda == 1)
                    {
                        qy = 1;
                    }
                }
                wapp.SQLiteConn.Sqllite.UP("update tmlb set sl=?, qy=? where zid=?", dasl.ToString(), qy.ToString(), tmid);
                updateQuestion(tkid);
            }
        }
    }
}
