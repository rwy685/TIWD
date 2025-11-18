using UnityEngine;

public class SupplyCrate : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;     // 보급상자 최대 체력
    [SerializeField] private int currentHp;     // 보급상자 현재 체력

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage = 1)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            DestroyCrate();
        }
    }

    private void DestroyCrate()
    {
        // TODO : 보급상자 파괴 시 효과 및 아이템 드랍 로직 추가
        Destroy(gameObject);
    }

    // Test용 충돌 처리 (플레이어와 충돌 시 데미지 받음)
    // TODO : 플레이어 도구로 공격 시 데미지 받도록 변경
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.TakeDamage();
    }
}
