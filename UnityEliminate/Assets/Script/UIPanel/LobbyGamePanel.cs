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

public class TestClass {

    public string testInt;
}


public partial class LobbyGamePanel : QUIBehaviour {


    private string[] readTypeName = new string[] { "Int", "Long", "String", "Float" , "Double", "Bool", "Vector2", "Vector3", "Vector4", "Quaternion", "Color", "Enum", "List", "Dictionary", "Byte", "Short",
        "Uint","Ulong","Ushort","Char","DateTime","Array" };
    private ResLoader mResLoader = ResLoader.Allocate();
    private string path;
    private Transform itemRead;
    private Transform itemWrite;
    private BtnRead itemReadData;
    private BtnWrite itemWriteData;
    protected override void InitUI(IUIData uiData = null) {
        base.InitUI(uiData);
        path = FilePath.PersistentDataPath4Res;

        itemRead = mResLoader.LoadSync<GameObject>(PrefabPath.BtnRead).GetComponent<Transform>();
        //itemWrite = mResLoader.LoadSync<GameObject>(PrefabPath.BtnWrite).GetComponent<Transform>();
        for (int i = 0; i < readTypeName.Length; i++) {
            itemReadData = itemRead.Instantiate().Parent(readBtnPos)
                .LocalPosition(Vector3.zero)
                .LocalScaleIdentity().GetComponent<BtnRead>();

            if (itemReadData != null) {
                itemReadData.index = i;
                itemReadData.OnRefresh((EnumSaveTypeKey)i + 1);
            }

            //itemWriteData = itemWrite.Instantiate().Parent(writeBtnPos)
            //     .LocalPosition(Vector3.zero)
            //     .LocalScaleIdentity().GetComponent<BtnWrite>();
            //if (itemWriteData != null) {
            //    itemWriteData.OnRefresh((EnumSaveTypeKey)i + 1);
            //}

        }
    }




    private void OnlGridViewCallBack(int index, GameObject item) {
        //itemWriteData = item.GetComponent<BtnWrite>();
        //if (itemWriteData != null) {
        //    itemWriteData.OnRefresh((EnumSaveTypeKey)index + 1);
        //}
        //IListItem itemData = item.GetComponent<IListItem>();

        //if (itemData != null) {
        //    itemData.Init(index);
        //    itemData.OnRefresh();
        //}

    }


    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        writeBtn[0].onClick.AddListener(OnWriteBtnByteClick);
        writeBtn[1].onClick.AddListener(OnWriteBtnXmlClick);
        writeBtn[2].onClick.AddListener(OnWriteBtnJsonClick);
        writeBtn[3].onClick.AddListener(OnWriteBtnProtoClick);

