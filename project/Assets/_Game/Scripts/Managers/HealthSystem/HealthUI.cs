using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject heartParent;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    [Header("Rect Transform Configuration")]
    [Tooltip("Original position of the group of hearts.")]
    public Vector2 heartsPosition;
    [Tooltip("Distance between hearts")]
    public Vector2 heartDistance;

    // Private references
    private List<HeartImage> heartImage;
    private List<Heart> heart;

    private void Awake()
    {
        heartImage = new List<HeartImage>();
    }

    public void SetupHUD(List<Heart> heartsList)
    {
        heart = heartsList;
        DisplayHearts();
    }

    // Shows all the hearts in scene
    public void DisplayHearts()
    {
        Vector2 heartAnchoredPosition = heartsPosition;
        for (int i = 0; i < heart.Count; i++)
        {
            Heart heart = this.heart[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartSprite(heart.IsDamaged());
            heartAnchoredPosition += heartDistance;
        }
    }

    // Creates a heart image object
    private HeartImage CreateHeartImage(Vector2 position)
    {
        GameObject heartGO = new ("Heart", typeof(Image));
        heartGO.transform.SetParent(heartParent.transform);

        RectTransform rect = heartGO.GetComponent<RectTransform>();
        rect.anchoredPosition = position;
        //rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, heartSize.x);
        //rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heartSize.y);

        Image heartImage = heartGO.GetComponent<Image>();

        HeartImage heart = new(this, heartImage);
        this.heartImage.Add(heart);

        return heart;
    }

    public void UpdateHeartsUI()
    {
        if (heart == null)
            return;

        for (int i = 0; i < heart.Count; i++)
        {
            HeartImage heartImage = this.heartImage[i];
            Heart heart = this.heart[i];
            heartImage.SetHeartSprite(heart.IsDamaged());
        }
    }

    // A class that represents a heart
    private class HeartImage
    {
        private HealthUI headerUI; 
        private Image heartImage;

        public HeartImage(HealthUI headerUI, Image heartImage)
        {
            this.headerUI = headerUI;
            this.heartImage = heartImage;
        }

        public void SetHeartSprite(bool isDamaged)
        {
            if ( isDamaged)
                heartImage.sprite = headerUI.emptyHeartSprite;
            else
                heartImage.sprite = headerUI.fullHeartSprite;
        }
    }
}
