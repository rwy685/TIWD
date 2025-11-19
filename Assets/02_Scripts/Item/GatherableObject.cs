using System.Collections;
using UnityEngine;

public interface IGatherable
{
    void OnGathered();

    void DropItems();
}

public class GatherableObject : MonoBehaviour, IDamagable, IGatherable
{
    [Header("SpawnInfo")]
    [SerializeField] private int maxHP = 5;
    [SerializeField] private int currentHP;
    [SerializeField] private float respawnTime = 10f;

    [Header("Drop Settings")]
    [SerializeField] private DropData[] dropItems;
    [SerializeField] private float dropRadius = 1.5f;   // 아이템 드랍 반경

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakePhysicalDamage(float damage=1f)
    {
        currentHP -= (int)damage;

        if (currentHP <= 0)
            OnGathered();
    }

    public void OnGathered()
    {
        DropItems();

        Invoke("Respawn", respawnTime);

        gameObject.SetActive(false);
    }

    public void DropItems()
    {
        // TODO : 나무 or 돌 드랍

        // null 체크
        if (dropItems == null || dropItems.Length == 0)
        {
            Debug.LogWarning($"{gameObject.name} : 드랍할 아이템이 없습니다!");
            return;
        }

        foreach (var dropData in dropItems)
        {
            // null 체크
            if (dropData == null || dropData.dropPrefab == null)
                continue;

            // 드랍 확률 체크
            float randomValue = Random.Range(0f, 100f);
            if (randomValue <= dropData.dropChance)
            {
                // 드랍 개수 결정 (min ~ max 사이의 랜덤 값)
                int dropCount = Random.Range(dropData.minDropCount, dropData.maxDropCount + 1);

                // 결정된 개수만큼 아이템 생성
                for (int i = 0; i < dropCount; i++)
                {
                    SpawnDropItem(dropData.dropPrefab);
                }
            }
        }
    }

    void SpawnDropItem(GameObject itemPrefab)
    {
        // 오브젝트 주변의 랜덤한 위치 계산
        Vector2 randomCircle = Random.insideUnitCircle * dropRadius;
        Vector3 dropPosition = transform.position + new Vector3(randomCircle.x, 0.5f, randomCircle.y);

        // 아이템 생성
        Instantiate(itemPrefab, dropPosition, Quaternion.identity);
    }

    void Respawn()
    {
        currentHP = maxHP;
        gameObject.SetActive(true);
    }

    // Test용 충돌 처리 (플레이어와 충돌 시 데미지 받음)
    // TODO : 플레이어 도구로 공격 시 데미지 받도록 변경
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.TakePhysicalDamage();
    }
}
