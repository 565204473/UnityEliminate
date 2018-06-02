using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoredataType {

    void Reader(Read reader, object c);
    void Write(object data, Writer write);
}
