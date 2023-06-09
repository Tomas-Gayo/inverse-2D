//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class HealthUI : MonoBehaviour
//{
//    [Header("Dependencies")]
//    public GameObject heartParent;
//    public UnityEngine.Sprite fullHeartSprite;
//    public UnityEngine.Sprite emptyHeartSprite;

//    // Private references
//    private List<HeartImage> heartImage;
//    private List<Heart> heart;

//    private void Awake()
//    {
//        heartImage = new List<HeartImage>();
//    }

//    public void SetupHUD(List<Heart> heartsList)
//    {
//        heart = heartsList;
//        DisplayHearts();
//    }

//    // Shows all the hearts in scene
//    public void DisplayHearts()
//    {
//        for (int i = 0; i < heart.Count; i++)
//        {
//            Heart heart = this.heart[i];
//            CreateHeartImage().SetHeartSprite(heart.IsDamaged());
//        }
//    }

//    // Creates a heart image object
//    private HeartImage CreateHeartImage()
//    {
//        GameObject heartGO = new ("Heart", typeof(Image));
//        heartGO.transform.SetParent(heartParent.transform);

//        Image heartImage = heartGO.GetComponent<Image>();

//        HeartImage heart = new(this, heartImage);
//        this.heartImage.Add(heart);

//        return heart;
//    }

//    public void UpdateHeartsUI()
//    {
//        if (heart == null)
//            return;

//        for (int i = 0; i < heart.Count; i++)
//        {
//            HeartImage heartImage = this.heartImage[i];
//            Heart heart = this.heart[i];
//            heartImage.SetHeartSprite(heart.IsDamaged());
//        }
//    }

//    // A class that represents a heart
//    private class HeartImage
//    {
//        private HealthUI headerUI; 
//        private Image heartImage;

//        public HeartImage(HealthUI headerUI, Image heartImage)
//        {
//            this.headerUI = headerUI;
//            this.heartImage = heartImage;
//        }

//        public void SetHeartSprite(bool isDamaged)
//        {
//            if ( isDamaged)
//                heartImage.sprite = headerUI.emptyHeartSprite;
//            else
//                heartImage.sprite = headerUI.fullHeartSprite;
//        }
//    }
//}
