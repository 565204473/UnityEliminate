using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveString : SaveType {

    public SaveString() : base(typeof(string)) {
        base.key = EnumSaveTypeKey.SaveString;
    }

    public override object Read(SaveRead reader) {
        Debug.Log("调用SaveRead读入string的实现");
        return null;
    }

    public override void Write(object data, Writer write) {

        Debug.LogError("写入sting的实现");
    }
}
