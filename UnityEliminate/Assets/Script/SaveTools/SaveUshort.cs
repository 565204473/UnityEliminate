using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveUshort : StoredataType {

    public SaveUshort() : base(typeof(ushort)) {
        key = EnumSaveTypeKey.SaveUshort;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadValue(key);
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadValue(key, defaultValue);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriterValue(key, data);
    }
}
