using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriterData : IDisposable
{

    private SaveSetting saveSetting;
    public WriterData(SaveSetting data)
    {
        this.saveSetting = data;

    }

    public void WriteInt(int value)
    {

        //  SerializeHelper.SerializeBinary(this.saveSetting.path, value);
        SerializeHelper.SerializeXML(this.saveSetting.path, value);
        Debug.LogError("要写入文件的int" + (int)value);

    }

    public void WriteString(string value)
    {
        SerializeHelper.SerializeBinary(this.saveSetting.path, value);
        //  SerializeHelper.SerializeXML(this.saveSetting.path, value);
        Debug.LogError("要写入文件的string" + value);
    }


    public void WriteFloat(object value)
    {

        var tempJson = new JsonTestFloat { Savekey = this.saveSetting.filenameData.tag, SaveValue = value };
        tempJson.SaveJson(this.saveSetting.path);
        Debug.LogError("要写入文件的float" + (float)value);
    }

    public void WriteBool(bool value)
    {
        var tempProto = new ProtoBufSave
        {
            saveKey = this.saveSetting.filenameData.tag,
            savevalue = value
        };
        Debug.LogError("要写入文件的bool" + value);
        tempProto.SaveProtoBuff(this.saveSetting.path);

    }

    public void Dispose()
    {


    }
}
