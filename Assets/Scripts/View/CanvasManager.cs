using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject _menuCanvas;
    public GameObject _chooseCanvas;
    public GameObject _playingCanvas;
    public PathogenSelectView _pathogenSelectCanvas;
    public NameDiseaseView _nameDiseaseView;

    public void ShowMenuCanvas()
    {
        HideAll();
        _menuCanvas.SetActive(true);
    }
    public void ShowChooseCanvas()
    {
        HideAll();
        _chooseCanvas.SetActive(true);
    }
    public void ShowPlayingCanvas()
    {
        HideAll();
        _playingCanvas.SetActive(true);
    }
    public void ShowPathogenSelectCanvas()
    {
        HideAll();
        _pathogenSelectCanvas.gameObject.SetActive(true);
    }
    public void ShowNameDiseaseCanvas()
    {
        HideAll();
        _nameDiseaseView.gameObject.SetActive(true);
    }
    private void HideAll()
    {
        _menuCanvas.SetActive(false);
        _chooseCanvas.SetActive(false);
        _playingCanvas.SetActive(false);

        _pathogenSelectCanvas.gameObject.SetActive(false);
        _nameDiseaseView.gameObject.SetActive(false);
    }
}
