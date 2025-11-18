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
        ItemData item = player.acquiredItem;

        if (item == null)
        {
            Debug.Log("[TryUseResource] 플레이어가 들고 있는 아이템 없음");
            return;
        }

        // 1) 가장 가까운 건축물 찾기
        BuildObject buildable = GetClosestBuildable(player.transform.position);
        if (buildable == null)
        {
            Debug.Log("[TryUseResource] 근처에 건축중인 구조물이 없음");
            return;
        }

        // 2) 이 아이템이 건설 자원으로 사용 가능한지 확인
        BuildResourceData resourceType = buildable.GetResourceTypeByItem(item);
        if (resourceType == null)
        {
            Debug.Log("[TryUseResource] 이 아이템은 해당 건축물에 투입할 수 없음");
            return;
        }

        // 3) 인벤토리에서 실제 자원 소비
        if (!inv.ConsumeMultiple(item, 1))
        {
            Debug.Log("[TryUseResource] 인벤토리에 자원이 부족합니다.");
            return;
        }

        // 4) 건축물에 자원 투입
        bool result = buildable.AddResource(resourceType, 1);

        if (result)
            Debug.Log($"[TryUseResource] {item.name} 1개 사용 → {buildable.name}에 투입 완료");
    }



}
