using System;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public BuildData data;

    public int CurrentResource { get; private set; }

    public int NeededResource => data.neededResource;
    public bool IsComplete => CurrentResource >= NeededResource;

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

    public void Build()
    {
        if (data.CompletePrefab != null)
        {
            Instantiate(data.CompletePrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}


