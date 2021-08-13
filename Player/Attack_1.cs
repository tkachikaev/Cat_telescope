using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(AudioSource))]
public class Attack_1 : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _upOffset;
    [SerializeField] private float _reloadTime;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bullet2; //TEMP
    [SerializeField] private AudioSource _firepointSound; //TEMP
    private SpriteRenderer _spriteRenderer;
    private Resources _resources;
    private PlayerAnimation _playerAnimation;
    private AudioSource _hitSound;
    private bool _attack = true;

    private void Start()
    {
        _hitSound = _firePoint.GetComponent<AudioSource>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _resources = GetComponent<Resources>();
    }

    public void ButtonAttack()
    {
        if (_attack && _resources.GetFish() > 0)
        {
            _attack = false;
            _hitSound.Play();
            _resources.TakeFish(1);
            _playerAnimation.Throw();
            Attack();
            StartCoroutine(nameof(TimeReload));
        }
    }

    private void Attack()
    {
        float rotation = Random.Range(0f, 180f);
        var currentBullet = Instantiate<GameObject>(_bullet, _firePoint.position, Quaternion.Euler(0, 0, rotation));
        var currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (_spriteRenderer.flipX)
        {
            currentBulletVelocity.velocity = new Vector2(_speedBullet * 1, _upOffset);
        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(_speedBullet * -1, _upOffset);
        }
    }

    private IEnumerator TimeReload()
    {
        yield return new WaitForSecondsRealtime(_reloadTime);
        _attack = true;
        StopCoroutine(nameof(TimeReload));
    }

    #region TEMP

    public void ButtonAttack_TEMPOn()
    {
        _playerAnimation.MegaAttack(true);
        StartCoroutine(nameof(MegaPrep));
    }
    public void ButtonAttack_TEMPof()
    {
        _bullet2.SetActive(false);
        _playerAnimation.MegaAttack(false);
        _firepointSound.Stop();
        StopCoroutine(nameof(MegaPrep));
    }


    IEnumerator MegaPrep()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        _firepointSound.Play();
        _firepointSound.loop = true;
        _bullet2.SetActive(true);
        StopCoroutine(nameof(MegaPrep));
    }
    #endregion
}
