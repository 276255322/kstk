using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SQLite;

namespace App
{
    /// <summary>SQLite���ݿ������</summary>
    [Serializable]
    public class SQLiteData : IData
    {
        #region ˽������

        /// <summary>��ֵΪfalse������ӵ�����Ϊ������д���(Ĭ��ֵ��true)</summary>
        private bool _AcceptChangesDuringFill = true;

        /// <summary>��ȡ������ִ�е�SQL����洢��������ֹ��ִ������ĳ��Բ����ɴ���֮ǰ�ĵȴ�ʱ�䣬����Ϊ��λ(Ĭ��ֵ��30)</summary>
        private int _CommandTimeout = 30;

        /// <summary>��ȡ���������ݿ������ַ���(Ĭ��ֵ�����ַ���)</summary>
        private string _ConnString = "";

        /// <summary>��ȡ�����ö�Ӧ�������ݲ�����������,1 ���ַ���,2 ������Nullֵ,3 ��������Nullֵ,4 ����Nullֵ,���� �ַ���</summary>
        private List<int> _DataTypes = new List<int>();

        #endregion

        #region ��������

        /// <summary>��ֵΪfalse������ӵ�����Ϊ������д���(Ĭ��ֵ��true)</summary>
        public bool AcceptChangesDuringFill
        {
            get { return _AcceptChangesDuringFill; }
            set { _AcceptChangesDuringFill = value; }
        }

        /// <summary>��ȡ������ִ�е�SQL����洢��������ֹ��ִ������ĳ��Բ����ɴ���֮ǰ�ĵȴ�ʱ�䣬����Ϊ��λ(Ĭ��ֵ��30)</summary>
        public int CommandTimeout
        {
            get { return _CommandTimeout; }
            set { _CommandTimeout = value; }
        }

        /// <summary>��ȡ���������ݿ������ַ���(Ĭ��ֵ�����ַ���)</summary>
        public string ConnString
        {
            get { return _ConnString; }
            set { _ConnString = value; }
        }

        /// <summary>��ȡ�����ö�Ӧ�������ݲ�����������,1 ���ַ���,2 ������Nullֵ,3 ��������Nullֵ,4 ����Nullֵ,���� �ַ���</summary>
        public List<int> DataTypes
        {
            get { return _DataTypes; }
            set { _DataTypes = value; }
        }

        #endregion

        #region ������

        /// <summary>������</summary>
        public SQLiteData() { }

        #endregion

        #region ��������

        /// <summary>���Բ��������ݿ�,����true�ɹ� ����ʧ��</summary>
        /// <returns>���Բ��������ݿ�,����true�ɹ� ����ʧ��</returns>
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

