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
        using (Read reader = Read.Create(setting)) {

            return reader.Reader<T>(setting.filenameData.tag);
        }
    }
}
