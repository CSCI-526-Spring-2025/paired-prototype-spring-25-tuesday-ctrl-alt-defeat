using UnityEngine;

public class CollisionParticleEffects : MonoBehaviour
{
    public ParticleSystem triggerEffect; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerEffect != null)
        {
            ParticleSystem effect = Instantiate(triggerEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
        }
        Destroy(gameObject);
    }
}