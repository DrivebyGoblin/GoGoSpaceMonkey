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
                break;
                
        }   
    }


    


    private void da()
    {
        _sprite.sprite = sprites[0];
        transform.position = _spawnPosition.position;
        transform.gameObject.SetActive(true);
    }

    

    private void Start()
    {
        


    }


    private void Update()
    {
        _sprite = GetComponent<SpriteRenderer>();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ImproveWeapon();
        }
    }
}
