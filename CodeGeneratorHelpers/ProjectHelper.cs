using System.Collections.Generic;
using System.Runtime.InteropServices;
using EnvDTE;

namespace CodeGeneratorHelpers
{
    /// <summary>
    ///     Constants for EnvDTE
    /// </summary>
    [Guid("88BFE631-54CD-4FCF-958E-F31187BE32D2")]
    internal abstract class EnvDTEConstants
    {
        public const string vsProjectKindSolutionFolder = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        public const string vsProjectKindProjectItemFolder = "{EA6618E8-6E24-4528-94BE-6889FE16485C}";
    }
    public class ProjectHelper
    {
        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns></returns>
        public static ProjectItem GetFolderPath(Project p, string folderName)
        {
            return p.ProjectItems.Item(folderName);
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string GetFilePath(Project p, string fileName)
        {
            return p.ProjectItems.Item(fileName).Properties.Item("FullPath").Value.ToString();
        }
    }
}
