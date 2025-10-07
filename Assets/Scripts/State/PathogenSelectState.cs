using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSelectState : IState
{
    private PathogenSelectView _view;
    public PathogenSelectState(PathogenSelectView view)
    {
        _view = view;
    }
    public void Enter()
    {
        _view.gameObject.SetActive(true);
        _view.CreateButtons();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        _view.gameObject.SetActive(false);
    }
}
