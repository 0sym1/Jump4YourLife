using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ground", menuName = "ScriptableObject/Ground")]
public class Ground : ScriptableObject
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    public Sprite GetSprite1(){ return sprite1; }
    public Sprite GetSprite2(){ return sprite2; }
}
