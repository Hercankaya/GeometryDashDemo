using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem PlayerExplosionEffect;
    [SerializeField] ParticleSystem PlayerFlyingEffect;
    PlayerController _playerController;
    private bool _isEffectPlayed = false;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        if (_playerController == null)
        {
            Debug.LogError("PlayerController'a ulaþýlamadý ");
        }
    }

    private void Update()
    {
        transform.position = _playerController.transform.position;
       
        if (_playerController != null && !_playerController.PlayerLive )
        {
            if (PlayerExplosionEffect != null && !_isEffectPlayed)
            {
                PlayerExplosionEffect.gameObject.SetActive(true);
                PlayerExplosionEffect.Play();
                Invoke("SetEffectPlayedTrue", 2f);
                PlayerFlyingEffect.gameObject.SetActive(false);

            }
        }
        if (_playerController != null && _playerController.PlayerStatusCheck )
        {
            if(PlayerFlyingEffect!= null)
            {
                PlayerFlyingEffect.gameObject.SetActive(true);
                PlayerFlyingEffect.Play();
            }
            
        }
        else if (_playerController != null && !_playerController.PlayerStatusCheck )
        {
            PlayerFlyingEffect.gameObject.SetActive(false);

            //Kübün yüzeye temas etmesini kontrol edeceðim ve Yere temas ettiði durumda ki efekti çalýþtýrmam gerekiyor .
        }
    }

    private void SetEffectPlayedTrue()
    {
        _isEffectPlayed = true;
    }
}
