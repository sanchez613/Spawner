using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class RedBarrel : MonoBehaviour
{
    [SerializeField] private UnityEvent _exploded;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BarrelDestroyer>(out BarrelDestroyer destroyer))
        {
            _exploded?.Invoke();
            _audioSource.Play();
            Invoke(nameof(SetInactive), 0.5f);
        }
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
