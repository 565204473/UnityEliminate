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

    private object SelectReadType(SaveImplementType type, EnumSaveTypeKey keyType) {
        switch (type) {

            case SaveImplementType.ImplementByte:
                Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
                if (stream != null) {
                    var data = SerializeHelper.DeserializeBinary(stream);
                    if (data != null) {
                        // Debug.LogError(data.ConverToString());
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return (int)data;
                            case EnumSaveTypeKey.SaveFolat:
                                return (float)data;
                            case EnumSaveTypeKey.SaveString:
                                return (string)data;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data;
                            case EnumSaveTypeKey.SaveVector2:
                                return StringExtention.GetValue<Vector2>(data.ConverToString());
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
                            case EnumSaveTypeKey.SaveFolat:
                                return float.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveString:
                                return data.SaveValue.ToString();
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveVector2:
                                return StringExtention.GetValue<Vector2>(data.SaveValue.ConverToString());
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementProto:
                if (!string.IsNullOrEmpty(saveSetting.path)) {
                    var data = SerializeHelper.LoadProtoBuff<ProtoBufSave>(saveSetting.path);
                    if (data != null) {
                        // Debug.LogError((bool)data.SaveValue);
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
                    var data = SerializeHelper.DeserializeXML<string>(saveSetting.path);
                    if (data != null) {
                        //  Debug.LogError(data);
                        switch (keyType) {
                            case EnumSaveTypeKey.SaveInt:
                                return (int)data;
                            case EnumSaveTypeKey.SaveFolat:
                                return (float)data;
                            case EnumSaveTypeKey.SaveString:
                                return (string)data;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data;
                            case EnumSaveTypeKey.SaveVector2:
                                return StringExtention.GetValue<Vector2>(data.ConverToString());
                        }
                        return null;
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
    }
}
