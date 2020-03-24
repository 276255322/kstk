using App;
using App.Web;
using App.Win;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wapp
{
    public class AppPub
    {
        /// <summary>设置列表值委托</summary>
        public delegate void DelegateSetListViewValue(int row, string val);

        public static string QuestionTemplateFile = ConfigurationManager.AppSettings["QuestionTemplate"];

        public static string getQuestionTemplatePath()
        {
            return SQLiteConn.basePath + "\\" + QuestionTemplateFile;
        }

        /// <summary>返回当前程序运行路径</summary>
        /// <returns>返回当前程序运行路径</returns>
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8); // 8是 file:// 的长度   
            string[] arrSection = _CodeBase.Split(new char[] { '/' });
            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "\\";
            }
            return _FolderPath;
        }

        /// <summary>文本窗显示委托方法</summary>
        /// <param name="myControl">文本对象</param>
        /// <param name="color">文本颜色(列子：#ff0000)</param>
        /// <param name="myCaption">需要插入的文本</param>
        /// <param name="isqc">是否清空文本对象true 是 false 否</param>
        /// <param name="blxx">基础文本</param>
        public static void RTB(RichTextBox myControl, string color, string myCaption, bool isqc, string blxx)
        {
            if (isqc)
            {
                myControl.Text = "";
                myControl.SelectionColor = ColorTranslator.FromHtml(color);
                myControl.AppendText(blxx);
            }
            myControl.SelectionColor = ColorTranslator.FromHtml(color);
            myControl.AppendText(myCaption);
            myControl.ScrollToCaret();
        }

        /// <summary>文本显示委托方法</summary>
        /// <param name="myLabel">文本对象</param>
        /// <param name="myCaption">需要显示的文本</param>
        public static void LB(Label myLabel, string myCaption)
        {
            myLabel.Text = myCaption;
        }

        /// <summary>返回object数组</summary>
        /// <param name="objs">object数组</param>
        public static object[] GetArray(params object[] objs)
        {
            return objs;
        }


        /// <summary>自动调整图片控件大小</summary>
        /// <param name="pic">图片控件</param>
        /// <param name="pan">图片空间容器</param>
        public static void AutoPictureBoxSize(PictureBox pic, Panel pan)
        {
            if (pic.Image != null)
            {
                try
                {
                    System.Drawing.Image imfile = pic.Image;
                    int imsw = pan.Width - 1;
                    int imsh = pan.Height - 1;
                    int plx = pan.Width / 2;
                    int ply = pan.Height / 2;
                    Often.AutoSizeNarrow(ref imsw, ref imsh, imfile.Size.Width, imfile.Size.Height);
                    pic.Width = imsw;
                    pic.Height = imsh;
                    pic.Top = ply - (pic.Height / 2);
                    pic.Left = plx - (pic.Width / 2);
                }
                catch
                {
                }
            }
        }

        /// <summary>设置时分秒组合框列表内容</summary>
        /// <param name="cbs">时组合框</param>
        /// <param name="cbf">分组合框</param>
        /// <param name="cbm">秒组合框</param>
        /// <param name="tst">秒分秒字符串</param>
        public static void SetTimeComboBox(ComboBox cbs, ComboBox cbf, ComboBox cbm, string tst)
        {
            bool istst = false;
            if (tst != "")
            {
                string[] tarr = tst.Split(':');
                if (tarr.Length == 3)
                {
                    string s = tarr[0].Trim();
                    string f = tarr[1].Trim();
                    string m = tarr[2].Trim();
                    if (Often.IsInt32(s) && Often.IsInt32(f) && Often.IsInt32(m))
                    {
                        App.Win.Utils.SetComboBoxItems(cbs, AppList.Hour(), s);
                        App.Win.Utils.SetComboBoxItems(cbf, AppList.Minute(), f);
                        App.Win.Utils.SetComboBoxItems(cbm, AppList.Minute(), m);
                        istst = true;
                    }
                }
            }
            if (!istst)
            {
                App.Win.Utils.SetComboBoxItems(cbs, AppList.Hour(), "0");
                App.Win.Utils.SetComboBoxItems(cbf, AppList.Minute(), "0");
                App.Win.Utils.SetComboBoxItems(cbm, AppList.Minute(), "0");
            }
        }

        /// <summary>返回时分秒组合框时间字符串</summary>
        /// <param name="cbs">时组合框</param>
        /// <param name="cbf">分组合框</param>
        /// <param name="cbm">秒组合框</param>
        /// <returns>返回时分秒组合框时间字符串</returns>
        public static string GetTimeComboBox(ComboBox cbs, ComboBox cbf, ComboBox cbm)
        {
            string s = App.Win.Utils.GetComboBoxValue(cbs);
            string f = App.Win.Utils.GetComboBoxValue(cbf);
            string m = App.Win.Utils.GetComboBoxValue(cbm);
            return s + ":" + f + ":" + m;
        }

        /// <summary>根据时间返回日期</summary>
        /// <param name="dTime">指定日期</param>
        /// <param name="hour">小时数</param>
        /// <returns>根据时间返回日期</returns>
        public static DateTime GetRandomTime(DateTime dTime, int hour)
        {
            Random random = new Random(Often.Seed);
            int minute = random.Next(20, 59);
            int second = random.Next(0, 59);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} " + hour.ToString() + ":" + minute.ToString() + ":" + second.ToString(), dTime));
        }

        /// <summary>根据url或本地路径返回图片对象</summary>
        /// <param name="path">url或本地路径</param>
        /// <returns>根据url或本地路径返回图片对象</returns>
        public static Image GetImage(string path)
        {
            try
            {
                if (Often.IsUrl(path))
                {
                    Uri uri = new Uri(path);
                    WebRequest req = WebRequest.Create(uri);
                    WebResponse resp = req.GetResponse();
                    Stream str = resp.GetResponseStream();
                    Image img = Image.FromStream(str);
                    return img;
                }
                else if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    return img;
                }
            }
            catch
            {

            }
            return null;
        }

        /// <summary>在ListView添加Button并设置居中显示</summary>
        /// <param name="lv">ListView</param>
        /// <param name="bt">Button</param>
        /// <param name="bttext">Button文字</param>
        /// <param name="btw">Button宽度</param>
        /// <param name="bth">Button高度</param>
        /// <param name="rindex">ListView的行号</param>
        /// <param name="cindex">ListView的列号</param>
        public static void SetListViewButtonCenter(ListView lv, Button bt, string bttext, int btw, int bth, int rindex, int cindex)
        {
            bt.Text = bttext;
            Label bl = new Label();
            bl.Visible = false;
            bl.Text = rindex.ToString();
            bt.Controls.Add(bl);
            bt.Size = new Size(btw, bth);
            int lw = lv.Items[rindex].SubItems[cindex].Bounds.Width;
            int lh = lv.Items[rindex].SubItems[cindex].Bounds.Height;
            int x = lv.Items[rindex].SubItems[cindex].Bounds.Left + (int)((lw - btw) / 2);
            int y = lv.Items[rindex].SubItems[cindex].Bounds.Top + (int)((lh - bth) / 2);
            bt.Location = new Point(x, y);
        }

    }
}
