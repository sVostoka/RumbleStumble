using System;

public abstract class ObservationObject
{
    public event Action Changed;
    public void CallObservers()
    {
        if (Changed != null)
        {
            Changed.Invoke();
        }
    }
}