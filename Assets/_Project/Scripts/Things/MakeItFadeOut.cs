public class MakeItFadeOut : MakeItFadeIn 
{
    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!start)
        {
            start = true;
            fadeInOutPanelAnimator.SetTrigger("FadeToBlack");
            return new DoInteractionState();
        }
        else
        {
            if (!black) return new DoInteractionState();
            else
            {
                start = false;
                return null;
            }
        }
    }

    protected override void Update()
    {
        if (fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            black = true;
        }
        else
        {
            black = false;
        }
    }
}
