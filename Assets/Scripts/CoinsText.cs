using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    private CoinManager coinManager;

    // Start is called before the first frame update
    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();    
    }

    private void Update()
    {
        coinsText.text = coinManager.coins.ToString();
    }
}
