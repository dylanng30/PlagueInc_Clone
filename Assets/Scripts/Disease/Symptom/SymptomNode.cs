using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SymptomNode : MonoBehaviour
{
    public bool IsLocked;
    public bool IsDisplayed;

    public List<SymptomNode> childNodes = new List<SymptomNode>();

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Load();
    }
    #region Update
    private void OnMouseDown()
    {
        //SymptomManager.Instance.UnlockSymptomNode(this);
        Debug.Log("mousedown");
    }
    public void LoadUI()
    {
        Color color = Color.white;

        color.a = IsDisplayed ? 100f : 0f;

        if (!IsLocked)
            color.a = 255f;

        spriteRenderer.color = color;
    }
    #endregion

    #region Loading
    private void Load()
    {
        LoadSpriteRenderer();
    }

    private void LoadSpriteRenderer()
    {
        if (spriteRenderer != null)
            return;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    #endregion
}