        readerBtn[0].onClick.AddListener(OnReaderBtnByteClick);
        readerBtn[1].onClick.AddListener(OnReaderBtnXmlClick);
        readerBtn[2].onClick.AddListener(OnReaderBtnJsonClick);
        readerBtn[3].onClick.AddListener(OnReaderBtnProtoClick);
        UIToos.ButtonAddListener(BtnBack, OnBtnBack);
        UITransitionExtension.BindTransition<LobbyGamePanel, LobbyGameLobbyPanel>(BtnBack);
    }


    private void OnWriteBtnByteClick() {
        WriteFileData();
    }


    private void OnWriteBtnXmlClick() {

        WriteFileData(SaveImplementType.ImplementXML);
    }

    private void OnWriteBtnJsonClick() {
        WriteFileData(SaveImplementType.ImplementJson);
    }


    private void OnWriteBtnProtoClick() {

        WriteFileData(SaveImplementType.ImplementProto);
    }


    private void OnReaderBtnByteClick() {
        ReadFileData();
    }

    private void OnReaderBtnXmlClick() {
        ReadFileData(SaveImplementType.ImplementXML);
    }

    private void OnReaderBtnJsonClick() {
        ReadFileData(SaveImplementType.ImplementJson);
    }


    private void OnReaderBtnProtoClick() {
        ReadFileData(SaveImplementType.ImplementProto);
    }

    private void WriteFileData(SaveImplementType type = SaveImplementType.ImplementByte) {
        using (Profiler p = new Profiler("SaveToolsHelp.Write")) {
            for (int i = 0; i < count; i++) {
                SaveToolsHelp.Write(i, i + "文件", type);
            }
        }
    }

    private void ReadFileData(SaveImplementType type = SaveImplementType.ImplementByte) {
        using (Profiler p = new Profiler("SaveToolsHelp.Reader")) {
            for (int i = 0; i < count; i++) {
                SaveToolsHelp.Reader<int>(i + "文件", type);
            }
        }
    }

    private void OnBtnBack(GameObject go) {
        // QUIManager.Instance.HideUI(this.name);
        //UIMgr.HidePanel<LobbyGamePanel>();
        // UIMgr.OpenPanel<LobbyGameLobbyPanel>();

    }



    protected override void OnShow() {
        base.OnShow();
        //SaveSetting saveSetting = new SaveSetting("1", path);
        //SaveSetting saveSetting1 = new SaveSetting("2", path);
        //SaveSetting saveSetting2 = new SaveSetting("3", path);
        //SaveSetting saveSetting3 = new SaveSetting("4", path);
        //SaveSetting saveSetting4 = new SaveSetting("5", path);
        //SaveSetting saveSetting5 = new SaveSetting("6", path);
        //SaveSetting saveSetting6 = new SaveSetting("7", path);

        Debug.LogError(SaveToolsHelp.Reader<int>("1"));
        //List<string> ls = new List<string>();
        //ls.Add("哈哈");
        //ls.Add("嘻嘻");
        //ls.Add("娃娃");

        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "哈哈");
        dictionary.Add(2, "嘻嘻");
        SaveToolsHelp.Write(dictionary, "XMl测试", SaveImplementType.ImplementXML);
        foreach (var item in SaveToolsHelp.Reader<Dictionary<int, string>>("XMl测试", SaveImplementType.ImplementXML)) {
            Debug.LogError(item);
        }
        //Debug.LogError(SaveToolsHelp.Reader<List<float>>("XMl测试", SaveImplementType.ImplementXML));

        //Dictionary<int, TestEnum> dictionary = new Dictionary<int, TestEnum>();
        //dictionary.Add(1, TestEnum.One);
        //dictionary.Add(2, TestEnum.Two);
        //Vector2 v = new Vector2(600, 800);
        //dictionary.Add(3, TestEnum.Two);
        // DateTime dateTime = new DateTime(1991, 10, 21);
        //string[] tesBool = new string[] { "嘻嘻", "哈哈" };
        //SaveToolsHelp.Write(tesBool, "加密", SaveImplementType.ImplementJson);
        //foreach (var item in SaveToolsHelp.Reader<Dictionary<int, TestEnum>>("加密", SaveImplementType.ImplementJson)) {
        //    Debug.LogError(item.Key + "&&&" + item.Value);
        //}
        //string[] tstInt = SaveToolsHelp.Reader<string[]>("加密", SaveImplementType.ImplementJson);
        //for (int i = 0; i < tstInt.Length; i++) {
        //    LogTest(tstInt[i]);
        //}
        //Debug.LogError(SaveToolsHelp.Reader<DateTime>("加密", SaveImplementType.ImplementJson));
        //imgColor.color = SaveToolsHelp.Reader<Color>("Color");
        //SaveToolsHelp.Write("haha", "存的string数据");



        //SaveToolsHelp.Write(ls, "加密list");

        //SaveToolsHelp.Write(100, "json加密", SaveImplementType.ImplementJson);
        //Debug.LogError(SaveToolsHelp.Reader<int>("json加密", SaveImplementType.ImplementJson));

        //SaveToolsHelp.Write(ls, "jsonlist加密", SaveImplementType.ImplementJson);
        //foreach (var item in SaveToolsHelp.Reader<List<int>>("jsonlist加密", SaveImplementType.ImplementJson)) {
        //    Debug.LogError(item);
        //}
        // SaveToolsHelp.Clear();

        // SaveToolsHelp.Write("我也是醉了", "string");
        //  LogTest(SaveToolsHelp.Reader("string", "我是默认值"));
        //  SaveToolsHelp.Write(100, "int");
        // LogTest(SaveToolsHelp.Reader<int>("int"));
        //   SaveToolsHelp.Write(true, "bool");
        //  LogTest(SaveToolsHelp.Reader<bool>("bool"));
        //   SaveToolsHelp.Write(0.3, "folat");
        //  LogTest(SaveToolsHelp.Reader<float>("folat"));
        //  Vector2 v = new Vector2(100, 100);
        //    SaveToolsHelp.Write(v, "Vector2");
        //   LogTest(SaveToolsHelp.Reader<Vector2>("Vector2"));
        // Vector3 v3 = new Vector3(200, 200, 0);
        //     SaveToolsHelp.Write(v3, "Vector3");
        //   LogTest(SaveToolsHelp.Reader<Vector3>("Vector3"));
        // Vector4 v4 = new Vector4(300, 300, 300, 300);
        //   SaveToolsHelp.Write(v4, "Vector4");
        //  LogTest(SaveToolsHelp.Reader<Vector4>("Vector4"));
        //   long lo = 9223372036854775807;
        //   SaveToolsHelp.Write(lo, "long");
        //  LogTest(SaveToolsHelp.Reader<long>("long"));
        //    SaveToolsHelp.Write(Quaternion.identity, "Quaternion");
        //  LogTest(SaveToolsHelp.Reader<Quaternion>("Quaternion"));
        //    SaveToolsHelp.Write(Color.blue, "Color");
        //  LogTest(SaveToolsHelp.Reader<Color>("Color"));
        // double d = 1.7976931348623157;
        //     SaveToolsHelp.Write(d, "double");
        //  LogTest(SaveToolsHelp.Reader<double>("double"));
        //     SaveToolsHelp.Write(TestEnum.Two, "Enum");
        //  LogTest(SaveToolsHelp.Reader<TestEnum>("Enum"));
        //List<int> lsString = new List<int>();
        //lsString.Add(1);
        //lsString.Add(8);
        //lsString.Add(9);
        //SaveToolsHelp.Write(lsString, "List");
        //foreach (var item in SaveToolsHelp.Reader("List", lsString)) {
        //    LogTest(item);
        //}

        // SaveToolsHelp.Write(dictionary, "Dictionary");
        //foreach (var item in SaveToolsHelp.Reader("Dictionary", dictionary)) {
        //    // LogTest(item.Value);
        //}
        Byte by = 233;
        //    SaveToolsHelp.Write(by, "Byte");
        //  LogTest(SaveToolsHelp.Reader<byte>("Byte"));
        short sh = 32767;
        //    SaveToolsHelp.Write(sh, "Short");
        //  LogTest(SaveToolsHelp.Reader<short>("Short"));
        uint ui = 4294967295;
        //  SaveToolsHelp.Write(ui, "uint");
        //   LogTest(SaveToolsHelp.Reader<uint>("uint"));
        ulong ul = 18446744073709551615;
        //   SaveToolsHelp.Write(ui, "ulong");
        //  LogTest(SaveToolsHelp.Reader<ulong>("ulong"));
        ushort us = 65535;
        //  SaveToolsHelp.Write(us, "ushort");
        //  LogTest(SaveToolsHelp.Reader<ushort>("ushort"));
        char ch = 'A';
        //   SaveToolsHelp.Write(ch, "char");
        //   LogTest(SaveToolsHelp.Reader<char>("char"));
        //    SaveToolsHelp.Write(DateTime.Now, "DateTime");
        //  LogTest(SaveToolsHelp.Reader<DateTime>("DateTime"));
        double[] array = new double[] { 100, 200 };
        //   SaveToolsHelp.Write(array, "Array");
        //   bool[] tesBool = new bool[] { false, true };
        //bool[] tstInt = SaveToolsHelp.Reader<bool[]>("Array");
        //for (int i = 0; i < tstInt.Length; i++) {
        //    LogTest(tstInt[i]);
        //}
        //Hashtable hs = new Hashtable();
        //hs.Add(1, "A");
        //hs.Add(2, "B");
        // SaveToolsHelp.Write(hs, "Hashtable",SaveImplementType.ImplementJson);
        //foreach (DictionaryEntry item in SaveToolsHelp.Reader<Hashtable>("Hashtable", SaveImplementType.ImplementJson)) {
        //    LogTest(item.Key + "***" + item.Value);
        //}
        //ArrayList arrayList = new ArrayList();
        //arrayList.Add("Abc");
        //arrayList.Add(false);
        //arrayList.Add(0.01f);
        //SaveToolsHelp.Write(arrayList, "ArrayList", SaveImplementType.ImplementJson);
        //foreach (var item in SaveToolsHelp.Reader<ArrayList>("ArrayList", SaveImplementType.ImplementJson)) {
        //    LogTest(item);
        //}
        //   SaveToolsHelp.Clear();

        lGridView.cols = 2;
        lGridView.cellsCount = readTypeName.Length;
        lGridView.SetCellHandle(OnlGridViewCallBack);
        lGridView.reloadData();

        lGridPageView.cols = 3;
        lGridPageView.rows = 4;
        lGridPageView.gridCellsCount = 22;
        lGridPageView.onPageChangedHandler = LGridPageViewCallback;
        lGridPageView.reloadData();
    }

    private void LGridPageViewCallback(int idx) {
        Debug.LogError(idx);
    }

    public void LogTest(object value) {

        string str = string.Format("结果:{0}", value);
        Debug.LogError(str);
    }

    protected override void OnHide() {
        base.OnHide();
    }
}
