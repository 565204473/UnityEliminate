using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRead : IDisposable
{

    public SaveRead(string settings)
    {

    }

    public SaveRead(SaveSetting saveSetting)
    {

    }

    public static SaveRead Create(string settings)
    {
        return new SaveRead(settings);
    }

    public static SaveRead Create(SaveSetting setting)
    {
        return new SaveRead(setting);
    }


    public T Read<T>()
    {
        return Read<T>(SaveTypeMgr.GetSaveType(typeof(T)));
    }

    public T Read<T>(SaveType type)
    {
        if (type != null) {
            return (T)type.Read(this);
        }
        return default(T);
    }

    public T Read<T>(string tag)
    {
        SaveType expectedValue = SaveTypeMgr.GetSaveType(typeof(T));
        return this.Read<T>(expectedValue);
    }

    public void Dispose()
    {

    }
}
