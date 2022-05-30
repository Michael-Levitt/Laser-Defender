using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;
    
    [Header("Projectile")]
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 1.5f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 7f;
    
    [Header("Enemy FX")]
    [SerializeField] GameObject explosionStars;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] SoundManager soundManager;
    
    float shotCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        // Shoots at a random intervals
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        soundManager.TriggerEnemyShotSFX();
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().Score += scoreValue;
        soundManager.TriggerEnemyDeadSFX();
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionStars, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
    }
}
