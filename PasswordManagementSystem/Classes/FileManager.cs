using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManagementSystem.Classes
{
    public static class FileManager
    {
        /**
         * Provide file path and List of Strings,
         * to write information to the file
         * 
         */
        public static void WriteFile(string filePath, List<string> data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath,true))
                {
                    //sw.WriteLine("");
                    
                    foreach (var d in data)
                    {                      
                        sw.WriteLine(d,Environment.NewLine);
                        //sw.WriteLine(d);
                        //sw.Write(d);
                    }
                    sw.Close();
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
        }
        /**
         * Provide path of the file which will contain
         * directories, and return all these directories
         * in a form of a List of Strings
         * 
         */
        public static List<string> GetDirsFromFile(string filePath)
        {
            List<string> temp = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream) temp.Add(sr.ReadLine());
            }
            return temp;
        }
        
        /**
         * Provide a path of directory, to get all files from it
         * 
         */
        public static string[] GetFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new string[] { };
        }
        public static void Delete(string filePath)
        {
            try
            {
                if (File.Exists(filePath)) File.Delete(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
