using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WriterData : IDisposable {

    private SaveSetting saveSetting;
    public WriterData(SaveSetting data) {
        this.saveSetting = data;
    }

    public void WriterValue(EnumSaveTypeKey type, object value) {
        string strValue = string.Empty;
        switch (type) {
            case EnumSaveTypeKey.SaveInt:
            case EnumSaveTypeKey.SaveLong:
            case EnumSaveTypeKey.SaveString:
            case EnumSaveTypeKey.SaveFolat:
            case EnumSaveTypeKey.SaveDouble:
            case EnumSaveTypeKey.SaveBool:
            case EnumSaveTypeKey.SaveShort:
            case EnumSaveTypeKey.SaveUint:
            case EnumSaveTypeKey.SaveUlong:
            case EnumSaveTypeKey.SaveUshort:
            case EnumSaveTypeKey.SaveChar:
            case EnumSaveTypeKey.SaveDateTime:
                SelectWriteType(saveSetting.saveImplementType, value);
                break;
            case EnumSaveTypeKey.SaveVector2:
                strValue = StringExtention.Vector2ToString((Vector2)value);
                break;
            case EnumSaveTypeKey.SaveVector3:
                strValue = StringExtention.Vector3ToString((Vector3)value);
                break;
            case EnumSaveTypeKey.SaveVector4:
                strValue = StringExtention.Vector4ToString((Vector4)value);
                break;
            case EnumSaveTypeKey.SaveQuaternion:
                strValue = StringExtention.QuaternionToString((Quaternion)value);
                break;
            case EnumSaveTypeKey.SaveColor:
                strValue = StringExtention.ColorToString((Color)value);
                break;
            case EnumSaveTypeKey.SaveEnum:
            case EnumSaveTypeKey.SaveList:
            case EnumSaveTypeKey.SaveDictionary:
            case EnumSaveTypeKey.Savebyte:
            case EnumSaveTypeKey.SaveHashtable:
            case EnumSaveTypeKey.SaveArrayList:
                strValue = StringExtention.ConverToString(value);
                break;
            case EnumSaveTypeKey.SaveArray:
                strValue = StringExtention.ArrConvertToString((Array)value);
                break;
        }

        if (!string.IsNullOrEmpty(strValue)) {
            SelectWriteType(saveSetting.saveImplementType, strValue);
        }
    }

    private void SelectWriteType(SaveImplementType type, object value) {
        byte[] tx = Encoding.UTF8.GetBytes(value.ConverToString());
        byte[] txEncrypt = EncryptHelp.AESEncrypt(tx, SaveDefaultData.EncryptKey, SaveDefaultData.EncryptValue);

        switch (saveSetting.saveImplementType) {
            case SaveImplementType.ImplementByte:
                if (txEncrypt != null) {
                    SerializeHelper.SerializeBinary(saveSetting.path, txEncrypt);
                }
                break;
            case SaveImplementType.ImplementJson:
                var tempJson = new JsonTestFloat { Savekey = this.saveSetting.filenameData.tag, SaveValue = txEncrypt };
                tempJson.SaveJson(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementProto:
                var tempProto = new ProtoBufSave {
                    Savekey = this.saveSetting.filenameData.tag,
                    SaveValue = (int)value
                };
                tempProto.SaveProtoBuff(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementXML:
                SerializeHelper.SerializeXML(this.saveSetting.path, txEncrypt);
                break;
        }
    }

    public void Dispose() {
        saveSetting = null;
    }
}
