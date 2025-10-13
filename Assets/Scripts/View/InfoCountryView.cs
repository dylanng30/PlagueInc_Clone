using System;
using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoCountryView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InforBlock normalBlock;
    [SerializeField] private InforBlock infectedBlock;
    [SerializeField] private InforBlock deadBlock;

    public void TurnOn()
    {
        if (animator == null)
        {
            Debug.Log("Chưa gán animator");
            return;
        }

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

    public void UpdateDetail(CountryModel model)
    {
        normalBlock.numberText.text = FormatNumber(model.Normal);
        infectedBlock.numberText.text = FormatNumber(model.Infected);
        deadBlock.numberText.text = FormatNumber(model.Dead);
    }

    private string FormatNumber(long number, int space = 3)
    {
        string raw = number.ToString();
        List<string> groups = new List<string>();

        for (int i = raw.Length; i > 0; i -= space)
        {
            int start = Math.Max(0, i - space);
            int length = i - start;
            groups.Insert(0, raw.Substring(start, length));
        }

        return string.Join(".", groups);
    }

}

[Serializable]
public struct InforBlock
{
    public GameObject block;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI numberText;
}
