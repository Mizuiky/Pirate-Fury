using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TripleCannonBall : CannonBallBase
{
    [SerializeField]
    private GameObject [] _cannonBalls;

    [SerializeField]
    private float _ballOffset;

    [SerializeField]
    private SpriteRenderer _ballSprite;

    private BoxCollider2D _boxCollider;

    protected override void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.size = new Vector2(_ballSprite.bounds.size.x, _ballSprite.bounds.size.y);

        SetPosition();
        UpdateColliderRange();
    }

    private void  SetPosition()
    {
        Vector3 p = transform.position;

        _cannonBalls[0].transform.position = p - transform.right * _ballOffset;
        _cannonBalls[1].transform.position = p;
        _cannonBalls[2].transform.position = p + transform.right * _ballOffset;
    }

    private void UpdateColliderRange()
    {
        Vector2 originalSize = _boxCollider.size;
        Vector2 newSize = new(originalSize.x + _ballOffset * 2, originalSize.y);

        _boxCollider.size = newSize;
    }
}
