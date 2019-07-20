using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public enum MenuScreen { Main, PlayerSelect, TwoPlayerCustomization };

    public GameObject MainMenu;
    public GameObject PlayerSelectMenu;
    public GameObject TwoPlayerCustomizationMenu;
    private GameObject currentMenu;

    void Awake()
    {
        currentMenu = MainMenu;
        SwitchMenu(MenuScreen.Main);
    }


    public void SwitchMenu(MenuScreen menuToOpen)
    {
        GameObject newMenu;
        switch (menuToOpen)
        {
            case MenuScreen.Main:
                newMenu = MainMenu;
                break;
            case MenuScreen.PlayerSelect:
                newMenu = PlayerSelectMenu;
                break;
            case MenuScreen.TwoPlayerCustomization:
                newMenu = TwoPlayerCustomizationMenu;
                break;
            default:
                newMenu = MainMenu;
                break;
        }
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        currentMenu.SetActive(true);
    }


    public void OpenMainMenu()
    {
        SwitchMenu(MenuScreen.Main);
    }


    public void OpenPlayerSelectMenu()
    {
        SwitchMenu(MenuScreen.PlayerSelect);
    }


    public void OpenTwoPlayerCustomizationMenu()
    {
        SwitchMenu(MenuScreen.TwoPlayerCustomization);
    }
}
