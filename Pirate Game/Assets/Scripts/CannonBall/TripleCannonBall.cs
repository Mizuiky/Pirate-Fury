using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("triple start");

        _boxCollider = GetComponent<BoxCollider2D>();

        if (_ballSprite != null)
            _boxCollider.size = new Vector2(_ballSprite.bounds.size.x, _ballSprite.bounds.size.y);

        SetPosition();

        UpdateColliderRange();
    }

    private void  SetPosition()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                _cannonBalls[i].transform.position = transform.position + new Vector3(_ballOffset, 0, 0);
            }
            else if(i == 1)
            {
                _cannonBalls[i].transform.position = transform.position;
            }
            else if(i == 2)
            {
                _cannonBalls[i].transform.position = transform.position - new Vector3(_ballOffset, 0, 0);
            }
        }
    }

    private void UpdateColliderRange()
    {
        Vector2 originalSize = _boxCollider.size;

        Vector2 newSize = new Vector2((originalSize.x * 3) + _ballOffset, originalSize.y);

        _boxCollider.size = newSize;
    }
}
