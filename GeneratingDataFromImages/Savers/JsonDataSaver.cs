using CommonLibrary.DataDTO;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Runtime.Serialization.Json;

namespace GeneratingDataFromImages.Savers
{
    public class JsonDataSaver
    {
        private string _fileName;

        public JsonDataSaver(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(DataNumberDTO_28x28_Set[] data, ref string exMessage)
        {
            try
            {
                var ms = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(DataNumberDTO_28x28_Set[]));
                serializer.WriteObject(ms, data);

                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }
                using (var fs = File.Create(_fileName))
                {
                    var bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
        }
    }
}
