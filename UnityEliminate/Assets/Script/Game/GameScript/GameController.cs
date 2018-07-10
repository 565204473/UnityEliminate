using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class GameController : MonoBehaviour {

    public Item StartCode;
    public Item EndCode;
    private Vector2 Startpos;
    private Vector2 EndPos;
    void Start() {
        QUIEventListener.CheckAndAddListener(this.gameObject).onEndDrag = OnEndDrag;
        QUIEventListener.CheckAndAddListener(this.gameObject).onBeginDrag = OnBeginDrag;
        QUIEventListener.CheckAndAddListener(this.gameObject).onDrag = OnDrag;
    }


    /// <summary>
    /// 开始拖动
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        GameObject pointobj = eventData1.pointerEnter;
        Item it = GameMgr.Instance.GetDicItem(pointobj.name);
        StartCode = it;
        Startpos = it.GetV;
    }

    /// <summary>
    /// 结束拖动
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        Exchange(StartCode.gameObject, EndCode.gameObject);
        UpCode();

    }

    /// <summary>
    /// 拖动中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(BaseEventData eventData) {
        PointerEventData eventData1 = eventData as PointerEventData;
        GameObject pointobj = eventData1.pointerEnter;
        Item it = GameMgr.Instance.GetDicItem(pointobj.name);
        EndCode = it;
        EndPos = it.GetV;
    }

    /// <summary>
    /// 交换位置
    /// </summary>
    /// <param name="startG"></param>
    /// <param name="endG"></param>
    public void Exchange(GameObject startG, GameObject endG) {
        startG.transform.Position(EndPos);
        endG.transform.Position(Startpos);
    }


    public void UpCode() {
        if (StartCode != null && EndCode != null) {
            int X = (EndCode.GetX - StartCode.GetX);
            int Y = (EndCode.GetY - StartCode.GetY);
            //横轴滑动
            if (Mathf.Abs(X) > Mathf.Abs(Y)) {
                //右滑
                if (X > 0) {
                    Debug.Log("向左滑动");
                }
                //左滑
                else if (X < 0) {
                    Debug.Log("向右滑动");
                }
                else {
                    EndCode = null;
                }

            }  //纵轴滑动
            else if (Mathf.Abs(X) < Mathf.Abs(Y)) {
                if (Y > 0) {
                    Debug.Log("向下滑动");
                }
                else if (Y < 0) {
                    Debug.Log("向上滑动");
                }
                else {
                    EndCode = null;
                }
            }
            StartCode = null;
            EndCode = null;
        }
    }
}
