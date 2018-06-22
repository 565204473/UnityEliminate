using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveList : StoredataType {

    public SaveList() : base(typeof(List<>)) {
        key = EnumSaveTypeKey.SaveList;
    }


    public override object Reader(Read reader) {
        return reader.readData.ReadList(string.Empty);
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadList(defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteList(data);
    }
}
