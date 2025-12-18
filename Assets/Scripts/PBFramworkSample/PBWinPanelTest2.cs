using Architecture;

namespace PBFramworkSample
{
    public class PBWinPanelTest2 : BasePanel
    {
        protected override void OnBtnClick(string btnName)
        {
            base.OnBtnClick(btnName);
            switch(btnName)
            {
                case "NextBtn":
                    UIManager.Instance.HidePanel(gameObject.name);
                    break;
            }
        }
    }
}
