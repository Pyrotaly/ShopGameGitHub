using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDesk : MonoBehaviour, IInteractable
{
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerActivateStore;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerActivateStore;
    }

    public void OnInteract()
    {
        Debug.Log("sgdhsgh");

        GameManager.Instance.ChangeState(GameState.GenerateGrid);
    }

    private void GameManagerActivateStore(GameState obj)
    {

    }
}
