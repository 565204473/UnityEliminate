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
        //Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
        //if (stream != null)
        //{
        //    var data = SerializeHelper.DeserializeBinary(stream);

        //    if (data != null)
        //    {
        //        Debug.LogError(data.ConverToString());
        //        return 1;
        //    }
        //}

        string path = this.saveSetting.path;
        if (!string.IsNullOrEmpty(path)) {
            var data = SerializeHelper.DeserializeXML<int>(path);
            if (data != null) {

                Debug.LogError(data.ConverToString());
                return 1;
            }
        }
        return 1;
    }

    public string ReadString() {
        Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
        if (stream != null) {
            var data = SerializeHelper.DeserializeBinary(stream);
            if (data != null) {
                Debug.LogError(data.ConverToString());
                return data.ConverToString();
            }
        }
        return string.Empty;
    }


    public float ReadFolat() {
        string path = this.saveSetting.path;
        if (!string.IsNullOrEmpty(path)) {
            var data = SerializeHelper.LoadJson<JsonTestFloat>(this.saveSetting.path);
            Debug.LogError(float.Parse(data.SaveValue.ToString()));
            return float.Parse(data.SaveValue.ToString());

        }
        return 0.1f;
    }


    public bool ReadBool() {

        string path = this.saveSetting.path;
        if (!string.IsNullOrEmpty(path)) {
            var data = SerializeHelper.LoadProtoBuff<ProtoBufSave>(path);
            Debug.LogError((bool)data.savevalue);
            return true;
        }

        return false;

    }


    public void Dispose() {
    }
}
