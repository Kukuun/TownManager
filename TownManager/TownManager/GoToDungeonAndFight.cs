using System;

namespace TownManager {
    class GoToDungeonAndFight : State {
        Dungeon d;
        public void Enter(Group g) {
            d = g.Town.DungeonList[g.GroupDungeonIndex];
            g.StartTime = DateTime.Now;
            d.ReqTime = Convert.ToInt32((Convert.ToDecimal(d.Level) / Convert.ToDecimal(g.AverageLevel)) * 120);
            g.HomeWhen = g.StartTime.AddSeconds(d.ReqTime);
            TimeSpan delteTime = g.HomeWhen - g.StartTime;
            g.TimeTillHome = Convert.ToInt32(delteTime.TotalSeconds);

            g.EarnedGold = 0;

            string dungeonType = d.Type.ToString();

            if (!g.OnQuest) {
                g.Log += "The group moves out on adventure!" + Environment.NewLine;
                g.Log += "In a " + dungeonType + " Dungeon!" + Environment.NewLine;
                g.OnQuest = true;
                g.Available = false;
            }
        }

        public void Execute(Group g) {
            bool fled = false;
            g.Log += "The group arrives at the dungeon" + Environment.NewLine;

            for (int l = 1; l < d.Layer + 1; l++) {
                g.Log += "Continuing to layer " + l.ToString() + Environment.NewLine;


                int monsterGroupHp;
                int monsterCurrentGroupHp;
                int monsterDamage;

                if (l == d.Layer) {
                    monsterGroupHp = RndPicker.Rnd.Next((d.Level + l) * 50, (d.Level + l) * 100);
                    monsterCurrentGroupHp = monsterGroupHp;
                    monsterDamage = RndPicker.Rnd.Next((d.Level + l) * 3, (d.Level + l) * 4);
                    g.Log += "The group has encountered the master of the dungeon!" + Environment.NewLine;
                }
                else {
                    monsterGroupHp = RndPicker.Rnd.Next((d.Level + l) * 10, (d.Level + l) * 20);
                    monsterCurrentGroupHp = monsterGroupHp;
                    monsterDamage = RndPicker.Rnd.Next((d.Level + l) * 3, (d.Level + l) * 4);
                    g.Log += "The group has encountered a monster in the dungeon!" + Environment.NewLine;
                }

                g.Log += "Group HP: " + g.GroupCurrentHp + "/" + g.GroupHp + " || MonsterGroup HP: " + monsterCurrentGroupHp + "/" + monsterGroupHp + Environment.NewLine + Environment.NewLine;

                int i = 0;


                while (monsterCurrentGroupHp > 0 && g.GroupCurrentHp > 0) {
                    i++;
                    if (g.GroupCurrentHp <= g.GroupHp / 10 && monsterCurrentGroupHp > monsterGroupHp / 10) {
                        g.Log += "The group tries to flee due to damage." + Environment.NewLine;

                        if (RndPicker.Rnd.Next(0, 100) < 50) {
                            g.Log += "The group succesfully fled..." + Environment.NewLine + Environment.NewLine;
                            fled = true;
                            g.ChangeState(new GoHomeAndRest());
                            return;
                        }
                        else {
                            g.Log += "... but they failed" + Environment.NewLine + Environment.NewLine;
                        }
                    }
                    g.Log += "Round " + i + Environment.NewLine;
                    if (g.GroupCurrentHp > 0) {
                        g.Log += "The group attacks || " + g.GroupDamage + "dmg" + Environment.NewLine;
                        monsterCurrentGroupHp -= g.GroupDamage;
                        if (monsterCurrentGroupHp < 0)
                            monsterCurrentGroupHp = 0;

                    }
                    if (monsterCurrentGroupHp > 0) {
                        g.Log += "The monster attacks || " + monsterDamage + "dmg" + Environment.NewLine;
                        g.GroupCurrentHp -= monsterDamage;
                        if (g.GroupCurrentHp < 0)
                            g.GroupCurrentHp = 0;

                    }
                    else {
                        g.Log += "The monster died!" + Environment.NewLine;

                    }
                    g.Log += "|| Group HP: " + g.GroupCurrentHp + "/" + g.GroupHp + " || MonsterGroup HP: " + monsterCurrentGroupHp + "/" + monsterGroupHp + " ||" + Environment.NewLine + Environment.NewLine;

                }

                if (g.GroupCurrentHp > 0 && monsterCurrentGroupHp == 0) {
                    g.Log += "The group has succesfully slayed the monster!" + Environment.NewLine;
                    g.Log += "The heroes get " + d.LayerXP.ToString() + " Experience for completing the layer" + Environment.NewLine;
                    g.Log += "The heroes find " + d.LayerGold.ToString() + " Gold while searching this layer" + Environment.NewLine + Environment.NewLine;
                    foreach (Hero hero in g.GroupHero) {
                        bool heroLevelUp = hero.IncreaseXp(d.LayerXP);
                        if (heroLevelUp) {
                            g.Log += "Level Up! Hero " + hero.FullName + " is now level " + hero.Level.ToString() + Environment.NewLine;
                            g.UpdateGroup(g);
                            g.Town.Form1.UpdateCurrentGroups();
                            g.Town.Form1.UpdateGroupsToDungeon();
                        }
                    }
                    g.EarnedGold += d.LayerGold;

                    g.Log += "The heroes rest for a bit, before venturing deeper down" + Environment.NewLine;

                    g.GroupCurrentHp = (int)(g.GroupHp + (g.GroupHp * 0.05f));
                    if (g.GroupCurrentHp > g.GroupHp) {
                        g.GroupCurrentHp = g.GroupHp;
                    }

                    g.Log += Environment.NewLine;



                }
                else if (g.GroupCurrentHp == 0 && monsterCurrentGroupHp > 0) {
                    g.Log += "The group died a horrible death!" + Environment.NewLine;
                    g.IsAlive = false;
                    return;
                }

            }
            g.Log += "The heroes succesfully completed the dungeon" + Environment.NewLine;

            if (!fled) {
                foreach (Hero hero in g.GroupHero) {
                    bool heroLevelUp = hero.IncreaseXp(d.XPReward);
                    if (heroLevelUp) {
                        g.Log += "Level Up! Hero " + hero.FullName + " is now level " + hero.Level.ToString() + Environment.NewLine;
                        g.UpdateGroup(g);
                        g.Town.Form1.UpdateCurrentGroups();
                        g.Town.Form1.UpdateGroupsToDungeon();
                    }
                }
                g.EarnedGold += d.GoldReward;
            }

            g.ChangeState(new GoHomeAndRest());
        }

        public void Exit(Group g) {
            bool foundItem = d.GetAnItem(g.Town);
            g.Log += "The group found " + d.GoldReward.ToString() + " gold in the dungeon" + Environment.NewLine;
            g.Log += "Each hero gain " + d.XPReward.ToString() + " Experience for killing the monster" + Environment.NewLine;
            if (foundItem) {
                g.Log += "The group found an item and brought it back to the town" + Environment.NewLine;
            }
            g.Log += Environment.NewLine;

            g.Log += "The group leaves the dungeon and returns home to rest" + Environment.NewLine + Environment.NewLine;

            g.OnQuest = false;
        }
    }
}