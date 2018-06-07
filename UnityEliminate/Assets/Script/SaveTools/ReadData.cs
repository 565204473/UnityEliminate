using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadData : IDisposable
{
    private SaveSetting saveSetting;
    public ReadData(SaveSetting data)
    {
        saveSetting = data;
    }

    public Int32 ReadInt32()
    {
        return (int)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveInt);
    }

    public string ReadString()
    {
        return (string)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveString);
    }


    public float ReadFolat()
    {
        return (float)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveFolat);
    }


    public bool ReadBool()
    {
        return (bool)SelectReadType(saveSetting.saveImplementType, EnumSaveTypeKey.SaveBool);
    }


    private object SelectReadType(SaveImplementType type, EnumSaveTypeKey keyType)
    {
        switch (type)
        {

            case SaveImplementType.ImplementByte:
                Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
                if (stream != null)
                {
                    var data = SerializeHelper.DeserializeBinary(stream);
                    if (data != null)
                    {
                        Debug.LogError(data.ConverToString());
                        switch (keyType)
                        {
                            case EnumSaveTypeKey.SaveInt:
                                return (int)data;
                            case EnumSaveTypeKey.SaveFolat:
                                return (float)data;
                            case EnumSaveTypeKey.SaveString:
                                return (string)data;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data;
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementJson:
                if (!string.IsNullOrEmpty(saveSetting.path))
                {
                    var data = SerializeHelper.LoadJson<JsonTestFloat>(this.saveSetting.path);
                    if (data != null)
                    {
                        // Debug.LogError(float.Parse(data.SaveValue.ToString()));
                        switch (keyType)
                        {
                            case EnumSaveTypeKey.SaveInt:
                                return int.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveFolat:
                                return float.Parse(data.SaveValue.ToString());
                            case EnumSaveTypeKey.SaveString:
                                return data.SaveValue.ToString();
                            case EnumSaveTypeKey.SaveBool:
                                return bool.Parse(data.SaveValue.ToString());
                        }
                        return null;
                    }
                }
                break;
            case SaveImplementType.ImplementProto:
                if (!string.IsNullOrEmpty(saveSetting.path))
                {
                    var data = SerializeHelper.LoadProtoBuff<ProtoBufSave>(saveSetting.path);
                    if (data != null)
                    {
                        Debug.LogError((bool)data.SaveValue);
                        switch (keyType)
                        {
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
                if (!string.IsNullOrEmpty(saveSetting.path))
                {
                    var data = SerializeHelper.DeserializeXML<int>(saveSetting.path);
                    if (data != null)
                    {
                        Debug.LogError(data);
                        switch (keyType)
                        {
                            case EnumSaveTypeKey.SaveInt:
                                return (int)data;
                            case EnumSaveTypeKey.SaveFolat:
                                return (float)data;
                            case EnumSaveTypeKey.SaveString:
                                return (string)data;
                            case EnumSaveTypeKey.SaveBool:
                                return (bool)data;
                        }
                        return null;
                    }
                }
                break;
        }
        return null;
    }


    public void Dispose()
    {
    }
}
