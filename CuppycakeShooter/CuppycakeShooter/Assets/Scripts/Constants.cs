using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

    //Player
    public const string Player = "player";

    //Bullet Strings
    public const string Cake = "cake";
    public const string Bullet = "bullet";
    public const string BeerBottle = "beer";
    public const string PigBullet = "pig";
    // Bullet Types   
    public const int CakeAmmo = 3;
    public const int RubbahBullet = 0;
    public const int Beer = 2;
    public const int Pig = 1;
    
    // Misc   
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    public static readonly int[] AllPickupTypes = new int[4] {
        CakeAmmo,
        RubbahBullet,
        Beer,
        Pig
    };
}
