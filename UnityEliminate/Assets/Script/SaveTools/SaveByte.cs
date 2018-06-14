using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveByte : StoredataType
{

    public SaveByte() : base(typeof(byte))
    {
        key = EnumSaveTypeKey.Savebyte;
    }

    public override object Reader(Read reader)
    {
        return base.Reader(reader);
    }


    public override void Write(object data, Writer write)
    {
        write.writerData.WriteByte((byte)data);
    }

}
