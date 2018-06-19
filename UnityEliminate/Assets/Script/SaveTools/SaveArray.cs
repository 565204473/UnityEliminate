using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveArray : StoredataType {

    public SaveArray() : base(typeof(Array)) {
        key = EnumSaveTypeKey.SaveArray;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadArray();
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteArray((Array)data);
    }

}
