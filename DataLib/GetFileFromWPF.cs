using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataLib.RequestModel;
using DataLib.ResponseModel;

namespace DataLib
{
    public class GetFileFromWPF
    {
        public static List<TelnumEntry> GetLinesFromWPF(string path)
        {
            var telnumModel = new List<TelnumEntry>();
            //var output = new List<CRAQueryInputModel>();
            List<string> dataList = File.ReadAllLines(path).ToList();
            if (dataList.Count <= 100)
            {
                foreach (string item in dataList.ToList())
                {
                    if (item.Length >= 12 || item.Length <= 9)
                    {
                        dataList.Remove(item);
                    }

                    else
                    {
                        if (item.Contains(' '))
                        {
                            dataList.Remove(item);
                        }
                        if (item.Length == 11)
                        {
                            telnumModel.Add(new TelnumEntry() { servicenumber = item.Substring(1, 10) });
                        }
                        else
                        {
                            telnumModel.Add(new TelnumEntry() { servicenumber = item });
                        }
                    }
                }
                
                return telnumModel;
            }
            else
            {
                return new List<TelnumEntry>() { };
            }

        }
        public static void ExtractCRAQuery(List<CRAQueryResponseModel> input,string path)
        {
            List<string> linesplit = new List<string>();
            foreach (var item in input)
            {
                linesplit.Add($"{item.requestId},{item.classifier},{item.comment},{item.response},{item.providerName},{item.result}");
            }
            File.WriteAllLines(path, linesplit);
        }
    }
}
