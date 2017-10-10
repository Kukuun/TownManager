using System.Collections.Generic;
using System.Linq;

namespace TownManager {
    class Town {
        #region FIELDS
        /// <summary>
        /// Lists, variables and more.
        /// </summary>
        Form1 form1;

        private List<Hero> herolist;
        private List<Group> grouplist;
        private List<Group> removeGrouplist;
        private List<Dungeon> dungeonList;
        private List<Dungeon> removeDungeonList;
        private List<string> items;
        private List<string> logs;

        private int townID;
        private string townName;

        private byte townHallLevel;
        private byte storageLevel;
        private byte infimaryLevel;
        private byte innLevel;
        private byte barrackLevel;
        private byte sanctumLevel;
        private byte archeryRangeLevel;
        private int townMoneyStorage;
        private int heroAmount;

        private int currentGold;

        public List<Hero> Herolist {
            get { return herolist; }
            set { herolist = value; }
        }
        public List<Group> Grouplist {
            get { return grouplist; }
            set { grouplist = value; }
        }
        public List<Group> RemoveGrouplist {
            get { return removeGrouplist; }
            set { removeGrouplist = value; }
        }
        public List<string> Logs {
            get { return logs; }
            set { logs = value; }
        }
        public List<Dungeon> DungeonList {
            get { return dungeonList; }
            set { dungeonList = value; }
        }
        public List<Dungeon> RemoveDungeonList {
            get { return removeDungeonList; }
            set { removeDungeonList = value; }
        }
        public List<string> Items {
            get { return items; }
            set { items = value; }
        }
        public int TownID {
            get { return townID; }
            set { townID = value; }
        }
        public string TownName {
            get { return townName; }
            set { townName = value; }
        }
        public int CurrentGold {
            get { return currentGold; }
            set { currentGold = value; }
        }
        public int HeroAmount {
            get { return heroAmount; }
            set { heroAmount = value; }
        }
        public byte TownHallLevel {
            get { return townHallLevel; }
            set { townHallLevel = value; }
        }
        public byte StorageLevel {
            get { return storageLevel; }
            set { storageLevel = value; }
        }
        public byte InfimaryLevel {
            get { return infimaryLevel; }
            set { infimaryLevel = value; }
        }
        public byte InnLevel {
            get { return innLevel; }
            set { innLevel = value; }
        }
        public byte BarrackLevel {
            get { return barrackLevel; }
            set { barrackLevel = value; }
        }
        public byte SanctumLevel {
            get { return sanctumLevel; }
            set { sanctumLevel = value; }
        }
        public byte ArcheryRangeLevel {
            get { return archeryRangeLevel; }
            set { archeryRangeLevel = value; }
        }
        public Form1 Form1 {
            get { return form1; }
            set { form1 = value; }
        }


        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor, instances of lists and variables.
        /// </summary>
        /// <param name="form1"></param>
        public Town(Form1 form1) {
            this.form1 = form1;

            townID = -1;
            townName = "tempTownName";

            townHallLevel = 1;
            storageLevel = 0;
            infimaryLevel = 1;
            innLevel = 1;
            barrackLevel = 0;
            sanctumLevel = 0;
            archeryRangeLevel = 0;
            heroAmount = 5;

            herolist = new List<Hero>();
            grouplist = new List<Group>();
            removeGrouplist = new List<Group>();
            logs = new List<string>();
            dungeonList = new List<Dungeon>();
            items = new List<string>();

            currentGold = 0;
        }
        #endregion

