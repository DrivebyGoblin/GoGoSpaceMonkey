using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponImprove : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    private SpriteRenderer _sprite;
    private float _moveValue;
    private float _moveSpeed = 1f;
    private float _radius = 1.2f;


    public void ImproveWeapon()
    {
        var x = _player.ShotSystem;

        switch (x)
        {

            case SingleShot:
                _player.ChangeGun(new FastSingleShot());
                break;

            case FastSingleShot:
                _player.ChangeGun(new DoubleShot());
                break;

            case DoubleShot:
                _player.ChangeGun(new FastDoubleShot());
                break;
            
            case FastDoubleShot:
                _player.ChangeGun(new TripleShot());
                break;

            case TripleShot:
                _player.ChangeGun(new FastTripleShot());
                break;
                
        }   
    }




    public void SpawnImprover()
    {
        //_sprite.sprite = sprites[0];
        transform.position = _spawnPosition.position;
        transform.gameObject.SetActive(true);
    }

    

    private void Start()
    {
        transform.gameObject.SetActive(false);


    }


    

    private void Update()
    {
        _sprite = GetComponent<SpriteRenderer>();


        //_moveValue += Time.deltaTime * _moveSpeed;

        //var x = Mathf.Sin(_moveValue) * _radius;
        //var y = Mathf.Cos(_moveValue) * _radius;

        //transform.position = new Vector3(x, y, 0);



    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {

            ImproveWeapon();
            SpawnImprover() ;
            transform.gameObject.SetActive(false);
        }
    }
}
