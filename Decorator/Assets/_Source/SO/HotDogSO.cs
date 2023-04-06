using UnityEngine;

[CreateAssetMenu(fileName = "HotDog", menuName = "SO/HotDog", order = 1)]
public class HotDogSO : ScriptableObject
{
    // сериализованные поля, если одно из них не будет заполнено, то все сломается
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private int _weight;

    public string Name { get => _name; private set { } }
    public int Cost { get => _cost; private set { } }
    public int Weight { get => _weight; private set { } }
}