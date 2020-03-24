using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SQLite;

namespace App
{
    /// <summary>SQLite数据库操作类</summary>
    [Serializable]
    public class SQLiteData : IData
    {
        #region 私有属性

        /// <summary>该值为false则将新添加的行作为插入的行处理。(默认值：true)</summary>
        private bool _AcceptChangesDuringFill = true;

        /// <summary>获取或设置执行的SQL语句或存储过程在终止对执行命令的尝试并生成错误之前的等待时间，以秒为单位(默认值：30)</summary>
        private int _CommandTimeout = 30;

        /// <summary>获取或设置数据库连接字符串(默认值：空字符串)</summary>
        private string _ConnString = "";

        /// <summary>获取或设置对应索引数据参数操作类型,1 长字符串,2 日期型Null值,3 长整数型Null值,4 浮点Null值,其它 字符型</summary>
        private List<int> _DataTypes = new List<int>();

        #endregion

        #region 公共属性

        /// <summary>该值为false则将新添加的行作为插入的行处理。(默认值：true)</summary>
        public bool AcceptChangesDuringFill
        {
            get { return _AcceptChangesDuringFill; }
            set { _AcceptChangesDuringFill = value; }
        }

        /// <summary>获取或设置执行的SQL语句或存储过程在终止对执行命令的尝试并生成错误之前的等待时间，以秒为单位(默认值：30)</summary>
        public int CommandTimeout
        {
            get { return _CommandTimeout; }
            set { _CommandTimeout = value; }
        }

        /// <summary>获取或设置数据库连接字符串(默认值：空字符串)</summary>
        public string ConnString
        {
            get { return _ConnString; }
            set { _ConnString = value; }
        }

        /// <summary>获取或设置对应索引数据参数操作类型,1 长字符串,2 日期型Null值,3 长整数型Null值,4 浮点Null值,其它 字符型</summary>
        public List<int> DataTypes
        {
            get { return _DataTypes; }
            set { _DataTypes = value; }
        }

        #endregion

        #region 构造类

        /// <summary>构造类</summary>
        public SQLiteData() { }

        #endregion

        #region 公共方法

        /// <summary>测试并连接数据库,返回true成功 否则失败</summary>
        /// <returns>测试并连接数据库,返回true成功 否则失败</returns>
        public bool ConnTest()
        {
            bool IsCan = false;
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            try
            {
                conn.Open();
                IsCan = true;
            }
            catch
            {
                IsCan = false;
            }
            finally
            {
                conn.Close();
            }
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                return IsCan;
            }
            else
            {
                return IsCan;
            }
        }

        #region 根据默认数据库连接字符串获取或更新数据库,参数数组：params

        /// <summary>根据默认数据库连接字符串读取数据库并返回第一列的第一个参数(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>读取数据库并返回第一列的第一个参数</returns>
        public string GetES(string sql, params string[] param)
        {
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            string str = conncmd.ExecuteScalar() + "";
            conn.Close();
            return str;
        }

