using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    private static int coinsCollected = 0;
    private static int currentPlayerHealth = 1;
    private static int maxPlayerHealth = 3;
    private static int rubiesCollected = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PickUpCoin(int coinValue)
    {
        coinsCollected += coinValue;
        // TODO Update and show coin counter
    }

    public static void PickUpPotion()
    {
        currentPlayerHealth = maxPlayerHealth;
        // TODO Update health bar
    }

    public static void PickUpRuby(int rubyValue)
    {
        rubiesCollected += rubyValue;
        // TODO Update and show coin counter
    }

  
}
