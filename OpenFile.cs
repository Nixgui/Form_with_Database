using System.IO;
using System.Windows.Forms;

namespace FromTund
{
    public class OpenFile
    {
        Resourse set = new Resourse();
        
        public string openFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open Image";
            openFile.Filter = "Image Files|*.jpg|Image File|*.png|All Files|*.*";
            openFile.InitialDirectory = set.GetResourcesFolder();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                string filename = Path.GetFileName(filePath);
                return filename;
            }
            else
            {
                return null;
            }
            
        }
        
    }
}