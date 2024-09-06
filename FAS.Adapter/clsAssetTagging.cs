using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Adapter
{
    public class clsAssetTagging
    {
        #region Variables

        private const string _spName = "USP_AssetTagging";

        private DBBridge ObjDBBridge = new DBBridge();

        private decimal _TID;
        private string _UniqueID;
        private string _AssetNumber;
        private string _AssetDescription;
        private string _Status;
        private string _category_code;
        private string _group_code;
        private string _location_code;
        private string _section_code;
        private string _room_code;
        private string _room_type;
        private string _floor_code;
        private string _location_name;
        private string _section_name;
        private string _Room_name;
        private string _Room_type_name;
        private string _floor_name;
        private System.DateTime _CreatedOn;
        private string _CreatedBy;
        private System.DateTime _UpdatedOn;
        private string _UpdatedBy;
        private bool _IsDelete;
        private string _L3CatCode;
        private string _L4CatCode;
        private int _Sequence;
        private int _ColorType;

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

        public string category_code
        {
            get
            {
                return _category_code;
            }
            set
            {
                _category_code = value;
            }
        }

        public string group_code
        {
            get
            {
                return _group_code;
            }
            set
            {
                _group_code = value;
            }
        }

        public string location_code
        {
            get
            {
                return _location_code;
            }
            set
            {
                _location_code = value;
            }
        }

        public string section_code
        {
            get
            {
                return _section_code;
            }
            set
            {
                _section_code = value;
            }
        }

        public string room_code
        {
            get
            {
                return _room_code;
            }
            set
            {
                _room_code = value;
            }
        }

        public string room_type
        {
            get
            {
                return _room_type;
            }
            set
            {
                _room_type = value;
            }
        }

        public string floor_code
        {
            get
            {
                return _floor_code;
            }
            set
            {
                _floor_code = value;
            }
        }

        public string location_name
        {
            get
            {
                return _location_name;
            }
            set
            {
                _location_name = value;
            }
        }

        public string section_name
        {
            get
            {
                return _section_name;
            }
            set
            {
                _section_name = value;
            }
        }

        public string Room_name
        {
            get
            {
                return _Room_name;
            }
            set
            {
                _Room_name = value;
            }
        }

        public string Room_type_name
        {
            get
            {
                return _Room_type_name;
            }
            set
            {
                _Room_type_name = value;
            }
        }

        public string floor_name
        {
            get
            {
                return _floor_name;
            }
            set
            {
                _floor_name = value;
            }
        }

        public System.DateTime CreatedOn
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

        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        public System.DateTime UpdatedOn
        {
            get
            {
                return _UpdatedOn;
            }
            set
            {
                _UpdatedOn = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return _UpdatedBy;
            }
            set
            {
                _UpdatedBy = value;
            }
        }

        public bool IsDelete
        {
            get
            {
                return _IsDelete;
            }
            set
            {
                _IsDelete = value;
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

        public int Sequence
        {
            get
            {
                return _Sequence;
            }
            set
            {
                _Sequence = value;
            }
        }

        public int ColorType
        {
            get
            {
                return _ColorType;
            }
            set
            {
                _ColorType = value;
            }
        }


        #endregion

        #region Method
        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[27];
            param[0] = new SqlParameter("@Mode", "Insert");
            param[1] = new SqlParameter("@TID", _TID);
            param[2] = new SqlParameter("@UniqueID", _UniqueID);
            param[3] = new SqlParameter("@AssetNumber", _AssetNumber);
            param[4] = new SqlParameter("@AssetDescription", _AssetDescription);
            param[5] = new SqlParameter("@Status", _Status);
            param[6] = new SqlParameter("@category_code", _category_code);
            param[7] = new SqlParameter("@group_code", _group_code);
            param[8] = new SqlParameter("@location_code", _location_code);
            param[9] = new SqlParameter("@section_code", _section_code);
            param[10] = new SqlParameter("@room_code", _room_code);
            param[11] = new SqlParameter("@room_type", _room_type);
            param[12] = new SqlParameter("@floor_code", _floor_code);
            param[13] = new SqlParameter("@location_name", _location_name);
            param[14] = new SqlParameter("@section_name", _section_name);
            param[15] = new SqlParameter("@Room_name", _Room_name);
            param[16] = new SqlParameter("@Room_type_name", _Room_type_name);
            param[17] = new SqlParameter("@floor_name", _floor_name);
            param[18] = new SqlParameter("@CreatedOn", _CreatedOn);
            param[19] = new SqlParameter("@CreatedBy", _CreatedBy);
            param[20] = new SqlParameter("@UpdatedOn", _UpdatedOn);
            param[21] = new SqlParameter("@UpdatedBy", _UpdatedBy);
            param[22] = new SqlParameter("@IsDelete", _IsDelete);
            param[23] = new SqlParameter("@L3CatCode", _L3CatCode);
            param[24] = new SqlParameter("@L4CatCode", _L4CatCode);
            param[25] = new SqlParameter("@Sequence", _Sequence);
            param[26] = new SqlParameter("@ColorType", _ColorType);

            return ObjDBBridge.ExecuteNonQuery(_spName, param);

        }

        public int Update()
        {
            SqlParameter[] param = new SqlParameter[27];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@TID", _TID);
            param[2] = new SqlParameter("@UniqueID", _UniqueID);
            param[3] = new SqlParameter("@AssetNumber", _AssetNumber);
            param[4] = new SqlParameter("@AssetDescription", _AssetDescription);
            param[5] = new SqlParameter("@Status", _Status);
            param[6] = new SqlParameter("@category_code", _category_code);
            param[7] = new SqlParameter("@group_code", _group_code);
            param[8] = new SqlParameter("@location_code", _location_code);
            param[9] = new SqlParameter("@section_code", _section_code);
            param[10] = new SqlParameter("@room_code", _room_code);
            param[11] = new SqlParameter("@room_type", _room_type);
            param[12] = new SqlParameter("@floor_code", _floor_code);
            param[13] = new SqlParameter("@location_name", _location_name);
            param[14] = new SqlParameter("@section_name", _section_name);
            param[15] = new SqlParameter("@Room_name", _Room_name);
            param[16] = new SqlParameter("@Room_type_name", _Room_type_name);
            param[17] = new SqlParameter("@floor_name", _floor_name);
            param[18] = new SqlParameter("@CreatedOn", _CreatedOn);
            param[19] = new SqlParameter("@CreatedBy", _CreatedBy);
            param[20] = new SqlParameter("@UpdatedOn", _UpdatedOn);
            param[21] = new SqlParameter("@UpdatedBy", _UpdatedBy);
            param[22] = new SqlParameter("@IsDelete", _IsDelete);
            param[23] = new SqlParameter("@L3CatCode", _L3CatCode);
            param[24] = new SqlParameter("@L4CatCode", _L4CatCode);
            param[25] = new SqlParameter("@Sequence", _Sequence);
            param[26] = new SqlParameter("@ColorType", _ColorType);

            return ObjDBBridge.ExecuteNonQuery(_spName, param);

        }

        public void SelectById()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ViewById");
            param[1] = new SqlParameter("@TID", _TID);
            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dt.Rows.Count != 0)
            {
                DataRow dr = null;
                dr = dt.Rows[0];

                _TID = int.Parse(dr["TID"].ToString());
                _UniqueID = dr["UniqueID"].ToString();
                _AssetNumber = dr["AssetNumber"].ToString();
                _AssetDescription = dr["AssetDescription"].ToString();
                _Status = dr["Status"].ToString();
                _category_code = dr["category_code"].ToString();
                _group_code = dr["group_code"].ToString();
                _location_code = dr["location_code"].ToString();
                _section_code = dr["section_code"].ToString();
                _room_code = dr["room_code"].ToString();
                _room_type = dr["room_type"].ToString();
                _floor_code = dr["floor_code"].ToString();
                _location_name = dr["location_name"].ToString();
                _section_name = dr["section_name"].ToString();
                _Room_name = dr["Room_name"].ToString();
                _Room_type_name = dr["Room_type_name"].ToString();
                _floor_name = dr["floor_name"].ToString();
                _CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                _CreatedBy = dr["CreatedBy"].ToString();
                _UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                _UpdatedBy = dr["UpdatedBy"].ToString();
                _IsDelete = bool.Parse(dr["IsDelete"].ToString());
                _L3CatCode = dr["L3CatCode"].ToString();
                _L4CatCode = dr["L4CatCode"].ToString();
                _Sequence = int.Parse(dr["Sequence"].ToString());
                _ColorType = int.Parse(dr["ColorType"].ToString());

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

        public DataTable GetAllAssetTaggingByLocationId()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Mode", "GetAllAssetTaggingByLocationId");
            param[1] = new SqlParameter("@location_code", _location_code);
            param[2] = new SqlParameter("@section_code", _section_code);
            param[3] = new SqlParameter("@room_code", _room_code);

            DataTable dt = new DataTable();
            dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

            return dt;
        }

        //API GET TAGGING DATA BY LOCATION ID
        //public DataTable GetAssetTaggingDataByLocationId()
        //{
        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@Mode", "GetAssetTaggingDataByLocationId");
        //    param[1] = new SqlParameter("@location_code", _location_code);
        //    //param[2] = new SqlParameter("@CreatedOn", _CreatedOn);
        //    param[2] = new SqlParameter("@UniqueID", _UniqueID);

        //    DataTable dt = new DataTable();
        //    dt = ObjDBBridge.ExecuteDataset(_spName, param).Tables[0];

        //    return dt;
        //}

        //API UPDATE TAGGING DATA
        //public int UpdateAssetTaggingData()
        //{
        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@Mode", "UpdateAssetTaggingData");
        //    param[1] = new SqlParameter("@TID", _TID);
        //    param[2] = new SqlParameter("@AssetNumber", _AssetNumber);

        //    return ObjDBBridge.ExecuteNonQuery(_spName, param);
        //}

        #endregion
    }
}
