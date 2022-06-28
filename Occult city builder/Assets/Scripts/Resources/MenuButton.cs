using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMouse;

public class MenuButton : MonoBehaviour
{
    private Vector3 originalPosition;
    FollowMouse mouse;
    public bool isFollowing;
    public enum ButtonType 
    { Play,Quit}
    public ButtonType buttonType;
    void Start()
    {
        originalPosition = transform.position;
        mouse = GetComponent<FollowMouse>();
        mouse.enabled = false;
    }

    private void OnMouseDown()
    {
        mouse.enabled = true;
        isFollowing = true;
    }
    private void OnMouseUp()
    {
        isFollowing = false;
        mouse.enabled = false;
        transform.position = originalPosition;
    }
}
