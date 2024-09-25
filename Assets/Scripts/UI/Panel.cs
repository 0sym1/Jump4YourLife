using UnityEngine;

public class Panel : MonoBehaviour
{
    protected string panelName;

    public void Init(string pName)
    {
        panelName = pName;
    }

    public void OpenPanel()
    {
        // Debug.Log(gameObject.name);
        // Debug.Log(gameObject.activeInHierarchy);
        // Debug.Log(gameObject.activeSelf);
        Debug.Log("Open panel: " + panelName);
        gameObject.SetActive(true);
        // Debug.Log(gameObject.activeInHierarchy);
        // Debug.Log(gameObject.activeSelf);
    }

    public void ClosePanel()
    {
        Destroy(gameObject);
    }
}