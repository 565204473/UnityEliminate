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

        SerializeHelper.SerializeBinary(this.saveSetting.path, "我也是醉了");
        Debug.LogError("要写入文件的int" + (int)value);
      
    }

    public void WriteString(string value) {
        Debug.LogError("要写入文件的string" + value);
    }

    public void Dispose() {


    }
}
