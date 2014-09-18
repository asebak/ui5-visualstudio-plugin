using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace SapUI5AppWizard
{
    public class SapUI5WizardProvider: IWizard
    {
        private SapUI5AppWizard mForm;
        private DTE mDTE;
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
        }

        public void ProjectFinishedGenerating(Project project)
        {
            throw new NotImplementedException();
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            throw new NotImplementedException();
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public void RunFinished()
        {
            throw new NotImplementedException();
        }
    }
}
