using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveColor : StoredataType {

    public SaveColor() : base(typeof(Color)) {
        key = EnumSaveTypeKey.SaveColor;
    }

    public override object Reader(Read reader) {
        Color color = Color.black;
        return reader.readData.ReadColor(color);
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadColor((Color)defaultData);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteColor((Color)data);
    }
}
