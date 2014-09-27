using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CodeGeneratorHelpers;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace UI5AppWizard
{
    public class UI5WizardProvider: IWizard
    {
        private UI5AppWizard mForm;
        private DTE mDTE;
        private IView mView;
        private UI5ProjectType mType;
        private string mRootPath;
        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind" /> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        /// <exception cref="Microsoft.VisualStudio.TemplateWizard.WizardBackoutException"></exception>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            this.mForm = new UI5AppWizard();
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
            this.mRootPath = replacementsDictionary["$safeprojectname$"].ToLowerInvariant()
                .Replace(" ", string.Empty);
            replacementsDictionary.Add("$rootmodulepath$", this.mRootPath);
            this.mView = this.mForm.SelectedView(this.mRootPath + ".Main");
            this.mType = this.mForm.SelectedProject;
        }

        /// <summary>
        /// Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public void ProjectFinishedGenerating(Project project)
        {
            //adds view
            var viewContents = this.mView.createFromT4Template(this.mType);
            var tempFile = Path.GetTempPath() + string.Format("Main.view.{0}", this.mView.viewExtension);
            this.WriteToFile(tempFile, viewContents);
            var projectItem = ProjectHelper.GetFolderPath(project, this.mRootPath);
            if (projectItem != null)
            {
                projectItem.ProjectItems.AddFromFileCopy(tempFile);
            }
            File.Delete(tempFile);
            this.WriteToFile(ProjectHelper.GetFilePath(project, "Index.html"),
                Index.createContentFromT4(this.mType, this.mView.viewExtension.ToUpper(), this.mRootPath));
        }

        private void WriteToFile(string iPath, string iContent)
        {
            File.WriteAllText(iPath, iContent);
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
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
