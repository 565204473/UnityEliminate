using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListItem : MonoBehaviour, IListItem {
    protected int index;
    public virtual void Init(int index) {
        this.index = index;
    }

    public virtual void OnRefresh() {

    }
}
