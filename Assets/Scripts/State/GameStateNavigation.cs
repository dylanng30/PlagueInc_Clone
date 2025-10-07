using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStateNavigation : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private Button backButton;

    private void Awake()
    {
        LoadBackButton();
    }
    private void LoadBackButton()
    {
        if(backButton != null)
        {
            return;
        }

        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(() => ChangeState());
    }

    private void ChangeState()
    {
        GameManager.Instance.ChangeState(gameState);
    }
}
