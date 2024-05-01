using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public int equippedSkin = 2;
    public bool shieldUnlocked;
    public bool highJumpUnlocked;

    public static PlayerUpgradeManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