        #region ����Ĭ�����ݿ������ַ�����ȡ��������ݿ�,�������飺params

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ�еĵ�һ������(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>��ȡ���ݿⲢ���ص�һ�еĵ�һ������</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⷵ�ط�ҳ������DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="setEachCount">����ÿҳ�����������</param>
        /// <param name="setDataStart">���ÿ�ʼ��������</param>
        /// <param name="pageNum">���ò����ص�ǰҳ��</param>
        /// <param name="outDataCount">������������</param>
        /// <param name="outCentCount">����ҳ������</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>��������DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="dataStart">��ʼ��������</param>
        /// <param name="cachCount">ȡ���������</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ������DataRow�����û���κ������н�����null(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>���ص�һ������DataRow</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ����������ݿⲢ���ز����ɹ�����(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>���ز����ɹ�����</returns>
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

        #region ����Ĭ�����ݿ������ַ�����ȡ��������ݿ�,�������飺List<string>

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ�еĵ�һ������(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>��ȡ���ݿⲢ���ص�һ�еĵ�һ������</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⷵ�ط�ҳ������DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="setEachCount">����ÿҳ�����������</param>
        /// <param name="setDataStart">���ÿ�ʼ��������</param>
        /// <param name="pageNum">���ò����ص�ǰҳ��</param>
        /// <param name="outDataCount">������������</param>
        /// <param name="outCentCount">����ҳ������</param>
        /// <param name="param">string����List��������</param>
        /// <returns>��������DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="dataStart">��ʼ��������</param>
        /// <param name="cachCount">ȡ���������</param>
        /// <param name="param">string����List��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ������DataRow�����û���κ������н�����null(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>���ص�һ������DataRow</returns>
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

        /// <summary>����Ĭ�����ݿ������ַ����������ݿⲢ���ز����ɹ�����(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>���ز����ɹ�����</returns>
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

        #region ָ�����ݿ������ַ�����ȡ��������ݿ�,�������飺params

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ�еĵ�һ������(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>��ȡ���ݿⲢ���ص�һ�еĵ�һ������</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⷵ�ط�ҳ������DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="setEachCount">����ÿҳ�����������</param>
        /// <param name="setDataStart">���ÿ�ʼ��������</param>
        /// <param name="pageNum">���ò����ص�ǰҳ��</param>
        /// <param name="outDataCount">������������</param>
        /// <param name="outCentCount">����ҳ������</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>��������DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="dataStart">��ʼ��������</param>
        /// <param name="cachCount">ȡ���������</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ������DataRow�����û���κ������н�����null(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>���ص�һ������DataRow</returns>
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

        /// <summary>ָ�����ݿ������ַ����������ݿⲢ���ز����ɹ�����(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>���ز����ɹ�����</returns>
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

        #region ָ�����ݿ������ַ�����ȡ��������ݿ�,�������飺List<string>

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ�еĵ�һ������(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>��ȡ���ݿⲢ���ص�һ�еĵ�һ������</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⷵ�ط�ҳ������DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="setEachCount">����ÿҳ�����������</param>
        /// <param name="setDataStart">���ÿ�ʼ��������</param>
        /// <param name="pageNum">���ò����ص�ǰҳ��</param>
        /// <param name="outDataCount">������������</param>
        /// <param name="outCentCount">����ҳ������</param>
        /// <param name="param">string����List��������</param>
        /// <returns>��������DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ����DataTable(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="dataStart">��ʼ��������</param>
        /// <param name="cachCount">ȡ���������</param>
        /// <param name="param">string����List��������</param>
        /// <returns>����DataTable</returns>
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

        /// <summary>ָ�����ݿ������ַ�����ȡ���ݿⲢ���ص�һ������DataRow�����û���κ������н�����null(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>���ص�һ������DataRow</returns>
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

        /// <summary>ָ�����ݿ������ַ����������ݿⲢ���ز����ɹ�����(string����List���鴫�ݲ���)</summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="conns">���ݿ������ַ���</param>
        /// <param name="param">string����List��������</param>
        /// <returns>���ز����ɹ�����</returns>
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

        #region ��ȡ�ڲ�SQLiteCommand

        /// <summary>����ArrayList����SQLiteCommand(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        /// <summary>����ArrayList����SQLiteCommand(string����List���鴫�ݲ���)</summary>
        /// <param name="param">string����List����</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        #region ��ȡSQLiteCommand

        /// <summary>����ArrayList����SQLiteCommand(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        /// <summary>����ArrayList����SQLiteCommand(string����List���鴫�ݲ���)</summary>
        /// <param name="param">string����List����</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        /// <summary>����ArrayList����SQLiteCommand(params�ɱ����鴫�ݲ���)</summary>
        /// <param name="dataTypes">��Ӧ�������ݲ��������������飬1 ���ַ���,2 ������Nullֵ,3 ��������Nullֵ,4 ����Nullֵ,���� �ַ���</param>
        /// <param name="param">params�ɱ��������</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        /// <summary>����ArrayList����SQLiteCommand(string����List���鴫�ݲ���)</summary>
        /// <param name="dataTypes">��Ӧ�������ݲ��������������飬1 ���ַ���,2 ������Nullֵ,3 ��������Nullֵ,4 ����Nullֵ,���� �ַ���</param>
        /// <param name="param">string����List����</param>
        /// <returns>����һ��SQLiteCommand</returns>
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

        /// <summary>����SQLiteCommand����ֵ</summary>
        /// <param name="arrayCom">SQLiteCommand����</param>
        /// <param name="dataType">���ݲ�����������</param>
        /// <param name="pName">��������</param>
        /// <param name="pValue">����ֵ</param>
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

        /// <summary>��Sql����е�?����˳���滻��@Par + i��ʽ������</summary>
        /// <param name="sql">��Ҫ�滻��Sql���</param>
        /// <returns>�������滻��ɵ�Sql���</returns>
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

