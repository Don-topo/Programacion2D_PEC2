using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject collectibles;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI rubiesText;
    public GameObject[] health;

    private int coinsCollected = 0;
    private int currentPlayerHealth = 1;
    private int maxPlayerHealth = 4;
    private int rubiesCollected = 0;
    private static GameManager gmInstance;

    public static GameManager Instance { get { return gmInstance; } }
    

    // Start is called before the first frame update
    private void Awake()
    {
        if (gmInstance != null && gmInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gmInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpCoin(int coinValue)
    {
        coinsCollected += coinValue;
        coinsText.SetText(coinsCollected.ToString());
        var animatorState = collectibles.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName("HideCollectibles") && animatorState.normalizedTime >= 1.0f)
        {
            collectibles.GetComponent<Animator>().SetTrigger("Show");
        }
    }

    public void PickUpPotion()
    {
        currentPlayerHealth = maxPlayerHealth;
        UpdateHealthUI();
    }

    public void PickUpRuby(int rubyValue)
    {
        rubiesCollected += rubyValue;
        rubiesText.SetText(rubiesCollected.ToString());
        var animatorState = collectibles.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName("HideCollectibles") && animatorState.normalizedTime >= 1.0f)
        {
            collectibles.GetComponent<Animator>().SetTrigger("Show");
        }        
    }

    private void UpdateHealthUI()
    {
        for(int i = 0; i < currentPlayerHealth; i++)
        {

        }
    }

  
}
