using UnityEngine.SceneManagement;

public class HomePanel : Panel
{
    public void PlayGame()
    {
        SceneManager.LoadScene(GameConfig.GameScene);
    }

    public void OnClickSettingButton()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SettingPanel);
    }

    public void OnClickShopButton()
    {
        PanelManager.Instance.OpenPanel(GameConfig.ShopPanel);
    }
}