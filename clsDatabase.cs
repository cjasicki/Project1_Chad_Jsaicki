﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Project1_Chad_Jsaicki
{
    public class clsDatabase
    {
        //***** AcquireConnection()
        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();

                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //***** AcquireConnection() NOTE! Overloaded function
        private static SqlConnection AcquireConnection(Boolean blnUseApp)
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (blnUseApp)
            {
                if (ConfigurationManager.AppSettings["DBConnect"] != null)
                {
                    cnSQL = new SqlConnection();
                    cnSQL.ConnectionString = ConfigurationManager.AppSettings["DBConnect"].ToString();

                    try
                    {
                        cnSQL.Open();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        cnSQL.Dispose();
                    }
                }
            }
            else
            {
                if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
                {
                    cnSQL = new SqlConnection();
                    cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();

                    try
                    {
                        cnSQL.Open();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        cnSQL.Dispose();
                    }
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //***** GetProductByID()
        public static DataSet GetTechInfoByID(string strProdID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            if (strProdID.Trim().Length > 0)
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetTechnicianByID";

                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = strProdID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        dsSQL.Dispose();
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** gettechs()
        public static DataSet gettechs()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetTechnicianList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** GetProducts()
        public static DataSet GetProducts()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetProducts";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** DeleteProduct()
        public static Int32 DeleteTech(String strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspDeleteTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //***** InsertProduct()
        public static Int32 InsertProduct(String strProdID, String strProdDesc, String strProdHS, String strManufacturer)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertProduct";

                cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProductID"].Value = strProdID;

                cmdSQL.Parameters.Add(new SqlParameter("@ProdDesc", SqlDbType.NVarChar, 250));
                cmdSQL.Parameters["@ProdDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProdDesc"].Value = strProdDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@ProdHS", SqlDbType.NChar, 1));
                cmdSQL.Parameters["@ProdHS"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProdHS"].Value = strProdHS;

                cmdSQL.Parameters.Add(new SqlParameter("@Mfg", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@Mfg"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Mfg"].Value = strManufacturer;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //***** GetTickets()
        public static DataSet GetTickets(Boolean blnUseAppSetting)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;

            cnSQL = AcquireConnection(blnUseAppSetting);
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.Text;
                cmdSQL.CommandText = "SELECT * FROM [dbo].[ServiceEvents] ORDER BY [TicketID];";

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
        //***INsertServiceEvent()   
        public static Int32 InsertTech(string strLName, string strFName, string strMidIni, string strEmail, string strDept, Int32 intPhone, Decimal decRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;
            Int32 intNewTech = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 20));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NChar, 1));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@MInit"].Value = strMidIni;

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EMail"].Value = strEmail;

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 25));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Dept"].Value = strDept;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = intPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = decRate;


                cmdSQL.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

                if (!blnErrorOccurred)
                {
                    try
                    {
                        intNewTech = Convert.ToInt32(cmdSQL.Parameters["@NewTechnicianID"].Value);
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                }
                //** Cleanup
                cmdSQL.Parameters.Clear();
                cmdSQL.Dispose();
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return intNewTech;
            }
        }
    }
}