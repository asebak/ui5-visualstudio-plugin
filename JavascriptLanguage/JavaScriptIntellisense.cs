// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

#endregion

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
                var userPath = GetUserFilePath(Path.GetFileName(path));
                var assembly = Assembly.GetExecutingAssembly().Location;
                var folder = Path.GetDirectoryName(assembly).ToLowerInvariant();
                var file = Path.Combine(folder, path);
                if (!File.Exists(file))
                    return;
                File.Copy(file, userPath, true);
                using (var key = root.OpenSubKey("JavaScriptLanguageService", true))
                {
                    if (key == null)
                        return;
                    key.SetValue("ReferenceGroups_WE", "Implicit (Web)|" + userPath + ";");
                }
            }
            catch
            {
            }
        }

        private static string GetUserFilePath(string fileName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var WE_folder = Path.Combine(folder, "SAP UI5 VS Plugin");
            if (!Directory.Exists(WE_folder))
            {
                Directory.CreateDirectory(WE_folder);
            }
            return Path.Combine(WE_folder, fileName);
        }
    }
}