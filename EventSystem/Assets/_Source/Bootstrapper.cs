using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AddMenuView addMenuView;
    [SerializeField] private RemoveMenuView removeMenuView;

    private void Awake()
    {
        new UISwitcher(mainMenuView, addMenuView, removeMenuView, new ResourcePool());
    }
}