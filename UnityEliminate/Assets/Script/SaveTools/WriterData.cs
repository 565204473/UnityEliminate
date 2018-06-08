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
        SelectWriteType(saveSetting.saveImplementType, value);

    }

    public void WriteString(string value)
    {
        SelectWriteType(saveSetting.saveImplementType, value);
    }


    public void WriteFloat(object value)
    {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteBool(bool value)
    {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteVector2(Vector2 value)
    {
        string stringValue = StringExtention.Vector2ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }


    public void WriteVector3(Vector3 value)
    {
        string stringValue = StringExtention.Vector3ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteVector4(Vector4 value)
    {
        string stringValue = StringExtention.Vector4ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }


    private void SelectWriteType(SaveImplementType type, object value)
    {
        switch (this.saveSetting.saveImplementType)
        {
            case SaveImplementType.ImplementByte:
                SerializeHelper.SerializeBinary(this.saveSetting.path, value);
                break;
            case SaveImplementType.ImplementJson:
                Debug.LogFormat(value.ConverToString());
                var tempJson = new JsonTestFloat { Savekey = this.saveSetting.filenameData.tag, SaveValue = value };
                tempJson.SaveJson(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementProto:
                var tempProto = new ProtoBufSave
                {
                    Savekey = this.saveSetting.filenameData.tag,
                    SaveValue = (bool)value
                };
                tempProto.SaveProtoBuff(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementXML:
                SerializeHelper.SerializeXML(this.saveSetting.path, value);
                break;
        }
    }

    public void Dispose()
    {
        saveSetting = null;
    }
}
