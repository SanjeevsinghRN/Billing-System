
#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Data;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Properties;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

#endregion


public class ErrorLogger
{
    #region Public Methods

    public static void LogMessage(Exception err, string errorLogPath)
    {
        /*
        LogEntry logEntry = new LogEntry();
        logEntry.Categories.Add("Error");
        logEntry.Message = err.Message + "\n\n" + err.StackTrace;
        logEntry.TimeStamp = DateTime.Now;

        TextFormatter formatter = new TextFormatter
            ("Timestamp: {timestamp}{newline}" +
            "Message: {message}{newline}" +
            "Category: {category}{newline}");

        errorLogPath = CheckDriveExists(errorLogPath);

        FlatFileTraceListener logFileListener =
            new FlatFileTraceListener(errorLogPath,
                                        "----------",
                                        "----------",
                                        formatter);

        EventLogTraceListener logEventListener = new EventLogTraceListener("RemedyNet");

        LogSource mainLogSource = new LogSource("MainLogSource", SourceLevels.All);
        mainLogSource.Listeners.Add(logFileListener);
        mainLogSource.Listeners.Add(logEventListener);

        LogSource nonExistantLogSource = new LogSource("Empty");

        IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
        traceSources.Add("Error", mainLogSource);
        traceSources.Add("Debug", mainLogSource);

        LogWriter _writer = new LogWriter(new ILogFilter[0],
                        traceSources, nonExistantLogSource, nonExistantLogSource, mainLogSource, "Error", false, true);

        _writer.Write(logEntry);
        */
        string innerEx = (err.InnerException != null) ? err.InnerException.Message : string.Empty;
        RN_Logger.LogMessage(err.Message + " {newline}Stack Trace:" + err.StackTrace + " {newline}Inner Exception:" + innerEx, "Error", errorLogPath);
    }

    public static void PerFormanceLogFile(string message, string LogPath)
    {
           
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        if(!Directory.Exists(LogPath))
        {
            Directory.CreateDirectory(LogPath);
        }
        LogPath = LogPath+"Performance" + "_" + sErrorTime + ".csv";
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(LogPath, true);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }
        catch { }
        finally
        {
            if (sw != null)
            {
                sw.Dispose();
            }
        }        
    }

    public static void CreateLogFile(string message, string errorLogPath)
    {
        string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

        //this variable used to create log filename format "
        //for example filename : ErrorLogYYYYMMDD
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;

        errorLogPath = errorLogPath + "_" + sErrorTime + ".log";
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(errorLogPath + sErrorTime, true);
            sw.WriteLine(sLogFormat + message);
            sw.Flush();
            sw.Close();
        }
        catch { }
        finally
        {
            if (sw != null)
            {
                sw.Dispose();
            }
        }
        //LogEntry logEntry = new LogEntry();
        //logEntry.Categories.Add("Error");
        //logEntry.Message = message;
        //logEntry.TimeStamp = DateTime.Now;

        //TextFormatter formatter = new TextFormatter
        //    ("{message}{newline}");

        //FlatFileTraceListener logFileListener =
        //    new FlatFileTraceListener(errorLogPath,formatter);

        //LogSource mainLogSource = new LogSource("MainLogSource", SourceLevels.Information);
        //mainLogSource.Listeners.Add(logFileListener);

        //LogSource nonExistantLogSource = new LogSource("Empty");

        //IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
        //traceSources.Add("Error", mainLogSource);

        //LogWriter _writer = new LogWriter(new ILogFilter[0],
        //                traceSources, nonExistantLogSource, nonExistantLogSource, mainLogSource, "Error", false, true);

        //_writer.Write(logEntry);
    }

    /// <summary>
    /// Create log for specified file.
    /// </summary>
    /// <param name="message">string</param>
    /// <param name="errorLogPath">string</param>
    /// <param name="isDateRequired">bool</param>
    public static void CreateLogFile(string message, string errorLogPath, bool isDateRequired)
    {
        string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        try
        {
            StreamWriter sw = new StreamWriter(errorLogPath, true);
            if (isDateRequired)
            {
                sw.WriteLine(sLogFormat + message);
            }
            else
            {
                sw.WriteLine(message);
            }

            sw.Flush();
            sw.Close();
        }
        catch { }
    }

    private static string CheckDriveExists(string errorLogPath)
    {
        DriveInfo drive = new DriveInfo(errorLogPath);
        string newErrorLogPath = string.Empty;

        if (drive.IsReady)
        {
            newErrorLogPath = errorLogPath;
        }
        else
        {
            newErrorLogPath = errorLogPath.Replace(drive.ToString(), "");
            newErrorLogPath = "C:\\" + newErrorLogPath;

        }
        return newErrorLogPath;
    }
    #endregion
}

