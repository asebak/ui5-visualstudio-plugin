using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahoo.Yui.Compressor;
namespace ControllerCompressor
{
    /// <summary>
    /// UI5 View and Controller Compressor Helper Class
    /// </summary>
    public class UI5Compressor
    {
        private readonly JavaScriptCompressor mCompressor;
        /// <summary>
        /// Initializes a new instance of the <see cref="UI5Compressor"/> class.
        /// </summary>
        public UI5Compressor()
        {
            this.mCompressor = new JavaScriptCompressor();
        }

        /// <summary>
        /// Compresses the specified folder path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        public void Compress(string folderPath)
        {
            var folderFiles = this.GetAllFiles(folderPath);
            //<!--Create Debug Versions of each file, needs to be change Name-dbg.view Name-dbg.controller-->
        }

        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        private string[] GetAllFiles(string folder)
        {
            return Directory.GetFiles(folder);
        }
        private void CopyDirectory(string sourcePath, string destPath)
        {
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(file));
                File.Copy(file, dest);
            }

            foreach (string folder in Directory.GetDirectories(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(folder));
                CopyDirectory(folder, dest);
            }
        }
        private void CreateDebugVersionsOfFiles(string[] files)
        {
            
        }
    }
}
