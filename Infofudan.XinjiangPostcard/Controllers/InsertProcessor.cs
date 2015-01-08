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
        private List<FullInfo> readResultSet;
        private String filePath;
        private Dictionary<String, String> failedList;

        public InsertProcessor(String filepath)
        {
            this.filePath = filepath;
            readResultSet = new List<FullInfo>();
            failedList = new Dictionary<String, String>();
        }

        public Dictionary<String, String> InsertDataByFile()
        {

            ReadFile(filePath);
            if (readResultSet == null)
            {
                return failedList;
            }
            InsertToDatabase();
            return failedList;
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
                FullInfo fi = new FullInfo();
                try
                {
                    if (dr["编号"].ToString() != "")
                    {
                        fi.CardId = dr["编号"].ToString();
                        fi.CardContent.CardId = dr["编号"].ToString();
                        fi.CardContent.SenderName = dr["姓名"].ToString();
                        fi.CardContent.Message = dr["摘录"].ToString();

                        if (dr["景坐标"].ToString() != "")
                        {
                            fi.PhotoPlace.IsDomestic = (dr["景国内外"].ToString() == "国内");
                            fi.PhotoPlace.CityName = dr["地区(省)"].ToString();
                            fi.PhotoPlace.Detail = dr["风景地"].ToString();
                            fi.PhotoPlace.Lon = Convert.ToDouble(dr["景坐标"].ToString().Split(',')[0]);
                            fi.PhotoPlace.Lat = Convert.ToDouble(dr["景坐标"].ToString().Split(',')[1]);
                            fi.PhotoPlace.Type = 0;
                            fi.PhotoPlace.Count = 1;
                        }
                        else
                        {
                            fi.PhotoPlace = null;
                        }
                        if (dr["邮戳地"].ToString() != "")
                        {
                            fi.SenderPlace.IsDomestic = (dr["戳国内外"].ToString() == "国内");
                            fi.SenderPlace.CityName = dr["邮戳地"].ToString();
                            fi.SenderPlace.Lon = Convert.ToDouble(dr["戳坐标"].ToString().Split(',')[0]);
                            fi.SenderPlace.Lat = Convert.ToDouble(dr["戳坐标"].ToString().Split(',')[1]);
                            fi.SenderPlace.Type = 1;
                        }
                        else
                        {
                            fi.SenderPlace = null;
                        }
                        readResultSet.Add(fi);
                    }
                }
                catch (Exception e)
                {
                    if (fi != null)
                    {
                        failedList.Add(fi.CardId,e.Message);
                    }
                }
            }
        }

        private void InsertToDatabase()
        {
            PostcardRepository pr = new PostcardRepository();
            foreach (FullInfo fi in readResultSet)
            {
                try
                {
                    int senderPlaceId = pr.GetPlaceIdByName(fi.SenderPlace.CityName, 1);
                    if (senderPlaceId == -1)
                    {
                        fi.SenderPlace.Count = 0;
                        pr.InsertPlace(fi.SenderPlace);
                        fi.CardContent.SenderPlaceId = pr.GetLatestPlaceId(1);
                    }
                    else 
                    {
                        fi.CardContent.SenderPlaceId = senderPlaceId;
                    }

                    if (fi.PhotoPlace != null)
                    {
                        int photoPlaceId = pr.GetPlaceIdByName(fi.SenderPlace.CityName+fi.SenderPlace.Detail, 0);
                        if (photoPlaceId == -1)
                        {
                            fi.SenderPlace.Count = 0;
                            pr.InsertPlace(fi.PhotoPlace);
                            fi.CardContent.PhotoPlaceId = pr.GetLatestPlaceId(0);
                        }
                        else
                        {
                            fi.CardContent.PhotoPlaceId = photoPlaceId;
                        }
                    }
                    pr.InsertPostcard(fi.CardContent);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write(e.StackTrace);
                    failedList.Add(fi.CardId,e.Message);
                }
            }

        }
    }
}