using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private int[] intArray;
    private List<GameObject> buttons;
    public ShoePicker shoePicker;
    internal static Color m_backColor;

    void Start()
    {
        buttons = new List<GameObject>();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }

        foreach (int i in intArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;

            button.SetActive(true);

            //button.GetComponent<ButtonListButton>().SetText("Shoe #" + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);

            //button.GetComponent<Button>().onClick.AddListener(shoePicker.ShowShoe(i-1));

        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }
}
