﻿using Newtonsoft.Json;

namespace DbService {
    public class JsonSave<T> {

        string filePath;

        public JsonSave(string fileName) {
            filePath = Environment.CurrentDirectory + "/" + fileName;
        }

        public void SaveData(object data, bool append = false) {
            var setting = new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            };

            var format = Formatting.Indented;

            string? text = JsonConvert.SerializeObject(data, format, setting);

            using (StreamWriter sw = new StreamWriter(filePath, append)) {
                sw.WriteLine(text);
            }
        }

        public List<T> GetData() {
            var setting = new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            };

            if (!File.Exists(filePath)) {
                using (FileStream fs = new FileStream(filePath, FileMode.Create)) { }
            }
            string text = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<T>>(text, setting);
            if (list is null) 
                return new List<T>();
            return list;
        }
    }
}