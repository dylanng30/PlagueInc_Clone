using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameDiseaseView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private Button playButton;
    [SerializeField] private Button getRandomNameButton;
    [SerializeField] private List<string> names = new List<string>();

    private void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        getRandomNameButton.onClick.AddListener(NameDisease);
    }
    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        getRandomNameButton.onClick.RemoveAllListeners();

    }
    private void Play()
    {
        GameManager.Instance.RegisterNameForDisease(_nameInput.text);
        GameManager.Instance.ChangeState(GameState.Playing);
    }
    private void NameDisease()
    {
        _nameInput.text = names[Random.Range(0, names.Count)];
    }

}
