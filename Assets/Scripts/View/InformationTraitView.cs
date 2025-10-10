using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationTraitView : MonoBehaviour
{
    public event Action OnEvolvePressed;

    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI nameTraitText;
    [SerializeField] private TextMeshProUGUI contentTraitText;
    [SerializeField] private TextMeshProUGUI dnaCostText;

    [SerializeField] private Button evolveButton;
    [SerializeField] private Button turnOffButton;

    private void Awake()
    {
        evolveButton.onClick.AddListener(() => OnEvolvePressed?.Invoke());
        turnOffButton.onClick.AddListener(TurnOff);
        this.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        if (animator == null)
        {
            Debug.Log("Chưa gán animator");
            return;
        }
        this.gameObject.SetActive(true);

        animator.Play("PopUp");
    }
    public void TurnOff()
    {
        if (animator == null)
        {
            Debug.Log("Chưa gán animator");
            return;
        }

        animator.Play("PopDown");
    }

    public void UpdateView(EvolutionNodeModel model)
    {
        nameTraitText.text = model.data._name;
        contentTraitText.text = model.data._description;
        dnaCostText.text = $"-{model.data._dnaCost} DNA";

        evolveButton.gameObject.SetActive(!model.isUnlocked);
    }
}
