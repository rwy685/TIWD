using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildCatalog", menuName = "Build/Build Catalog")]
public class BuildCatalog : ScriptableObject
{
    public List<BuildData> buildList;
}
