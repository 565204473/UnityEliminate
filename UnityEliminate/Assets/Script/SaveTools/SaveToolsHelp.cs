using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveToolsHelp {

    public static void Save<T>(T param, string identifier, SaveSetting setting) {
        using (Writer writer = Writer.Create(setting)) {
            writer.Write<T>(param, setting.filenameData.tag);
            writer.Save();
        }
    }

    public static void Save<T>(T param, string identifier, SaveImplementType type = SaveImplementType.ImplementByte) {
        SaveSetting setting = new SaveSetting(identifier, type);
        using (Writer writer = Writer.Create(setting)) {

            writer.Write<T>(param, setting.filenameData.tag);
            writer.Save();
        }
    }

    public static T Load<T>(string identifier, SaveImplementType type = SaveImplementType.ImplementByte) {
        SaveSetting setting = new SaveSetting(identifier, type);
        using (Read reader = Read.Create(setting)) {
            return reader.Reader<T>(setting.filenameData.tag);
        }
    }

    public static T Load<T>(string identifier, SaveSetting setting) {
        SaveSetting settingClone = setting.Clone();
        using (Read reader = Read.Create(settingClone)) {
            return reader.Reader<T>(setting.filenameData.tag);
        }
    }
}
