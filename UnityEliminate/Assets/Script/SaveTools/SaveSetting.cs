using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using QFramework;
using UnityEditor;

public sealed class SaveSetting {
    public FilenameData filenameData;
    public string path;
    public SaveSetting() {

    }

    public SaveSetting(string tag) {
        filenameData = new FilenameData(tag);
    }

    public SaveSetting(string tag, string path) {
        filenameData = new FilenameData(tag);
        this.path = path + "/" + tag;
        if (!FileMgr.Instance.FileExists(path)) {
            Directory.CreateDirectory(path);
#if UNITY_IPHONE && !UNITY_EDITOR
						UnityEngine.iOS.Device.SetNoBackupFlag(path);
#endif
        }

    }

    public SaveSetting Clone() {
        return new SaveSetting {
            filenameData = this.filenameData,
            path = this.path
        };
    }
}
