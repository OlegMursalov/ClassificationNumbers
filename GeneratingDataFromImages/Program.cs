using CommonLibrary.Transformators;
using System.Configuration;

namespace GeneratingDataFromImages
{
    class Program
    {
        static void Main()
        {
            var path = ConfigurationManager.AppSettings["path"];
            var fileExt = ConfigurationManager.AppSettings["fileExt"];
            var imageTransformatter = new ImageTranformatter(path, fileExt);
            var data = imageTransformatter.GetData28x28();
        }
    }
}