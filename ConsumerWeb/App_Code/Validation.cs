using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RN.MOBILE_COMMON;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
    private const string EmailFormatRegx = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,9}|[0-9]{1,3})(\]?)$";
    private const string MobileFormatRegx = @"^([1-9]{1}[0-9]{9}?)$";
    public Validation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetToken(string key)
    {
        Utils _utils = new Utils();
        string requestURI = Utils.CLSURL +string.Format("api/Common/GetToken?key={0}", key);
        string Token = string.Empty;
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            Token = JsonConvert.DeserializeObject<string>(response);
            if (Token == null || Token.Length <= 3)
            {
                Token = string.Empty;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Token;
    }
    public static bool VerifyEmailId(string stringToValidate)
    {
        if (!string.IsNullOrEmpty(stringToValidate))
        {
            // matchs the email id with the resource file
            return Regex.IsMatch(stringToValidate, EmailFormatRegx);

        }
        else
        {
            return false;
        }
    }

    public static bool VerifyMobileNo(string stringToValidate)
    {
        if (!string.IsNullOrEmpty(stringToValidate))
        {
            // matchs the email id with the resource file
            return Regex.IsMatch(stringToValidate, MobileFormatRegx);

        }
        else
        {
            return false;
        }
    }
}