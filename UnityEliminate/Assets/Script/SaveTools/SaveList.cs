using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  sealed class SaveList : StoredataType {

    public SaveList() : base(typeof(List<>)) {
        key = EnumSaveTypeKey.SaveList;
    }


    public override object Reader(Read reader) {
        return base.Reader(reader);
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteList(data);
    }
}
