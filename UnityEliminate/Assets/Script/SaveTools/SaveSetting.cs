using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveSetting
{
    public FilenameData filenameData;
    public string path;
    public SaveSetting()
    {

    }

    public SaveSetting(string tag)
    {
        filenameData = new FilenameData(tag);
    }


    public SaveSetting Clone()
    {
        return new SaveSetting
        {
            filenameData = this.filenameData,
            path = this.path

        };
    }
}
