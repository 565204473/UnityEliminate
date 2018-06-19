using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveToolsHelp {
    /// <summary>
    /// 保存文件+需要自定义风格
    /// </summary>
    /// <typeparam name="保存的类型"></typeparam>
    /// <param name="保存的内容"></param>
    /// <param name="保存的Key"></param>
    /// <param name="自定义风格"></param>
    public static void Save<T>(T param, string identifier, SaveSetting setting) {
        using (Writer writer = Writer.Create(setting)) {
            writer.Write<T>(param, setting.filenameData.tag);
        }
    }

    /// <summary>
    /// 保存+默认保存路径+默认风格
    /// </summary>
    /// <typeparam name="保存的类型"></typeparam>
    /// <param name="保存的内容"></param>
    /// <param name="保存的key"></param>
    /// <param name="保存的实现方式"></param>

    public static void Save<T>(T param, string identifier, SaveImplementType type = SaveImplementType.ImplementByte) {
        SaveSetting setting = new SaveSetting(identifier, type);
        using (Writer writer = Writer.Create(setting)) {
            writer.Write<T>(param, setting.filenameData.tag);
        }
    }

    /// <summary>
    /// 读取文件+默认风格
    /// </summary>
    /// <typeparam name="读取的类型"></typeparam>
    /// <param name="读取的key（就是保存文件用的key）"></param>
    /// <param name="读取的实现方式"></param>
    /// <returns></returns>

    public static T Load<T>(string identifier, SaveImplementType type = SaveImplementType.ImplementByte) {
        SaveSetting setting = new SaveSetting(identifier, type);
        using (Read reader = Read.Create(setting)) {
            return reader.Reader<T>(setting.filenameData.tag);
        }
    }

    /// <summary>
    /// 读取文件+有自定义风格的
    /// </summary>
    /// <typeparam name="读取的类型"></typeparam>
    /// <param name="读取的key"></param>
    /// <param name="读取的自定义风格"></param>
    /// <returns></returns>

    public static T Load<T>(string identifier, SaveSetting setting) {
        SaveSetting settingClone = setting.Clone();
        using (Read reader = Read.Create(settingClone)) {
            return reader.Reader<T>(setting.filenameData.tag);
        }
    }

    /// <summary>
    /// 删除保存的文件
    /// </summary>
    /// <param name="保存的key"></param>
    public static void Delete(string identifier) {
        SaveSetting setting = new SaveSetting(identifier, SaveReadingType.Delete);
    }

    /// <summary>
    /// 是否拥有这个文件
    /// </summary>
    /// <param name="保存的key"></param>
    /// <returns></returns>
    public static bool Exists(string identifier) {
        SaveSetting setting = new SaveSetting();
        return setting.IsExists(identifier);
    }

    /// <summary>
    /// 获取当前保存的key的文件的保存位置信息
    /// </summary>
    /// <param name="保存的key"></param>
    /// <returns></returns>
    public static string GetFiles(string identifier) {
        SaveSetting setting = new SaveSetting();
        return setting.GetFiles(identifier);
    }
}
