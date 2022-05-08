using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    public GameObject finishScreen;

    // Scene items
    public GameObject player;
    public GameObject platformManager;
    public GameObject staticObjects;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showEndScreen(bool won)
    {
        player.transform.DetachChildren();
        player.SetActive(false);
        platformManager.SetActive(false);
        staticObjects.SetActive(false);
        background.SetActive(false);
        
        finishScreen.SetActive(true);
        TextMeshProUGUI finishText = finishScreen.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(finishText);
        if (won) {
            finishText.text = "You won";
            finishText.color = Color.green;
        } else {
            finishText.text = "You lost";
            finishText.color = Color.red;
        }
    }

    public void onRestartGame()
    {
        finishScreen.SetActive(false);
        
        platformManager.SetActive(true);
        staticObjects.SetActive(true);
        background.SetActive(true);
        
        player.SetActive(true);
        player.GetComponent<PlayerMovement>().reset();
    }

    
}
