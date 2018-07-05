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


public class Item : MonoBehaviour {
    public Image imaBg;
    public List<Sprite> lsSpite = new List<Sprite>();
    public ItemType curItemType { get; protected set; }



    public void OnRefresh() {
        int index = Random.Range(0, lsSpite.Count);
        this.imaBg.sprite = lsSpite[index];
        this.curItemType = (ItemType)index;
    }
}
