using BomberSquad.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private static PlayerPrefsManager instance = null;
    public static PlayerPrefsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PlayerPrefsManager").AddComponent<PlayerPrefsManager>();
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }

    [SerializeField] SOPlayerStats _playerStatsSO;

    [HideInInspector]
    public int capacity;
    [HideInInspector]
    public int armor;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public int capacityCount;
    [HideInInspector]
    public int armorCount;
    [HideInInspector]
    public int damageCount;
    [HideInInspector]
    public int coin;
    
    [HideInInspector]
    public string capacityString = "capacity";
    [HideInInspector]
    public string armorString = "armor";
    [HideInInspector]
    public string damageString = "damage";
    [HideInInspector]
    public string capacityCountString = "capacityCount";
    [HideInInspector]
    public string armorCountString = "armorCount";
    [HideInInspector]
    public string damageCountString = "damageCount";
    [HideInInspector]
    public string coinString = "coin";
    private void Awake()
    {
        StartPlayerPrefs();
    }
    void Start()
    {
        
    }

    void StartPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(capacityString))
        {
            capacity = PlayerPrefs.GetInt(capacityString);
        }
        else
        {
            capacity = _playerStatsSO._capacity;

        }
        if (PlayerPrefs.HasKey(armorString))
        {
            armor = PlayerPrefs.GetInt(armorString);
        }
        else
        {
            armor = _playerStatsSO._armor; 
        }
        if (PlayerPrefs.HasKey(damageString))
        {
            damage = PlayerPrefs.GetInt(damageString);
        }
        else
        {
            damage = _playerStatsSO._damage;
        }
        if (PlayerPrefs.HasKey(capacityCountString))
        {
            capacityCount = PlayerPrefs.GetInt(capacityCountString);
        }
        else
        {
            capacityCount = 0;
        }
        if (PlayerPrefs.HasKey(armorCountString))
        {
            armorCount = PlayerPrefs.GetInt(armorCountString);
        }
        else
        {
            armorCount = 0;
        }
        if (PlayerPrefs.HasKey(damageCountString))
        {
            damageCount = PlayerPrefs.GetInt(damageCountString);
        }
        else
        {
            damageCount= 0;
        }
        if (PlayerPrefs.HasKey(coinString))
        {
            coin = PlayerPrefs.GetInt(coinString);
        }
        else
        {
            coin = _playerStatsSO._coin;
        }
    }
    
}
