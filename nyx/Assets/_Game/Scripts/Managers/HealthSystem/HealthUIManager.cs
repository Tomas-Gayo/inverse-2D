//using System.Collections.Generic;
//using UnityEngine;

//public class HealthUIManager : MonoBehaviour
//{
//    [Header("Dependencies")]
//    public HealthUI healthUI;

//    // Private references
//    List<Heart> heartsList;
//    private HealthSO player;

//    public void SetupUI(HealthUIRequest request)
//    {
//        // Save reference for later
//        player = request.health;

//        // Set number of lifes and substract 'til current life
//        CreateHeartList(player.Maxhealth);
//        TakeDamage();

//        // Display heart on canvas
//        healthUI.SetupHUD(heartsList);
//    }


//    // Set the current life of the player on damage
//    public void TakeDamage()
//    {
//        int currentLifes = player.CurrentHealth;

//        for (int i = heartsList.Count - 1; i >= currentLifes; i--)
//        {
//            Heart heart = heartsList[i];
//            heart.Damaged();
//        }

//        healthUI.UpdateHeartsUI();
//    }

//    // Set the current life of the player on damage
//    public void Heal()
//    {
//        int healAmount = player.CurrentHealth;

//        for (int i = 0; i < healAmount; i++)
//        {
//            Heart heart = heartsList[i];
//            if ( heart.IsDamaged())
//                heart.Healed();
//        }

//        healthUI.UpdateHeartsUI();
//    }

//    // Add to the heart list all the hearts depending on the max life of the player
//    private void CreateHeartList(int maxLifes)
//    {
//        heartsList = new List<Heart>();
//        for (int i = 0; i < maxLifes; i++)
//        {
//            Heart heart = new Heart(false);
//            heartsList.Add(heart);
//        }
//    }

//}

//// A class that represents a single heart
//public class Heart
//{
//    private bool isDamaged;

//    public Heart(bool isDamaged)
//    {
//        this.isDamaged = isDamaged;
//    }

//    public bool IsDamaged() => isDamaged;

//    public void Damaged()
//    {
//        isDamaged = true;
//    }

//    public void Healed()
//    {
//        isDamaged = false;
//    }
//}
