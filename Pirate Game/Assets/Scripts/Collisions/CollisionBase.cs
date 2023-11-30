using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    [SerializeField]
    private GameObject rootComponent;

    public delegate void CollisionEventHandler(GameObject component, GameObject collidedObject);
    public static event CollisionEventHandler OnCollision;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ICollision origin = rootComponent.GetComponent<ICollision>();
        ICollision destination = collision.gameObject.GetComponent<ICollision>();

        if (!origin.HasCollided && destination != null && !destination.HasCollided)
            OnCollision?.Invoke(rootComponent, collision.gameObject);                   
    }        
}
