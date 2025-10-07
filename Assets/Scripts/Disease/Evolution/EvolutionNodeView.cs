using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EvolutionNodeView : MonoBehaviour
{
    public Image icon;
    //public TMP_Text nodeName;
    public Button evolveButton;
    [SerializeField] private Color hideColor;
    [SerializeField] private Color showColor;
    [SerializeField] private TraitData _staticData;

    private EvolutionNodeModel model;
    public bool Assigned;

    private void Awake()
    {
        LoadButton();
    }

    public bool CanAssign(EvolutionNodeModel model)
    {
        if(model.data != _staticData)
            return false;

        this.model = model;
        //nodeName.text = model.data._name;
        Refresh();
        Assigned = true;
        return true;
    }

    public void Refresh()
    {
        evolveButton.interactable = model.isAvailable;

        if (!model.isAvailable)
        {
            icon.color = hideColor;
            return;
        }

        icon.color = showColor;
        //icon.sprite = model.isUnlocked ? model.data._sprites[0] : model.data._sprites[1];

    }

    private void Notify()
    {
        Debug.Log("OnClick");
        EvolutionController.Instance.OnNodeClicked(model.data);
    }

    private void LoadButton()
    {
        if (evolveButton != null)
        {
            return;
        }

        evolveButton = GetComponent<Button>();
        evolveButton.onClick.AddListener(() => Notify());
    }
}
