using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveVector3 : StoredataType {
    public SaveVector3() : base(typeof(Vector3)) {
        key = EnumSaveTypeKey.SaveVector3;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadVector3(Vector3.one);
    }
    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadVector3((Vector3)defaultValue);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteVector3((Vector3)data);
    }

}
