using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveList : StoredataType
{

    public SaveList() : base(typeof(List<object>))
    {
        key = EnumSaveTypeKey.SaveList;
    }


    public override object Reader(Read reader)
    {
        return reader.readData.ReadList();
    }

    public override void Write(object data, Writer write)
    {
        write.writerData.WriteList((List<object>)data);
    }
}
