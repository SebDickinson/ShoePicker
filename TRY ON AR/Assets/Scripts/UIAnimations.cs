using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIAnimations : MonoBehaviour
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

    private void OnEnable()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
        startScale = transform.localScale;
    }

    public void Selected()
    {
        // stop all animations
        transform.DOKill();

        // hover start animations
        transform.DOScale(scaleFactor, hoverStartAniamtionDuration);
        text.DOColor(textHoverColor, hoverStartAniamtionDuration);
        image.DOColor(buttonHoverColor, hoverStartAniamtionDuration);
        
        StartCoroutine(Deselected());
    }
    public IEnumerator Deselected()
    {
        yield return new WaitForSeconds(0.2f);
        // stop all animations
        transform.DOKill();

        // hover end animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        text.DOColor(startTextColor, hoverEndAnimationDuration);
        image.DOColor(startImageColor, hoverEndAnimationDuration);
    }
}
