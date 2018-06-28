namespace QFramework {
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    public static class SerializeHelper {
        public static bool SerializeBinary(string path, object obj) {
            if (string.IsNullOrEmpty(path)) {
                Log.W("SerializeBinary Without Valid Path.");
                return false;
            }

            if (obj == null) {
                Log.W("SerializeBinary obj is Null.");
                return false;
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
               // fs.Close();              
                return true;
            }
        }

        public static object DeserializeBinary(Stream stream) {
            if (stream == null) {
                Log.W("DeserializeBinary Failed!");
                return null;
            }

            using (stream) {
                BinaryFormatter bf = new BinaryFormatter();
                var data = bf.Deserialize(stream);
                // TODO:这里没风险嘛?
                return data;
            }
        }

        public static object DeserializeBinary(string path) {
            if (string.IsNullOrEmpty(path)) {
                Log.W("DeserializeBinary Without Valid Path.");
                return null;
            }

            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists) {
                Log.W("DeserializeBinary File Not Exit.");
                return null;
            }

            using (FileStream fs = fileInfo.OpenRead()) {
                BinaryFormatter bf = new BinaryFormatter();
                object data = bf.Deserialize(fs);
               // fs.Close();               
                if (data != null) {
                    byte[] txEncrypt = EncryptHelp.AESDecrypt((Byte[])data, SaveDefaultData.EncryptKey, SaveDefaultData.EncryptValue);
                    object str = Encoding.UTF8.GetString(txEncrypt);
                    return str;
                    //return data;
                }
            }

            Log.W("DeserializeBinary Failed:" + path);
            return null;
        }

        public static bool SerializeXML(string path, object obj) {
            if (string.IsNullOrEmpty(path)) {
                Log.W("SerializeBinary Without Valid Path.");
                return false;
            }

            if (obj == null) {
                Log.W("SerializeBinary obj is Null.");
                return false;
            }

            using (var fs = new FileStream(path, FileMode.OpenOrCreate)) {
                var xmlserializer = new XmlSerializer(obj.GetType());
                xmlserializer.Serialize(fs, obj);
                return true;
            }
        }

        public static object DeserializeXML<T>(string path) {
            if (string.IsNullOrEmpty(path)) {
                Log.W("DeserializeBinary Without Valid Path.");
                return null;
            }

            FileInfo fileInfo = new FileInfo(path);
            using (FileStream fs = fileInfo.OpenRead()) {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                object data = xmlserializer.Deserialize(fs);

                if (data != null) {
                    byte[] txEncrypt = EncryptHelp.AESDecrypt((Byte[])data, SaveDefaultData.EncryptKey, SaveDefaultData.EncryptValue);
                    object str = Encoding.UTF8.GetString(txEncrypt);
                    return str;
                    //return data;
                }
            }

            Log.W("DeserializeBinary Failed:" + path);
            return null;
        }

        public static string ToJson<T>(this T obj) where T : class {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T FromJson<T>(this string json) where T : class {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void SaveJson<T>(this T obj, string path) where T : class {
            File.WriteAllText(path, obj.ToJson<T>());
        }

        public static T LoadJson<T>(string path) where T : class {
            return File.ReadAllText(path).FromJson<T>();
        }

        public static byte[] ToProtoBuff<T>(this T obj) where T : class {
            using (MemoryStream ms = new MemoryStream()) {
                ProtoBuf.Serializer.Serialize<T>(ms, obj);
                return ms.ToArray();
            }
        }

        public static T FromProtoBuff<T>(this byte[] bytes) where T : class {
            if (bytes == null || bytes.Length == 0) {
                throw new System.ArgumentNullException("bytes");
            }
            T t = ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(bytes));
            return t;
        }

        public static void SaveProtoBuff<T>(this T obj, string path) where T : class {
            File.WriteAllBytes(path, obj.ToProtoBuff<T>());
        }

        public static T LoadProtoBuff<T>(string path) where T : class {
            return File.ReadAllBytes(path).FromProtoBuff<T>();
        }
    }
}