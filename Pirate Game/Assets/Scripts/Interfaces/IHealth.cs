
public interface IHealth
{
    public void Reset();
    public void UpdateLife(float value);
    public float CurrentLife { get; }
}
