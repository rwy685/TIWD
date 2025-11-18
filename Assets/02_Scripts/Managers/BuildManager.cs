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
        float closestDist = Mathf.Infinity;

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
    public void TryUseResource(Inventory inventory, ItemData item, Vector3 playerPos)
    {
        // 1. 가장 가까운 건축물 찾기
        BuildObject buildable = GetClosestBuildable(playerPos);
        if (buildable == null)
        {
            Debug.Log("[TryUseResource] 가까운 건축물이 없음");
            return;
        }

        // 2. ItemData → BuildResourceData 변환
        BuildResourceData resourceType = buildable.GetResourceTypeByItem(item);
        if (resourceType == null)
        {
            Debug.Log("[TryUseResource] 이 아이템은 이 건축물의 자원이 될 수 없음");
            return;
        }

        // 3. 인벤토리에서 아이템 소비
        //if (!inventory.Consume(item, 1))
        //{
        //    Debug.Log("[TryUseResource] 인벤토리에 충분한 자원이 없음");
        //    return;
        //}

        // 4. 건축물에 자원 투입
        bool result = buildable.AddResource(resourceType, 1);
        if (result)
            Debug.Log($"[TryUseResource] {item.name} 1개 사용 → {buildable.name}에 투입 완료");
    }


}
