using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveShort : StoredataType {

    public SaveShort() : base(typeof(short)) {
        key = EnumSaveTypeKey.SaveShort;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadShort();
    }

    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadShort((short)defaultData);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteShort((short)data);
    }
}
