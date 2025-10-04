using UnityEngine;

public class CountryController
{
    private Country model;
    private CountryView view;

    public CountryController(Country model, CountryView view)
    {
        this.model = model;
        this.view = view;

        view.Render(model);
    }

    public void Highlight()
    {
        //PopUpManager.Instance.UpdateInforCountryView(model);
        view.AddListener(ShowInfo);
        view.Highlight();
    }
    public void Lowlight()
    {
        view.RemoveListener();
        view.Lowlight();
    }
    public void ShowInfo()
    {
        PopUpManager.Instance.ShowInforCountry();
    }
    public Country GetModel() => model;
    public CountryView GetView() => view;
}