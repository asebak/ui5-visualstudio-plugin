using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CodeGeneratorHelpers;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace SapUI5AppWizard
{
    public class SapUI5ItemWizardProvider: IWizard
    {
        private SapUI5AppWizard mForm;
        private DTE mDTE;
        private IView mView;
        private SapUI5ProjectType mType;
        private string mRootPath;
        private string mControllerName;

        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind" /> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            this.mForm = new SapUI5AppWizard();
            this.mForm.ShowDialog();
            if (this.mForm.DialogResult == DialogResult.Cancel)
            {
                var destinationDirectory = replacementsDictionary["$destinationdirectory$"];
                if (Directory.Exists(destinationDirectory))
                {
                    Directory.Delete(destinationDirectory, true);
                }
                throw new WizardBackoutException();
            }
            this.mDTE = automationObject as DTE;
            var ns = replacementsDictionary["$rootnamespace$"];
            this.mRootPath = ns.Substring(ns.IndexOf('.') + 1);
            this.mControllerName = replacementsDictionary["$safeitemname$"].ToLowerInvariant();
            replacementsDictionary.Add("$rootmodulepath$", this.mRootPath);
            replacementsDictionary.Add("$controllername$", this.mControllerName);
            this.mView = this.mForm.SelectedView(this.mRootPath + "." + this.mControllerName);
            this.mType = this.mForm.SelectedProject;
        }

        /// <summary>
        /// Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public void ProjectFinishedGenerating(Project project)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            //adds view
            var viewContents = this.mView.createFromT4Template(this.mType);
            var tempFile = Path.GetTempPath() + string.Format("{0}.view.{1}", this.mControllerName, this.mView.viewExtension);
            this.WriteToFile(tempFile, viewContents);
            if (projectItem != null)
            {
                projectItem.ProjectItems.AddFromFileCopy(tempFile);
            }
            File.Delete(tempFile);
        }

        private void WriteToFile(string iPath, string iContent)
        {
            File.WriteAllText(iPath, iContent);
        }

        /// <summary>
        /// Indicates whether the specified project item should be added to the project.
        /// </summary>
        /// <param name="filePath">The path to the project item.</param>
        /// <returns>
        /// true if the project item should be added to the project; otherwise, false.
        /// </returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        /// <summary>
        /// Runs custom wizard logic before opening an item in the template.
        /// </summary>
        /// <param name="projectItem">The project item that will be opened.</param>
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public void RunFinished()
        {
        }
    }
}
