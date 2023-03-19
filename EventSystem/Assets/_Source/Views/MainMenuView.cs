using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameObject mainMenuPanel;

    [SerializeField] private Button resetButton;
    [SerializeField] private Transform group;
    [SerializeField] private CardView card;

    public Button MainMenuButton { get => mainMenuButton; }
    public GameObject MainMenuPanel { get => mainMenuPanel; }
    public Button ResetButton { get => resetButton; }
    public Transform Group { get => group; }
    public CardView Card { get => card; }
}