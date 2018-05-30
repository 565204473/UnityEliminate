using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveToolsHelp {

    public static void Save<T>(T param, string identifier) {
        SaveSetting setting = new SaveSetting();
        using (Writer writer = Writer.Create(setting)) {

            writer.Write<T>(param, setting.filenameData.tag);
            writer.Save();
        }
    }

    public static T Load<T>(string identifier) {

        SaveSetting setting = new SaveSetting();
        using (SaveRead reader = SaveRead.Create(setting)) {

            return reader.Read<T>(setting.filenameData.tag);
        }
    }
}
