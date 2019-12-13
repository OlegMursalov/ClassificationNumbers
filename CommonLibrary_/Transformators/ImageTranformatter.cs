using System.Collections.Generic;

namespace GeneratingDataFromImages.Transformators
{
    public class ImageTranformatter
    {
        private string _path;
        private string _fileExt;

        public ImageTranformatter(string path, string fileExt)
        {
            _path = path;
            _fileExt = fileExt;
        }

        /*public Dictionary<int, DataNumberDTO_5x5> x()
        {
            var images = Directory.GetFiles(path, fileExt);
        }*/
    }
}