        /// <summary>根据默认数据库连接字符串读取数据库返回分页和数据DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="setEachCount">设置每页最大数据行数</param>
        /// <param name="setDataStart">设置开始数据行数</param>
        /// <param name="pageNum">设置并返回当前页码</param>
        /// <param name="outDataCount">返回数据总数</param>
        /// <param name="outCentCount">返回页面总数</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回数据DataTable</returns>
        public DataTable GetDT(string sql, int setEachCount, int setDataStart, ref int pageNum, ref int outDataCount, ref int outCentCount, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            outDataCount = dt.Rows.Count;
            outCentCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(outDataCount) / setEachCount));
            if (outCentCount < 1)
            {
                outCentCount = 1;
            }
            if (pageNum > outCentCount)
            {
                pageNum = outCentCount;
            }
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            int stat = setEachCount * (pageNum - 1) + (setDataStart - 1);
            DataTable dtClone = dt.Clone();
            for (int i = 0; i < setEachCount; i++)
            {
                if (stat >= outDataCount)
                {
                    break;
                }
                dtClone.Rows.Add(dt.Rows[stat].ItemArray);
                stat += 1;
            }
            return dtClone;
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDT(string sql, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="dataStart">开始的行索引</param>
        /// <param name="cachCount">取的最大行数</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDT(string sql, int dataStart, int cachCount, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            DataSet dt = new DataSet();
            cadapter.Fill(dt, dataStart, cachCount, "DataFrom");
            conn.Close();
            return dt.Tables["DataFrom"];
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回第一行数据DataRow，如果没有任何数据行将返回null(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回第一行数据DataRow</returns>
        public DataRow GetRow(string sql, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>根据默认数据库连接字符串更新数据库并返回操作成功行数(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回操作成功行数</returns>
        public int UP(string sql, params string[] param)
        {
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            int getint = conncmd.ExecuteNonQuery();
            conn.Close();
            return getint;
        }

        #endregion

        #region 根据默认数据库连接字符串获取或更新数据库,参数数组：List<string>

        /// <summary>根据默认数据库连接字符串读取数据库并返回第一列的第一个参数(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>读取数据库并返回第一列的第一个参数</returns>
        public string GetES(string sql, List<string> param)
        {
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            string str = conncmd.ExecuteScalar() + "";
            conn.Close();
            return str;
        }

        /// <summary>根据默认数据库连接字符串读取数据库返回分页和数据DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="setEachCount">设置每页最大数据行数</param>
        /// <param name="setDataStart">设置开始数据行数</param>
        /// <param name="pageNum">设置并返回当前页码</param>
        /// <param name="outDataCount">返回数据总数</param>
        /// <param name="outCentCount">返回页面总数</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回数据DataTable</returns>
        public DataTable GetDT(string sql, int setEachCount, int setDataStart, ref int pageNum, ref int outDataCount, ref int outCentCount, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            outDataCount = dt.Rows.Count;
            outCentCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(outDataCount) / setEachCount));
            if (outCentCount < 1)
            {
                outCentCount = 1;
            }
            if (pageNum > outCentCount)
            {
                pageNum = outCentCount;
            }
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            int stat = setEachCount * (pageNum - 1) + (setDataStart - 1);
            DataTable dtClone = dt.Clone();
            for (int i = 0; i < setEachCount; i++)
            {
                if (stat >= outDataCount)
                {
                    break;
                }
                dtClone.Rows.Add(dt.Rows[stat].ItemArray);
                stat += 1;
            }
            return dtClone;
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDT(string sql, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="dataStart">开始的行索引</param>
        /// <param name="cachCount">取的最大行数</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDT(string sql, int dataStart, int cachCount, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            DataSet dt = new DataSet();
            cadapter.Fill(dt, dataStart, cachCount, "DataFrom");
            conn.Close();
            return dt.Tables["DataFrom"];
        }

        /// <summary>根据默认数据库连接字符串读取数据库并返回第一行数据DataRow，如果没有任何数据行将返回null(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回第一行数据DataRow</returns>
        public DataRow GetRow(string sql, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>根据默认数据库连接字符串更新数据库并返回操作成功行数(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回操作成功行数</returns>
        public int UP(string sql, List<string> param)
        {
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(_ConnString);
            conn.Open();
            conncmd.Connection = conn;
            int getint = conncmd.ExecuteNonQuery();
            conn.Close();
            return getint;
        }

        #endregion

        #region 指定数据库连接字符串获取或更新数据库,参数数组：params

        /// <summary>指定数据库连接字符串读取数据库并返回第一列的第一个参数(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>读取数据库并返回第一列的第一个参数</returns>
        public string GetESConns(string sql, string conns, params string[] param)
        {
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            string str = conncmd.ExecuteScalar() + "";
            conn.Close();
            return str;
        }

        /// <summary>指定数据库连接字符串读取数据库返回分页和数据DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="setEachCount">设置每页最大数据行数</param>
        /// <param name="setDataStart">设置开始数据行数</param>
        /// <param name="pageNum">设置并返回当前页码</param>
        /// <param name="outDataCount">返回数据总数</param>
        /// <param name="outCentCount">返回页面总数</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回数据DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, int setEachCount, int setDataStart, ref int pageNum, ref int outDataCount, ref int outCentCount, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            outDataCount = dt.Rows.Count;
            outCentCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(outDataCount) / setEachCount));
            if (outCentCount < 1)
            {
                outCentCount = 1;
            }
            if (pageNum > outCentCount)
            {
                pageNum = outCentCount;
            }
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            int stat = setEachCount * (pageNum - 1) + (setDataStart - 1);
            DataTable dtClone = dt.Clone();
            for (int i = 0; i < setEachCount; i++)
            {
                if (stat >= outDataCount)
                {
                    break;
                }
                dtClone.Rows.Add(dt.Rows[stat].ItemArray);
                stat += 1;
            }
            return dtClone;
        }

        /// <summary>指定数据库连接字符串读取数据库并返回DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>指定数据库连接字符串读取数据库并返回DataTable(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="dataStart">开始的行索引</param>
        /// <param name="cachCount">取的最大行数</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, int dataStart, int cachCount, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            DataSet dt = new DataSet();
            cadapter.Fill(dt, dataStart, cachCount, "DataFrom");
            conn.Close();
            return dt.Tables["DataFrom"];
        }

        /// <summary>指定数据库连接字符串读取数据库并返回第一行数据DataRow，如果没有任何数据行将返回null(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回第一行数据DataRow</returns>
        public DataRow GetRowConns(string sql, string conns, params string[] param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComPar(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>指定数据库连接字符串更新数据库并返回操作成功行数(params可变数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回操作成功行数</returns>
        public int UPConns(string sql, string conns, params string[] param)
        {
            SQLiteCommand conncmd = GetSqlComPar(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            int getint = conncmd.ExecuteNonQuery();
            conn.Close();
            return getint;
        }

        #endregion

        #region 指定数据库连接字符串获取或更新数据库,参数数组：List<string>

        /// <summary>指定数据库连接字符串读取数据库并返回第一列的第一个参数(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>读取数据库并返回第一列的第一个参数</returns>
        public string GetESConns(string sql, string conns, List<string> param)
        {
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            string str = conncmd.ExecuteScalar() + "";
            conn.Close();
            return str;
        }

        /// <summary>指定数据库连接字符串读取数据库返回分页和数据DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="setEachCount">设置每页最大数据行数</param>
        /// <param name="setDataStart">设置开始数据行数</param>
        /// <param name="pageNum">设置并返回当前页码</param>
        /// <param name="outDataCount">返回数据总数</param>
        /// <param name="outCentCount">返回页面总数</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回数据DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, int setEachCount, int setDataStart, ref int pageNum, ref int outDataCount, ref int outCentCount, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            outDataCount = dt.Rows.Count;
            outCentCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(outDataCount) / setEachCount));
            if (outCentCount < 1)
            {
                outCentCount = 1;
            }
            if (pageNum > outCentCount)
            {
                pageNum = outCentCount;
            }
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            int stat = setEachCount * (pageNum - 1) + (setDataStart - 1);
            DataTable dtClone = dt.Clone();
            for (int i = 0; i < setEachCount; i++)
            {
                if (stat >= outDataCount)
                {
                    break;
                }
                dtClone.Rows.Add(dt.Rows[stat].ItemArray);
                stat += 1;
            }
            return dtClone;
        }

        /// <summary>指定数据库连接字符串读取数据库并返回DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>指定数据库连接字符串读取数据库并返回DataTable(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="dataStart">开始的行索引</param>
        /// <param name="cachCount">取的最大行数</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDTConns(string sql, string conns, int dataStart, int cachCount, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            DataSet dt = new DataSet();
            cadapter.Fill(dt, dataStart, cachCount, "DataFrom");
            conn.Close();
            return dt.Tables["DataFrom"];
        }

        /// <summary>指定数据库连接字符串读取数据库并返回第一行数据DataRow，如果没有任何数据行将返回null(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回第一行数据DataRow</returns>
        public DataRow GetRowConns(string sql, string conns, List<string> param)
        {
            SQLiteDataAdapter cadapter = new SQLiteDataAdapter();
            cadapter.AcceptChangesDuringFill = _AcceptChangesDuringFill;
            SQLiteCommand conncmd = GetSqlComArr(param);
            DataTable dt = new DataTable();
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            conncmd.CommandTimeout = _CommandTimeout;
            cadapter.SelectCommand = conncmd;
            cadapter.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>指定数据库连接字符串更新数据库并返回操作成功行数(string类型List数组传递参数)</summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="conns">数据库连接字符串</param>
        /// <param name="param">string类型List参数数组</param>
        /// <returns>返回操作成功行数</returns>
        public int UPConns(string sql, string conns, List<string> param)
        {
            SQLiteCommand conncmd = GetSqlComArr(param);
            conncmd.CommandText = GetSqlFormat(sql);
            SQLiteConnection conn = new SQLiteConnection(conns);
            conn.Open();
            conncmd.Connection = conn;
            int getint = conncmd.ExecuteNonQuery();
            conn.Close();
            return getint;
        }

        #endregion

        #region 获取内部SQLiteCommand

        /// <summary>根据ArrayList返回SQLiteCommand(params可变数组传递参数)</summary>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public SQLiteCommand GetSqlComPar(params string[] param)
        {
            if (_DataTypes.Count == 0)
            {
                return GetSqlParCom(param);
            }
            else
            {
                return GetSqlParCom(_DataTypes, param);
            }
        }

        /// <summary>根据ArrayList返回SQLiteCommand(string类型List数组传递参数)</summary>
        /// <param name="param">string类型List数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public SQLiteCommand GetSqlComArr(List<string> param)
        {
            if (_DataTypes.Count == 0)
            {
                return GetSqlArrCom(param);
            }
            else
            {
                return GetSqlArrCom(_DataTypes, param);
            }
        }

        #endregion

        #region 获取SQLiteCommand

        /// <summary>根据ArrayList返回SQLiteCommand(params可变数组传递参数)</summary>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public static SQLiteCommand GetSqlParCom(params string[] param)
        {
            SQLiteCommand ArrayCom = new SQLiteCommand();
            if (param == null)
            {
                return ArrayCom;
            }
            for (int i = 0; i < param.Length; i++)
            {
                ArrayCom.Parameters.Add(new SQLiteParameter("@Par" + i, param[i]));
            }
            return ArrayCom;
        }

        /// <summary>根据ArrayList返回SQLiteCommand(string类型List数组传递参数)</summary>
        /// <param name="param">string类型List数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public static SQLiteCommand GetSqlArrCom(List<string> param)
        {
            SQLiteCommand ArrayCom = new SQLiteCommand();
            if (param == null)
            {
                return ArrayCom;
            }
            for (int i = 0; i < param.Count; i++)
            {
                ArrayCom.Parameters.Add(new SQLiteParameter("@Par" + i, param[i]));
            }
            return ArrayCom;
        }

        /// <summary>根据ArrayList返回SQLiteCommand(params可变数组传递参数)</summary>
        /// <param name="dataTypes">对应索引数据参数操作类型数组，1 长字符串,2 日期型Null值,3 长整数型Null值,4 浮点Null值,其它 字符型</param>
        /// <param name="param">params可变参数数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public static SQLiteCommand GetSqlParCom(List<int> dataTypes, params string[] param)
        {
            SQLiteCommand ArrayCom = new SQLiteCommand();
            if (param == null)
            {
                return ArrayCom;
            }
            for (int i = 0; i < param.Length; i++)
            {
                ParametersAdd(ref ArrayCom, DataOften.GetIntListVal(dataTypes, i), "@Par" + i, param[i]);
            }
            return ArrayCom;
        }

        /// <summary>根据ArrayList返回SQLiteCommand(string类型List数组传递参数)</summary>
        /// <param name="dataTypes">对应索引数据参数操作类型数组，1 长字符串,2 日期型Null值,3 长整数型Null值,4 浮点Null值,其它 字符型</param>
        /// <param name="param">string类型List数组</param>
        /// <returns>返回一个SQLiteCommand</returns>
        public static SQLiteCommand GetSqlArrCom(List<int> dataTypes, List<string> param)
        {
            SQLiteCommand ArrayCom = new SQLiteCommand();
            if (param == null)
            {
                return ArrayCom;
            }
            for (int i = 0; i < param.Count; i++)
            {
                ParametersAdd(ref ArrayCom, DataOften.GetIntListVal(dataTypes, i), "@Par" + i, param[i]);
            }
            return ArrayCom;
        }

        /// <summary>设置SQLiteCommand参数值</summary>
        /// <param name="arrayCom">SQLiteCommand对象</param>
        /// <param name="dataType">数据参数操作类型</param>
        /// <param name="pName">参数名称</param>
        /// <param name="pValue">参数值</param>
        public static void ParametersAdd(ref SQLiteCommand arrayCom, int dataType, string pName, string pValue)
        {
            if (dataType == 1 && pValue.Length > 0)
            {
                arrayCom.Parameters.Add(pName, DbType.String, 99999999).Value = pValue;
            }
            else if (dataType == 2)
            {
                arrayCom.Parameters.Add(pName, DbType.DateTime).Value = System.DBNull.Value;
            }
            else if (dataType == 3)
            {
                arrayCom.Parameters.Add(pName, DbType.Int64).Value = System.DBNull.Value;
            }
            else if (dataType == 4)
            {
                arrayCom.Parameters.Add(pName, DbType.Decimal).Value = System.DBNull.Value;
            }
            else
            {
                arrayCom.Parameters.Add(new SQLiteParameter(pName, pValue));
            }
        }

        /// <summary>将Sql语句中的?按照顺序替换成@Par + i格式并返回</summary>
        /// <param name="sql">需要替换的Sql语句</param>
        /// <returns>返回已替换完成的Sql语句</returns>
        public static string GetSqlFormat(string sql)
        {
            if (sql.IndexOf('?') == -1)
            {
                return sql;
            }
            int index = 0;
            int i = 0;
            StringBuilder sb = new StringBuilder(sql);
            index = sb.ToString().IndexOf('?');
            while (index > -1)
            {
                sb.Replace("?", "@Par" + i, index, 1);
                i++;
                index = sb.ToString().IndexOf('?');
            }
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}

