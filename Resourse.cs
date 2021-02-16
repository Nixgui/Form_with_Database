using System;
using System.IO;

namespace FromTund
{
    public class Resourse
    {
        private string ResourcesFolder;

        public Resourse()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin",StringComparison.Ordinal);
            string binFolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();
            ResourcesFolder = binFolder + "image\\";
        }

        public string GetResourcesFolder()
        {
            return ResourcesFolder;
        }
    }
}