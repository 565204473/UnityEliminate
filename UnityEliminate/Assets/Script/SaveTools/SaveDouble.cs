using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed  class SaveDouble : StoredataType {

    public SaveDouble() : base(typeof(double)) {
        key = EnumSaveTypeKey.SaveDouble;
    }

    public override object Reader(Read reader)
    {
        return reader.readData.ReadDouble();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadDouble((double)defaultValue);
    }

    public override void Write(object data, Writer write)
    {
        write.writerData.WriteDouble((double)data);
    }
}
