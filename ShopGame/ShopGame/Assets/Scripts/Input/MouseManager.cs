using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 worldPos;

    Vector3 testPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        testPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));

        Debug.Log(testPos);
    }
}
