using UnityEngine;
using UnityEngine.UI;

public class GameStateNavigation : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] Button backButton;

    private void Awake()
    {
        LoadBackButton();
    }
    private void LoadBackButton()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(() => ChangeState());
    }

    private void ChangeState()
    {
        
        GameManager.Instance.ChangeState(gameState);
    }
}
