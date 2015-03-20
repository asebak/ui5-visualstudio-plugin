using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace JavascriptLanguage
{
    public static class JavaScriptIntellisense
    {
        public static void Register(RegistryKey root)
        {
            RegisterFile("Resources\\SAPUI5.Intellisense.js", root);
        }
        private static void RegisterFile(string path, RegistryKey root)
        {
            try
            {
                string userPath = GetUserFilePath(Path.GetFileName(path));
                string assembly = Assembly.GetExecutingAssembly().Location;
                string folder = Path.GetDirectoryName(assembly).ToLowerInvariant();
                string file = Path.Combine(folder, path);
                if (!File.Exists(file))
                    return;
                File.Copy(file, userPath, true);
                using (RegistryKey key = root.OpenSubKey("JavaScriptLanguageService", true))
                {
                    if (key == null)
                        return;
                    key.SetValue("ReferenceGroups_WE", "Implicit (Web)|" + userPath + ";");
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string GetUserFilePath(string fileName)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string WE_folder = Path.Combine(folder, "Web Essentials 2015");
            if (!Directory.Exists(WE_folder))
                Directory.CreateDirectory(WE_folder);
            return Path.Combine(WE_folder, fileName);
        }
    }
}
