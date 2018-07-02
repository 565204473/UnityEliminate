using Lui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class LobbyGamePanel {
    [SerializeField] public Image imgbg;
    [SerializeField] public Image imgColor;
    [SerializeField] public TextAsset text;
    [SerializeField] public List<Button> writeBtn;
    [SerializeField] private List<Button> readerBtn;
    [SerializeField] public Transform readBtnPos;
    [SerializeField] public Transform writeBtnPos;
    [SerializeField] public int count = 10000;
    [SerializeField] private LGridView lGridView;

}
