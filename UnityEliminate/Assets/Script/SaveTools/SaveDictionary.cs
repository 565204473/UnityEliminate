using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveDictionary : StoredataType {

    public SaveDictionary() : base(typeof(Dictionary<,>)) {
        key = EnumSaveTypeKey.SaveDictionary;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadDictionary(string.Empty);
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadDictionary(defaultData);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteDictionary(data);
    }
}
