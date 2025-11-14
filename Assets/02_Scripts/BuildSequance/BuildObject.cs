using System;
using UnityEngine;

public interface IBuildable
{
    int NeededResource { get; }
    int CurrentResource { get; }
    void AddResource(int amount);
    bool IsComplete { get; }
    void Build();
}

public abstract class BuildObject : MonoBehaviour, IBuildable
{
    public int NeededResource { get; protected set; }
    public int CurrentResource { get; protected set; }
    public bool IsComplete
    {
        get
        {
            return CurrentResource >= NeededResource;
        }
    }

    public event Action OnComplete;

    public void AddResource(int amount)
    {
        CurrentResource += amount;
        if (CurrentResource >= NeededResource)
        {
            CurrentResource = NeededResource;
            OnComplete?.Invoke();
        }
    }
    public abstract void Build();
}
