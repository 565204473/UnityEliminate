using QFramework;
using System;
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
        // ES2File.CreateFolder("朱雀网络");
        // ES2.Delete("w");
        //if (!ES2.Exists("w")) {
        //    Debug.LogError("不存在");
        //    ES2.Save(1, "123");

        //    ES2.Save("保存的是String", "w");
        //    ES2.Save(0.1f, "f");
        //    ES2.Save(false, "t");
        //    ES2.Save(TestEnum.One, "h");
        //}
        //string des = StringExtention.FillFormat("{0}/{1}/{2}/{3}/{4}",
        //      ES2.Load<int>("123"), ES2.Load<string>("w"),
        //      ES2.Load<float>("f"), ES2.Load<bool>("t"),ES2.Load<TestEnum>("h"));
        //Debug.LogError(des);

        // ES2.Load<int>("444");
        PlayerPrefs.SetString("name", "xiaoming");
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
