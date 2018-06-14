using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private int row;
    private int column;
    public Image imaBg;
    public List<Color> lsColors = new List<Color>();

    public void OnRefresh()
    {
        int index = Random.Range(0, lsColors.Count);
        this.imaBg.color = lsColors[index];
    }

    public void SetPos(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
}
