using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveInt : SaveType
{
    public SaveInt() : base(typeof(int))
    {
        base.key = EnumSaveTypeKey.SaveInt;
    }

    public override object Read(SaveRead reader)
    {
        Debug.LogError("调用SaveRead读int的实现");
        return reader.ReadInit();
    }

    public override void Write(object data, Writer write)
    {
        Debug.LogError("写入int的实现");
    }
}
