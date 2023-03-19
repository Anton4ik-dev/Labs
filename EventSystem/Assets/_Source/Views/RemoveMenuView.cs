using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveMenuView : MonoBehaviour
{
    [SerializeField] private Button removeMenuButton;
    [SerializeField] private GameObject removeMenuPanel;

    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Dropdown dropDown;
    [SerializeField] private TMP_InputField inputField;

    public Button RemoveMenuButton { get => removeMenuButton; }
    public GameObject RemoveMenuPanel { get => removeMenuPanel; }
    public Button RemoveButton { get => removeButton; }
    public TMP_Dropdown DropDown { get => dropDown; }
    public TMP_InputField InputField { get => inputField; }
}