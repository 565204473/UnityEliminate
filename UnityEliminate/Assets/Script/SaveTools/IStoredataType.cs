using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoredataType {

    object Reader(Read reader);
    object Reader(Read reader, object defaultData);
    void Write(object data, Writer write);
}
