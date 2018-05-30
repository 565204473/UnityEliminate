using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveType {

    void Read(SaveRead reader, object c);
    void Write(object data, Writer write);
}
