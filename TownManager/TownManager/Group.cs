using System;
using System.Collections.Generic;

namespace TownManager {
    class Group {
        private int groupDungeonIndex = 0;

        public int GroupDungeonIndex {
            get { return groupDungeonIndex; }
            set { groupDungeonIndex = value; }
        }
        Town town;

        private State currentState;

        private int groupID;
        private int groupHp;
        private int groupCurrentHp;
        private int groupDamage;
        private int averageLevel;

        private bool onQuest;
        private bool available;
        private bool isAlive;

        private int timeTillHome;
        private DateTime homeWhen;
        private DateTime startTime;

        public DateTime StartTime {
            get { return startTime; }
            set { startTime = value; }
        }
        public DateTime HomeWhen {
            get { return homeWhen; }
            set { homeWhen = value; }
        }

        int earnedGold;
        public int EarnedGold {
            get { return earnedGold; }
            set { earnedGold = value; }
        }

        private string log;


        public Town Town {
            get { return town; }
            set { town = value; }
        }
        public int GroupID {
            get { return groupID; }
            set { groupID = value; }
        }
        public int GroupHp {
            get { return groupHp; }
            set { groupHp = value; }
        }
        public int GroupCurrentHp {
            get { return groupCurrentHp; }
            set { groupCurrentHp = value; }
        }
        public int GroupDamage {
            get { return groupDamage; }
            set { groupDamage = value; }
        }
        public int AverageLevel {
            get { return averageLevel; }
            set { averageLevel = value; }
        }
        public bool OnQuest {
            get { return onQuest; }
            set { onQuest = value; }
        }
        public bool Available {
            get { return available; }
            set { available = value; }
        }
        public bool IsAlive {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public int TimeTillHome {
            get { return timeTillHome; }
            set { timeTillHome = value; }
        }
        public string Log {
            get { return log; }
            set { log = value; }
        }

        private List<Hero> groupHero = new List<Hero>();

        public List<Hero> GroupHero {
            get { return groupHero; }
            set { groupHero = value; }
        }

        public Group(int groupID, bool onQuest, bool available, int time, string log, Town town) {
            this.groupID = groupID;

            this.onQuest = onQuest;
            this.available = available;

            isAlive = true;
            timeTillHome = time;
            this.town = town;

            if (!this.available) {
                this.log = log;

                startTime = DateTime.Now;
                homeWhen = startTime.AddSeconds(timeTillHome);
            }
        }

        public Group(Hero hero1, Town town) {
            groupID = -1;

            groupDamage = hero1.Damage;
            groupHp = hero1.Health;
            groupCurrentHp = groupHp;
            groupHero.Add(hero1);

            onQuest = false;
            available = true;

            isAlive = true;
            timeTillHome = 0;
            this.town = town;
            CalcAverageLevel();
        }
        public Group(Hero hero1, Hero hero2, Town town) {
            groupID = -1;

            groupDamage = hero1.Damage + hero2.Damage;
            groupHp = hero1.Health + hero2.Health;
            groupCurrentHp = groupHp;
            groupHero.Add(hero1);
            groupHero.Add(hero2);

            onQuest = false;
            available = true;

            isAlive = true;
            timeTillHome = 0;
            this.town = town;
            CalcAverageLevel();
        }
        public Group(Hero hero1, Hero hero2, Hero hero3, Town town) {
            groupID = -1;

            groupDamage = hero1.Damage + hero2.Damage + hero3.Damage;
            groupHp = hero1.Health + hero2.Health + hero3.Health;
            groupCurrentHp = groupHp;
            groupHero.Add(hero1);
            groupHero.Add(hero2);
            groupHero.Add(hero3);

            onQuest = false;
            available = true;

            isAlive = true;
            timeTillHome = 0;
            this.town = town;
            CalcAverageLevel();
        }
        public Group(Hero hero1, Hero hero2, Hero hero3, Hero hero4, Town town) {
            groupID = -1;

            groupDamage = hero1.Damage + hero2.Damage + hero3.Damage + hero4.Damage;
            groupHp = hero1.Health + hero2.Health + hero3.Health + hero4.Health;
            groupCurrentHp = groupHp;
            groupHero.Add(hero1);
            groupHero.Add(hero2);
            groupHero.Add(hero3);
            groupHero.Add(hero4);

            onQuest = false;
            available = true;

            isAlive = true;
            timeTillHome = 0;
            this.town = town;
            CalcAverageLevel();
        }
        public Group(Hero hero1, Hero hero2, Hero hero3, Hero hero4, Hero hero5, Town town) {
            groupID = -1;

            groupDamage = hero1.Damage + hero2.Damage + hero3.Damage + hero4.Damage + hero5.Damage;
            groupHp = hero1.Health + hero2.Health + hero3.Health + hero4.Health + hero5.Health;
            groupCurrentHp = groupHp;
            groupHero.Add(hero1);
            groupHero.Add(hero2);
            groupHero.Add(hero3);
            groupHero.Add(hero4);
            groupHero.Add(hero5);

            onQuest = false;
            available = true;

            isAlive = true;
            timeTillHome = 0;
            this.town = town;
            CalcAverageLevel();
        }

        public void GroupStateUpdate() {
            currentState.Enter(this);
            currentState.Execute(this);
        }

        public void SendToDungeon(int dungeonIndex) {
            log = "";

            groupDungeonIndex = dungeonIndex;

            currentState = new GoToDungeonAndFight();

            GroupStateUpdate();


        }

        public void ChangeState(State newState) {
            currentState.Exit(this);

            //New state
            currentState = newState;

            currentState.Enter(this);

            currentState.Execute(this);
        }

        public void BecomeAvailable() {
            currentState.Exit(this);
        }

        public void Die(Town town, int deadGroupIndex) {
            town.DeleteHero(groupHero);
            town.Grouplist.RemoveAt(deadGroupIndex);
        }

        public void AddGoldToTown(int goldAmount) {
            town.AddGold(goldAmount);
        }

        public void UpdateGroup(Group g) {
            g.GroupDamage = 0;
            g.GroupHp = 0;
            g.averageLevel = 0;
            foreach (Hero hero in g.GroupHero) {
                g.GroupDamage += hero.Damage;
                g.GroupHp += hero.Health;
                g.AverageLevel += hero.Level;
            }
            g.AverageLevel = g.AverageLevel / g.GroupHero.Count;
        }

        public void AddLog() {
            town.Logs.Add(log);
            town.AddGold(earnedGold);
        }

        public void CheckIfHome() {
            if (DateTime.Now >= HomeWhen) {
                available = true;
                town.Form1.UpdateGroupsToDungeon();
                town.Form1.UpdateCurrentGroups();
                AddLog();
                if (!isAlive)
                    town.RemoveGrouplist.Add(this);
            }
        }

        public void CalcAverageLevel() {
            averageLevel = 0;

            foreach (Hero hero in GroupHero) {
                averageLevel += hero.Level;
            }

            averageLevel = averageLevel / GroupHero.Count;
        }

        public void CalcHealthAndDamage() {
            foreach (Hero hero in groupHero) {
                groupHp += hero.Health;
                groupDamage += hero.Damage;
            }
            groupCurrentHp = groupHp;
        }
    }
}