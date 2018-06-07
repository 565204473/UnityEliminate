using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : IDisposable
{
    public ReadData readData;

    public Read(string settings)
    {

    }

    public Read(SaveSetting saveSetting)
    {
        readData = new ReadData(saveSetting);
    }

    public static Read Create(string settings)
    {
        return new Read(settings);
    }

    public static Read Create(SaveSetting setting)
    {
        return new Read(setting);
    }


    public T Reader<T>()
    {
        return Reader<T>(StoredataTypeMgr.GetStoredataType(typeof(T)));
    }

    public T Reader<T>(StoredataType type)
    {
        if (type != null)
        {
            return (T)type.Reader(this);
        }
        return default(T);
    }

    public T Reader<T>(string tag)
    {
        StoredataType expectedValue = StoredataTypeMgr.GetStoredataType(typeof(T));
        return this.Reader<T>(expectedValue);
    }

    public void Dispose()
    {
        readData = null;
    }
}
