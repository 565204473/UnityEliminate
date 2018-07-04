using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelData : UIPageData {
    public int index = 0;
    public PanelData(int index) {
        this.index = index;
    }
}

public partial class LobbyExampleULui : QUIBehaviour {

    private PanelData mData;
    protected override void InitUI(IUIData uiData = null) {
        mData = uiData as PanelData;
        Debug.LogError(mData.index);
    }

    protected override void OnShow() {
        base.OnShow();

    }

    protected override void OnHide() {
        base.OnHide();
    }
    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        UITransitionExtension.BindTransition<LobbyExampleULui, LobbyGameOpenPanel>(BtnBack);
        UIToos.ButtonAddListener(BtnOpenLobby, OnBtnOpenLobbyClick);
    }

    private void OnBtnOpenLobbyClick(GameObject go) {
        UIMgr.OpenPanel<LobbyGameLobbyPanel>();
    }
}
