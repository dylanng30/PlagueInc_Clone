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
        _chooseCanvas.SetActive(true);
    }
    public void HideChooseCanvas()
    {
        _chooseCanvas.SetActive(false);
    }
    //Playing
    public void ShowPlayingCanvas()
    {
        _playingCanvas.SetActive(true);
    }
    public void HidePlayingCanvas()
    {
        _playingCanvas.SetActive(false);
    }
    //PathogenSelect
    public void ShowPathogenSelectCanvas()
    {
        _pathogenSelectCanvas.gameObject.SetActive(true);
    }
    public void HidePathogenSelectCanvas()
    {
        _pathogenSelectCanvas.gameObject.SetActive(false);
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
        _chooseCanvas.SetActive(false);
        _playingCanvas.SetActive(false);
        _pathogenSelectCanvas.gameObject.SetActive(false);
        _nameDiseaseView.gameObject.SetActive(false);
        _endGameCanvas.gameObject.SetActive(false);
    }
}
