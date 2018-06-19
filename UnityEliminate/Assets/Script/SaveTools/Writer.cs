using System;
using System.Collections;
using System.Collections.Generic;
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

    public static Writer Create(string settings) {

        return new Writer(settings);
    }

    public static Writer Create(SaveSetting setting) {
        return new Writer(setting);
    }


    public void Write<T>(T param) {
        this.Write<T>(param, StoredataTypeMgr.GetStoredataType(param.GetType()));
    }

    public void Write<T>(T param, StoredataType type) {
        if (type == null) {
            Debug.LogError("SaveType " + param.GetType().ToString() + ".");
        }
        else {
            type.Write(param, this);
        }
    }

    public void Write<T>(T param, string tag) {
        StoredataType valueType = StoredataTypeMgr.GetStoredataType(param.GetType());
        this.Write<T>(param, valueType);
    }

    public void Dispose() {

    }
}