        #region METODER
        /// <summary>
        /// Method that's used to increase the level of buildings.
        /// </summary>
        /// <param name="b"></param>
        public void UpgradeBuilding(BuildingType b) {
            switch (b) {
                case BuildingType.TownHall:
                    townHallLevel++;
                    break;
                case BuildingType.Storage:
                    storageLevel++;
                    break;
                case BuildingType.Infirmary:
                    infimaryLevel++;
                    break;
                case BuildingType.Inn:
                    innLevel++;
                    break;
                case BuildingType.Barrack:
                    barrackLevel++;
                    break;
                case BuildingType.Sanctum:
                    sanctumLevel++;
                    break;
                case BuildingType.ArcheryRange:
                    archeryRangeLevel++;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method used to determine how much gold our city can store.
        /// </summary>
        public void CheckMaxStorage() {
            if (storageLevel == 0) {
                townMoneyStorage = 500;
            }
            else if (storageLevel >= 1) {
                townMoneyStorage = storageLevel * 1000 + 500;
            }

            heroAmount = innLevel * 5;
        }

        /// <summary>
        /// Method used to determine if we exceed the maximum amount of gold we can have.
        /// </summary>
        /// <param name="reward"></param>
        public void AddGold(int reward) {
            if (reward + currentGold > townMoneyStorage) {
                currentGold = townMoneyStorage;
            }
            else {
                currentGold = currentGold + reward;
            }
        }

        /// <summary>
        /// Method used to subtract gold when we make purchases.
        /// </summary>
        /// <param name="required"></param>
        /// <returns></returns>
        public bool UseGold(int required) {
            if (currentGold >= required) {
                currentGold = currentGold - required;
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Method used to make and place our heroes in lists.
        /// </summary>
        public void MakeHero() {
            herolist.Add(CreateHero());
            if (herolist.Count < heroAmount) {
                MakeHero();
            }
            else {
                form1.UpdateAvailableHeros();
            }
        }

        /// <summary>
        /// Method used to distribute random stats for our heroes.
        /// </summary>
        /// <returns></returns>
        private Hero CreateHero() {
            int dmg = RndPicker.Rnd.Next(5, 11);
            int health = RndPicker.Rnd.Next(5, 11);
            return new Hero(dmg, health);
        }

        /// <summary>
        /// Method used to remove dead heroes from their groups.
        /// </summary>
        /// <param name="groupToDie"></param>
        public void DeleteHero(List<Hero> groupToDie) {
            foreach (Hero deadHero in groupToDie) {
                for (int i = 0; i < herolist.Count; i++) {
                    if (herolist[i] == deadHero) {
                        herolist.Remove(deadHero);
                    }
                }
            }
        }

        /// <summary>
        /// Method used to create a group of 1 to 5 heroes in a list.
        /// </summary>
        /// <param name="heroListPos"></param>
        public void CreateGroup(List<int> heroListPos) {
            if (heroListPos.Count < 6) {
                if (heroListPos.Count == 1) {
                    grouplist.Add(new Group(herolist[heroListPos[0]], this));
                    herolist[heroListPos[0]].InGroup = true;
                }
                if (heroListPos.Count == 2) {
                    grouplist.Add(new Group(herolist[heroListPos[0]], herolist[heroListPos[1]], this));
                    herolist[heroListPos[0]].InGroup = true;
                    herolist[heroListPos[1]].InGroup = true;
                }
                if (heroListPos.Count == 3) {
                    grouplist.Add(new Group(herolist[heroListPos[0]], herolist[heroListPos[1]], herolist[heroListPos[2]], this));
                    herolist[heroListPos[0]].InGroup = true;
                    herolist[heroListPos[1]].InGroup = true;
                    herolist[heroListPos[2]].InGroup = true;
                }
                if (heroListPos.Count == 4) {
                    grouplist.Add(new Group(herolist[heroListPos[0]], herolist[heroListPos[1]], herolist[heroListPos[2]], herolist[heroListPos[3]], this));
                    herolist[heroListPos[0]].InGroup = true;
                    herolist[heroListPos[1]].InGroup = true;
                    herolist[heroListPos[2]].InGroup = true;
                    herolist[heroListPos[3]].InGroup = true;
                }
                if (heroListPos.Count == 5) {
                    grouplist.Add(new Group(herolist[heroListPos[0]], herolist[heroListPos[1]], herolist[heroListPos[2]], herolist[heroListPos[3]], herolist[heroListPos[4]], this));
                    herolist[heroListPos[0]].InGroup = true;
                    herolist[heroListPos[1]].InGroup = true;
                    herolist[heroListPos[2]].InGroup = true;
                    herolist[heroListPos[3]].InGroup = true;
                    herolist[heroListPos[4]].InGroup = true;
                }
            }

            form1.UpdateAvailableHeros();
            form1.UpdateCurrentGroups();
            form1.UpdateGroupsToDungeon();
        }

        /// <summary>
        /// Method used to disband a select group.
        /// </summary>
        /// <param name="listPos"></param>
        public void DisbandGroup(List<int> listPos) {
            for (int i = 0; i < listPos.Count; i++) {
                for (int heroNumber = 0; heroNumber < grouplist[i].GroupHero.Count; heroNumber++) {
                    grouplist[i].GroupHero[heroNumber].InGroup = false;
                }
                removeGrouplist.Add(grouplist[i]);
            }

            for (int i = 0; i < removeGrouplist.Count; i++) {
                grouplist.Remove(removeGrouplist[i]);
            }

            removeGrouplist.Clear();

            form1.UpdateAvailableHeros();
            form1.UpdateCurrentGroups();
            form1.UpdateGroupsToDungeon();
        }

        /// <summary>
        /// Method used to automatically remove a group if it does not complete a quest.
        /// </summary>
        public void RemoveDeadGroup() {
            for (int i = 0; i < removeGrouplist.Count; i++) {
                DeleteHero(removeGrouplist[i].GroupHero);
                grouplist.Remove(removeGrouplist[i]);
            }

            removeGrouplist.Clear();

            form1.UpdateAvailableHeros();
            form1.UpdateCurrentGroups();
            form1.UpdateGroupsToDungeon();
        }

        /// <summary>
        /// Method used to ensure that there's always three quests available.
        /// </summary>
        public void MakeDungeon() {
            dungeonList.Add(GenerateDungeon());
            if (dungeonList.Count < 3) {
                MakeDungeon();
            }
            else {

            }
        }

        /// <summary>
        /// Method used to generate a dungeon and set it's difficulty.
        /// </summary>
        /// <returns></returns>
        public Dungeon GenerateDungeon() {
            int maxLevel = 0;
            int minLevel = 0;
            int averageLevel = 0;
            int totalLevel = 0;
            foreach (Hero hero in herolist) {
                if (hero.Level > maxLevel) {
                    maxLevel = hero.Level;
                }
                if (hero.Level < minLevel) {
                    minLevel = hero.Level;
                }
                totalLevel += hero.Level;
            }

            averageLevel = totalLevel / herolist.Count;

            return new Dungeon(maxLevel, minLevel, averageLevel);
        }

        /// <summary>
        /// Method used to add items to a list.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(string item) {
            if (item != string.Empty) {
                items.Add(item);
            }
        }

        /// <summary>
        /// Method used to remove dungeons from the display when it reaches the expiration time.
        /// </summary>
        public void RemoveExpiredDungeons() {
            for (int i = 0; i < removeDungeonList.Count; i++) {
                dungeonList.Remove(removeDungeonList[i]);
            }
            removeDungeonList.Clear();
        }

        /// <summary>
        /// Method used to add heroes if there aren't enough heroes, remove a group if it doesn't complete a quest, ensure there's always 3 quests, check storage limit, make a temporary list used while determining 
        /// if a quest is still in progress.
        /// </summary>
        public void Update() {
            // Checks to see if max heroes are in town... More will be added if not
            if (Herolist.Count < HeroAmount) {
                MakeHero();
            }
            if (RemoveGrouplist.Count > 0) {
                RemoveDeadGroup();
            }
            if (DungeonList.Count < 3) {
                MakeDungeon();
                form1.ListOutDungeons();
            }

            CheckMaxStorage();

            List<Dungeon> tempList = new List<Dungeon>();

            tempList = DungeonList.ToList();

            foreach (Dungeon d in tempList) {
                d.CheckTimeLeft(this);
                if (d.Delete) {
                    DungeonList.Remove(d);
                }
            }
            //Rettet
            foreach (Group group in grouplist) {
                if (!group.Available) {
                    group.CheckIfHome();
                }
            }
        }

        #endregion
    }
}