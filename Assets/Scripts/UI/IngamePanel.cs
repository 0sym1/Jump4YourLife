namespace UI
{
    public class IngamePanel : Panel
    {
        public void OnClickPauseButton()
        {
            PanelManager.Instance.OpenPanel(GameConfig.PausePanel);
        }
    }
}