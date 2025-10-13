using System.Collections;
using System.Collections.Generic;
using Refactor_01.Presentation;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject _menuCanvas;
    public PathogenSelectView PathogenSelectCanvas;
    public ChooseCountryView ChooseCountryCanvas;
    public PlayingView PlayingCanvas;
    
    public NameDiseaseView _nameDiseaseView;
    public GameObject _endGameCanvas;

    //Menu
    public void ShowMenuCanvas()
    {
        _menuCanvas.SetActive(true);
    }
    public void HideMenuCanvas()
    {
        _menuCanvas.SetActive(false);
    }
    //Choose
    public void ShowChooseCanvas()
    {
        ChooseCountryCanvas.gameObject.SetActive(true);
    }
    public void HideChooseCanvas()
    {
        ChooseCountryCanvas.gameObject.SetActive(false);
    }
    //Playing
    public void ShowPlayingCanvas()
    {
        PlayingCanvas.gameObject.SetActive(true);
    }
    public void HidePlayingCanvas()
    {
        PlayingCanvas.gameObject.SetActive(false);
    }
    //PathogenSelect
    public void ShowPathogenSelectCanvas()
    {
        PathogenSelectCanvas.gameObject.SetActive(true);
    }
    public void HidePathogenSelectCanvas()
    {
        PathogenSelectCanvas.gameObject.SetActive(false);
    }
    //NameDisease
    public void ShowNameDiseaseCanvas()
    {
        _nameDiseaseView.gameObject.SetActive(true);
    }
    public void HideNameDiseaseCanvas()
    {
        _nameDiseaseView.gameObject.SetActive(false);
    }
    //EndGame
    public void ShowEndGame()
    {
        _endGameCanvas.gameObject.SetActive(true);
    }
    public void HideEndGame()
    {
        _endGameCanvas.gameObject.SetActive(false);
    }

    //HideAll
    public void HideAll()
    {
        _menuCanvas.SetActive(false);
        ChooseCountryCanvas.gameObject.SetActive(false);
        PlayingCanvas.gameObject.SetActive(false);
        PathogenSelectCanvas.gameObject.SetActive(false);
        _nameDiseaseView.gameObject.SetActive(false);
        _endGameCanvas.gameObject.SetActive(false);
    }
}
