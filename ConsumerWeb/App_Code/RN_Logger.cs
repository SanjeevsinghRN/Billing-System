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


public static class RN_Logger
{
    static string errorLogPath = string.Empty;
    static string errorLogFile = string.Concat(DateTime.Now.Day.ToString(), "-", DateTime.Now.Month.ToString(), "-", DateTime.Now.Year.ToString(), ".log");

    static LogWriter _writer;


    public static void LogMessage(string message)
    {
        LogMessage(message, "Error");
    }

    public static void LogMessage(string message, string category, string strerrorLogPath = "")
    {
        TextFormatter formatter = new TextFormatter
            ("Timestamp: {timestamp(hh:mm:ss tt)}{newline}" +
            "Message: {message}{newline}" +
            "Category: {category}{newline}");
        if (strerrorLogPath == string.Empty)
            strerrorLogPath = ConfigurationManager.AppSettings["ErrorLogPath"].ToString();
        errorLogPath = CheckDriveExists(strerrorLogPath);

        FlatFileTraceListener logFileListener =
            new FlatFileTraceListener(errorLogPath,
                                        "----------",
                                        "----------",
                                        formatter);

        // EventLogTraceListener logEventListener = new EventLogTraceListener("Remedinet");

        // LogSource infoLogSource = new LogSource("InfoLogSource", SourceLevels.ActivityTracing);
        //infoLogSource.Listeners.Add(logFileListener);

        LogSource mainLogSource = new LogSource("MainLogSource", SourceLevels.All);
        mainLogSource.Listeners.Add(logFileListener);
        //mainLogSource.Listeners.Add(logEventListener);

        LogSource nonExistantLogSource = new LogSource("Empty");

        IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
        traceSources.Add("Error", mainLogSource);
        traceSources.Add("Debug", mainLogSource);

        // traceSources.Add("Remedinet", infoLogSource);

        _writer = new LogWriter(new ILogFilter[0],
                        traceSources, nonExistantLogSource, nonExistantLogSource, mainLogSource, "Error", false, true);
        LogEntry entry = new LogEntry();
        try
        {
            entry.Categories.Add(category);
            entry.Message = message;
            entry.TimeStamp = DateTime.Now;
            _writer.Write(entry);
        }
        catch (Exception ex) { }
        finally
        {
            if (formatter != null)
                formatter = null;
            if (logFileListener != null)
            {
                logFileListener.Flush();
                logFileListener.Dispose();
            }
            if (mainLogSource != null)
            {
                mainLogSource.Dispose();
                mainLogSource = null;
            }
            if (nonExistantLogSource != null)
            {
                nonExistantLogSource.Dispose();
                nonExistantLogSource = null;
            }
            if (traceSources != null)
            {
                traceSources = null;
            }
            if (_writer != null)
            {
                _writer.Dispose();
                _writer = null;
            }
        }

    }

    private static string CheckDriveExists(string errorLogPath)
    {
        errorLogPath = GetFullErrorLogPath(errorLogPath);
        DriveInfo drive = new DriveInfo(errorLogPath);
        string newErrorLogPath = string.Empty;

        //Create File for each Day
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

    private static string GetFullErrorLogPath(string path)
    {
        return Path.Combine(path, errorLogFile);
    }
}

