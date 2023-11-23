using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;
    Interact _interact;

    public int[] _numberPassword = {0, 0, 0, 0};

    private void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
        _interact = FindObjectOfType<Interact>();
    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
        {
            // Password is correct
            Debug.Log("Password correct");

            // Call enabling methods from the Interact script
            _interact.CorrectCode();
        }
    }
}
