using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriterData : IDisposable {

    private SaveSetting saveSetting;
    public WriterData(SaveSetting data) {
        this.saveSetting = data;
    }

    public void WriteInt(int value) {
        Debug.LogError("要写入文件的int" + (int)value);
        SelectWriteType(saveSetting.saveImplementType, value);

    }

    public void WriteString(string value) {
        Debug.LogError("要写入文件的string" + value);
        SelectWriteType(saveSetting.saveImplementType, value);
    }


    public void WriteFloat(object value) {
        Debug.LogError("要写入文件的float" + (float)value);
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteBool(bool value) {
        Debug.LogError("要写入文件的bool" + value);
        SelectWriteType(saveSetting.saveImplementType, value);
    }


    private void SelectWriteType(SaveImplementType type, object value) {
        switch (this.saveSetting.saveImplementType) {
            case SaveImplementType.ImplementByte:
                SerializeHelper.SerializeBinary(this.saveSetting.path, value);
                break;
            case SaveImplementType.ImplementJson:
                var tempJson = new JsonTestFloat { Savekey = this.saveSetting.filenameData.tag, SaveValue = value };
                tempJson.SaveJson(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementProto:
                var tempProto = new ProtoBufSave {
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

    public void Dispose() {
        saveSetting = null;
    }
}
