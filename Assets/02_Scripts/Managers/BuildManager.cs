using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    private List<BuildObject> buildables; //BuildObject을 가진 대상을 리스트화
    private Dictionary<BuildObject, Action> callbackMap;

    private void Awake()
    {
         buildables = new List<BuildObject>();
         callbackMap = new Dictionary<BuildObject, Action>();
    }

    // BuildObject 리스트 등록 및 이벤트 구독
    public void Register(BuildObject buildObject) // 리스트에 등록
    {
        buildables.Add(buildObject);

        Action callback = () => OnBuildComplete(buildObject); //람다를 Action으로 저장
        callbackMap[buildObject] = callback; // 구독해지할때 필요 딕셔너리에 보관
        buildObject.OnComplete += callback; // 건축 필요 양과 같아질 경우 OnBuildComplte 호출
    }

    // BuildObject 리스트 제거 및 이벤트 해제
    public void Unregister(BuildObject buildObject)
    {
        if (callbackMap.TryGetValue(buildObject, out var callback))
        {
            buildObject.OnComplete -= callback;
            callbackMap.Remove(buildObject); // 람다 구독해지 
        }

        buildables.Remove(buildObject); // 리스트에서 제거
    }

    // 건물 완성시 실행시킬 함수
    private void OnBuildComplete(BuildObject buildObject)
    {
        buildObject.Build(); // 해당 건축구조물 만들기
        Unregister(buildObject); // 건축완료시 구독해제 + 리스트 제거
    }

    // 가장 가까운 BuildObject를 찾기
    public BuildObject GetClosestBuildable(Vector3 playerPos, float maxDistance = 4f)
    {
        BuildObject closest = null;
        float closestDist = Mathf.Infinity; //거리 비교용 최대값

        foreach (var b in buildables)
        {
            if (b == null) continue;

            float dist = Vector3.Distance(playerPos, b.transform.position);
            if (dist < closestDist && dist <= maxDistance)
            {
                closestDist = dist;
                closest = b;
            }
        }

        return closest;
    }

    //인벤토리에서 자원을 건축재료로 사용
    public void TryUseResource(Player player)
    {
        Inventory inv = player.inventory;

        // 1) 가장 가까운 건축물 찾기
        BuildObject buildable = GetClosestBuildable(player.transform.position);
        if (buildable == null)
        {
            Debug.Log("[TryUseResource] 근처에 건축중인 구조물이 없음");
            return;
        }

        // 2) 건축물이 요구하는 재료들을 확인
        foreach (var req in buildable.data.requirements)
        {
            BuildResourceData resourceType = req.resource;

            // acceptable Items 목록에서 인벤토리에 있는 아이템 찾기
            foreach (var item in resourceType.acceptableItems)
            {
                if (inv.Has(item, 1))
                {
                    // 3) 인벤토리에서 소비
                    if (inv.ConsumeMultiple(item, 1))
                    {
                        // 4) 건축물에 자원 투입
                        buildable.AddResource(resourceType, 1);

                        Debug.Log($"[TryUseResource] {item.name} 1개 사용 → {buildable.name}에 투입 완료");
                        return;
                    }
                }
            }
        }

        Debug.Log("[TryUseResource] 인벤토리에 해당 자원이 없음");
    }

}
