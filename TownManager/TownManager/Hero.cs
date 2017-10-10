namespace TownManager {
    class Hero {
        private int damage;
        private int health;
        private int heroID;
        private int curXp;
        private int xPToNext;
        private int level;
        private int upkeep;
        private bool inGroup;
        private string firstName;
        private string lastName;
        private string fullName;
        
        string[] firstNames = new string[] { "Kenneth", "Ludvig", "Arthur", "Valdemar", "Jens", "Gurli", "Hilda", "Ema", "Ole", "Åse", "Olaf", "Betty", "Bodil", "Michael",
                                            "Leroooy", "Harald", "Holger", "Tove", "Birthe", "Allan", "Sigurd", "Flemming", "Frank", "Poul", "Gitte"};
        string[] lastNames = new string[] { "Andersen", "Mjød Dranker", "Longsword", "Sitting Bull", "Mogensen", "Firefly", "Brumbass", "Snailman",
                                            "Parker", "Asgaard", "God Speaker", "Demon Hunter", "Dawnbreaker", "Nightfall", "Jenkiiins", "Bluetooth", "Danske",
                                            "Game Master", "Demon Lord", "Novice Adventure"};

        public int HeroID {
            get { return heroID; }
            set { heroID = value; }
        }
        public int Level {
            get { return level; }
            set { level = value; }
        }
        public int CurXp {
            get { return curXp; }
            set { curXp = value; }
        }
        public string FullName {
            get { return fullName; }
            set { fullName = value; }
        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Damage {
            get { return damage; }
            set { damage = value; }
        }
        public int Health {
            get { return health; }
            set { health = value; }
        }
        public bool InGroup {
            get { return inGroup; }
            set { inGroup = value; }
        }
        public int XPToNext {
            get { return xPToNext; }
            set { xPToNext = value; }
        }

        public Hero(int damage, int health) {
            heroID = -1;

            int randomValue = RndPicker.Rnd.Next(0, firstNames.Length);
            firstName = firstNames[randomValue];
            randomValue = RndPicker.Rnd.Next(0, lastNames.Length);
            lastName = lastNames[randomValue];
            fullName = firstName + " " + lastName;
            this.damage = damage;
            this.health = health;
            inGroup = false;
            level = 1;
            curXp = 0;
            xPToNext = (level * 100) / 2;
            upkeep = 10;
        }

        public Hero(int heroID, string firstname, string lastname, int level, int health, int damage, int exp) {
            this.heroID = heroID;

            this.firstName = firstname;
            this.lastName = lastname;
            fullName = firstName + " " + lastName;
            this.damage = damage;
            this.health = health;
            inGroup = false;
            this.level = level;
            curXp = exp;
            xPToNext = (level * 100) / 2;
            upkeep = 10;
        }

        public bool IncreaseXp(int increaseAmount) {
            curXp = curXp + increaseAmount;

            if (curXp >= xPToNext) {
                LevelUp();
                return true;
            }

            return false;
        }

        private void LevelUp() {
            level++;
            curXp = curXp - xPToNext;
            xPToNext = (level * 100) / 2;
            health += 100;
            damage += 2;
        }
    }
}