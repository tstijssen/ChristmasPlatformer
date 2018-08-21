using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Pickup.FlyWeight
{
    public enum PickupType { Score, Multiplier, Invincibility, OneUp };

    interface IPickupBase
    {
        #region Intrinsic State
        PickupStats stats { get; }  // allow stats of pickups to be retrieved
        #endregion

        #region Extrinsic State
        // empty
        #endregion
    }

    public class PickupStats
    {
        public PickupType type;
        public int value;       // retrived upon pickup (i.e. score value, invuln timer)
        public float rotSpeed;
    }

    // type of pickup, score, gives 10 points on collection
    public class cScore : IPickupBase
    {
        private PickupStats _Stats = null;
        public PickupStats stats
        {
            get
            {
                if (_Stats == null)
                {
                    _Stats = new PickupStats()
                    {
                        type = PickupType.Score,
                        value = 10,
                        rotSpeed = 50
                    };
                }
                return _Stats;
            }
        }
    }

    //type: life pickup, gives 1 life on collection
    public class cLife : IPickupBase
    {
        private PickupStats _Stats = null;
        public PickupStats stats
        {
            get
            {
                if (_Stats == null)
                {
                    _Stats = new PickupStats()
                    {
                        type = PickupType.OneUp,
                        value = 1,
                        rotSpeed = 50
                    };
                }
                return _Stats;
            }
        }
    }

    //factory for creation and retrieval of flyweights
    static class PickupFlyweightFactory
    {
        // contains all types of pickup already created, used to retrieve flyweight references
        private static Dictionary<PickupType, IPickupBase> pickups = new Dictionary<PickupType, IPickupBase>();
        public static int PickupCount { get; private set; }

        public static IPickupBase Pickup(PickupType type)
        {
            if(!pickups.ContainsKey(type))  // check if type of pickup has already been created
            {
                switch (type)   // if not, create it and add it to the dictionary
                {
                    case PickupType.Score:
                        pickups.Add(type, new cScore());
                        break;

                    case PickupType.OneUp:
                        pickups.Add(type, new cLife());
                        break;
                    default:
                        break;
                }
                PickupCount++;
            }
            return pickups[type];   // if pickup type already created, simply return a reference to it
        }
    }
}



