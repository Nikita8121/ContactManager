using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class JsonService
    {
        private readonly string _filePath;

        public JsonService(string filePath)
        {
            _filePath = filePath;
        }

        public T Get<T>()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"File not found at path: {_filePath}");
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Write<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
