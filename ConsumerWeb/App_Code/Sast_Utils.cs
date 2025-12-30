using RN.MOBILE_COMMON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Xml;

/// <summary>
/// Summary description for Sast_Utils
/// </summary>
public class Sast_Utils
{
    #region PRIVATE FIELDS
    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn2"].ConnectionString);

    #endregion
    //public Sast_Utils()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //

    //}

    public DataTable Get_Credential_Details(int userType, string mobileNo, string password)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            //            sql = @"SELECT * FROM Family_op  A 
            //INNER JOIN FamilyMember_op B ON B.hhid =A.hhid
            //RIGHT OUTER JOIN Address_op  C ON C.member_id =B.member_id
            //WHERE B.mobileNumber= @vuserName and B.dependent_flag='S'";

            sql = "select l.USERID,l.USERNAME,l.USERROLE,l.EMAIL,l.address,l.CITY,l.STATE,l.MOBILE from logindetails l with (nolock) where l.MOBILE =@mobNo ";

            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            //cmd = new SqlCommand(selectString, conn1);
            cmd.Parameters.AddWithValue("@mobNo", mobileNo);
            //cmd.Parameters.AddWithValue("@vuserName", userName);
            dt = new DataTable();
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public DataTable Get_User_Credential_Details(int userType, string userName, string password)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            sql = @"select * from Credential_Details_op where hhid=@vuserName";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", userName);
            dt = new DataTable();
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public DataTable GetPatients_SAST(string userName)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            //            sql = @"SELECT * FROM Family_op  A 
            //INNER JOIN FamilyMember_op B ON B.hhid =A.hhid
            //RIGHT OUTER JOIN Address_op  C ON C.member_id =B.member_id
            //WHERE A.hhid= @vuserName";
            sql = "select * from logindetails with (nolock) where USERID =@vuserName ";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", userName);
            dt = new DataTable();
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public DataTable GenerateMenuListConsumer(string CorporateCode)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            sql = @"Select * From MENU_DATA M
inner join USER_ACCESS c on c.menu_id= m.menu_id where USER_NAME= @vuserName ";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", CorporateCode);
            dt = new DataTable();
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }
    public Int32 GetCityID(string CityName, string pincode)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        Int32 cityid = 0;
        try
        {
            sql = @"Select * From CITY_PINCODE_OP where pincode=@vuserName";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", pincode);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 0)
            {
                sql = @"SELECT * FROM CITY_OP WHERE UPPER(CITY_NAME) LIKE @vCityName";
                cmd = new SqlCommand(sql, conn1);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@vCityName", CityName.ToUpper());
                dt = new DataTable();
                da.Fill(dt);
            }
            DataRow DR = dt.Rows[0];
            cityid = Convert.ToInt32(DR["CITY_ID"]);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return cityid;

    }

    public DataTable GetPhysicianSplSearchMenu_v1(string CityName, string pincode)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        Int32 cityid = 0;
        try
        {
            //            sql = @"select * from PACKAGESPECIALITYMASTER  where SUBCATEGORYID in (
            //SELECT DISTINCT(C.SPECIALITY_ID) FROM HOSP_EMPANEL_MASTER_DATA_REF A
            //RIGHT JOIN masterhospital B ON B.HOSPCODE=A.PROVIDER_CODE
            //RIGHT JOIN HOSP_EMPANEL_SPECIALISTS_DETAIL C ON C.REFNO=A.REFNO and C.HID=A.HID AND C.IS_APPROVED='1'
            //RIGHT JOIN PACKAGESPECIALITYMASTER D ON D.SUBCATEGORYID=C.SPECIALITY_ID
            //WHERE B.AREACODE =@vpinCode)";
            //            sql = @"select * from PaclageCategoryMaster p
            //  RIGHT JOIN Payer_Provider_category c ON c.PKG_CATEGORY = p.CategoryName 
            //  RIGHT JOIN masterhospital B ON B.HOSPCODE=C.PROVIDERCODE

            //WHERE B.AREACODE =@vpinCode";
            sql = @" SELECT DISTINCT CategoryName PKG_CATEGORY, 'Consulat.png' as IMAGE_NAME,CategoryId
FROM PaclageCategoryMaster
WHERE ENTITYCODE = 'T_18193'";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            // cmd.Parameters.AddWithValue("@vpinCode", pincode);
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public DataTable GetPhysicianSearch(string CityName, string pincode, GeoLocation objGeo = null)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        Int32 cityid = 0;
        try
        {
            sql = @"SELECT *
FROM(SELECT
    b.HNO,b.STREET,b.AREACODE,b.LOC,b.Longitude,b.Latitude,b.HOSPCODE,b.HOSPNAME,b.PHONE1,a.PKG_CATEGORY,
    dbo.Calc_distance(
        CAST(@vClat AS FLOAT),   
        CAST(@vClon AS FLOAT),   
        CAST(b.Latitude AS FLOAT),   
        CAST(b.Longitude AS FLOAT),3963         
    ) AS Distance
FROM
    Payer_Provider_category a
INNER JOIN
    masterhospital b ON a.PROVIDERCODE = b.HOSPCODE
WHERE
    a.PAYERCODE = 'T_18193' and areacode = @vpinCode and b.Latitude is not null)AS DistanceTable
WHERE Distance <= 50";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            //cmd.Parameters.AddWithValue("@vClat", "13.049938");
            //cmd.Parameters.AddWithValue("@vClon", "80.208645");
            //cmd.Parameters.AddWithValue("@vpinCode", "600001");
            cmd.Parameters.AddWithValue("@vClat", objGeo.GEO_LATITUDE);
            cmd.Parameters.AddWithValue("@vClon", objGeo.GEO_LONGITUDE);
            cmd.Parameters.AddWithValue("@vpinCode", "600001");
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public string SaveAppointment(string xmldata)
    {
        string Appointment = string.Empty;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        try
        {
            using (XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(xmldata)))
            {
                SqlCommand command = new SqlCommand("InsertOrUpdateAppointmentDetails_OP", conn1);
                command.CommandType = CommandType.StoredProcedure;

                // Add XML parameter
                SqlParameter xmlParameter = command.Parameters.AddWithValue("@XmlData", SqlDbType.Xml);
                xmlParameter.Value = new SqlXml(xmlReader);
                // Output parameter for Appointment ID
                SqlParameter appointmentIdParam = command.Parameters.Add("@AppointmentIDOutput", SqlDbType.NVarChar, int.MaxValue);
                appointmentIdParam.Direction = ParameterDirection.Output;

                conn1.Open();

                command.ExecuteNonQuery();
                // Get the output parameter value
                Appointment = appointmentIdParam.Value.ToString();
                //Console.WriteLine("Inserted/Updated Appointment ID: " + appointmentId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }
        }
        return Appointment;

    }

    public DataTable GetAppointmentDashboard_V1(string patientId)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            sql = @"select * from APPOINTMENT_DETAILS_OP a
inner join FamilyMember_op b on b.member_id=a.MEMBER_ID
inner join masterhospital e on e.HOSPCODE=a.HOSPCODE
inner join HOSP_EMPANEL_SPECIALISTS_DETAIL c on c.SPECIALIST_ID=a.PHYSICIAN_ID
inner join PACKAGESPECIALITYMASTER D ON D.SUBCATEGORYID=C.SPECIALITY_ID
where PATIENT_ID=@vuserName order by APPOINTMENT_ID desc";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", patientId);
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }

    public string PostRequestKASS(string url, string postData, string token)

    {
        string result = string.Empty;
        WebResponse response;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            if (token != string.Empty)
            {
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json";

            }
            else
            {

                request.ContentType = "application/x-www-form-urlencoded";
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            if (postData != string.Empty)
            {
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            else
            {
                request.ContentLength = 0;
            }
            //var task = Task.Run(() =>
            //{
            //    try
            //    {
            response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();

            }
            response.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //});
            //if (!task.Wait(TimeSpan.FromSeconds(30)))
            //{
            //    throw new Exception("Timeout");
            //}
        }
        catch (WebException wex)
        {
            string Output = string.Empty;


            if (wex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)wex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        result = error;
                        Output = "Status Code:" + errorResponse.StatusCode + "|Errmsg:" + error;
                    }
                }
            }
            // throw new Exception(Output);
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Internal Server Error');", true);
        }

        finally
        {


        }
        return result;
    }

    public string Save_user(string xmldata)
    {
        string Appointment = string.Empty;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        try
        {
            using (XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(xmldata)))
            {
                SqlCommand command = new SqlCommand("InsertFamilyData_OP", conn1);
                command.CommandType = CommandType.StoredProcedure;

                // Add XML parameter
                SqlParameter xmlParameter = command.Parameters.AddWithValue("@XmlData", SqlDbType.Xml);
                xmlParameter.Value = new SqlXml(xmlReader);
                // Output parameter for Appointment ID
                SqlParameter appointmentIdParam = command.Parameters.Add("@SuccessMessage", SqlDbType.NVarChar, int.MaxValue);
                appointmentIdParam.Direction = ParameterDirection.Output;

                conn1.Open();

                command.ExecuteNonQuery();
                // Get the output parameter value
                Appointment = appointmentIdParam.Value.ToString();
                //Console.WriteLine("Inserted/Updated Appointment ID: " + appointmentId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }
        }
        return Appointment;

    }
    public void InsertCredential_Details_op(string hhid, string mobileNumber, string otp, string MPIN)
    {
        SqlCommand Cmd = null;
        string StrSql = "";
        try
        {
            StrSql = "INSERT INTO Credential_Details_op(hhid,mobileNumber,otp,MPIN) VALUES(@hhid,@mobileNumber,@otp,@MPIN)";
            Cmd = new SqlCommand(StrSql, conn1);
            Cmd.Parameters.AddWithValue("@hhid", hhid);
            Cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            Cmd.Parameters.AddWithValue("@otp", otp);
            Cmd.Parameters.AddWithValue("@MPIN", MPIN);

            conn1.Open();
            Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (Cmd != null) Cmd.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }
        }
    }

    public List<PrescriptionClass> GetPrescriptionList_v1(string PatientID, string transType)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        Int32 cityid = 0;
        List<PrescriptionClass> _objLstPclass = new List<PrescriptionClass>();
        try
        {
            sql = @"SELECT APPOINTMENT_ID, CONCAT(APPOINTMENT_DATE, ' ', APPOINTMENT_TIME) AS APPOINTMENT_DATE,PATIENT_ID,PHYSICIAN_ID,A.MOBILE_NO,SPECIALIST_NAME,SPECIALITYNAME,A.MODIFIED_DATE,A.MEMBER_ID,MEMBERNAME,a.docremarks,e.HOSPNAME,e.HOSPCODE,a.MODIFIED_BY,a.STATUS  
                       FROM APPOINTMENT_DETAILS_OP a
                       INNER JOIN FamilyMember_op b ON b.member_id = a.MEMBER_ID
                       INNER JOIN masterhospital e ON e.HOSPCODE = a.HOSPCODE
                       INNER JOIN HOSP_EMPANEL_SPECIALISTS_DETAIL c ON c.SPECIALIST_ID = a.PHYSICIAN_ID
                       INNER JOIN PACKAGESPECIALITYMASTER D ON D.SUBCATEGORYID = c.SPECIALITY_ID
                       WHERE A.STATUS='0' and A.PATIENT_ID=@vuserName";
            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@vuserName", PatientID);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                PrescriptionClass _pres = new PrescriptionClass();
                foreach (DataRow row in dt.Rows)
                {
                    _pres = new PrescriptionClass();
                    _pres.prescriptionId = Convert.ToString(row["APPOINTMENT_ID"]) + "_" + Convert.ToString(row["HOSPCODE"]) + "_" + Convert.ToString(row["PATIENT_ID"]);
                    _pres.prescriptionDate = Convert.ToString(row["MODIFIED_DATE"]);
                    _pres.patientName = Convert.ToString(row["MEMBERNAME"]);
                    _pres.MemberID = Convert.ToString(row["MEMBER_ID"]);
                    _pres.MobileNo = Convert.ToString(row["MOBILE_NO"]);
                    _pres.patient_id = Convert.ToString(row["PATIENT_ID"]);
                    _pres.ailmentid = string.Empty;
                    _pres.IsOfflinePrescription = 0;
                    _pres.PrecFileName = string.Empty;
                    _pres.Remarks = Convert.ToString(row["docremarks"]);
                    _pres.prescriptionDate = Convert.ToString(row["MODIFIED_DATE"]);
                    _pres.physician_Speciality = Convert.ToString(row["SPECIALITYNAME"]);
                    _pres.physician_id = Convert.ToString(row["PHYSICIAN_ID"]);
                    _pres.physicianName = Convert.ToString(row["SPECIALIST_NAME"]);
                    _pres.IsAppointment = 1;
                    _pres.intAppointmentId = Convert.ToString(row["APPOINTMENT_ID"]);
                    _pres.EntityName = Convert.ToString(row["HOSPNAME"]);
                    _pres.EntityCode = Convert.ToString(row["HOSPCODE"]);
                    _pres.CREATED_BY = Convert.ToString(row["MODIFIED_BY"]);
                    _pres.Action_status = Convert.ToString(row["STATUS"]);
                    _pres.Action_status_Id = Convert.ToString(row["STATUS"]);
                    _pres.IsView = true;
                    _objLstPclass.Add(_pres);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return _objLstPclass;

    }
    public DataTable pkgDetail(string Entitycode, string catogory)
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string sql = string.Empty;
        try
        {
            //            sql = @"SELECT * FROM Family_op  A 
            //INNER JOIN FamilyMember_op B ON B.hhid =A.hhid
            //RIGHT OUTER JOIN Address_op  C ON C.member_id =B.member_id
            //WHERE B.mobileNumber= @vuserName and B.dependent_flag='S'";

            // sql = " select top 50 *  from PACKAGE_SPECIALITY   where ENTITYCODE='T_18193'";
            sql = @" select  p.PROCEDURECODE,p.PROCEDURE_DESCRIPTION,p.MAPPING,pa.PROVIDER_GRADE,pa.GRADE_RATES from PACKAGEDESCRIPTION  p 
 INNER JOIN PAYER_PROVIDER_PROCEDURE_AFFILIATION  pa on pa.PROCEDURECODE=p.PROCEDURECODE
 where p.PAYERCODE='T_18193' and pa.PROVIDERCODE=@vhospCode and p.PROCEDURE_DESCRIPTION in ( 
  select PROCEDURECODE from PACKAGE_SPECIALITY   where ENTITYCODE='T_18193' and PKG_CATEGORY=@vCatogory)";

            cmd = new SqlCommand(sql, conn1);
            da = new SqlDataAdapter(cmd);
            //cmd = new SqlCommand(selectString, conn1);
            cmd.Parameters.AddWithValue("@vhospCode", Entitycode);
            cmd.Parameters.AddWithValue("@vCatogory", catogory);
            dt = new DataTable();
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (conn1.State != ConnectionState.Closed)
            {
                conn1.Close();
            }

        }
        return dt;

    }
}