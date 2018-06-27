using System;
public class Read : IDisposable {
    public ReadData readData;
    public SaveSetting Setting;

    public Read(SaveSetting saveSetting) {
        readData = new ReadData(saveSetting);
        Setting = saveSetting;
    }

    public static Read Create(SaveSetting setting) {
        return new Read(setting);
    }


    private T Reader<T>(StoredataType type) {
        if (type != null) {
            return (T)type.Reader(this);
        }
        return default(T);
    }

    private T Reader<T>(StoredataType type, T defaultData) {
        if (type != null) {
            return (T)type.Reader(this, defaultData);
        }
        return default(T);
    }

    public T Reader<T>(string tag) {
        StoredataType expectedValue = StoredataTypeMgr.GetStoredataType(typeof(T));
        Setting.curObject = typeof(T);
        return Reader<T>(expectedValue);
    }

    public T Reader<T>(string tag, T defaultData) {
        StoredataType expectedValue = StoredataTypeMgr.GetStoredataType(typeof(T));
        Setting.curObject = typeof(T);
        return Reader<T>(expectedValue, defaultData);
    }

    public void Dispose() {
        readData = null;
    }
}
