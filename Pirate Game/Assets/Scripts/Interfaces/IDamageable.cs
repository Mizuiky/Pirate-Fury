
public interface IDamageable
{
    public void Damage(float damage);
    public void Destroy();
    public void Kill();
    public float TotalDamageToDeal { get; }
}
