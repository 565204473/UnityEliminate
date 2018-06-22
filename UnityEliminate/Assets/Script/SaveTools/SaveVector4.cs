using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveVector4 : StoredataType {
    public SaveVector4() : base(typeof(Vector4)) {
        key = EnumSaveTypeKey.SaveVector4;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadVector4(Vector4.one);
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadVector4((Vector4)defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteVector4((Vector4)data);
    }
}
