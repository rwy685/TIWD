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
    public void AddResource(BuildResourceData resource, int amount)
    {
        if (!currentResources.ContainsKey(resource))
            return;  // 이 건축물은 해당 자원이 필요 없음

        currentResources[resource] =
            Mathf.Min(currentResources[resource] + amount,
                      GetRequiredAmount(resource));

        if (IsComplete())
            OnComplete?.Invoke();
    }

    // 특정 자원의 필요량 가져오기
    public int GetRequiredAmount(BuildResourceData resource)
    {
        foreach (var req in data.requirements)
        {
            if (req.resource == resource)
                return req.amount;
        }
        return 0;
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


