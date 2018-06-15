using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveChar : StoredataType {

    public SaveChar() : base(typeof(char)) {
        key = EnumSaveTypeKey.SaveChar;
    }


    public override object Reader(Read reader) {
        return reader.readData.ReadChar();
    }

    public override void Write(object data, Writer write) {
        write.writerData.WriteChar((char)data);
    }

}
