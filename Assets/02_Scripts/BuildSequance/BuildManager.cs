using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public BuildManager Instance;

    private List<IBuildable> buildables = new List<IBuildable>(); //IBuildable을 가진 대상을 리스트화

    private void Awake()
    {
        Instance = this;
    }

    public void Register(IBuildable buildObject) // 리스트에 등록
    {
        buildables.Add(buildObject);
        buildObject.OnComplete += () => OnBuildComplete(buildObject); // 건축 필요 양과 같아질 경우 OnBuildComplte 호출
    }

    public void Unregister(IBuildable buildObject)
    {
        buildables.Remove(buildObject); // 건축완료시 리스트에서 제거용
    }

    private void OnBuildComplete(IBuildable buildObject)
    {
        buildObject.Build(); // 해당 건축구조물 만들기
        Unregister(buildObject);
    }

    //void TryInteract()
    //{
    //    if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, 3f))
    //    {
    //        if (hit.collider.TryGetComponent(out IBuildable buildable))
    //        {
    //            buildable.AddResource(1);
    //        }
    //    }
    //}

    //public void TryUseResource(PlayerInventory inv, Vector3 playerPos)
    //{
    //    var buildable = GetClosestBuildable(playerPos);
    //    if (buildable == null) return;

    //    inv.ConsumeResource(1);              // 플레이어 인벤 변경
    //    buildable.AddResource(1);            // 건축물 자원 채우기
    //}

}
