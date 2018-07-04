using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public partial class LobbyGameLobbyPanel : QUIBehaviour
{
    protected override void InitUI(IUIData uiData = null)
    {
        base.InitUI(uiData);
    }

    protected override void OnShow()
    {
        base.OnShow();
    }

    protected override void OnHide()
    {
        base.OnHide();
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        UIToos.ButtonAddListener(BtnOpenGameEnd, OnBtnOpenGameEnd);
        UIToos.ButtonAddListener(BtnBtnULui, OnOpenLuiPanel);
    }


    private void OnBtnOpenGameEnd(GameObject go)
    {
        QUIManager.Instance.HideUI(this.name);
        ScenesMgr.Instance.OpenScene(SceneType.SceneGame);
    }

    private void OnOpenLuiPanel(GameObject go) {
        Debug.Log("打开ui例子界面");
    }
}
