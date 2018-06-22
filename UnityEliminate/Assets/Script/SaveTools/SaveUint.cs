using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveUint : StoredataType {

    public SaveUint() : base(typeof(uint)) {
        key = EnumSaveTypeKey.SaveUint;
    }


    public override object Reader(Read reader) {
        return reader.readData.ReadUint();
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadUint((uint)defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteUint((uint)data);
    }
}
