using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public BuildData data;
    
    //자원 투입 현황
    private Dictionary<BuildResourceData, int> currentResources = new Dictionary<BuildResourceData, int>();

    public event Action OnComplete;

    private void Start()
    {
        // 초기화: 모든 요구 자원을 0으로 시작
        foreach (var req in data.requirements)
        {
            currentResources[req.resource] = 0;
        }

        GameManager.Instance.buildManager.Register(this);
    }

    // 자원 투입
    public bool AddResource(ItemData item, int amount)
    {
        foreach (var req in data.requirements)
        {
            if (req.resource.itemData == item)
            {
                currentResources[req.resource] = Mathf.Min(currentResources[req.resource] + amount, req.amount);

                if (IsComplete())
                    OnComplete?.Invoke();

                return true;
            }
        }

        return false;
    }

    // 완성 여부 체크
    public bool IsComplete()
    {
        foreach (var req in data.requirements)
        {
            if (currentResources[req.resource] < req.amount)
                return false;
        }
        return true;
    }
    public void Build()
    {
        Instantiate(data.completePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}


