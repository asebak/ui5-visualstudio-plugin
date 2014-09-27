using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace ViewControllerCompressor
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        public Connect()
        {
        }

        /// <summary>
        /// Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="connectMode">The connect mode.</param>
        /// <param name="addInInst">The add in inst.</param>
        /// <param name="custom">The custom.</param>
        /// <seealso class="IDTExtensibility2" />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            if (connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                var contextGUIDS = new object[] { };
                var commands = (Commands2)_applicationObject.Commands;
                var cmdBars = (CommandBars)(_applicationObject.CommandBars);
                var vsBarProject = cmdBars["Folder"];
                CommandBarButton control = null;
                try
                {
                    var command = commands.AddNamedCommand2(_addInInstance, "Minimizer", "Minimizer", "Executes the command for Minimizer", true, 2817, ref contextGUIDS);
                    if ((command != null) && (vsBarProject != null))
                    {
                        control = (CommandBarButton)command.AddControl(vsBarProject);
                    }
                }
                catch (ArgumentException)
                {
                }
                if (control != null)
                {
                    control.Click += minimizeControl_Click;
                }
            }
        }

        /// <summary>
        /// Minimizes the control_ click.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="canceldefault">if set to <c>true</c> [canceldefault].</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void minimizeControl_Click(CommandBarButton ctrl, ref bool canceldefault)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.
        /// </summary>
        /// <param name="disconnectMode">The disconnect mode.</param>
        /// <param name="custom">The custom.</param>
        /// <seealso class="IDTExtensibility2" />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.
        /// </summary>
        /// <param name="custom">The custom.</param>
        /// <seealso class="IDTExtensibility2" />
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.
        /// </summary>
        /// <param name="custom">The custom.</param>
        /// <seealso class="IDTExtensibility2" />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.
        /// </summary>
        /// <param name="custom">The custom.</param>
        /// <seealso class="IDTExtensibility2" />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>
        /// Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <param name="neededText">The needed text.</param>
        /// <param name="status">The status.</param>
        /// <param name="commandText">The command text.</param>
        /// <seealso class="Exec" />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (commandName == "Minimizer.Connect.Minimizer")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
            }
        }

        /// <summary>
        /// Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <param name="executeOption">The execute option.</param>
        /// <param name="varIn">The variable in.</param>
        /// <param name="varOut">The variable out.</param>
        /// <param name="handled">if set to <c>true</c> [handled].</param>
        /// <seealso class="Exec" />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (commandName == "Minimizer.Connect.Minimizer")
                {
                    handled = true;
                    return;
                }
            }
        }
        private DTE2 _applicationObject;
        private AddIn _addInInstance;
    }
}