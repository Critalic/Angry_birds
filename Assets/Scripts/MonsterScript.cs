using System;
using System.Collections;
using UnityEngine;

[SelectionBase] 
public class MonsterScript : MonoBehaviour
{
    [SerializeField] private Sprite _knockSprite;
    [SerializeField] private ParticleSystem _particleSystem;
    private Boolean _isAlive = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (NotKnockedOut(other) && _isAlive)
        {
            Incativate();
        }
    }

    private bool NotKnockedOut(Collision2D collision)
    {
        BirdScript bird = collision.gameObject.GetComponent<BirdScript>();
        return (bird != null || collision.contacts[0].normal.y < -0.5);
    }

    private void Incativate()
    {
        GetComponent<SpriteRenderer>().sprite = _knockSprite;
        _particleSystem.Play();
        _isAlive = false;
        StartCoroutine( KnockoutDelay());
         
    }

    private IEnumerator KnockoutDelay()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
