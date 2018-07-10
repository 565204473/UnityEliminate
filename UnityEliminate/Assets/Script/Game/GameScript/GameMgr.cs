using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : QMonoSingleton<GameMgr> {

    public Dictionary<string, Item> dic;
    public Item StartCode;
    public int StartIndex;
    public Item EndCode;


    public override void OnSingletonInit() {
        base.OnSingletonInit();
        dic = new Dictionary<string, Item>();
    }

    public void AddDic(string name, Item it) {

        if (!dic.ContainsKey(name)) {
            dic[name] = it;
        }
    }

    public Item GetDicItem(string name) {

        Item it;
        if (dic.TryGetValue(name, out it)) {
            return it;
        }
        return null;
    }
}
