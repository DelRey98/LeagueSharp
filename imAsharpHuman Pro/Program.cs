﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace imAsharpHuman
{
    class Program
    {
        static Menu _menu;
        static Random _random;
        private static int _lastCommandT = 0;
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += gameLoadEventArgs =>
            {
                _random = new Random(Environment.TickCount - Utils.GameTimeTickCount);
                _menu = new Menu("imAsharpHuman", "iashpromenu", true);
                _menu.AddItem(new MenuItem("iashpromenu.MinClicks", "Min clicks per second").SetValue(new Slider(_random.Next(5,6), 1, 6)).DontSave());
                _menu.AddItem(new MenuItem("iashpromenu.MaxClicks", "Max clicks per second").SetValue(new Slider(_random.Next(7, 11), 7, 15)).DontSave());
                _menu.AddToMainMenu();
            };
            Obj_AI_Base.OnIssueOrder += (sender, issueOrderEventArgs) =>
            {
                if (sender.IsMe && issueOrderEventArgs.Order == GameObjectOrder.AttackUnit || issueOrderEventArgs.Order == GameObjectOrder.MoveTo || issueOrderEventArgs.Order == GameObjectOrder.MovePet)
                {
                    if (Utils.GameTimeTickCount - _lastCommandT <
                        _random.Next(1000 / _menu.Item("iashpromenu.MaxClicks").GetValue<Slider>().Value,
                            1000 / _menu.Item("iashpromenu.MinClicks").GetValue<Slider>().Value))
                    {
                        issueOrderEventArgs.Process = false;
                        return;
                    }
                    _lastCommandT = Utils.GameTimeTickCount;
                }
            };
        }
    }
}