using Newtonsoft.Json;
using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

public class ReadData : IDisposable {
    private SaveSetting saveSetting;
    public ReadData(SaveSetting data) {
        saveSetting = data;
    }

    public object ReadValue(EnumSaveTypeKey type) {

        switch (type) {
            case EnumSaveTypeKey.SaveString:
                return ReadString();
            case EnumSaveTypeKey.SaveInt:
                return ReadInt32();
            case EnumSaveTypeKey.SaveBool:
                return ReadBool();
            case EnumSaveTypeKey.SaveFolat:
                return ReadFolat();
            case EnumSaveTypeKey.SaveVector2:
                return ReadVector2(Vector2.one);
            case EnumSaveTypeKey.SaveVector3:
                return ReadVector3(Vector3.one);
            case EnumSaveTypeKey.SaveVector4:
                return ReadVector4(Vector4.one);
            case EnumSaveTypeKey.SaveQuaternion:
                return ReadQuaternion(Quaternion.identity);
            case EnumSaveTypeKey.SaveColor:
                return ReadColor(Color.black);
            case EnumSaveTypeKey.SaveDouble:
                return ReadDouble();
            case EnumSaveTypeKey.SaveEnum:
                return ReadEnum(TestEnum.One);
            case EnumSaveTypeKey.SaveList:
                return ReadList(string.Empty);
            case EnumSaveTypeKey.SaveDictionary:
                return ReadDictionary(string.Empty);
            case EnumSaveTypeKey.Savebyte:
                return ReadByte();
            case EnumSaveTypeKey.SaveShort:
                return ReadShort();
            case EnumSaveTypeKey.SaveUint:
                return ReadUint();
            case EnumSaveTypeKey.SaveUlong:
                return ReadUlong();
            case EnumSaveTypeKey.SaveUshort:
                return ReadUshort();
            case EnumSaveTypeKey.SaveChar:
                return ReadChar();
            case EnumSaveTypeKey.SaveDateTime:
                return ReadDateTime(DateTime.Now);
            case EnumSaveTypeKey.SaveArray:
                Array array = new Array[1];
                return ReadArray(array);
            case EnumSaveTypeKey.SaveHashtable:
                Hashtable hs = new Hashtable();
                return ReadHashtable(hs);
            case EnumSaveTypeKey.SaveArrayList:
                ArrayList df = new ArrayList();
                return ReadArrayList(df);
        }
        return null;
    }


    public object ReadValue(EnumSaveTypeKey type, object defaultValue) {

        switch (type) {
            case EnumSaveTypeKey.SaveString:
                return ReadString((string)defaultValue);
            case EnumSaveTypeKey.SaveInt:
                return ReadInt32((int)defaultValue);
            case EnumSaveTypeKey.SaveBool:
                return ReadBool((bool)defaultValue);
            case EnumSaveTypeKey.SaveFolat:
                return ReadFolat((float)defaultValue);
            case EnumSaveTypeKey.SaveVector2:
                return ReadVector2((Vector2)defaultValue);
            case EnumSaveTypeKey.SaveVector3:
                return ReadVector3((Vector3)defaultValue);
            case EnumSaveTypeKey.SaveVector4:
                return ReadVector4((Vector4)defaultValue);
            case EnumSaveTypeKey.SaveQuaternion:
                return ReadQuaternion((Quaternion)defaultValue);
            case EnumSaveTypeKey.SaveColor:
                return ReadColor((Color)defaultValue);
            case EnumSaveTypeKey.SaveDouble:
                return ReadDouble((double)defaultValue);
            case EnumSaveTypeKey.SaveEnum:
                return ReadEnum((Enum)defaultValue);
            case EnumSaveTypeKey.SaveList:
                return ReadList(defaultValue);
            case EnumSaveTypeKey.SaveDictionary:
                return ReadDictionary(defaultValue);
            case EnumSaveTypeKey.Savebyte:
                return ReadByte((byte)defaultValue);
            case EnumSaveTypeKey.SaveShort:
                return ReadShort((short)defaultValue);
            case EnumSaveTypeKey.SaveUint:
                return ReadUint((uint)defaultValue);
            case EnumSaveTypeKey.SaveUlong:
                return ReadUlong((ulong)defaultValue);
            case EnumSaveTypeKey.SaveUshort:
                return ReadUshort((ushort)defaultValue);
            case EnumSaveTypeKey.SaveChar:
                return ReadChar((char)defaultValue);
            case EnumSaveTypeKey.SaveDateTime:
                return ReadDateTime((DateTime)defaultValue);
            case EnumSaveTypeKey.SaveArray:
                return ReadArray((Array)defaultValue);
            case EnumSaveTypeKey.SaveHashtable:
                return ReadHashtable((Hashtable)defaultValue);
            case EnumSaveTypeKey.SaveArrayList:
                return ReadArrayList((ArrayList)defaultValue);
        }
        return null;
    }


