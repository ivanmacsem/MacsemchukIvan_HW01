using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerupBase : MonoBehaviour
{
    [SerializeField] int powerupDuration = 3;
    Rigidbody rb;
    MeshRenderer mr;
    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);
    private void Awake(){
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other){
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null){
            PowerUp(player);
            Feedback();
            rb.detectCollisions = false;
            mr.enabled = false;
            StartCoroutine(PowerDownWait(player));
        }
    }
    private IEnumerator PowerDownWait(Player player){
        yield return new WaitForSeconds(powerupDuration);
        PowerDown(player);
        gameObject.SetActive(false);
    }
    private void Feedback(){
        if(_collectParticles !=  null){
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
            _collectParticles.Play();
        }
        if(_collectSound != null){
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}
