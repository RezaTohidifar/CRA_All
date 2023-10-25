using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLib;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CRAwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            APIClient.ApiHelper();
            URLDictionary.URLMETHOD();
        }

        Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "NationalID", 0 },
                { "Passport", 1 },
                { "RefugeeCard", 2 }
            };

        private void CertType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private async void Query_Click(object sender, RoutedEventArgs e)
        {
            ClassifierID.Clear();
            //var dataEntry = Telnum.Text;
            CRAQueryInputModel dataEntry = new CRAQueryInputModel()
            {
                serviceNumber = "0" + Telnum.Text,
                requestId = CRASEQUENCE.SeqIDGenerator()
            };
            DBConHellper.InsertDataToPRC(new ServiceNumber() { servicenumber = dataEntry.serviceNumber });
            CRAQueryResponseModel outPutQuery 
                = await ApiCallerGeneric.CRACallerGenericAsync<CRAQueryInputModel,CRAQueryResponseModel>(dataEntry,URLDictionary.AllURL.GetValueOrDefault("Query"));

            if (outPutQuery.classifier != null)
            {
                ClassifierID.Text = outPutQuery.classifier;
            }
            else
            {
                ClassifierID.Text = outPutQuery.result;
            }
            DBConHellper.UpdateQueryDataToDB(outPutQuery);
        }

        private async void MobileCount_Click(object sender, RoutedEventArgs e)
        {
            MobileCountNum.Clear();
            
            ComboBoxItem typeItem = (ComboBoxItem)CertType.SelectedItem;
            string value = typeItem.Content.ToString();
            MobileCountModel dataEntry = new MobileCountModel() { identificationNo = CertNum.Text, identificationType = dict[value] };
            CRAMobileCountOutModel mobileCount = await ApiCallerGeneric.CRACallerGenericAsync<MobileCountModel, CRAMobileCountOutModel>(dataEntry, URLDictionary.AllURL.GetValueOrDefault("MobileCount"));
            MobileCountNum.Text = mobileCount.result;
        }

        private async void QueryMatching_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            string certNo = CertNO.Text;
            string serviceNo = "0" + ServiceNO.Text;
            ComboBoxItem typeItem = (ComboBoxItem)CertType.SelectedItem;
            string value = typeItem.Content.ToString();
            CARSERVICEMATCHINGMODEL dataEntry = new()
            { serviceNumber = serviceNo, identificationNo = certNo,identificationType =dict[value]};
            CRAServiceOutModel outPut =
                await ApiCallerGeneric.CRACallerGenericAsync<CARSERVICEMATCHINGMODEL, CRAServiceOutModel>(dataEntry, URLDictionary.AllURL.GetValueOrDefault("Matching"));
            Result.Text = outPut.result;

        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            QueryList.Items.Clear();
            BatchQueryResult.Items.Clear();
            FilePath.Text = null;
            OpenFileDialog fileOpener = new OpenFileDialog(); // create an instance of the Class
            fileOpener.DefaultExt = ".txt"; // determine the type of the file
            fileOpener.Filter = "Text Document (.txt)|*.txt"; // Filter the file name
                                                              //bool? isOk = fileOpener.ShowDialog(); // If there was any data selected, if not the value will be null
            bool? result = fileOpener.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string data = fileOpener.FileName;
                FilePath.Text = data;
                //var dataList = File.ReadAllLines(fileOpener.FileName).ToList();
                List<TelnumEntry> dataList = GetFileFromWPF.GetLinesFromWPF(fileOpener.FileName);
                foreach (var item in dataList)
                {
                    QueryList.Items.Add(item.servicenumber);
                }
            }
            
        }

        private async void QueryAllItems_Click(object sender, RoutedEventArgs e)
        {
            ItemCollection listData = QueryList.Items;
            List<CRAQueryInputModel> queryModelList = new();
            foreach (var item in listData)
            {
                queryModelList.Add(new CRAQueryInputModel() { serviceNumber = "0" + item.ToString() ,requestId = CRASEQUENCE.SeqIDGenerator()});
            }
            foreach (var query in queryModelList)
            {
                DBConHellper.InsertDataToPRC(new ServiceNumber() { servicenumber = query.serviceNumber });
                DataLib.ResponseModel.CRAQueryResponseModel outPutQuery =
                    await ApiCallerGeneric.CRACallerGenericAsync<CRAQueryInputModel, CRAQueryResponseModel>(query, URLDictionary.AllURL.GetValueOrDefault("Query"));
                DBConHellper.UpdateQueryDataToDB(outPutQuery);
                BatchQueryResult.Items.Add(JsonConvert.SerializeObject(outPutQuery.classifier));
            }
        }
    }
}
