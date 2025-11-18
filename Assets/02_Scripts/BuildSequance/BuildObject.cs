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
    public bool AddResource(BuildResourceData resource, int amount)
    {
        Debug.Log($"[AddResource] 입력된 자원 SO : {resource.name}");

        if (!currentResources.ContainsKey(resource))
        {
            Debug.LogWarning("[AddResource] currentResources에 해당 자원없음");
            return false;
        }

        Debug.Log($"[AddResource] 기존 투입량: {currentResources[resource]}, 요구량: {GetRequiredAmount(resource)}");

        int before = currentResources[resource];
        currentResources[resource] =
            Mathf.Min(currentResources[resource] + amount,
                      GetRequiredAmount(resource));

        Debug.Log($"[AddResource] {resource.name} 증가: {before} → {currentResources[resource]}");

        if (IsComplete())
            OnComplete?.Invoke();

        return true;
    }

    // 자원 요구량 체크
    public int GetRequiredAmount(BuildResourceData resource)
    {
        foreach (var req in data.requirements)
        {
            Debug.Log($"[GetRequiredAmount] 비교중: req.resource = {req.resource.name}, 입력: {resource.name}");
            if (req.resource == resource)
            {
                Debug.Log($"[GetRequiredAmount] 매칭 성공/ 요구량 {req.amount}");
                return req.amount;
            }
        }
        Debug.LogWarning($"[GetRequiredAmount] 매칭 실패 / 요구량 0 반환");
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

    // ItemData가 어떤 BuildResourceData로 투입 가능한지 반환
    public BuildResourceData GetResourceTypeByItem(ItemData item)
    {
        foreach (var req in data.requirements)
        {
            foreach (var acceptable in req.resource.acceptableItems)
            {
                if (acceptable == item)
                    return req.resource;
            }
        }

        return null;
    }

}


