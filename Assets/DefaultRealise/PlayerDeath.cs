using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;
    private PlayerMovement _movement;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void PlayParticle()
    {
        _movement.MovementPossibility(false);
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        _particle.gameObject.SetActive(true);
        _particle.Play();
    }

    public void Death()
    {
        _player.ChangeGun(new SingleShot());
        PlayParticle();
        print("умер игрок");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        

    //    if (collision.gameObject.GetComponent<Enemy>())
    //    {
    //        Death();
    //    }
    //}
}
