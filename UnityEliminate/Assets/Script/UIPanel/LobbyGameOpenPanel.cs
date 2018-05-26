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
        mData=uiData as UIMenuPanelData;
        TestTxt.text = "测试Txt";
        
    }

}
