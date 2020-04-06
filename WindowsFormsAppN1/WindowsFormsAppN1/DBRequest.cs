using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppN1
{
    public class DBRequest
    {
        private SqlConnection SQLCon = new SqlConnection();

        public SqlDataAdapter GetAdapter(string Query)
        {
            return new SqlDataAdapter(Query, SQLCon);
        }

        public void ConnectTo(string DataSource, string InitialCatalog)
        {
            SQLCon.ConnectionString = "Integrated Security=true;" +
            "Data Source=" + DataSource + ";" +
            "Initial Catalog=" + InitialCatalog + ";" +
            "User ID=sa; Password=";
            try
            {
                SQLCon.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (SQLCon.State == ConnectionState.Open)
                {
                    SQLCon.Close();
                }
            }
            catch
            {
            }
        }

        ~DBRequest()
        {
            Disconnect();
        }

        public string GetTableFields(string TableName)
        {
            if (SQLCon.State == ConnectionState.Open)
            {
                DataTable CurTable = new DataTable("ConnectedTab");
                SqlDataAdapter SQLAdapt;
                try
                {
                    SQLAdapt = new SqlDataAdapter("SELECT * FROM " + TableName, SQLCon);
                    SQLAdapt.Fill(CurTable);
                }
                catch (Exception e)
                {
                    throw e;
                }
                string ResStr = "";
                int ColCount = CurTable.Columns.Count;
                for (int i = 0; i < ColCount; i++)
                {
                    string StrCon = ", ";
                    if (i == ColCount - 1) StrCon = ";";
                    ResStr += CurTable.Columns[i].ColumnName + "[" +
                    CurTable.Columns[i].DataType.Name + "]" + StrCon;
                }
                return ResStr;
            }
            else
                return null;
        }

        public DataTable SQLRequest(string RequestStr)
        {
            if (SQLCon.State == ConnectionState.Open)
            {
                DataTable ResultTab = new DataTable("SQLresult");
                SqlDataAdapter SQLAdapt;
                try
                {
                    SQLAdapt = new SqlDataAdapter(RequestStr, SQLCon);
                    SQLAdapt.Fill(ResultTab);
                }
                catch (Exception e)
                {
                    throw e;
                }
                return ResultTab;
            }
            else
                return null;
        }
    }
}

