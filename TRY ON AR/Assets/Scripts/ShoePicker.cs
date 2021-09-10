using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class ShoeEvent : UnityEvent<int> { };

public class ShoePicker : MonoBehaviour
{
    public List<GameObject> shoes = new List<GameObject>();

    private void Start()
    {
        HideShoes();
    }

    public void HideShoes()
    {
        foreach(var shoe in shoes)
        {
            shoe.gameObject.SetActive(false);
        }
    }

   public void ShowShoe(int index)
    {
        HideShoes();
        shoes[index].SetActive(true);
    }

    public void Input(int index)
    {
        ButtonListControl.m_backColor = Color.cyan;
    }

}


