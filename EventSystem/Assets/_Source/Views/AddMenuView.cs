using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddMenuView : MonoBehaviour
{
    [SerializeField] private Button addMenuButton;
    [SerializeField] private GameObject addMenuPanel;

    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Dropdown dropDown;
    [SerializeField] private TMP_InputField inputField;

    public Button AddMenuButton { get => addMenuButton; }
    public GameObject AddMenuPanel { get => addMenuPanel; }
    public Button RemoveButton { get => removeButton; }
    public TMP_Dropdown DropDown { get => dropDown; }
    public TMP_InputField InputField { get => inputField; }
}