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
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveInt) is int) {
            return (int)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveInt);
        }
        NoHasKeyHint();
        return 1;
    }

    public long ReadLong() {

        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveLong) is long) {
            return (long)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveLong);
        }
        NoHasKeyHint();

        return 0;
    }

    public string ReadString() {

        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveString) is string) {
            return (string)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveString);
        }
        NoHasKeyHint();
        return string.Empty;
    }


    public float ReadFolat() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveFolat) is float) {

            return (float)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveFolat);
        }
        NoHasKeyHint();
        return 0.1f;
    }


    public bool ReadBool() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveBool) is bool) {
            return (bool)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveBool);
        }
        NoHasKeyHint();
        return false;
    }

    public Vector2 ReadVector2() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector2) is Vector2) {
            return (Vector2)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector2);
        }
        NoHasKeyHint();
        return Vector2.zero;
    }

    public Vector3 ReadVector3() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector3) is Vector3) {
            return (Vector3)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector3);
        }
        NoHasKeyHint();
        return Vector3.one;
    }

    public Vector4 ReadVector4() {

        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector4) is Vector4) {
            return (Vector4)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveVector4);
        }
        NoHasKeyHint();
        return Vector4.one;
    }


    public Quaternion ReadQuaternion() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveQuaternion) is Quaternion) {
            return (Quaternion)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveQuaternion);
        }
        NoHasKeyHint();
        return Quaternion.identity;
    }


    public Color ReadColor() {
        if (SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveColor) is Color) {
            return (Color)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveColor);
        }
        NoHasKeyHint();
        return Color.black;
    }

    private object SelectReadType(SaveImplementType type, EnumSaveTypeKey keyType) {
        switch (type) {
            case SaveImplementType.ImplementByte:
                Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
                if (stream != null) {
                    var data = SerializeHelper.DeserializeBinary(stream);
                    if (data != null) {
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return (int)data;
                            case EnumSaveTypeKey.SaveLong:
                                return (long)data;
                            case EnumSaveTypeKey.SaveFolat:
                                return (float)data;
                            case EnumSaveTypeKey.SaveString:
                                return (string)data;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data;
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

                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementJson:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
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
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.SaveValue.ToString());
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
                            //case EnumSaveTypeKey.SaveInt:
                            //    return (int)data.SaveValue;
                            //case EnumSaveTypeKey.SaveFolat:
                            //    return (float)data.SaveValue;
                            //case EnumSaveTypeKey.SaveString:
                            //    return (string)data.SaveValue;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data.SaveValue;
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
                        case EnumSaveTypeKey.SaveBool:
                            var dataBool = SerializeHelper.DeserializeXML<bool>(saveSetting.path);
                            if (dataBool == null) {
                                return null;
                            }
                            return (bool)dataBool;
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
                            Debug.LogError(dataColor + "****");
                            if (dataColor == null) {
                                return null;
                            }
                            return StringExtention.GetValue<Color>(dataColor.ConverToString());
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
