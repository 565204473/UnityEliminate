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
        BtnOpenGameEnd.onClick.AddListener(OnBtnOpenGameEnd);
    }


    private void OnBtnOpenGameEnd()
    {
        QUIManager.Instance.HideUI(this.name);
        ScenesMgr.Instance.OpenScene(SceneType.SceneGame);
    }
}
