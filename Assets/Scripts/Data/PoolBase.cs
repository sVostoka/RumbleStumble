using System;
using System.Collections.Generic;

public class PoolBase<T>
{
    private Func<T> _preloadFunc;
    private Action<T> _getAction;
    private Action<T> _returnAction;

    private Queue<T> _pool = new();
    private List<T> _activeElements = new List<T>();

    public PoolBase(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
    {
        _preloadFunc = preloadFunc;
        _getAction = getAction;
        _returnAction = returnAction;

        for(int i = 0; i < preloadCount; i++)
        {
            Return(preloadFunc());
        }
    }

    public T GetElement()
    {
        T element = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
        _getAction(element);
        _activeElements.Add(element);

        return element;
    }

    public void Return(T element)
    {
        _returnAction(element);
        _pool.Enqueue(element);
        _activeElements.Remove(element);
    }

    public void ReturnAll()
    {
        foreach(T element in _activeElements.ToArray())
        {
            Return(element);
        }
    }
}