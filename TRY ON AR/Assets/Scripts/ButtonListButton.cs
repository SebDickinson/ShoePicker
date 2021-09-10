using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonListButton : MonoBehaviour
{
[SerializeField] private Text myText;
private string myTextString;

[SerializeField] private Image shoeImage;
public Sprite mySprite;

[SerializeField] private ButtonListControl buttonControl;
public ShoeEvent ButtonClicked;

public List<GameObject> shoes = new List<GameObject>();

public int value;
public void SetText(string textString)
    {
        myText.text = textString;
        myTextString = textString;
    }

    public void SetImage(Sprite imageSprite)
    {
        shoeImage.sprite = imageSprite;
        mySprite = imageSprite;
    }
    public void OnClick()
    {
        buttonControl.ButtonClicked(myTextString);
        ButtonClicked?.Invoke(value);
    }

    public void ShowShoe(int index)
    {
        HideShoes();
        shoes[index].SetActive(true);
    }

    public void HideShoes()
    {
        foreach (var shoe in shoes)
        {
            shoe.gameObject.SetActive(false);
        }
    }

}
