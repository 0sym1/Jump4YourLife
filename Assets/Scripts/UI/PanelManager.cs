using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelManager : MonoBehaviour
{
    [SerializeField] protected GameObject panel;
    [SerializeField] protected GameObject panelPrefab;

    public void ClosePanel(){panel.SetActive(false);}
}
