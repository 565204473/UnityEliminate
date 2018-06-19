using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

enum TestEnum {
    One,
    Two,
    Three
}


public partial class LobbyGamePanel : QUIBehaviour {

    private string path;
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
        path = FilePath.PersistentDataPath4Res;
    }

    public void Update() {


    }

    protected override void OnShow() {
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
        //SaveToolsHelp.Save(0.0001f, "19");
        //SaveToolsHelp.Save(0.00012f, "20");
        //TestEnum testEnum = TestEnum.Three;
        //SaveToolsHelp.Save(testEnum, "21");
        //List<object> lsTestString = new List<object>();
        //lsTestString.Add("我真的好累啊");
        //lsTestString.Add("真的");
        //lsTestString.Add(123);
        //SaveToolsHelp.Save(lsTestString, "22", SaveImplementType.ImplementXML);
        //List<object> lsTestint = new List<object>();
        //lsTestint.Add(2);
        //lsTestint.Add(3);
        //SaveToolsHelp.Save(lsTestint, "23");
        //Dictionary<object, object> lsDicTest = new Dictionary<object, object>();
        //lsDicTest.Add(1, "哈哈");
        //lsDicTest.Add(2, "嘻嘻");
        //SaveToolsHelp.Save(lsDicTest, "24", SaveImplementType.ImplementXML);
        //SaveToolsHelp.Save(text.text + "***" + DateTime.Now, "25");
        //SaveToolsHelp.Save(text.text + "***" + DateTime.Now, "26", SaveImplementType.ImplementJson);
        //SaveToolsHelp.Save(text.text + "***" + DateTime.Now, "27", SaveImplementType.ImplementXML);
        //SaveToolsHelp.Save(text.text + "***" + DateTime.Now, "28", SaveImplementType.ImplementProto);
        //Byte b = 2;
        //Byte c = 3;
        //SaveToolsHelp.Save(b, "29");
        //SaveToolsHelp.Save(c, "30");
        //short s = 12;
        //SaveToolsHelp.Save(s, "31");
        //uint u = 123;
        //SaveToolsHelp.Save(u, "32");
        //ulong ul = 1234;
        //SaveToolsHelp.Save(ul, "33");
        //ushort us = 12345;
        //SaveToolsHelp.Save(us, "34");
        //char ch = 'F';
        //SaveToolsHelp.Save(ch, "35");
        //SaveToolsHelp.Save(88, "36");
        //SaveToolsHelp.Save(99, "37");
        //DateTime dateTime = new DateTime(2018, 06, 19);
        //Debug.LogError(dateTime);
        //SaveToolsHelp.Save(dateTime, "38", SaveImplementType.ImplementXML);


        //int[] array = new int[2] { 33, 44 };
        //SaveToolsHelp.Save(array, "39");

        string[] array1 = new string[3] { "55", "66", "我是中文" };
        SaveToolsHelp.Save(array1, "40");

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
        // imgColor.color = SaveToolsHelp.Load<Color>("18", SaveImplementType.ImplementXML);
        //Debug.LogError(SaveToolsHelp.Load<double>("19"));
        //Debug.LogError(SaveToolsHelp.Load<double>("20"));
        // Debug.LogError(SaveToolsHelp.Load<TestEnum>("21"));
        //Debug.LogError(SaveToolsHelp.Load<List<object>>("22", SaveImplementType.ImplementXML).Count);
        //foreach (var item in SaveToolsHelp.Load<List<object>>("22", SaveImplementType.ImplementXML)) {
        //    Debug.LogError(item.GetType());
        //}

        //Debug.LogError(SaveToolsHelp.Load<List<object>>("23").Count);
        //foreach (var item in SaveToolsHelp.Load<List<object>>("23")) {
        //    Debug.LogError(item);
        //}

        //Debug.LogError(SaveToolsHelp.Load<Dictionary<object, object>>("24", SaveImplementType.ImplementXML).Count);
        //foreach (var item in SaveToolsHelp.Load<Dictionary<object, object>>("24", SaveImplementType.ImplementXML)) {
        //    Debug.LogError(item.Key + "***" + item.Value);
        //}

        //int num = SaveToolsHelp.Load<int>("8");
        //int num1 = SaveToolsHelp.Load<int>("9");
        //Debug.LogError(num + "****" + num1);

        //SaveToolsHelp.Load<string>("25");
        //SaveToolsHelp.Load<string>("27", SaveImplementType.ImplementXML);
        //SaveToolsHelp.Load<string>("26", SaveImplementType.ImplementJson);
        //SaveToolsHelp.Load<string>("28", SaveImplementType.ImplementProto);

        //SaveToolsHelp.Delete("1");
        //Debug.LogError(SaveToolsHelp.Exists("2"));
        //Debug.LogError(SaveToolsHelp.GetFiles("100"));
        //Debug.LogError(SaveToolsHelp.Load<byte>("29"));
        //Debug.LogError(SaveToolsHelp.Load<byte>("30"));
        //  Debug.LogError(SaveToolsHelp.Load<short>("31"));
        //  Debug.LogError(SaveToolsHelp.Load<uint>("32"));
        //  Debug.LogError(SaveToolsHelp.Load<ulong>("33"));
        //Debug.LogError(SaveToolsHelp.Load<ushort>("34"));
        //Debug.LogError(SaveToolsHelp.Load<char>("35"));
        //Debug.LogError(SaveToolsHelp.Load<int>("36"));
        //Debug.LogError(SaveToolsHelp.Load<int>("37"));

        //  Debug.LogError(SaveToolsHelp.Load<DateTime>("38", SaveImplementType.ImplementXML));
        //Debug.LogError(SaveToolsHelp.Load<int[]>("39").Length);
        //foreach (var item in SaveToolsHelp.Load<int[]>("39")) {
        //    Debug.LogError(item);
        //}

        foreach (var item in SaveToolsHelp.Load<string[]>("40")) {
            Debug.LogError(item);
        }
    }

    protected override void OnHide() {
        base.OnHide();
    }
}
