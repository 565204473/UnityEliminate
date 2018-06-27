using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveFloat : StoredataType {

    public SaveFloat() : base(typeof(float)) {
        base.key = EnumSaveTypeKey.SaveFolat;
    }

    public override object Reader(Read reader) {
        return reader.readData.ReadFolat();
    }

    public override object Reader(Read reader, object defaultValue) {
        return reader.readData.ReadFolat((float)defaultValue);
    }


    public override void Write(object data, Writer write) {

        write.writerData.WriteFloat(data);
    }
}
