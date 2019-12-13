using System.Collections.Generic;
using CommonLibrary.DataDTO;

namespace CommonLibrary.Transformators
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

        public Dictionary<int, DataNumberDTO_5x5> GetData()
        {
            var data = new Dictionary<int, DataNumberDTO_5x5>();
            var images = System.IO.Directory.GetFiles(_path, _fileExt);
            return data;
        }
    }
}