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

    public override void Init(int index) {
        base.Init(index);
        QUIEventListener.CheckAndAddListener(this.gameObject).onPointerUp = OnPointerUp;
        QUIEventListener.CheckAndAddListener(this.gameObject).onPointerDown = OnPointerDown;
    }

    public override void OnRefresh() {
        base.OnRefresh();
        int index = Random.Range(0, lsSpite.Count);
        this.imaBg.sprite = lsSpite[index];
        this.curItemType = (ItemType)index;
        Debug.LogError(curItemType);
    }


    public void OnPointerDown(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        Debug.LogError("按下");
    }

    public void OnPointerUp(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        Debug.LogError("抬起");
    }

}
