namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIRoot _uiRoot;
            
            public UIManager(UIRoot uiRoot)
            {
                _uiRoot = uiRoot;
            }
            
            public void OpenViewController(IController controller)
            {
                _uiRoot.Create(nameof(PController), controller);
            }
            
            public void OpenViewHud(IPlayer player)
            {
                _uiRoot.Create(nameof(PHud), player);
            }
            
            public void OpenViewMainMenu()
            {
                _uiRoot.Create<IEmptyWidget>(nameof(PMainMenu), null);
            }
            
            public void OpenViewLoseWin()
            {
                _uiRoot.Create<IEmptyWidget>(nameof(WLoseWin), null);
            }

            public void CloseViewGameplay()
            {
                _uiRoot.Kill(nameof(PController));
                _uiRoot.Kill(nameof(PHud));
            }
        }
    }
}