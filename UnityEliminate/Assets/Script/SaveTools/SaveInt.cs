using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveInt : StoredataType
{
    public SaveInt() : base(typeof(int))
    {
        base.key = EnumSaveTypeKey.SaveInt;
    }

    public override object Reader(Read reader)
    {
        return reader.readData.ReadInt32();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadInt32((int)defaultValue);
    }


    public override void Write(object data, Writer write)
    {
        write.writerData.WriteInt((int)data);
    }
}
