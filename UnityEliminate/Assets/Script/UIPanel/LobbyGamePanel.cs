using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

enum TestEnum
{
    One,
    Two,
    Three
}


public partial class LobbyGamePanel : QUIBehaviour
{

    private string path;
    protected override void InitUI(IUIData uiData = null)
    {
        base.InitUI(uiData);
        path = FilePath.PersistentDataPath4Res;
    }

    protected override void OnShow()
    {
        base.OnShow();

        SaveSetting saveSetting = new SaveSetting("1", path);
        SaveSetting saveSetting1 = new SaveSetting("2", path);
        SaveSetting saveSetting2 = new SaveSetting("3", path);
        SaveSetting saveSetting3 = new SaveSetting("4", path);
        SaveSetting saveSetting4 = new SaveSetting("5", path);
        SaveSetting saveSetting5 = new SaveSetting("6", path);
        SaveSetting saveSetting6 = new SaveSetting("7", path);
        //SaveToolsHelp.Save(98, "1", saveSetting);
        //SaveToolsHelp.Save("123", "2", saveSetting1);
        //SaveToolsHelp.Save(100, "3", saveSetting2);
        //SaveToolsHelp.Save(0.1f, "4", saveSetting3);
        //SaveToolsHelp.Save(0.2f, "5", saveSetting4);
        //SaveToolsHelp.Save(false, "6", saveSetting5);
        //SaveToolsHelp.Save(true, "7", saveSetting6);
        //SaveToolsHelp.Save(111, "8");
        //SaveToolsHelp.Save(999, "9");

        //Vector2 ve = new Vector2(88, 88);
        //SaveToolsHelp.Save(ve, "10");
        //SaveToolsHelp.Save(66, "11", SaveImplementType.ImplementXML);
        //SaveToolsHelp.Save("保存类型", "12", SaveImplementType.ImplementXML);
        //SaveToolsHelp.Save(true, "13", SaveImplementType.ImplementXML);
        //Vector3 ve3 = new Vector3(2, 2, 2);
        //SaveToolsHelp.Save(ve3, "14");
        //Vector4 ve4 = new Vector4(5, 5, 5, 5);
        //SaveToolsHelp.Save(ve4, "15");
        //SaveToolsHelp.Save(922337203685477580, "16");
        //Quaternion qu = Quaternion.AngleAxis(0.8f, new Vector3(8, 9, 4));
        //SaveToolsHelp.Save(qu, "17", SaveImplementType.ImplementXML);

        //Color color = new Color(100f, 100f, 180f, 255f);
        //SaveToolsHelp.Save(color, "18", SaveImplementType.ImplementXML);
        SaveToolsHelp.Save(0.0001f, "19");
        SaveToolsHelp.Save(0.00012f, "20");

        TestEnum testEnum = TestEnum.Three;
      //  SaveToolsHelp.Save(testEnum, "21");

        //Debug.LogError(SaveToolsHelp.Load<int>("1", saveSetting));
        //Debug.LogError(SaveToolsHelp.Load<int>("3", saveSetting2));
        //Debug.LogError(SaveToolsHelp.Load<string>("2", saveSetting1));
        //Debug.LogError(SaveToolsHelp.Load<float>("4", saveSetting3));
        //Debug.LogError(SaveToolsHelp.Load<float>("5", saveSetting4));
        //Debug.LogError(SaveToolsHelp.Load<bool>("6", saveSetting5));
        //Debug.LogError(SaveToolsHelp.Load<bool>("100"));
        //Debug.LogError(SaveToolsHelp.Load<int>("111"));
        //Vector2 ve1 = SaveToolsHelp.Load<Vector2>("10");
        //Debug.LogError(ve1);
        //Debug.LogError(SaveToolsHelp.Load<int>("11", SaveImplementType.ImplementXML));
        //Debug.LogError(SaveToolsHelp.Load<string>("12", SaveImplementType.ImplementXML));
        //Debug.LogError(SaveToolsHelp.Load<bool>("13", SaveImplementType.ImplementXML));
        //Debug.LogError(SaveToolsHelp.Load<Vector3>("14"));
        //Debug.LogError(SaveToolsHelp.Load<Vector4>("15"));
        //Debug.LogError(SaveToolsHelp.Load<long>("16"));
        //Debug.LogError(SaveToolsHelp.Load<Quaternion>("17", SaveImplementType.ImplementXML));
        //Debug.LogError(SaveToolsHelp.Load<Color>("18", SaveImplementType.ImplementXML));
        imgColor.color = SaveToolsHelp.Load<Color>("18", SaveImplementType.ImplementXML);
        //Debug.LogError(SaveToolsHelp.Load<double>("19"));
        //Debug.LogError(SaveToolsHelp.Load<double>("20"));
        Debug.LogError(SaveToolsHelp.Load<TestEnum>("21"));
        //int num = SaveToolsHelp.Load<int>("8");
        //int num1 = SaveToolsHelp.Load<int>("9");
        //Debug.LogError(num + "****" + num1);
    }

    protected override void OnHide()
    {
        base.OnHide();
    }
}
