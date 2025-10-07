using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(() => Play());
    }
    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
    }
    public void Play()
    {
        GameManager.Instance.ChangeState(GameState.PathogenSelect);
    }
}
