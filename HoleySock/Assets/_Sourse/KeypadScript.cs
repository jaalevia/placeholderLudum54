using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _charHolder;
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _button3;
    [SerializeField] private GameObject _button4;
    [SerializeField] private GameObject _button5;
    [SerializeField] private GameObject _button6;
    [SerializeField] private GameObject _button7;
    [SerializeField] private GameObject _button8;
    [SerializeField] private GameObject _button9;
    [SerializeField] private GameObject _button0;
    [SerializeField] private GameObject _clearbutton;
    [SerializeField] private GameObject _enterbutton;
    [SerializeField] private GameObject _objectToDeactivate;
    private int _check = 0;

    private void Update()
    {
        if (_check > 4)
        {
            _charHolder.text = null;
            _check = 0;
        }
    }
    public void B1()
    {
        _charHolder.text = _charHolder.text + "1";
        _check += 1;
    }
    public void B2()
    {
        _charHolder.text = _charHolder.text + "2";
        _check += 1;
    }
    public void B3()
    {
        _charHolder.text = _charHolder.text + "3";
        _check += 1;
    }
    public void B4()
    {
        _charHolder.text = _charHolder.text + "4";
        _check += 1;
    }
    public void B5()
    {
        _charHolder.text = _charHolder.text + "5";
        _check += 1;
    }
    public void B6()
    {
        _charHolder.text = _charHolder.text + "6";
        _check += 1;
    }
    public void B7()
    {
        _charHolder.text = _charHolder.text + "7";
        _check += 1;
    }
    public void B8()
    {
        _charHolder.text = _charHolder.text + "8";
        _check += 1;
    }
    public void B9()
    {
        _charHolder.text = _charHolder.text + "9";
        _check += 1;
    }
    public void B0()
    {
        _charHolder.text = _charHolder.text + "0";
        _check += 1;
    }

    public void ClearEvent()
    {
        _charHolder.text = null;
        _check = 0;
    }
    public void EnterEvent()
    {
        if (_charHolder.text == "1420")
        {
            Destroy(_objectToDeactivate);
            Debug.Log("Success");
        }
        else
        {
            _charHolder.text = null;
            _check = 0;
            Debug.Log("Failed");
        }
    }
}
