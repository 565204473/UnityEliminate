using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType {
    /// <summary>
    /// 蓝色
    /// </summary>
    Bule = 0,
    /// <summary>
    /// 绿色
    /// </summary>
    Green,
    ///粉色
    Pink,
    /// <summary>
    /// 红色
    /// </summary>
    Red,
    /// <summary>
    /// 紫色
    /// </summary>
    Violet,
    /// <summary>
    /// 黄色
    /// </summary>
    Yellow
}


public class Item : ListItem {
    public Image imaBg;
    public List<Sprite> lsSpite = new List<Sprite>();
    public ItemType curItemType { get; protected set; }
    public GameObject StartCode;
    public GameObject EndCode;
    public int posIndex;
    public Vector2 GetV 
    {
        get { return this.gameObject.transform.GetPosition(); }
    }

    public int GetX
    {
        get { return (int)this.transform.GetLocalPosition().x; }
    }

    public int GetY
    {
        get { return (int)this.transform.GetLocalPosition().y; }
    }

    public override void Init(int index) {
        base.Init(index);
    }

    public override void OnRefresh() {
        base.OnRefresh();
        this.name = base.index.ToString();
        posIndex = base.index;
        int index = Random.Range(0, lsSpite.Count);
        this.imaBg.name = base.index.ToString();
        this.imaBg.sprite = lsSpite[index];
        this.curItemType = (ItemType)index;
        Debug.LogError(curItemType);
    }
}
