using CommonLibrary.Transformators;
using System.Configuration;
using System.Collections.Generic;
using GeneratingDataFromImages.Savers;
using System;
using System.IO;

namespace GeneratingDataFromImages
{
    class Program
    {
        static void Main()
        {
            var exMessage = string.Empty; 
            var errors = new Dictionary<string, string>();
            var path = ConfigurationManager.AppSettings["path"];
            var fileExt = ConfigurationManager.AppSettings["fileExt"];
            var finishPath = ConfigurationManager.AppSettings["finishPath"];
            var outputFileName = ConfigurationManager.AppSettings["outputFileName"];

            var imageTransformatter28x28 = new ImageTranformatter28x28(path, fileExt);
            var data = imageTransformatter28x28.GetData(ref errors);

            if (errors.Count > 0)
            {
                Console.WriteLine("Ошибки при извлечении данных из изображений:");
                foreach (var item in errors)
                {
                    Console.WriteLine($"file name - {item.Key}, ex message - {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("Вытаскивание данных из изображений прошло без ошибок");
            }

            var fileName = Path.Combine(finishPath, outputFileName);
            var jsonDataSaver = new JsonDataSaver(fileName);
            jsonDataSaver.Save(data, ref exMessage);

            if (!string.IsNullOrEmpty(exMessage))
            {
                Console.WriteLine($"Ошибка при сохранении данных - {exMessage}");
            }
            else
            {
                Console.WriteLine($"Данные об картинках 28x28 pixels успешно сохранены в файл {fileName}");
            }

            Console.ReadKey();
        }
    }
}