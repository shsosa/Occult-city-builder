using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCollisionDetector : MonoBehaviour
{
    GameManager manager;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("entered");
        MenuButton button;
        button = other.gameObject.GetComponent<MenuButton>();
        if (!button.isFollowing)
        {
            if (button.buttonType == MenuButton.ButtonType.Play)
            {
                manager.Loader(1);
                Debug.Log("play");
            }
            if (button.buttonType == MenuButton.ButtonType.Quit)
            {
                manager.Quit();
                Debug.Log("quit");
            }
        }
    }
}
