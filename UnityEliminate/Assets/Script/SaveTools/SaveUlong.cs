using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveUlong : StoredataType {

    public SaveUlong() : base(typeof(ulong)) {

        key = EnumSaveTypeKey.SaveUlong;
    }


    public override object Reader(Read reader) {
        return reader.readData.ReadUlong();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadUlong((ulong)defaultValue);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteUlong((ulong)data);
    }
}
