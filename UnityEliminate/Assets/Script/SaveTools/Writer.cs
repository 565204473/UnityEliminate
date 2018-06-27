using System;
using UnityEngine;

public class Writer : IDisposable {
    public WriterData writerData;
    private SaveSetting saveData;
    public Writer(string settings) {

    }

    public Writer(SaveSetting saveSetting) {
        saveData = saveSetting;
        writerData = new WriterData(saveData);
    }


    public static Writer Create(SaveSetting setting) {
        return new Writer(setting);
    }


    public void Write<T>(T param, string tag) {
        StoredataType valueType = StoredataTypeMgr.GetStoredataType(param.GetType());
        if (valueType == null) {
            Debug.LogError("SaveType " + param.GetType().ToString() + ".");
        }
        else {
            valueType.Write(param, this);
        }
    }

    public void Dispose() {
        writerData = null;
    }
}
