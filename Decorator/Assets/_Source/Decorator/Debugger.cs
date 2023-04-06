using UnityEngine;
using Decorator;

public class Debugger : MonoBehaviour
{
    // ��������������� ����, ���� ���� �� ��� �� ����� ���������, �� ��� ���������
    [SerializeField] private HotDogSO classicHotDogSO;
    [SerializeField] private HotDogSO cesarHotDogSO;
    [SerializeField] private HotDogSO meatHotDogSO;
    [SerializeField] private HotDogSO cucumberSO;
    [SerializeField] private HotDogSO onionSO;

    void Start()
    {
        ClassicHotDog hotdog1 = new ClassicHotDog(classicHotDogSO.Name, classicHotDogSO.Cost, classicHotDogSO.Weight);
        CucumberDecorator cdecorator1 = new CucumberDecorator(cucumberSO.Name, cucumberSO.Cost, cucumberSO.Weight, hotdog1);
        OnionDecorator odecorator1 = new OnionDecorator(onionSO.Name, onionSO.Cost, onionSO.Weight, hotdog1);

        CesarHotDog hotdog2 = new CesarHotDog(cesarHotDogSO.Name, cesarHotDogSO.Cost, cesarHotDogSO.Weight);
        CucumberDecorator cdecorator2 = new CucumberDecorator(cucumberSO.Name, cucumberSO.Cost, cucumberSO.Weight, hotdog2);
        OnionDecorator odecorator2 = new OnionDecorator(onionSO.Name, onionSO.Cost, onionSO.Weight, hotdog2);

        CesarHotDog hotdog3 = new CesarHotDog(meatHotDogSO.Name, meatHotDogSO.Cost, meatHotDogSO.Weight);
        CucumberDecorator cdecorator3 = new CucumberDecorator(cucumberSO.Name, cucumberSO.Cost, cucumberSO.Weight, hotdog3);
        OnionDecorator odecorator3 = new OnionDecorator(onionSO.Name, onionSO.Cost, onionSO.Weight, hotdog3);

        Debug.Log($"{hotdog1.Name} ({hotdog1.GetWeight()}�) - {hotdog1.GetCost()}�." +
            $"\n�������������� ����������:" +
            $"\n{hotdog1.Name} {cdecorator1.Name} ({cdecorator1.GetWeight()}�) - {cdecorator1.GetCost()}�." +
            $"\n{hotdog1.Name} {odecorator1.Name} ({odecorator1.GetWeight()}�) - {odecorator1.GetCost()}�.");

        Debug.Log($"{hotdog2.Name} ({hotdog2.GetWeight()}�) - {hotdog2.GetCost()}�." +
            $"\n�������������� ����������:" +
            $"\n{hotdog2.Name} {cdecorator2.Name} ({cdecorator2.GetWeight()}�) - {cdecorator2.GetCost()}�." +
            $"\n{hotdog2.Name} {odecorator2.Name} ({odecorator2.GetWeight()}�) - {odecorator2.GetCost()}�.");

        Debug.Log($"{hotdog3.Name} ({hotdog3.GetWeight()}�) - {hotdog3.GetCost()}�." +
            $"\n�������������� ����������:" +
            $"\n{hotdog3.Name} {cdecorator3.Name} ({cdecorator3.GetWeight()}�) - {cdecorator3.GetCost()}�." +
            $"\n{hotdog3.Name} {odecorator3.Name} ({odecorator3.GetWeight()}�) - {odecorator3.GetCost()}�.");
    }
}