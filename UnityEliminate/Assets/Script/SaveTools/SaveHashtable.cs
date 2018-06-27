using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveHashtable : StoredataType {

    public SaveHashtable() : base(typeof(Hashtable)) {
        key = EnumSaveTypeKey.SaveHashtable;
    }

    public override object Reader(Read reader) {
        Hashtable hs = new Hashtable();
        return reader.readData.ReadHashtable(hs);
    }

    public override object Reader(Read reader, object defaultValue) {

        return reader.readData.ReadHashtable((Hashtable)defaultValue);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteHashtable((Hashtable)data);
    }
}
