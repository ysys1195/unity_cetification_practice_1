using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int coinsRequiredForRecovery = 10;
    
    public UnityEvent onHealthRecovery = new UnityEvent();
    
    public int CurrentCoins { get; private set; }
    
    public static CoinManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        CurrentCoins = 0;
    }
    
    public void AddCoin()
    {
        CurrentCoins++;
        
        if (CurrentCoins >= coinsRequiredForRecovery)
        {
            CurrentCoins -= coinsRequiredForRecovery;
            onHealthRecovery.Invoke();
        }
    }
}