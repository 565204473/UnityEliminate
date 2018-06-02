using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed  class SaveString : StoredataType {

    public SaveString() : base(typeof(string)) {
        base.key = EnumSaveTypeKey.SaveString;
    }

    public override object Reader(Read reader) {
        Debug.LogError("调用SaveRead读入string的实现");
        return reader.ReadString();
    }

    public override void Write(object data, Writer write) {

        Debug.LogError("写入sting的实现");
    }
}
