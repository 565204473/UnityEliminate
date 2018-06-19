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
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteLong(long value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteString(string value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteFloat(object value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteDouble(double value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteBool(bool value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteVector2(Vector2 value) {
        string stringValue = StringExtention.Vector2ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }


    public void WriteVector3(Vector3 value) {
        string stringValue = StringExtention.Vector3ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteVector4(Vector4 value) {
        string stringValue = StringExtention.Vector4ToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteQuaternion(Quaternion value) {
        string stringValue = StringExtention.QuaternionToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteColor(Color value) {
        string stringValue = StringExtention.ColorToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteEnum(Enum value) {
        string stringValue = StringExtention.ConverToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteList<T>(List<T> value) {
        string stringValue = StringExtention.ListConvertToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteDictionary(Dictionary<object, object> value) {
        string stringValue = StringExtention.DictConvertToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }

    public void WriteByte(Byte value) {
        string stringValue = StringExtention.ConverToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }


    public void WriteShort(short value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteUint(uint value) {

        SelectWriteType(saveSetting.saveImplementType, value);
    }


    public void WriteUlong(ulong value) {

        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteUshort(ushort value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteChar(char value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }

    public void WriteDateTime(DateTime value) {
        SelectWriteType(saveSetting.saveImplementType, value);
    }


    public void WriteArray(Array value) {
        string stringValue = StringExtention.ArrConvertToString(value);
        SelectWriteType(saveSetting.saveImplementType, stringValue);
    }


    private void SelectWriteType(SaveImplementType type, object value) {
        switch (saveSetting.saveImplementType) {
            case SaveImplementType.ImplementByte:
                Debug.LogError(DateTime.Now.Millisecond + "Byte开始");
                SerializeHelper.SerializeBinary(this.saveSetting.path, value);
                break;
            case SaveImplementType.ImplementJson:
                var tempJson = new JsonTestFloat { Savekey = this.saveSetting.filenameData.tag, SaveValue = value };
                Debug.LogError(DateTime.Now.Millisecond + "***Json开始");
                tempJson.SaveJson(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementProto:
                var tempProto = new ProtoBufSave {
                    Savekey = this.saveSetting.filenameData.tag,
                    SaveValue = (string)value
                };
                UnityEngine.Debug.LogError(DateTime.Now.Millisecond + "**Proto开始");
                tempProto.SaveProtoBuff(this.saveSetting.path);
                break;
            case SaveImplementType.ImplementXML:
                Debug.LogError(DateTime.Now.Millisecond + "***Xml开始");
                SerializeHelper.SerializeXML(this.saveSetting.path, value);
                break;
        }
    }

    public void Dispose() {
        saveSetting = null;
    }
}
