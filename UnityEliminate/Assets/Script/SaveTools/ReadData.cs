using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadData : IDisposable
{
    private SaveSetting saveSetting;

    public ReadData(SaveSetting data)
    {
        saveSetting = data;
    }

    public Int32 ReadInt32()
    {
        Stream stream = FileMgr.Instance.OpenReadStream(this.saveSetting.path);
        if (stream != null)
        {
            var data = SerializeHelper.DeserializeBinary(stream);
            if (data != null)
            {
                Debug.LogError(data.ConverToString());
                return 1;
            }
        }
        return 1;
    }



    public void Dispose()
    {
    }
}
