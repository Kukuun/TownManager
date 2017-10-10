using System;

namespace TownManager {
    class Dungeon {
        #region Fields
        /// <summary>
        /// Variables for this class.
        /// </summary>
        private DungeonType type;
        private int layer;
        private int goldReward;
        private int xPReward;
        private int level;
        private int layerXP;
        private int layerGold;
        private BuildingType dropAbleSchematic;
        private string[] items;
        private DateTime started;
        private DateTime expire;
        private int reqTime;
        private int timeLeft;
        private bool delete;
        #endregion

        #region Properties
        /// <summary>
        /// Properties
        /// </summary>
        public bool Delete {
            get { return delete; }
            set { delete = value; }
        }
        public int GoldReward {
            get { return goldReward; }
            set { goldReward = value; }
        }
        public int XPReward {
            get { return xPReward; }
            set { xPReward = value; }
        }
        public int Layer {
            get { return layer; }
            set { layer = value; }
        }
        public int Level {
            get { return level; }
            set { level = value; }
        }
        public int LayerXP {
            get { return layerXP; }
            set { layerXP = value; }
        }
        public int LayerGold {
            get { return layerGold; }
            set { layerGold = value; }
        }
        public DungeonType Type {
            get { return type; }
            set { type = value; }
        }
        public DateTime Expire {
            get { return expire; }
            set { expire = value; }
        }
        public int ReqTime {
            get { return reqTime; }
            set { reqTime = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor containing items(didn't make it), schematic(didn't make it), gold and xp rewards.
        /// </summary>
        /// <param name="maxLevel"></param>
        /// <param name="minLevel"></param>
        /// <param name="averageLevel"></param>
        public Dungeon(int maxLevel, int minLevel, int averageLevel) {
            //Delete Dungeon
            started = DateTime.Now;
            expire = started.AddSeconds(60);
            TimeSpan delta = expire - started;
            timeLeft = delta.Seconds;

            //Timed Dungeon
            reqTime = 100;

            items = new string[] { "Potion", "Light Sword", "Mail" };
            type = (DungeonType)RndPicker.Rnd.Next(0, 3);

            if (type == DungeonType.Dragon) {
                dropAbleSchematic = BuildingType.ArcheryRange;
            }
            else if (type == DungeonType.Elemental) {
                dropAbleSchematic = BuildingType.Sanctum;
            }
            else if (type == DungeonType.Orc) {
                dropAbleSchematic = BuildingType.Barrack;
            }
            else {
                dropAbleSchematic = BuildingType.Storage;
            }

            level = RndPicker.Rnd.Next(minLevel - 2, maxLevel + 2);
            if (level < 1) {
                level = 1;
            }
            layerGold = (level * 10) + 30;
            layerXP = (level * 5) + 5;
            layer = 5;//(level / 5) + 1;

            goldReward = RndPicker.Rnd.Next((level * layer * 2 * 10), (level * layer * 2 * 10) + (averageLevel * 10));
            xPReward = RndPicker.Rnd.Next(20 - level + layer + (int)((level * 0.5f) + (layer * 0.1f)), 20 + level + layer + (int)((level * 0.5f) + (layer * 0.1f)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methose used to calculate chances we have to get items and schematics(didn't make it)
        /// </summary>
        /// <param name="town"></param>
        /// <returns></returns>
        public bool GetAnItem(Town town) {
            int chance = RndPicker.Rnd.Next(0, 100);
            if (chance <= 25) {
                int rndItemIndex = RndPicker.Rnd.Next(0, items.Length);
                town.AddItem(items[rndItemIndex]);

                int schematicChance = RndPicker.Rnd.Next(0, 100);

                if (schematicChance <= 5) {
                    int buildingLevel = 1;
                    if (dropAbleSchematic == BuildingType.Sanctum) {
                        buildingLevel = town.SanctumLevel + 1;
                    }
                    else if (dropAbleSchematic == BuildingType.ArcheryRange) {
                        buildingLevel = town.ArcheryRangeLevel + 1;
                    }
                    else if (dropAbleSchematic == BuildingType.Barrack) {
                        buildingLevel = town.BarrackLevel + 1;
                    }
                    else if (dropAbleSchematic == BuildingType.Inn) {
                        buildingLevel = town.InnLevel + 1;
                    }

                    string tempSchematic = dropAbleSchematic.ToString() + " schematic level " + buildingLevel.ToString();

                    CheckSchematic(ref tempSchematic, town, ref buildingLevel);


                    town.AddItem(tempSchematic);
                }

                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Method used to check which schematic we might've got(didn't make it).
        /// </summary>
        /// <param name="schematic"></param>
        /// <param name="town"></param>
        /// <param name="buildingLevel"></param>
        public void CheckSchematic(ref string schematic, Town town, ref int buildingLevel) {
            foreach (string item in town.Items) {
                if (schematic == item) {
                    string temp = schematic;
                    buildingLevel += 1;
                    schematic = dropAbleSchematic.ToString() + " schematic level " + buildingLevel.ToString();
                    CheckSchematic(ref schematic, town, ref buildingLevel);
                }
            }
        }

        /// <summary>
        /// Method used to determine if a group is still on a mission
        /// </summary>
        /// <param name="town"></param>
        public void CheckTimeLeft(Town town) {
            DateTime checkedTime = DateTime.Now;

            if (checkedTime >= expire) {
                //town.RemoveDungeonList.Add(this);
                delete = true;
            }
        }
        #endregion
    }
}