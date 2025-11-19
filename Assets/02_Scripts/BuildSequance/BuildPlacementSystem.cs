using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//preview 위치에 바로  BuildData compltePrebfab 건축물 설치
public class BuildPlacementSystem
{
    public void PlaceStructure(BuildData data, BuildPreviewController preview)
    {
        Object.Instantiate(data.completePrefab, preview.GetPosition(), preview.GetRotation());
    }
}


