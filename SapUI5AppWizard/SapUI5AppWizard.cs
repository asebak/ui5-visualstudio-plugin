using System;
using System.Windows.Forms;
using CodeGeneratorHelpers;

namespace SapUI5AppWizard
{
    public partial class SapUI5AppWizard : Form
    {
        /// <summary>
        /// Selecteds the project.
        /// </summary>
        /// <returns></returns>
        public SapUI5ProjectType SelectedProject
        {
            get { return this.desktop.Checked ? SapUI5ProjectType.Desktop : SapUI5ProjectType.Mobile; } 
        }

        /// <summary>
        /// Selecteds the view.
        /// </summary>
        /// <returns></returns>
        public IView SelectedView(string controllerName)
        {
            if (this.javascript.Checked)
            {
                return new JavascriptView(controllerName);
            }
            if (this.json.Checked)
            {
                return new JSONView(controllerName);
            }
            if (this.xml.Checked)
            {
                return new XMLView(controllerName);
            }
            if (this.html.Checked)
            {
                return new HTMLView(controllerName);
            }
            return null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SapUI5AppWizard"/> class.
        /// </summary>
        public SapUI5AppWizard()
        {
            InitializeComponent();
        }
    }
}
