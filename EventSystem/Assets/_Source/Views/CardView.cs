using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI materialName;
    [SerializeField] private TextMeshProUGUI materialAmount;

    public TextMeshProUGUI MaterialName { get => materialName; }
    public TextMeshProUGUI MaterialAmount { get => materialAmount; }
}