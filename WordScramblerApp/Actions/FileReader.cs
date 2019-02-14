using System;
using System.IO;

namespace WordScramblerApp.Actions
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileName);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return fileContent;
        }
    }
}
