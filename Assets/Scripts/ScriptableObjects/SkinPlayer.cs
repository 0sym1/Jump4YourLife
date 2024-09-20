using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPlayer", menuName = "ScriptableObject/SkinPlayer")]
public class SkinPlayer : ScriptableObject
{
    [SerializeField] private string nameSkin;
    [SerializeField] private Sprite avatar;
    [SerializeField] private GameObject prefab;
}
