using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuPanelData : IUIData {

}


public partial class LobbyGameOpenPanel : QUIBehaviour {

    UIMenuPanelData mData = null;
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
        mData = uiData as UIMenuPanelData;
        TestTxt.text = "测试Txt";
    }

    protected override void OnShow() {
        base.OnShow();
    }

    protected override void OnBeforeDestroy() {
        base.OnBeforeDestroy();
        Log.W("清除{0}", 1);
    }

    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        BtnOpen.onClick.AddListener(OnBtnOpenGameClick);
    }

    private void OnBtnOpenGameClick() {

        QUIManager.Instance.HideUI(this.name);
        ScenesMgr.Instance.OpenScene(SceneType.SceneLobby);
    }
}
