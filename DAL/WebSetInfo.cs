using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace WE_Project.DAL
{
    public class WebSetInfo
    {
        private static Model.WebSetInfo _model;
        public static Model.WebSetInfo Model
        {
            get
            {
                //if (_model == null)
                _model = GetModel();
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public static bool Update(Model.WebSetInfo model)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSetInfo set ");

            strSql.Append(" WebState = @WebState , ");
            strSql.Append(" PageSize = @PageSize , ");
            strSql.Append(" RegionalDirectorCondition = @RegionalDirectorCondition , ");
            strSql.Append(" RegionalDirectorTreatment = @RegionalDirectorTreatment , ");
            strSql.Append(" ServerCenterCondition = @ServerCenterCondition , ");
            strSql.Append(" ServerCenterTreatment = @ServerCenterTreatment , ");
            strSql.Append(" BTCenterCondition = @BTCenterCondition , ");
            strSql.Append(" BTCenterTreatment = @BTCenterTreatment , ");
            strSql.Append(" WebTitle = @WebTitle , ");
            strSql.Append(" WKeyword = @WKeyword , ");
            strSql.Append(" WDescription = @WDescription , ");
            strSql.Append(" WCopyright = @WCopyright , ");
            strSql.Append(" OpenTimeStr = @OpenTimeStr , ");
            strSql.Append(" CloseInfo = @CloseInfo , ");
            strSql.Append(" TXInfo = @TXInfo , ");
            strSql.Append(" HKInfo = @HKInfo  ");
            //strSql.Append(" where WebState=@WebState and WebTitle=@WebTitle and WKeyword=@WKeyword and WDescription=@WDescription and WCopyright=@WCopyright and OpenTimeStr=@OpenTimeStr and CloseInfo=@CloseInfo and TXInfo=@TXInfo and HKInfo=@HKInfo and PageSize=@PageSize and RegionalDirectorCondition=@RegionalDirectorCondition and RegionalDirectorTreatment=@RegionalDirectorTreatment and ServerCenterCondition=@ServerCenterCondition and ServerCenterTreatment=@ServerCenterTreatment and BTCenterCondition=@BTCenterCondition and BTCenterTreatment=@BTCenterTreatment  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@WebState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@PageSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@RegionalDirectorCondition", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@RegionalDirectorTreatment", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ServerCenterCondition", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ServerCenterTreatment", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@BTCenterCondition", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@BTCenterTreatment", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@WebTitle", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@WKeyword", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@WDescription", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@WCopyright", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@OpenTimeStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@CloseInfo", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@TXInfo", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@HKInfo", SqlDbType.NVarChar,2550)             
              
            };

            parameters[0].Value = model.WebState;
            parameters[1].Value = model.PageSize;
            parameters[2].Value = model.RegionalDirectorCondition;
            parameters[3].Value = model.RegionalDirectorTreatment;
            parameters[4].Value = model.ServerCenterCondition;
            parameters[5].Value = model.ServerCenterTreatment;
            parameters[6].Value = model.BTCenterCondition;
            parameters[7].Value = model.BTCenterTreatment;
            parameters[8].Value = model.WebTitle;
            parameters[9].Value = model.WKeyword;
            parameters[10].Value = model.WDescription;
            parameters[11].Value = model.WCopyright;
            parameters[12].Value = model.OpenTimeStr;
            parameters[13].Value = model.CloseInfo;
            parameters[14].Value = model.TXInfo;
            parameters[15].Value = model.HKInfo;   
            Model = null;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
        }

        private static Model.WebSetInfo GetModel()
        {
            string SqlStr = "select top 1 * from WebSetInfo";
            DataTable table = DbHelperSQL.Query(SqlStr).Tables[0];
            if (table.Rows.Count > 0)
            {
                return TranEntity(table.Rows[0]);
            }
            return null;
        }

        private static Model.WebSetInfo TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.WebSetInfo model = new Model.WebSetInfo();

                if (!string.IsNullOrEmpty(dr["WebState"].ToString()))
                {
                    model.WebState = bool.Parse(dr["WebState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PageSize"].ToString()))
                {
                    model.PageSize = int.Parse(dr["PageSize"].ToString());
                }
                model.RegionalDirectorCondition = dr["RegionalDirectorCondition"].ToString();
                model.RegionalDirectorTreatment = dr["RegionalDirectorTreatment"].ToString();
                model.ServerCenterCondition = dr["ServerCenterCondition"].ToString();
                model.ServerCenterTreatment = dr["ServerCenterTreatment"].ToString();
                model.BTCenterCondition = dr["BTCenterCondition"].ToString();
                model.BTCenterTreatment = dr["BTCenterTreatment"].ToString();
                model.WebTitle = dr["WebTitle"].ToString();
                model.WKeyword = dr["WKeyword"].ToString();
                model.WDescription = dr["WDescription"].ToString();
                model.WCopyright = dr["WCopyright"].ToString();
                model.OpenTimeStr = dr["OpenTimeStr"].ToString();
                model.CloseInfo = dr["CloseInfo"].ToString();
                model.TXInfo = dr["TXInfo"].ToString();
                model.HKInfo = dr["HKInfo"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
