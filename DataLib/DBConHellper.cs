using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using DataLib.RequestModel.DataLib;

namespace DataLib
{
    public class DBConHellper : IDBConHellper
    {
        public static List<CRAPUTMODEL> QueryCustomerInfo()
        {
            //var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(DBClient.DBclient("CRMDB")))
            {
                var outPut = new List<CRAPUTMODEL>();
                var putQueryResult = connection.Query<CRAPUTFLAT>($"select * from bhu_tohidifar.tbl_CRA_Project_entry a where a.filled=1").ToList();
                foreach (var item in putQueryResult)
                {
                    outPut.Add(new CRAPUTMODEL()
                    {
                        requestId = item.requestId,
                        resellerCode = item.resellerCode,
                        identificationType = item.identificationType,
                        identificationNo = item.identificationNo,
                        certificateNo = item.certificateNo,
                        birthDate = item.birthDate.Replace("/", string.Empty),
                        name = item.name,
                        family = item.family,
                        fatherName = item.fatherName,
                        gender = item.gender,
                        birthPlace = item.birthPlace,
                        mobile = item.mobile,
                        email = item.email,
                        person = item.person,
                        iranian = item.iranian,
                        isUnderLegalAge = item.isUnderLegalAge,
                        address = new Address()
                        {
                            provinceName = item.provinceName,
                            townshipName = item.townshipName,
                            address = item.address,
                            street2 = item.street2,
                            houseNumber = item.houseNumber,
                            postalCode = item.postalCode,
                            tel = item.tel
                        },
                        service = new Service()
                        {
                            type = item.type,
                            mobileNumber = "0" + item.mobileNumber,
                            mobileType = item.mobileType,
                            dataSim = item.dataSim,
                            serial = item.serial,
                            sms = item.sms,
                            gprs = item.gprs,
                            mms = item.mms,
                            wap = item.wap,
                            threeG = item.threeG,
                            fourG = item.fourG,
                            videoCall = item.videoCall,
                            ipStatic = item.ipStatic,
                            province = item.province,
                            networkName = item.networkName,
                            apn = item.apn,
                            privateNumber = item.privateNumber,
                            privateNumberDetection = item.privateNumberDetection
                        }
                    });
                }
                return outPut;
            }
        }
        public static void InsertDataToPRC(ServiceNumber serviceNumber)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_CRA_PRJADD", serviceNumber, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<ServiceNumber> QueryDataToPRC()
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                var QueryResult = connection.Query<ServiceNumber>($"select * from bhu_tohidifar.tbl_CRA_addlist a where a.state=1").ToList();
                return QueryResult;
            }
        }

        public static void UpdateQueryDataToDB(CRAQueryResponseModel cRAQueryResponseModel)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_CRA_UpdateQuery", cRAQueryResponseModel, commandType: CommandType.StoredProcedure);
            }
        }

        public static void InsertCloseRequestToDB(CRACLOSEINPUTMODEL cRACLOSEINPUTMODEL)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_CRA_DELETEREQUEST", cRACLOSEINPUTMODEL, commandType: CommandType.StoredProcedure);
            }
        }

        public static void InsertCloseResponseToDB(CRACLOSEOUTMODEL cRACLOSEOUTMODEL)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_CRA_DELETERESULT", cRACLOSEOUTMODEL, commandType: CommandType.StoredProcedure);
            }
        }

        public static void InsertPutResponseToDB(CRAPUTOUTMODEL cRAPUTOUTMODEL)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_PUT_RESPONSE", cRAPUTOUTMODEL, commandType: CommandType.StoredProcedure);
            }
        }

        public void LogDBForAll(DBLOG dBLOG)
        {
            //var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.7.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=crmdb)));User Id=bhu_tohidifar;Password=pass#1402;";
            using (IDbConnection connection = new OracleConnection(DBClient.DBclient("CRMDB")))
            {
                connection.Execute("BHU_TOHIDIFAR.PRC_DB_LOG", dBLOG, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
