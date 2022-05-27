using System;
using System.Collections;
using System.Collections.Generic;

using DefaultNamespace;

using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private BirdState _birdState;
    [SerializeField] private float _resetDelay;
    [SerializeField] private float _maxDrag = 5;
    
    private Vector2 _startPos;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    
    public BirdState State
    {
        set => _birdState = value;
    }
    
    private void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _birdState = GameObject.Find("SkinController").GetComponent<BirdSkinMgr>()
                .GETState(_rigidBody.gameObject);
    }

    void Start()
    {
        _startPos = _rigidBody.position;
        _rigidBody.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.yellow;
    }

    private void OnMouseUp()
    {
        
        var currPos = _rigidBody.position;
        var direction = _startPos - currPos;
        direction.Normalize();
        
        _rigidBody.isKinematic = false;
        Debug.Log(this._birdState);
        _rigidBody = _birdState.SetSkin(_rigidBody);
        Debug.Log(this._birdState);

        //_birdState.sendFlying(direction, _rigidBody);

        _spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distance = Vector2.Distance(mousePos, _startPos);
        if (distance > _maxDrag)
        {
            Vector2 direction = mousePos - _startPos;
            direction.Normalize();
            mousePos = _startPos + direction * _maxDrag;
        }

        
        _rigidBody.position = mousePos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(ResetDelay());

    }

    private IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(_resetDelay);
        _rigidBody.position = _startPos;
        _rigidBody.isKinematic = true;
        _rigidBody.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (_rigidBody.position.x > 23 || _rigidBody.position.x< (-30))
        {
            Debug.Log("Return to start position");
            _rigidBody.position = _startPos;
            _rigidBody.isKinematic = true;
            _rigidBody.velocity = Vector2.zero;
        }
    }
}
