using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace clickerGame
{
    public static class Game
    {
        private static int _goldPerClick = Const.STARTING_GPC;
        private static int _passiveGold = Const.STARTING_PASSIVE;
        private static Timer _gpsTimer;
        private static int[] _bonusThresholds;
        private static bool _started = false;
        private static int _goldSinceLastTick = 0;
        private static List<int> _goldGainedPerTick = new List<int>();
        private static Item[] shopInventory;

        public static int GoldPerClick { get => _goldPerClick; set => _goldPerClick = value; }
        public static Timer GameTimer { get => _gpsTimer; set => _gpsTimer = value; }
        public static int PassiveGold { get => _passiveGold; set => _passiveGold = value; }
        public static int[] BonusThresholds { get => _bonusThresholds; set => _bonusThresholds = value; }
        public static bool Started { get => _started; private set => _started = value; }

        public static int GoldSinceLastTick
        {
            get => _goldSinceLastTick;
            set
            {
                _goldSinceLastTick = value;
            }
        }

        public static List<int> GoldGainedPerTick { get => _goldGainedPerTick; set => _goldGainedPerTick = value; }

        public static void Start()
        {
            GoldPerClick = Const.STARTING_GPC;
            PassiveGold = Const.STARTING_PASSIVE;
            BonusThresholds = Const.DEFAULT_BONUS_THRESHOLDS;
            Shop.Initialize(shopInventory);
            Player.Initialize();
            GameTimer = new Timer()
            {
                Interval = Const.TICK_INTERVAL,
            };
            GameTimer.Tick += UpdateGPS;

            GameTimer.Enabled = true;
            Started = true;
        }
        private static void populateShoppingPool()
        {
            
        }
        public static void UpdateGPS(object sender, EventArgs e)
        {
            GoldGainedPerTick.Add(GoldSinceLastTick);
            if (GoldGainedPerTick.Count > Const.TICK_COUNT_FOR_GPS)
                GoldGainedPerTick.RemoveAt(0);

            Forms.UpdateUI();

            GoldSinceLastTick = 0;
        }
        public static double GetAverageGPS()
        {
            int ticksPerSecond = 1000 / GameTimer.Interval;
            double GPS = GoldGainedPerTick.Sum() / (double)(Const.TICK_COUNT_FOR_GPS / ticksPerSecond);
            return GPS;
        }
        public static void Increment()
        {
            if (Started)
            {
                Player.Gold += GoldPerClick;
                Forms.UpdateUI();
            }
        }

    }
}
