using System.Collections;

using DefaultNamespace;
using DefaultNamespace.State;

using UnityEngine;

public class Bird : MonoBehaviour
{
    private BirdState _birdState;
    [SerializeField] private float _resetDelay;
    [SerializeField] private float _maxDrag = 5;
    
    private Vector2 _startPos;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    public void setState(BirdState state)
    {
        Debug.Log("New state - " + _birdState);
        _birdState = state;
    }

    void Start()
    {  
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.white;
        _birdState = GameObject.Find("SkinController").GetComponent<ColorStateFactory>().GETInitialState();
        Debug.Log("Initial state - " + _birdState);
        
        _startPos = _rigidBody.position;
        _rigidBody.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _birdState.MouseDown(_spriteRenderer);
    }

    private void OnMouseUp()
    {
        _birdState.MouseUp(_startPos, _rigidBody, _spriteRenderer);
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
