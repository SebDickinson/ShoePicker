using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class ButtonInteractable : Selectable, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private const float hoverStartAniamtionDuration = 0.2f;
    private const float hoverEndAnimationDuration = 0.1f;
    private const float scaleFactor = 1.075f;

    private Image image;
    private TMP_Text text;
    private Vector3 startScale;

    public AudioSource audioSource;

    public AudioClip hoverClip;
    public AudioClip selectClip;

    public Color startTextColor;
    public Color startImageColor;
    public Color selectImageColor;

    public Color textHoverColor;
    public Color buttonHoverColor;

    public UnityEvent OnClick;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
        startScale = transform.localScale;
    }

    public void OnHoverStart()
    {
        // stop all animations
        transform.DOKill();

        // hover start animations
        transform.DOScale(scaleFactor, hoverStartAniamtionDuration);
        text.DOColor(textHoverColor, hoverStartAniamtionDuration);
        image.DOColor(buttonHoverColor, hoverStartAniamtionDuration);

        // hover sounds
        Soundmanager.instance.PlaySound(hoverClip, audioSource);
    }

    public void OnHoverEnd()
    {
        // stop all animations
        transform.DOKill();

        // hover end animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        text.DOColor(startTextColor, hoverEndAnimationDuration);
        image.DOColor(startImageColor, hoverEndAnimationDuration);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverStart();

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        OnHoverEnd();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        Press();
    }

    private void Press()
    {
        UISystemProfilerApi.AddMarker("Button.onClick", this);
        image.DOColor(selectImageColor, hoverEndAnimationDuration);

        Soundmanager.instance.PlaySound(selectClip, audioSource);

        OnClick.Invoke();
    }
}