    private Int32 ReadInt32(int def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveInt);
        if (dt is int) {
            return (int)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private long ReadLong(long def = 0) {

        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveLong);
        if (dt is long) {
            return (long)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private string ReadString(string def = "默认值") {

        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveString);
        if (dt is string) {
            return (string)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private float ReadFolat(float def = 0.1f) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveFolat);
        if (dt is float) {

            return (float)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private double ReadDouble(double def = 0.1f) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDouble);
        if (dt is double) {
            return (double)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private bool ReadBool(bool def = false) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveBool);
        if (dt is bool) {
            return (bool)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Vector2 ReadVector2(Vector2 def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector2);
        if (dt is Vector2) {
            return (Vector2)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Vector3 ReadVector3(Vector3 def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector3);
        if (dt is Vector3) {
            return (Vector3)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Vector4 ReadVector4(Vector4 def) {

        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector4);
        if (dt is Vector4) {
            return (Vector4)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private Quaternion ReadQuaternion(Quaternion def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveQuaternion);
        if (dt is Quaternion) {
            return (Quaternion)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private Color ReadColor(Color def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveColor);
        if (dt is Color) {
            return (Color)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Enum ReadEnum(Enum def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveEnum);
        if (dt is Enum) {
            return (Enum)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private object ReadList(object def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveList);
        if (dt != null && dt.GetType().IsGenericType) {
            return dt;
        }
        NoHasKeyHint();
        return StringExtention.GetValue(def.ConverToString(), (Type)saveSetting.curObject); ;
    }

    private object ReadDictionary(object def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDictionary);
        if (dt != null && dt.GetType().IsGenericType) {
            return dt;
        }
        NoHasKeyHint();
        return StringExtention.GetValue(def.ConverToString(), (Type)saveSetting.curObject);
    }

    private byte ReadByte(Byte def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.Savebyte);
        if (dt is byte) {
            return (byte)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private short ReadShort(short def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveShort);
        if (dt is short) {
            return (short)dt;
        }
        NoHasKeyHint();
        return def;
    }


    private uint ReadUint(uint def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUint);
        if (dt is uint) {
            return (uint)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private ulong ReadUlong(ulong def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUlong);
        if (dt is ulong) {
            return (ulong)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private ushort ReadUshort(ushort def = 1) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUshort);
        if (dt is ushort) {
            return (ushort)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private char ReadChar(char def = 'A') {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveChar);
        if (dt is char) {
            return (char)dt;
        }
        NoHasKeyHint();
        return 'A';
    }

    private DateTime ReadDateTime(DateTime def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDateTime);
        if (dt is DateTime) {
            return (DateTime)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Array ReadArray(Array def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveArray);
        if (dt is Array) {
            return (Array)dt;
        }
        NoHasKeyHint();
        return def;
    }

    private Hashtable ReadHashtable(Hashtable def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveHashtable);
        Hashtable ha = new Hashtable();
        if (dt != null && dt.GetType().IsGenericType) {
            Dictionary<string, string> dic = (Dictionary<string, string>)dt;
            foreach (var item in dic) {
                string key = item.Key;
                string value = item.Value;
                ha.Add(key, value);

            }
            return ha;
        }
        NoHasKeyHint();
        return def;
    }

    private ArrayList ReadArrayList(ArrayList def) {
        var dt = ReadValue(saveSetting.saveImplementType, EnumSaveTypeKey.SaveArrayList);
        ArrayList arList = new ArrayList();
        if (dt != null) {
            List<string> ls = (List<string>)dt;
            foreach (var item in ls) {
                arList.Add(item);
            }
            return arList;
        }
        NoHasKeyHint();
        return def;
    }


    private object ReadValue(SaveImplementType type, EnumSaveTypeKey keyType) {
        switch (type) {
            case SaveImplementType.ImplementByte:
                Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
                if (stream != null) {
                    stream.Close();
                    var data = SerializeHelper.DeserializeBinary(this.saveSetting.path);
                    if (data != null) {
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return int.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveLong:
                                return long.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveFolat:
                                return float.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveString:
                                return data.ToString();
                            case EnumSaveTypeKey.SaveDouble:
                                return double.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.ToString());
                            case EnumSaveTypeKey.Savebyte:
                                return byte.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveShort:
                                return short.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveUint:
                                return uint.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveUlong:
                                return ulong.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveUshort:
                                return ushort.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveChar:
                                return char.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveVector2:
                                return StringExtention.GetValue<Vector2>(data.ConverToString());
                            case EnumSaveTypeKey.SaveVector3:
                                return StringExtention.GetValue<Vector3>(data.ConverToString());
                            case EnumSaveTypeKey.SaveVector4:
                                return StringExtention.GetValue<Vector4>(data.ConverToString());
                            case EnumSaveTypeKey.SaveQuaternion:
                                return StringExtention.GetValue<Quaternion>(data.ConverToString());
                            case EnumSaveTypeKey.SaveColor:
                                return StringExtention.GetValue<Color>(data.ConverToString());
                            case EnumSaveTypeKey.SaveEnum:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveList:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveDictionary:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject); ;
                            case EnumSaveTypeKey.SaveDateTime:
                                return DateTime.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveArray:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveHashtable:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveArrayList:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementJson:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    var data = SerializeHelper.LoadJson<JsonTestFloat>(this.saveSetting.path);
                    if (data != null) {
                        byte[] txEncrypt = EncryptHelp.AESDecrypt(data.SaveValue, SaveDefaultData.EncryptKey, SaveDefaultData.EncryptValue);
                        string str = Encoding.UTF8.GetString(txEncrypt);
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return int.Parse(str.ToString());
                            case EnumSaveTypeKey.SaveLong:
                                return long.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveFolat:
                                return float.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveString:
                                return data.SaveValue.ToString();
                            case EnumSaveTypeKey.SaveDouble:
                                return double.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.Savebyte:
                                return byte.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveShort:
                                return short.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveUint:
                                return uint.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveUlong:
                                return ulong.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveUshort:
                                return ushort.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveChar:
                                return char.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveVector2:
                                return StringExtention.GetValue<Vector2>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveVector3:
                                return StringExtention.GetValue<Vector3>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveVector4:
                                return StringExtention.GetValue<Vector4>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveQuaternion:
                                return StringExtention.GetValue<Quaternion>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveColor:
                                return StringExtention.GetValue<Color>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveEnum:
                                return StringExtention.GetValue(data.SaveValue.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveList:
                                return StringExtention.GetValue(str.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveDictionary:
                                return StringExtention.GetValue(str.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveDateTime:
                                return DateTime.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveArray:
                                return StringExtention.GetValue(data.SaveValue.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveHashtable:
                                return StringExtention.GetValue(data.SaveValue.ConverToString(), (Type)saveSetting.curObject);
                            case EnumSaveTypeKey.SaveArrayList:
                                return StringExtention.GetValue(data.SaveValue.ConverToString(), (Type)saveSetting.curObject);
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementProto:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    var data = SerializeHelper.LoadProtoBuff<ProtoBufSave>(saveSetting.path);
                    if (data != null) {
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return data.SaveValue;
                            //case EnumSaveTypeKey.SaveFolat:
                            //    return (float)data.SaveValue;
                            case EnumSaveTypeKey.SaveString:
                                return data.SaveValue.ToString();
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.SaveValue.ToString());
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementXML:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    switch (keyType) {
                        case EnumSaveTypeKey.SaveInt:
                            var dataInt = SerializeHelper.DeserializeXML<int>(saveSetting.path);
                            if (dataInt == null) {
                                return null;
                            }
                            return (int)dataInt;
                        case EnumSaveTypeKey.SaveLong:
                            var dataLong = SerializeHelper.DeserializeXML<long>(saveSetting.path);
                            if (dataLong == null) {
                                return null;
                            }
                            return (long)dataLong;
                        case EnumSaveTypeKey.SaveFolat:
                            var dataFolat = SerializeHelper.DeserializeXML<float>(saveSetting.path);
                            if (dataFolat == null) {
                                return null;
                            }
                            return (float)dataFolat;
                        case EnumSaveTypeKey.SaveString:
                            var dataString = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataString == null) {
                                return null;
                            }
                            return (string)dataString;
                        case EnumSaveTypeKey.SaveDouble:
                            var dataDouble = SerializeHelper.DeserializeXML<double>(saveSetting.path);
                            if (dataDouble == null) {
                                return null;
                            }
                            return (double)dataDouble;
                        case EnumSaveTypeKey.SaveBool:
                            var dataBool = SerializeHelper.DeserializeXML<bool>(saveSetting.path);
                            if (dataBool == null) {
                                return null;
                            }
                            return (bool)dataBool;
                        case EnumSaveTypeKey.Savebyte:
                            var dataByte = SerializeHelper.DeserializeXML<byte>(saveSetting.path);
                            if (dataByte == null) {
                                return null;
                            }
                            return byte.Parse(dataByte.ToString());
                        case EnumSaveTypeKey.SaveShort:
                            var dataShort = SerializeHelper.DeserializeXML<short>(saveSetting.path);
                            if (dataShort == null) {
                                return null;
                            }
                            return (short)dataShort;
                        case EnumSaveTypeKey.SaveUint:
                            var dataUint = SerializeHelper.DeserializeXML<uint>(saveSetting.path);
                            if (dataUint == null) {
                                return null;
                            }
                            return (uint)dataUint;
                        case EnumSaveTypeKey.SaveUlong:
                            var dataUlong = SerializeHelper.DeserializeXML<ulong>(saveSetting.path);
                            if (dataUlong == null) {
                                return dataUlong;
                            }
                            return (ulong)dataUlong;
                        case EnumSaveTypeKey.SaveUshort:
                            var dataUshort = SerializeHelper.DeserializeXML<ushort>(saveSetting.path);
                            if (dataUshort == null) {
                                return dataUshort;
                            }
                            return (ushort)dataUshort;
                        case EnumSaveTypeKey.SaveChar:
                            var dataChar = SerializeHelper.DeserializeXML<char>(saveSetting.path);
                            if (dataChar == null) {
                                return dataChar;
                            }
                            return (char)dataChar;

                        case EnumSaveTypeKey.SaveVector2:
                            var dataVector2 = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataVector2 == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Vector2>(dataVector2.ConverToString());
                        case EnumSaveTypeKey.SaveVector3:
                            var dataVector3 = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataVector3 == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Vector3>(dataVector3.ConverToString());
                        case EnumSaveTypeKey.SaveVector4:
                            var dataVector4 = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataVector4 == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Vector4>(dataVector4.ConverToString());
                        case EnumSaveTypeKey.SaveQuaternion:
                            var dataQuaternion = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataQuaternion == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Quaternion>(dataQuaternion.ConverToString());
                        case EnumSaveTypeKey.SaveColor:
                            var dataColor = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataColor == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Color>(dataColor.ConverToString());
                        case EnumSaveTypeKey.SaveEnum:
                            var dataEnum = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataEnum == null) {
                                return null;
                            }
                            return StringExtention.GetValue(dataEnum.ConverToString(), (Type)saveSetting.curObject);
                        case EnumSaveTypeKey.SaveList:

                            var dataList = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataList == null) {
                                return null;
                            }
                            return StringExtention.GetValue<List<object>>(dataList.ConverToString());
                        case EnumSaveTypeKey.SaveDictionary:
                            var dataDictionary = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                            if (dataDictionary == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Dictionary<object, object>>(dataDictionary.ConverToString());
                        case EnumSaveTypeKey.SaveDateTime:
                            var dataDateTime = SerializeHelper.DeserializeXML<DateTime>(saveSetting.path);
                            if (dataDateTime == null) {
                                return null;
                            }
                            return (DateTime)dataDateTime;
                        case EnumSaveTypeKey.SaveArray:
                            var dataArray = SerializeHelper.DeserializeXML<Array>(saveSetting.path);
                            if (dataArray == null) {
                                return null;
                            }
                            return StringExtention.GetValue(dataArray.ConverToString(), (Type)saveSetting.curObject);
                        case EnumSaveTypeKey.SaveHashtable:
                            var dataHashtable = SerializeHelper.DeserializeXML<Hashtable>(saveSetting.path);
                            if (dataHashtable == null) {
                                return null;
                            }
                            return StringExtention.GetValue(dataHashtable.ConverToString(), (Type)saveSetting.curObject);
                        case EnumSaveTypeKey.SaveArrayList:
                            var dataArrayList = SerializeHelper.DeserializeXML<ArrayList>(saveSetting.path);
                            if (dataArrayList == null) {
                                return null;
                            }
                            return StringExtention.GetValue(dataArrayList.ConverToString(), (Type)saveSetting.curObject);
                    }
                }
                break;
        }
        return null;
    }


    private void NoHasKeyHint() {
        Debug.LogError("传入的key有问题，请检查是否有这个key的文件或者是否先保存了，默认返回一个默认值给你了,文件保存路径：" + saveSetting.path);
    }


    public void Dispose() {
        saveSetting = null;
    }
}
