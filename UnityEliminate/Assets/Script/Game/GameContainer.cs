using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

public class GameContainer : QMonoSingleton<GameContainer>
{
    private ResLoader mResLoader = ResLoader.Allocate();
    private Transform item;
    private Item itemData;
    public Vector2 offset = new Vector2(0, 0);
    //ITEM的边长
    public float itemSize = 80;
    void Start()
    {
        item = mResLoader.LoadSync<GameObject>(PrefabPath.PrefabBlock).GetComponent<Transform>();
        itemData = item.GetComponent<Item>();
        CreateView(5, 5);
    }

    public void CreateView(int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Vector3 locaV3 = new Vector3(j * itemSize, i * itemSize, 0) + new Vector3(offset.x, offset.y, 0);
                item.Instantiate().Parent(this.transform)
                    .LocalPosition(locaV3)
                    .LocalScaleIdentity();
                itemData.OnRefresh();
            }
        }
    }

}
