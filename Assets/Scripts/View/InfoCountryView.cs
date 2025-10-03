using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
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
    public IEnumerator TurnOff()
    {
        if (animator == null)
        {
            Debug.Log("Chưa gán animator");
            yield break;
        }

        animator.Play("PopDown");

        float length = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);
        gameObject.SetActive(false);
    }

    public void UpdateView(Country country)
    {
        if(country == null)
            return;

        normalBlock.numberText.text = FormatNumber(country.population);
        infectedBlock.numberText.text = FormatNumber(country.infected);
        deadBlock.numberText.text = FormatNumber(country.dead);
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
