using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Adapter
{
    public class clsAsset
    {
        #region Variables

        private const string _spName = "USP_Asset";

        private DBBridge ObjDBBridge = new DBBridge();

        private decimal _TID;
        private string _UniqueID;
        private string _AssetNumber;
        private string _L1CatCode;
        private string _L2CatCode;
        private string _L3CatCode;
        private string _L4CatCode;
        private string _L1LocCode;
        private string _L2LocCode;
        private string _L3LocCode;
        private string _L4LocCode;
        private string _L5LocCode;
        private string _AssetDescription;
        private string _ITC1;
        private string _ITC2;
        private string _ITC3;
        private string _LOCCODEASSET;
        private string _ROOMTYPECODE;
        private string _CODELEVEL;
        private string _Status;
        private string _DisposedOn;
        private string _DisposedBy;
        private string _VerificationStatus;
        private string _DateOfVerification;
        private string _CreatedOn;
        private string _Depreciated;
        private string _NetBookValue;
        private string _Brand;
        private string _Color;
        private string _SerialNumber;
        private string _Size;

        #endregion

        #region Public Property
        public decimal TID
        {
            get
            {
                return _TID;
            }
            set
            {
                _TID = value;
            }
        }
        public string UniqueID
        {
            get
            {
                return _UniqueID;
            }
            set
            {
                _UniqueID = value;
            }
        }
        public string AssetNumber
        {
            get
            {
                return _AssetNumber;
            }
            set
            {
                _AssetNumber = value;
            }
        }
        public string L1CatCode
        {
            get
            {
                return _L1CatCode;
            }
            set
            {
                _L1CatCode = value;
            }
        }
        public string L2CatCode
        {
            get
            {
                return _L2CatCode;
            }
            set
            {
                _L2CatCode = value;
            }
        }
        public string L3CatCode
        {
            get
            {
                return _L3CatCode;
            }
            set
            {
                _L3CatCode = value;
            }
        }
        public string L4CatCode
        {
            get
            {
                return _L4CatCode;
            }
            set
            {
                _L4CatCode = value;
            }
        }
        public string L1LocCode
        {
            get
            {
                return _L1LocCode;
            }
            set
            {
                _L1LocCode = value;
            }
        }
        public string L2LocCode
        {
            get
            {
                return _L2LocCode;
            }
            set
            {
                _L2LocCode = value;
            }
        }
        public string L3LocCode
        {
            get
            {
                return _L3LocCode;
            }
            set
            {
                _L3LocCode = value;
            }
        }
        public string L4LocCode
        {
            get
            {
                return _L4LocCode;
            }
            set
            {
                _L4LocCode = value;
            }
        }
        public string L5LocCode
        {
            get
            {
                return _L5LocCode;
            }
            set
            {
                _L5LocCode = value;
            }
        }
        public string AssetDescription
        {
            get
            {
                return _AssetDescription;
            }
            set
            {
                _AssetDescription = value;
            }
        }
        public string ITC1
        {
            get
            {
                return _ITC1;
            }
            set
            {
                _ITC1 = value;
            }
        }
        public string ITC2
        {
            get
            {
                return _ITC2;
            }
            set
            {
                _ITC2 = value;
            }
        }
        public string ITC3
        {
            get
            {
                return _ITC3;
            }
            set
            {
                _ITC3 = value;
            }
        }
        public string LOCCODEASSET
        {
            get
            {
                return _LOCCODEASSET;
            }
            set
            {
                _LOCCODEASSET = value;
            }
        }
        public string ROOMTYPECODE
        {
            get
            {
                return _ROOMTYPECODE;
            }
            set
            {
                _ROOMTYPECODE = value;
            }
        }
        public string CODELEVEL
        {
            get
            {
                return _CODELEVEL;
            }
            set
            {
                _CODELEVEL = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public string DisposedOn
        {
            get
            {
                return _DisposedOn;
            }
            set
            {
                _DisposedOn = value;
            }
        }
        public string DisposedBy
        {
            get
            {
                return _DisposedBy;
            }
            set
            {
                _DisposedBy = value;
            }
        }
        public string VerificationStatus
        {
            get
            {
                return _VerificationStatus;
            }
            set
            {
                _VerificationStatus = value;
            }
        }
        public string DateOfVerification
        {
            get
            {
                return _DateOfVerification;
            }
            set
            {
                _DateOfVerification = value;
            }
        }
        public string CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                _CreatedOn = value;
            }
        }
        public string Depreciated
        {
            get
            {
                return _Depreciated;
            }
            set
            {
                _Depreciated = value;
            }
        }
        public string NetBookValue
        {
            get
            {
                return _NetBookValue;
            }
            set
            {
                _NetBookValue = value;
            }
        }
        public string Brand
        {
            get
            {
                return _Brand;
            }
            set
            {
                _Brand = value;
            }
        }
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }
        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
            }
        }
        public string Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }

        #endregion

        #region Method
        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[31];
            param[0] = new SqlParameter("@Mode", "Insert");
            param[1] = new SqlParameter("@UniqueID", _UniqueID);
            param[2] = new SqlParameter("@AssetNumber", _AssetNumber);
            param[3] = new SqlParameter("@L1CatCode", _L1CatCode);
            param[4] = new SqlParameter("@L2CatCode", _L2CatCode);
            param[5] = new SqlParameter("@L3CatCode", _L3CatCode);
            param[6] = new SqlParameter("@L4CatCode", _L4CatCode);
            param[7] = new SqlParameter("@L1LocCode", _L1LocCode);
            param[8] = new SqlParameter("@L2LocCode", _L2LocCode);
            param[9] = new SqlParameter("@L3LocCode", _L3LocCode);
            param[10] = new SqlParameter("@L4LocCode", _L4LocCode);
            param[11] = new SqlParameter("@L5LocCode", _L5LocCode);
            param[12] = new SqlParameter("@AssetDescription", _AssetDescription);
            param[13] = new SqlParameter("@ITC1", _ITC1);
            param[14] = new SqlParameter("@ITC2", _ITC2);
            param[15] = new SqlParameter("@ITC3", _ITC3);
            param[16] = new SqlParameter("@LOCCODEASSET", _LOCCODEASSET);
            param[17] = new SqlParameter("@ROOMTYPECODE", _ROOMTYPECODE);
            param[18] = new SqlParameter("@CODELEVEL", _CODELEVEL);
            param[19] = new SqlParameter("@Status", _Status);
            param[20] = new SqlParameter("@DisposedOn", _DisposedOn);
            param[21] = new SqlParameter("@DisposedBy", _DisposedBy);
            param[22] = new SqlParameter("@VerificationStatus", _VerificationStatus);
            param[23] = new SqlParameter("@DateOfVerification", _DateOfVerification);
            param[24] = new SqlParameter("@CreatedOn", _CreatedOn);
            param[25] = new SqlParameter("@Depreciated", _Depreciated);
            param[26] = new SqlParameter("@NetBookValue", _NetBookValue);
            param[27] = new SqlParameter("@Brand", _Brand);
            param[28] = new SqlParameter("@Color", _Color);
            param[29] = new SqlParameter("@SerialNumber", _SerialNumber);
            param[30] = new SqlParameter("@Size", _Size);

            return ObjDBBridge.ExecuteNonQuery(_spName, param);

        }
        public int Update()
        {
            SqlParameter[] param = new SqlParameter[31];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@UniqueID", _UniqueID);
            param[2] = new SqlParameter("@AssetNumber", _AssetNumber);
            param[3] = new SqlParameter("@L1CatCode", _L1CatCode);
            param[4] = new SqlParameter("@L2CatCode", _L2CatCode);
            param[5] = new SqlParameter("@L3CatCode", _L3CatCode);
            param[6] = new SqlParameter("@L4CatCode", _L4CatCode);
            param[7] = new SqlParameter("@L1LocCode", _L1LocCode);
            param[8] = new SqlParameter("@L2LocCode", _L2LocCode);
            param[9] = new SqlParameter("@L3LocCode", _L3LocCode);
            param[10] = new SqlParameter("@L4LocCode", _L4LocCode);
            param[11] = new SqlParameter("@L5LocCode", _L5LocCode);
            param[12] = new SqlParameter("@AssetDescription", _AssetDescription);
            param[13] = new SqlParameter("@ITC1", _ITC1);
            param[14] = new SqlParameter("@ITC2", _ITC2);
            param[15] = new SqlParameter("@ITC3", _ITC3);
            param[16] = new SqlParameter("@LOCCODEASSET", _LOCCODEASSET);
            param[17] = new SqlParameter("@ROOMTYPECODE", _ROOMTYPECODE);
            param[18] = new SqlParameter("@CODELEVEL", _CODELEVEL);
            param[19] = new SqlParameter("@Status", _Status);
            param[20] = new SqlParameter("@DisposedOn", _DisposedOn);
            param[21] = new SqlParameter("@DisposedBy", _DisposedBy);
            param[22] = new SqlParameter("@VerificationStatus", _VerificationStatus);
            param[23] = new SqlParameter("@DateOfVerification", _DateOfVerification);
            param[24] = new SqlParameter("@CreatedOn", _CreatedOn);
            param[25] = new SqlParameter("@Depreciated", _Depreciated);
            param[26] = new SqlParameter("@NetBookValue", _NetBookValue);
            param[27] = new SqlParameter("@Brand", _Brand);
            param[28] = new SqlParameter("@Color", _Color);
            param[29] = new SqlParameter("@SerialNumber", _SerialNumber);
            param[30] = new SqlParameter("@Size", _Size);

            return ObjDBBridge.ExecuteNonQuery(_spName, param);

        }
        public void SelectById()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ViewById");
            param[1] = new SqlParameter("@AssetNumber", _AssetNumber);
            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dt.Rows.Count != 0)
            {
                DataRow dr = null;
                dr = dt.Rows[0];

                _UniqueID = dr["UniqueID"].ToString();
                _AssetNumber = dr["AssetNumber"].ToString();
                _L1CatCode = dr["L1CatCode"].ToString();
                _L2CatCode = dr["L2CatCode"].ToString();
                _L3CatCode = dr["L3CatCode"].ToString();
                _L4CatCode = dr["L4CatCode"].ToString();
                _L1LocCode = dr["L1LocCode"].ToString();
                _L2LocCode = dr["L2LocCode"].ToString();
                _L3LocCode = dr["L3LocCode"].ToString();
                _L4LocCode = dr["L4LocCode"].ToString();
                _L5LocCode = dr["L5LocCode"].ToString();
                _AssetDescription = dr["AssetDescription"].ToString();
                _ITC1 = dr["ITC1"].ToString();
                _ITC2 = dr["ITC2"].ToString();
                _ITC3 = dr["ITC3"].ToString();
                _LOCCODEASSET = dr["LOCCODEASSET"].ToString();
                _ROOMTYPECODE = dr["ROOMTYPECODE"].ToString();
                _CODELEVEL = dr["CODELEVEL"].ToString();
                _Status = dr["Status"].ToString();
                _DisposedOn = dr["DisposedOn"].ToString();
                _DisposedBy = dr["DisposedBy"].ToString();
                _VerificationStatus = dr["VerificationStatus"].ToString();
                _DateOfVerification = dr["DateOfVerification"].ToString();
                _CreatedOn = dr["CreatedOn"].ToString();
                _Depreciated = dr["Depreciated"].ToString();
                _NetBookValue = dr["NetBookValue"].ToString();
                _Brand = dr["Brand"].ToString();
                _Color = dr["Color"].ToString();
                _SerialNumber = dr["SerialNumber"].ToString();
                _Size = dr["Size"].ToString();

            }

        }
        public int GetId()
        {
            int tempGetId = 0;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "GetId");
            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dt.Rows.Count != 0)
            {
                DataRow dr = null;
                dr = dt.Rows[0];
                tempGetId = int.Parse(dr[0].ToString());
            }
            return tempGetId;
        }

        public DataTable ReportAssetReconcilationByRoom()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReportAssetReconcilationByRoom");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }

        //ASSET TAGGING MODULE START***************************************************(FOR DETAILS SEE CLSASSETTAGGING.CS)
        public DataTable GetAssetTaggingDataByLocationId()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "GetAssetTaggingDataByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);
            param[2] = new SqlParameter("@UniqueID", _UniqueID);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }

        public int UpdateAssetTaggingData()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "UpdateAssetTaggingData");
            param[1] = new SqlParameter("@TID", _TID);
            param[2] = new SqlParameter("@AssetNumber", _AssetNumber);

            return ObjDBBridge.ExecuteNonQuery(_spName, param);
        }

        //ASSET TAGGING MODULE END***************************************************(FOR DETAILS SEE CLSASSETTAGGING.CS)

        //SETUP MODULE START***************************************************
        public DataTable GetAssetsByLocationId()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetAssetsByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        public DataTable GetAllLocations()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "GetAllLocations");

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        public DataTable GetSectionsByLocationId()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetSectionsByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        public DataTable GetFloorsByLocationId()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetFloorsByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        public DataTable GetRoomsByLocationId()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetRoomsByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        public DataTable GetRoomTypesByLocationId()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetRoomTypesByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        //SETUP MODULE END***************************************************

                
        //REVERIFICATION MODULE START***************************************************
        public DataTable GetReverificationDataByLocationId()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "GetReverificationDataByLocationId");
            param[1] = new SqlParameter("@L1LocCode", _L1LocCode);
            param[2] = new SqlParameter("@UniqueID", _UniqueID);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }
        //REVERIFICATION MODULE END***************************************************
        #endregion
    }
}
