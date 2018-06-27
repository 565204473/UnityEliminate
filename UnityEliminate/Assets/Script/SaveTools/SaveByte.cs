using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveByte : StoredataType {

    public SaveByte() : base(typeof(byte)) {
        key = EnumSaveTypeKey.Savebyte;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadByte();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadByte((byte)defaultValue);
    }


    public override void Write(object data, Writer write) {
        write.writerData.WriteByte((byte)data);
    }

}
