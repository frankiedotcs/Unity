using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    
    [SerializeField]
    private int cakeAmmo = 13;
    [SerializeField]
    private int beerAmmo = 6;
    [SerializeField]
    private int pigAmmo = 1;

    public Dictionary<string, int> tagToAmmo;
    // Use this for initialization

    void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
        {
            {Constants.Cake, cakeAmmo },
            {Constants.BeerBottle, beerAmmo },
            {Constants.PigBullet, pigAmmo },
        };
    }

    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized bullet type passed:" + tag);
        }

        tagToAmmo[tag] += ammo;
    }

    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        return tagToAmmo[tag] > 0;
    }

    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized bullet type passed: " + tag);
        }
        return tagToAmmo[tag];
    }

    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized bullet type passed: " + tag);
        }

        tagToAmmo[tag]--;
    }
    
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
