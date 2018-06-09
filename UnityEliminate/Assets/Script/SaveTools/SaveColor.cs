using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveColor : StoredataType {

    public SaveColor() : base(typeof(Color)) {
        key = EnumSaveTypeKey.SaveColor;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadColor();
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteColor((Color)data);
    }
}
