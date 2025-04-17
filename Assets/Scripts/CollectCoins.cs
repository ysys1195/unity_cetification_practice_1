using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    [Tooltip("The particles that appear after the player collects a coin.")]
    public GameObject coinParticles;

    private PlayerMovement playerMovementScript;
    private CoinManager coinManager;
    
    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
        
        if (coinManager != null)
        {
            coinManager.onHealthRecovery.AddListener(RecoverPlayerHealth);
        }
    }
    
    void RecoverPlayerHealth()
    {
        if (playerMovementScript != null)
        {
            playerMovementScript.ChangeHealth(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovementScript = other.GetComponent<PlayerMovement>();
            playerMovementScript.soundManager.PlayCoinSound();
            ScoreManager.score += 10;
            
            // コインを追加
            if (coinManager != null)
            {
                coinManager.AddCoin();
            }
            
            GameObject particles = Instantiate(coinParticles, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}