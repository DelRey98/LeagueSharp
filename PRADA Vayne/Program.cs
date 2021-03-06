﻿using System;
using LeagueSharp;
using LeagueSharp.Common;
using PRADA_Vayne.MyUtils;

namespace PRADA_Vayne
{
    public class Program
    {
        #region Fields and Objects

        public static MActivator Activator;
        public static Orbwalking.Orbwalker Orbwalker;
        public static LeagueSharp.Common.Orbwalking.Orbwalker VHROrbwalker;
        public static EarlyEvade EarlyEvade;

        #region Menu

        public static Menu MainMenu;
        public static Menu ComboMenu;
        public static Menu LaneClearMenu;
        public static Menu EscapeMenu;
        public static Menu ActivatorMenu;
        public static Menu DrawingsMenu;
        public static Menu SkinhackMenu;
        public static Menu OrbwalkerMenu;

        #endregion Menu

        #region Spells

        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;

        #endregion Spells

        #endregion

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += onGameLoadArgs =>
            {
                if (ObjectManager.Player.CharData.BaseSkinName == "Vayne")
                {
                    EarlyEvade = new EarlyEvade();
                    PRADAHijacker.AttemptHijack();
                }
            };
        }
    }
}
