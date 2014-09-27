using System.Windows.Forms;
using CodeGeneratorHelpers;

namespace UI5AppWizard
{
    public partial class UI5AppWizard : Form
    {
        /// <summary>
        /// Selecteds the project.
        /// </summary>
        /// <returns></returns>
        public UI5ProjectType SelectedProject
        {
            get { return this.desktop.Checked ? UI5ProjectType.Desktop : UI5ProjectType.Mobile; } 
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
        /// Initializes a new instance of the <see cref="UI5AppWizard"/> class.
        /// </summary>
        public UI5AppWizard()
        {
            InitializeComponent();
        }
    }
}
