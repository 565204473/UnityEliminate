using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameContainerHelp
{
    public static void CreateView(int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Debug.Log("1");
            }
        }
    }
}
