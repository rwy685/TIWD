public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Attack
}

public enum EnemyState
{
    Idle,
    Wander,
    Chase,
    Attack
}

public enum ItemType
{
    Equipable,      // 장착 아이템
    Consumable,     // 소비 아이템
    Resource        // 기타 자원
}

public enum EquipableType
{
    None,       // Consumable 이나 Resource
    Weapon,     // 전투용 무기
    Tool        // 자원 채집용 도구
}

public enum ConsumableType
{
    Health,     // 체력 회복 아이템
    Stamina,    // 스태미나 회복 아이템
    Hunger,     // 허기 회복 아이템
    Thirst      // 갈증 회복 아이템
}
