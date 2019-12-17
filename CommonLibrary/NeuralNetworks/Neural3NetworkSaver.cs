using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CommonLibrary.NeuralNetworks
{
    /// <summary>
    /// Сохраняет простую трехслойную нейросеть в JSON файл
    /// </summary>
    public class Neural3NetworkSaver
    {
        private Neural3NetworkCreator _neural3NetworkCreator;

        public Neural3NetworkSaver(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
        }

        public void Save(Stream stream, out string exMessage)
        {
            exMessage = string.Empty;
            var jsonStr = string.Empty;
            try
            {
                var ms = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(Neural3NetworkCreator));
                serializer.WriteObject(ms, _neural3NetworkCreator);
                var bytes = ms.ToArray();
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
        }
    }
}