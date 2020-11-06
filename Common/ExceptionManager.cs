using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PrestoFolder
{
    [Serializable]
    public class ExceptionManager
    {
        /// <summary>
        /// Constante del Event Id
        /// </summary>
        public const int GENERIC_EVENT_ID = 5000;

        #region Methods

        public static void Write(string message, EventLogEntryType logEntryType, int eventId = GENERIC_EVENT_ID, short categoryId = 1)
        {
            string nameEventLog = ConfigurationManager.AppSettings["EventLogName"];
            string eventLogName = nameEventLog;
            string sourceName = nameEventLog;

            var hoksoftLog = new EventLog
            {
                Log = eventLogName
            };

            // set default event source (to be same as event log name) if not passed in
            if ((sourceName == null) || (sourceName.Trim().Length == 0))
            {
                sourceName = eventLogName;
            }

            hoksoftLog.Source = sourceName;

            // Check whether the Event Source exists. It is possible that this may
            // raise a security exception if the current process account doesn't
            // have permissions for all sub-keys under 
            // HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\EventLog
            // Check whether registry key for source exists
            string keyName = @"SYSTEM\CurrentControlSet\Services\EventLog\" + eventLogName;

            RegistryKey rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);

            // Check whether key exists
            if (rkEventSource == null)
            {
                // Key does not exist. Create key which represents source
                Registry.LocalMachine.CreateSubKey(keyName + @"\" + sourceName);
                rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);
            }

            // Now validate that the .NET Event Message File, EventMessageFile.dll (which correctly
            // formats the content in a Log Message) is set for the event source
            object eventMessageFile = rkEventSource.GetValue("EventMessageFile");

            // If the event Source Message File is not set, then set the Event Source message file.
            if (eventMessageFile == null)
            {
                // Source Event File Doesn't exist - determine .NET framework location,
                // for Event Messages file.
                RegistryKey dotNetFrameworkSettings = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NetFramework\");

                if (dotNetFrameworkSettings != null)
                {
                    object dotNetInstallRoot = dotNetFrameworkSettings.GetValue(
                    "InstallRoot",
                    null,
                    RegistryValueOptions.None);

                    if (dotNetInstallRoot != null)
                    {
                        string eventMessageFileLocation =
                        dotNetInstallRoot +
                        "v" +
                        Environment.Version.Major + "." +
                        Environment.Version.Minor + "." +
                        Environment.Version.Build +
                        @"\EventLogMessages.dll";

                        // Validate File exists
                        if (System.IO.File.Exists(eventMessageFileLocation))
                        {
                            // The Event Message File exists in the anticipated location on the
                            // machine. Set this value for the new Event Source
                            // Re-open the key as writable
                            rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName, true);
                            // Set the "EventMessageFile" property
                            rkEventSource.SetValue("EventMessageFile", eventMessageFileLocation, RegistryValueKind.String);
                        }
                    }
                }

                if (dotNetFrameworkSettings != null)
                {
                    dotNetFrameworkSettings.Close();
                }
            }

            rkEventSource.Close();

            hoksoftLog.WriteEntry(message, logEntryType, eventId, categoryId);
        }

        /// <summary>
        /// Método que nos permite Crear el Registro Presto en el EventLog y escribir sus entradas.
        /// </summary>
        /// <param name="sourceException">Exception que se genero.</param>
        /// <param name="logEntryType">Tipo de Log a Escribir: 1)Error 2)Warning 3)Information 4)Failure Audit 5) Sucess Audit.</param>
        /// <param name="eventId">Id del Evento.</param>
        /// <param name="categoryId">Id de la Categoria.</param>
        public static void HandleException(Exception sourceException, int logEntryType, int eventId, short categoryId = 1)
        {
            string nameEventLog = ConfigurationManager.AppSettings["EventLogName"];
            string eventLogName = nameEventLog;
            string sourceName = nameEventLog;

            var hoksoftLog = new EventLog
            {
                Log = eventLogName
            };

            // set default event source (to be same as event log name) if not passed in
            if ((sourceName == null) || (sourceName.Trim().Length == 0))
            {
                sourceName = eventLogName;
            }

            hoksoftLog.Source = sourceName;

            // Check whether the Event Source exists. It is possible that this may
            // raise a security exception if the current process account doesn't
            // have permissions for all sub-keys under 
            // HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\EventLog
            // Check whether registry key for source exists
            string keyName = @"SYSTEM\CurrentControlSet\Services\EventLog\" + eventLogName;

            RegistryKey rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);

            // Check whether key exists
            if (rkEventSource == null)
            {
                // Key does not exist. Create key which represents source
                Registry.LocalMachine.CreateSubKey(keyName + @"\" + sourceName);
                rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);
            }

            // Now validate that the .NET Event Message File, EventMessageFile.dll (which correctly
            // formats the content in a Log Message) is set for the event source
            object eventMessageFile = rkEventSource.GetValue("EventMessageFile");

            // If the event Source Message File is not set, then set the Event Source message file.
            if (eventMessageFile == null)
            {
                // Source Event File Doesn't exist - determine .NET framework location,
                // for Event Messages file.
                RegistryKey dotNetFrameworkSettings = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NetFramework\");

                if (dotNetFrameworkSettings != null)
                {
                    object dotNetInstallRoot = dotNetFrameworkSettings.GetValue(
                    "InstallRoot",
                    null,
                    RegistryValueOptions.None);

                    if (dotNetInstallRoot != null)
                    {
                        string eventMessageFileLocation =
                        dotNetInstallRoot +
                        "v" +
                        Environment.Version.Major + "." +
                        Environment.Version.Minor + "." +
                        Environment.Version.Build +
                        @"\EventLogMessages.dll";

                        // Validate File exists
                        if (System.IO.File.Exists(eventMessageFileLocation))
                        {
                            // The Event Message File exists in the anticipated location on the
                            // machine. Set this value for the new Event Source
                            // Re-open the key as writable
                            rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName, true);
                            // Set the "EventMessageFile" property
                            rkEventSource.SetValue("EventMessageFile", eventMessageFileLocation, RegistryValueKind.String);
                        }
                    }
                }

                if (dotNetFrameworkSettings != null)
                {
                    dotNetFrameworkSettings.Close();
                }
            }

            rkEventSource.Close();

            switch (logEntryType)
            {
                case 1:
                    hoksoftLog.WriteEntry(sourceException.ToString(), EventLogEntryType.Error, eventId, categoryId);
                    break;
                case 2:
                    hoksoftLog.WriteEntry(sourceException.ToString(), EventLogEntryType.Warning, eventId, categoryId);
                    break;
                case 3:
                    hoksoftLog.WriteEntry(sourceException.ToString(), EventLogEntryType.Information, eventId, categoryId);
                    break;
                case 4:
                    hoksoftLog.WriteEntry(sourceException.ToString(), EventLogEntryType.FailureAudit, eventId, categoryId);
                    break;
                case 5:
                    hoksoftLog.WriteEntry(sourceException.ToString(), EventLogEntryType.SuccessAudit, eventId, categoryId);
                    break;
            }
        }
        #endregion Methds
    }
}