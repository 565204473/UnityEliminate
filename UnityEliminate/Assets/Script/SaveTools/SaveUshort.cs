using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveUshort : StoredataType {

    public SaveUshort() : base(typeof(ushort)) {
        key = EnumSaveTypeKey.SaveUshort;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadUshort();
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteUshort((ushort)data);
    }
}
