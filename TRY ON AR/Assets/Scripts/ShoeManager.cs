using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeManager : MonoBehaviour
{
    public static ShoeManager Instance;
    public List<GameObject> LeftShoes = new List<GameObject>();
    public List<GameObject> RightShoes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }


    public void HideShoes()
    {
        foreach (var shoe in LeftShoes)
        {
            shoe.gameObject.SetActive(false);
        }

        foreach (var shoe in RightShoes)
        {
            shoe.gameObject.SetActive(false);
        }
    }
    public void ShowShoe(int index)
    {
        HideShoes();
        LeftShoes[index].SetActive(true);
        RightShoes[index].SetActive(true);
    }
}


