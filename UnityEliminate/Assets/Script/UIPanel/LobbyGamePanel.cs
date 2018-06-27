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
        itemWrite = mResLoader.LoadSync<GameObject>(PrefabPath.BtnWrite).GetComponent<Transform>();
        for (int i = 0; i < readTypeName.Length; i++) {
            itemReadData = itemRead.Instantiate().Parent(readBtnPos)
                .LocalPosition(Vector3.zero)
                .LocalScaleIdentity().GetComponent<BtnRead>();

            if (itemReadData != null) {
                itemReadData.index = i;
                itemReadData.OnRefresh((EnumSaveTypeKey)i + 1);
            }

            itemWriteData = itemWrite.Instantiate().Parent(writeBtnPos)
                 .LocalPosition(Vector3.zero)
                 .LocalScaleIdentity().GetComponent<BtnWrite>();
            if (itemWriteData != null) {
                itemWriteData.OnRefresh((EnumSaveTypeKey)i + 1);
            }

        }
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

        //List<TestClass> list = new List<TestClass>();
        //TestClass test = new TestClass();
        //test.testInt = "haha";
        //SaveToolsHelp.Write(list, "1",SaveImplementType.ImplementJson);
        //foreach (var item in SaveToolsHelp.Reader<List<TestClass>>("1",SaveImplementType.ImplementJson)) {
        //    Debug.LogError(item.testInt);
        //}

        //Hashtable ha = new Hashtable();
        //ha.Add("B", "3");
        //ha.Add("C", "2");
        //ha.Add("A", 0.1f);
        //SaveToolsHelp.Write(ha, "2", SaveImplementType.ImplementJson);
        //Debug.LogError(SaveToolsHelp.Reader<Hashtable>("2",SaveImplementType.ImplementJson).Count);
        //foreach (DictionaryEntry item in SaveToolsHelp.Reader<Hashtable>("2", SaveImplementType.ImplementJson)) {
        //    Debug.LogError(item.Key + "***" + item.Value);
        //}

        //ArrayList arrayList = new ArrayList();
        //arrayList.Add(32);
        //arrayList.Add("66");
        //SaveToolsHelp.Write(arrayList, "3");

        //ArrayList arrayList = new ArrayList();
        //arrayList.Add("AA");
        //arrayList.Add("88");
        //arrayList.Add(true);
        //SaveToolsHelp.Write(arrayList, "4");

        //foreach (var item in SaveToolsHelp.Reader<ArrayList>("3")) {
        //    Debug.LogError(item);
        //}

        //foreach (var item in SaveToolsHelp.Reader<ArrayList>("5")) {
        //    Debug.LogError(item);
        //}

        SaveToolsHelp.Write(2, "加密");
        Debug.LogError(SaveToolsHelp.Reader<int>("加密"));
        //imgColor.color = SaveToolsHelp.Reader<Color>("Color");

        List<int> ls = new List<int>();
        ls.Add(4);
        ls.Add(5);
        ls.Add(6);

        // SaveToolsHelp.Write(ls, "加密list");
        //foreach (var item in SaveToolsHelp.Reader<List<int>>("加密list")) {
        //    Debug.LogError(item);    
        // }
        //  SaveToolsHelp.Write(100, "json加密", SaveImplementType.ImplementJson);
        Debug.LogError(SaveToolsHelp.Reader<int>("json加密", SaveImplementType.ImplementJson));

        SaveToolsHelp.Write(ls, "jsonlist加密", SaveImplementType.ImplementJson);
        foreach (var item in SaveToolsHelp.Reader<List<int>>("jsonlist加密", SaveImplementType.ImplementJson)) {
            Debug.LogError(item);
        }

        SaveToolsHelp.Clear();

    }

    protected override void OnHide() {
        base.OnHide();
    }
}
