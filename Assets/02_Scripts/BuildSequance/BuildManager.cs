using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    private List<IBuildable> buildables = new List<IBuildable>();
    public float interactDistance = 5f;

    private void Awake()
    {
        Instance = this;
    }

    public void Register(IBuildable buildObject)
    {
        buildables.Add(buildObject);
    }
}
