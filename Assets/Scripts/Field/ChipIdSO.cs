using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ChipIdTable", menuName = "ScriptableObject/CreateChipIdTable")]
public class ChipIdSO : ScriptableObject
{
    public List<Sprite> chipImg = new List<Sprite>();

}