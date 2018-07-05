using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;

public partial class LobbyGameLobbyPanel : QUIBehaviour {
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);

    }

    protected override void OnShow() {
        base.OnShow();
        Grid.cols = 8;
        Grid.cellsCount = 98;
        Grid.SetCellHandle(ItemCallBack);
        Grid.reloadData();
    }

    protected override void OnHide() {
        base.OnHide();
    }

    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        UIToos.ButtonAddListener(BtnOpenGameEnd, OnBtnOpenGameEnd);
        UIToos.ButtonAddListener(BtnBtnULui, OnOpenLuiPanel);
    }


    private void ItemCallBack(int index, GameObject go) {
        Item itemData = go.GetComponent<Item>();
        if (itemData != null) {
            itemData.OnRefresh();
            Debug.LogError(itemData.curItemType);
            QUIEventListener.CheckAndAddListener(go).onPointerDown = onPointerDown;
        }
    }

    private void OnBtnOpenGameEnd(GameObject go) {
        QUIManager.Instance.HideUI(this.name);
        ScenesMgr.Instance.OpenScene(SceneType.SceneGame);
    }

    private void OnOpenLuiPanel(GameObject go) {
        Debug.Log("打开ui例子界面");
        UIMgr.HidePanel<LobbyGameLobbyPanel>();
        UIMgr.OpenPanel<LobbyExampleULui>(UILevel.AlwayTop, new PanelData(1));
    }

    private void onPointerDown(BaseEventData eventData) {

        Debug.LogError("打印出来" + eventData.currentInputModule);
    }
}
