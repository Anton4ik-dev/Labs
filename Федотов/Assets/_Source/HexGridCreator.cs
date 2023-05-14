using System.Collections.Generic;
using UnityEngine;

public class HexGridCreator : MonoBehaviour
{
    [SerializeField] private Hex _hexNormal;
    [SerializeField] private GameObject _hexBlocked;
    [SerializeField] private Character _character;

    [SerializeField] private int _minLengthOfRow;
    [SerializeField] private int _maxLengthOfRow;
    [SerializeField] private int _minLengthOfColumn;
    [SerializeField] private int _maxLengthOfColumn;

    [SerializeField] private float _upperStep;
    [SerializeField] private float _rightStep;

    private float _nowUpperStep;
    private float _nowRightStep;
    private List<Hex> _hexes = new List<Hex>();

    private void Awake()
    {
        _nowUpperStep = transform.position.y;
        _nowRightStep = transform.position.x;
        CreateGrid();
        SpawnCharacter();
    }

    private void CreateGrid()
    {
        for (int i = 0; i < Random.Range(_minLengthOfRow, _maxLengthOfRow); i++)
        {
            for (int j = 0; j < Random.Range(_minLengthOfColumn, _maxLengthOfColumn); j++)
            {
                if (Random.Range(0, 6) == 4)
                {
                    Instantiate(_hexBlocked, new Vector3(_nowRightStep, _nowUpperStep, 0), transform.rotation).transform.parent = transform;
                }
                else
                {
                    Hex hex = Instantiate(_hexNormal, new Vector3(_nowRightStep, _nowUpperStep, 0), transform.rotation);
                    hex.transform.parent = transform;
                    _hexes.Add(hex);
                }
                _nowRightStep += _rightStep;
            }
            _nowUpperStep += _upperStep;
            _nowRightStep = transform.position.x;
            if (i % 2 == 0)
                _nowRightStep += _rightStep / 2;
        }
    }

    private void SpawnCharacter()
    {
        int randomNum = Random.Range(0, _hexes.Count);
        Hex.Character = Instantiate(_character, _hexes[randomNum].transform.position, transform.rotation);
        Hex.HexWithCharacter = _hexes[randomNum];
    }
}