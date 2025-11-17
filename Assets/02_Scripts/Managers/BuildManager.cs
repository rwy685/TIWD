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

    private void OnBuildComplete(BuildObject buildObject)
    {
        buildObject.Build(); // 해당 건축구조물 만들기
        Unregister(buildObject); // 건축완료시 구독해제 + 리스트 제거
    }


    //public void TryUseResource(PlayerInventory inv, Vector3 playerPos)
    //{
    //    var buildable = GetClosestBuildable(playerPos);
    //    if (buildable == null) return;

    //    inv.ConsumeResource(1);              // 플레이어 인벤 변경
    //    buildable.AddResource(1);            // 건축물 자원 채우기
    //}

}
