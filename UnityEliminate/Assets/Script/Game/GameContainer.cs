using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

public class GameContainer : QMonoSingleton<GameContainer>
{
    private ResLoader mResLoader = ResLoader.Allocate();
    void Start()
    {
        CreateView(5, 5);
    }

    public void CreateView(int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                mResLoader.LoadSync<Image>("Resources/Prefab/PrefabBlock").Instantiate().Parent(this.transform);
            }
        }
    }

}
