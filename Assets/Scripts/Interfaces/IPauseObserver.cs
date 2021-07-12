//Interface to make a script "stop" when game is paused or another condition is met, through observer pattern.
using System;

public interface IPauseObserver
{
    public void OnPauseGame();
    public void OnResumeGame();

    //Search involving scripts on this function and add them OnPauseGame
    public void InitializeObserver();

}

//Interface to notify observers when a pausing event is called. At pause's end, notify it aswell
public interface IPauseSubject
{
    public void AddPauseObserver(Action action);
    public void AddResumeObserver(Action action);

    public void NotifyPauseObservers();
    public void NotifyResumeObservers();
}