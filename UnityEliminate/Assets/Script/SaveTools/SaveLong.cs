using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveLong : StoredataType {

    public SaveLong() : base(typeof(long)) {
        key = EnumSaveTypeKey.SaveLong;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadLong();
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadLong((long)defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteLong((long)data);
    }
}
