using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveColor : StoredataType {

    public SaveColor() : base(typeof(Color)) {
        key = EnumSaveTypeKey.SaveColor;
    }

    public override object Reader(Read reader) {
        Color color = Color.black;
        return reader.readData.ReadValue(key);
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadValue(key, defaultValue);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriterValue(key, data);
    }
}
