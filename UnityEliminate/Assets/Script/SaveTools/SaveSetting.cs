using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using QFramework;
using UnityEditor;

/// <summary>
/// 技术实现方式
/// </summary>
public enum SaveImplementType {
    ImplementByte,
    ImplementXML,
    ImplementJson,
    ImplementProto
}


public static class SaveDefaultData {
    public static string Path = FilePath.PersistentDataPath4Res;
}


public sealed class SaveSetting {
    public FilenameData filenameData;
    public string path;
    public SaveImplementType saveImplementType = SaveImplementType.ImplementByte;
    public SaveSetting() {

    }

    public SaveSetting(string tag, SaveImplementType type = SaveImplementType.ImplementByte) {
        filenameData = new FilenameData(tag);
        this.path = SaveDefaultData.Path + "/" + tag;
        this.saveImplementType = type;
        FileMgr.Instance.CreateDirIfNotExists(SaveDefaultData.Path);
    }

    public SaveSetting(string tag, string path, SaveImplementType type = SaveImplementType.ImplementByte) {
        filenameData = new FilenameData(tag);
        this.path = path + "/" + tag;
        this.saveImplementType = type;
        FileMgr.Instance.CreateDirIfNotExists(path);
    }

    public SaveSetting Clone() {
        return new SaveSetting {
            filenameData = this.filenameData,
            path = this.path,
            saveImplementType = this.saveImplementType
        };
    }
}
