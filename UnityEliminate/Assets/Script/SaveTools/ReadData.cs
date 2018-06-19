using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadData : IDisposable {
    private SaveSetting saveSetting;
    public ReadData(SaveSetting data) {
        saveSetting = data;
    }

    public Int32 ReadInt32() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveInt);
        if (dt is int) {
            return (int)dt;
        }
        NoHasKeyHint();
        return 1;
    }

    public long ReadLong() {

        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveLong);
        if (dt is long) {
            return (long)dt;
        }
        NoHasKeyHint();

        return 0;
    }

    public string ReadString() {

        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveString);
        if (dt is string) {
            return (string)dt;
        }
        NoHasKeyHint();
        return string.Empty;
    }


    public float ReadFolat() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveFolat);
        if (dt is float) {

            return (float)dt;
        }
        NoHasKeyHint();
        return 0.1f;
    }


    public double ReadDouble() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDouble);
        if (dt is double) {
            return (double)dt;
        }
        NoHasKeyHint();
        return 0.1f;
    }


    public bool ReadBool() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveBool);
        if (dt is bool) {
            return (bool)dt;
        }
        NoHasKeyHint();
        return false;
    }

    public Vector2 ReadVector2() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector2);
        if (dt is Vector2) {
            return (Vector2)dt;
        }
        NoHasKeyHint();
        return Vector2.zero;
    }

    public Vector3 ReadVector3() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector3);
        if (dt is Vector3) {
            return (Vector3)dt;
        }
        NoHasKeyHint();
        return Vector3.one;
    }

    public Vector4 ReadVector4() {

        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector4);
        if (dt is Vector4) {
            return (Vector4)dt;
        }
        NoHasKeyHint();
        return Vector4.one;
    }


    public Quaternion ReadQuaternion() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveQuaternion);
        if (dt is Quaternion) {
            return (Quaternion)dt;
        }
        NoHasKeyHint();
        return Quaternion.identity;
    }


    public Color ReadColor() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveColor);
        if (dt is Color) {
            return (Color)dt;
        }
        NoHasKeyHint();
        return Color.black;
    }

    public Enum ReadEnum() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveEnum);
        if (dt is Enum) {
            return (Enum)dt;
        }
        NoHasKeyHint();
        return TestEnum.One;
    }

    public List<object> ReadList() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveList);
        if (dt is List<object>) {
            return (List<object>)dt;
        }
        NoHasKeyHint();
        return new List<object>();
    }

    public Dictionary<object, object> ReadDictionary() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDictionary);
        if (dt is Dictionary<object, object>) {
            return ((Dictionary<object, object>)dt);
        }
        NoHasKeyHint();
        return new Dictionary<object, object>();
    }

    public byte ReadByte() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.Savebyte);
        if (dt is byte) {
            return (byte)dt;
        }
        NoHasKeyHint();
        return 1;
    }

    public short ReadShort() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveShort);
        if (dt is short) {
            return (short)dt;
        }
        NoHasKeyHint();
        return 1;
    }


    public uint ReadUint() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUint);
        if (dt is uint) {
            return (uint)dt;
        }
        NoHasKeyHint();
        return 1;
    }

    public ulong ReadUlong() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUlong);
        if (dt is ulong) {
            return (ulong)dt;
        }
        NoHasKeyHint();
        return 1;
    }

    public ushort ReadUshort() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveUshort);
        if (dt is ushort) {
            return (ushort)dt;
        }
        NoHasKeyHint();
        return 1;
    }

    public char ReadChar() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveChar);
        if (dt is char) {
            return (char)dt;
        }
        NoHasKeyHint();
        return 'A';
    }

    public DateTime ReadDateTime() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveDateTime);
        if (dt is DateTime) {
            return (DateTime)dt;
        }
        NoHasKeyHint();
        return new DateTime();
    }

    public Array ReadArray() {
        var dt = SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveArray);
        if (dt is Array) {
            return (Array)dt;
        }
        NoHasKeyHint();
        return new Array[1];
    }

    private object SelectReadType(SaveImplementType type, EnumSaveTypeKey keyType) {
        switch (type) {
            case SaveImplementType.ImplementByte:
                Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
                if (stream != null) {
                    Debug.LogError(DateTime.Now.Millisecond + "读Byte开始");
                    var data = SerializeHelper.DeserializeBinary(stream);
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
                                return StringExtention.GetValue<List<object>>(data.ConverToString());
                            case EnumSaveTypeKey.SaveDictionary:
                                return StringExtention.GetValue<Dictionary<object, object>>(data.ConverToString());
                            case EnumSaveTypeKey.SaveDateTime:
                                return DateTime.Parse(data.ToString());
                            case EnumSaveTypeKey.SaveArray:
                                return StringExtention.GetValue(data.ConverToString(), (Type)saveSetting.curObject);

                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementJson:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    Debug.LogError(DateTime.Now.Millisecond + "读json开始");
                    var data = SerializeHelper.LoadJson<JsonTestFloat>(this.saveSetting.path);
                    if (data != null) {
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return int.Parse(data.SaveValue.ToString());
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
                                return StringExtention.GetValue<List<object>>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveDictionary:
                                return StringExtention.GetValue<Dictionary<object, object>>(data.SaveValue.ConverToString());
                            case EnumSaveTypeKey.SaveDateTime:
                                return DateTime.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveArray:
                                return StringExtention.GetValue<Array>(data.SaveValue.ConverToString());

                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementProto:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    Debug.LogError(DateTime.Now.Millisecond + "读proto开始");
                    var data = SerializeHelper.LoadProtoBuff<ProtoBufSave>(saveSetting.path);
                    if (data != null) {
                        switch (keyType) {
                            //case EnumSaveTypeKey.SaveInt:
                            //    return (int)data.SaveValue;
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
                            UnityEngine.Debug.LogError(DateTime.Now.Millisecond + "读**Xml开始");
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
                            return StringExtention.GetValue<Array>(dataArray.ConverToString());
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
