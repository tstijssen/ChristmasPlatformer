using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pickup.FlyWeight;

public class PickupScript : MonoBehaviour {

    //PickupFactory factory = PickupFactoryProducer.getFactory();
    //public List<Pickup> pickups = new List<Pickup>();
    private IPickupBase _pickup;
    public PickupType type;

    private void Start()
    {
        _pickup = PickupFlyweightFactory.Pickup(type);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * _pickup.stats.rotSpeed * Time.deltaTime);
    }

    public PickupType GetPickupType()
    {
        return _pickup.stats.type;
    }

    public int GetPickupValue()
    {
        return _pickup.stats.value;
    }

}

//public abstract class Pickup
//{
//    public abstract void Get();
//    // Update is called once per frame
//}

//public class ScorePickup : Pickup
//{
//    public int scoreValue;
//    public ScorePickup() { scoreValue = 10; }

//    public override void Get()
//    {
//        Debug.Log("Score added");
//        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreValue);
//    }
//}

//public class LifePickup : Pickup
//{
//    public override void Get()
//    {
//        Debug.Log("Life added");
//        PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") + 1);
//    }
//}

//public class InvulPickup : Pickup
//{
//    public float invulTimer;
//    public InvulPickup() { invulTimer = 5; }

//    public override void Get()
//    {
//        PlayerPrefs.SetFloat("InvulTimer", invulTimer);
//    }
//}

//public class MultiPickup : Pickup
//{
//    public float multiTimer;
//    public int multiplier;
//    public MultiPickup() { multiTimer = 5; multiplier = 3; }

//    public override void Get()
//    {
//        PlayerPrefs.SetFloat("MultiTimer", multiTimer);
//        PlayerPrefs.SetInt("Multiplier", multiplier);
//    }
//}

//public class PickupFactory
//{
//    public Pickup getPickup(PickupType type)
//    {
//        switch (type)
//        {
//            case PickupType.Score:
//                return new ScorePickup();
//            case PickupType.Multiplier:
//                return new MultiPickup();
//            case PickupType.OneUp:
//                return new LifePickup();
//            case PickupType.Invincibility:
//                return new InvulPickup();
//            default:
//                return null;
//        }

//    }
//}

//public class PickupFactoryProducer
//{
//    public static PickupFactory getFactory()
//    {
//        return new PickupFactory();
//    }

//}

//
