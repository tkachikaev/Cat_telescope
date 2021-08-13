using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _gold;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _particleDestroy;
    [SerializeField] private CoinSound _coinSound;
    [SerializeField] private AnimationClip _animationClip;

    private void Start()
    {
        _animator.GetComponent<Animator>();
        _animator.Play(_animationClip.name, 0, Random.Range(0.1f, 0.5f)); //Запуск рандомного кадра по времени.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Resources playerResources = collision.gameObject.GetComponent<Resources>();
        if (playerResources)
        {
            playerResources.AddGold(_gold);
            _coinSound.PlayAudioCoin();
            _particleDestroy.SetActive(true);
            _particleDestroy.gameObject.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
