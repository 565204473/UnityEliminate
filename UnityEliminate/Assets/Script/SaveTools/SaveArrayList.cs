using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveArrayList : StoredataType {

    public SaveArrayList() : base(typeof(ArrayList)) {
        key = EnumSaveTypeKey.SaveArrayList;
    }

    public override object Reader(Read reader) {
        ArrayList df = new ArrayList();
        return reader.readData.ReadArrayList(df);
    }
    public override object Reader(Read reader, object defaultData) {
        return reader.readData.ReadArrayList((ArrayList)defaultData);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteArrayList((ArrayList)data);
    }
}
