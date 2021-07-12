//Interface to make a script "stop" when game is paused or anothe condition is met through observer pattern.
public interface IPauseObserver
{
    public void OnPauseGame();
    public void OnResumeGame();

    public void InitializeObserver();

}