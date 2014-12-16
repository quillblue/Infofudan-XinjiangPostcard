using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infofudan.XinjiangPostcard.Models;
using System.Data.OleDb;
using System.Data;

namespace Infofudan.XinjiangPostcard.Controllers
{
    public class InsertProcessor
    {
        private List<Postcard> readResultSet;
        private String filePath;
        private List<int> failedList;

        public InsertProcessor(String filepath)
        {
            this.filePath = filepath;
            failedList = new List<int>();
        }
        
        public List<int> InsertDataByFile()
        {
            PostcardRepository pr=new PostcardRepository();
            ReadFile(filePath);
            InsertToDatabase();
            if (readResultSet == null)
            {
                return failedList;
            }
            else 
            {
                foreach(Postcard p in readResultSet){
                    int senderPlaceId = pr.GetPlaceIdByName("", 1);
                    if (senderPlaceId == 0)
                    {

                    }
                    else 
                    {

                    }
                }
                return failedList;
            }
        }

        private void ReadFile(String filePath) 
        {
            DataSet workListDataset = new DataSet();
            String sConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filePath + ";Extended Properties='Excel 8.0; HDR=yes; IMEX=0'"; ;
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter();
            objAdapter.SelectCommand = objCmdSelect;
            objAdapter.Fill(workListDataset);
            for (int i = 0; i < workListDataset.Tables[0].Rows.Count; i++)
            {
                DataRow dr = workListDataset.Tables[0].Rows[i];
                try
                {
                    if (dr["乘车日期"].ToString() != "")
                    {

                    }
                    else
                    {

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    failedList.Add(i + 1);
                }
            }
        }

        private void InsertToDatabase()
        {
            
        }
    }
}