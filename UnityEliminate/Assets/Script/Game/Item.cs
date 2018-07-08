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
    private int posIndex;
    private Vector2 Startpos;
    private Vector2 EndPos;

    public override void Init(int index) {
        base.Init(index);
        QUIEventListener.CheckAndAddListener(this.gameObject).onPointerUp = OnPointerUp;
        QUIEventListener.CheckAndAddListener(this.gameObject).onPointerDown = OnPointerDown;
        QUIEventListener.CheckAndAddListener(this.gameObject).onPointerEnter = OnPointerEnter;
    }

    public override void OnRefresh() {
        base.OnRefresh();
        this.name = base.index.ToString();
        posIndex = base.index;
        int index = Random.Range(0, lsSpite.Count);
        this.imaBg.sprite = lsSpite[index];
        this.curItemType = (ItemType)index;
        Debug.LogError(curItemType);
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        StartCode = this.gameObject;
        Startpos = StartCode.transform.GetPosition();
    }

    /// <summary>
    /// 抬起
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
       // Exchange(StartCode, EndCode);
        UpCode();

    }

    /// <summary>
    /// 指向
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        EndCode = this.gameObject;
        EndPos = eventData1.position;
    }


    public void UpCode() {
        if (StartCode != null && EndCode != null) {
            int X = (int)(EndCode.transform.GetPosition().x - StartCode.transform.GetPosition().x);
            int Y = (int)(EndCode.transform.GetPosition().y - StartCode.transform.GetPosition().y);

            //横轴滑动
            if (Mathf.Abs(X) > Mathf.Abs(Y)) {
                //右滑
                if (X > 0) {
                    Debug.Log("向右滑动");
                }
                //左滑
                else if (X < 0) {
                    Debug.Log("向左滑动");
                }
                //纵轴滑动
                else if (Mathf.Abs(X) < Mathf.Abs(Y)) {
                    if (Y > 0) {
                        Debug.Log("向下滑动");
                    }
                    else if (Y < 0) {
                        Debug.Log("向上滑动");
                    }
                }
                else {
                    EndCode = null;
                }
                StartCode = null;
                EndCode = null;
            }

        }

    }


    public void Exchange(GameObject startG, GameObject endG) {

        startG.transform.Position(EndPos);
        Debug.LogError(startG.transform.GetPosition());
        endG.transform.Position(Startpos);
    }


}
