public interface IDamagable
{
    void TakePhysicalDamage(float damage);
}

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public interface IGatherable
{
    void TakeGatheringDamage(int damage);

    void OnGathered();

    void DropItems();
}
