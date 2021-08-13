using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioCoin()
    {
        _audioSource.Play();
        gameObject.transform.parent = null;
        Destroy(gameObject, _audioSource.clip.length);
    }
}
