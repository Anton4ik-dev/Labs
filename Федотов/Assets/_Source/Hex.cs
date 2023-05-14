using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hex : MonoBehaviour
{
    [SerializeField] private Text numberText;
    [SerializeField] private LayerMask _hexLayer;

    public static Character Character;
    public static Hex HexWithCharacter;
    public static List<Hex> Way = new List<Hex>();

    private List<Hex> _connectedHexes = new List<Hex>();

    private void OnMouseEnter()
    {
        BuildTheWay();
        numberText.text = $"{Way.Count}";
    }

    private void OnMouseExit()
    {
        Exit();
    }

    private void OnMouseUp()
    {
        StartCoroutine(Character.MoveCharacter(Way));
        HexWithCharacter = this;
        Exit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _hexLayer) > 0)
        {
            _connectedHexes.Add(collision.gameObject.GetComponent<Hex>());
        }
    }

    public bool BuildTheWay()
    {
        if(_connectedHexes.Contains(HexWithCharacter))
        {
            Way.Add(this);
            return true;
        }
        for (int i = 0; i < _connectedHexes.Count; i++)
        {
            if (_connectedHexes[i].BuildTheWay())
            {
                Way.Add(this);
                return true;
            }
        }
        return false;
    }

    private void Exit()
    {
        Way = new List<Hex>();
        numberText.text = "";
    }
}
