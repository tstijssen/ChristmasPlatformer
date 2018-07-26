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
        PickupStats stats { get; }
        #endregion

        #region Extrinsic State
        // empty
        #endregion
    }

    public class PickupStats
    {
        public PickupType type;
        public int value;
        public float rotSpeed;
    }

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


    static class PickupFlyweightFactory
    {
        private static Dictionary<PickupType, IPickupBase> pickups = new Dictionary<PickupType, IPickupBase>();
        public static int PickupCount { get; private set; }

        public static IPickupBase Pickup(PickupType type)
        {
            if(!pickups.ContainsKey(type))
            {
                switch (type)
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
            return pickups[type];
        }
    }
}



