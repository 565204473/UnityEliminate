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
        Debug.LogError("调用SaveRead读int的实现");
        return reader.readData.ReadInt32();
    }

    public override void Write(object data, Writer write)
    {
        Debug.LogError("写入int的实现");
        write.writerData.WriteInt((int)data);
    }
}
