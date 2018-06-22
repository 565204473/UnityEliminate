using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveArray : StoredataType {

    public SaveArray() : base(typeof(Array)) {
        key = EnumSaveTypeKey.SaveArray;
    }

    public override object Reader(Read reader) {
        Array array = new Array[1];
        return reader.readData.ReadArray(array);
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadArray((Array)defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteArray((Array)data);
    }

}
