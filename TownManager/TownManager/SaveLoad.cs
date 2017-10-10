using System;
using System.Data;
using System.Data.SQLite;

namespace TownManager {
    class SaveLoad {
        DataTable dt;

        public Town _town { get; set; }

        dbDataAccess db = new dbDataAccess();

        #region SAVE GAME

        public void SaveGame() {
            SaveTown();
            SaveHeroes();
            SaveHeroGroups();
            SaveCombatLogs();

        }

        public void SaveTown() {
            string sql;

            if (_town.TownID < 0) {
                sql = "INSERT INTO tbltown (fldName, fldCreationDate) VALUES (@townName, datetime('now', 'localtime')); SELECT last_insert_rowid();";

                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Parameters.AddWithValue("@townName", _town.TownName);

                _town.TownID = db.GetScalarData(cmd);
            }
            if (_town.TownID >= 0) {
                sql = "UPDATE tbltown SET fldTownHallLevel = @townHallLevel, fldStorageLevel = @storageLevel, fldInfirmaryLevel = @infirmaryLevel, fldInnLevel = @innLevel, fldBarrackLevel = @barrackLevel, fldSanctumLevel = @sanctumLevel, fldArcheryLevel = @archeryLevel, fldGoldAmount = @gold WHERE fldID = @townID";

                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Parameters.AddWithValue("@townID", _town.TownID);
                cmd.Parameters.AddWithValue("@townHallLevel", _town.TownHallLevel);
                cmd.Parameters.AddWithValue("@storageLevel", _town.StorageLevel);
                cmd.Parameters.AddWithValue("@infirmaryLevel", _town.InfimaryLevel);
                cmd.Parameters.AddWithValue("@innLevel", _town.InnLevel);
                cmd.Parameters.AddWithValue("@barrackLevel", _town.BarrackLevel);
                cmd.Parameters.AddWithValue("@sanctumLevel", _town.SanctumLevel);
                cmd.Parameters.AddWithValue("@archeryLevel", _town.ArcheryRangeLevel);
                cmd.Parameters.AddWithValue("@gold", _town.CurrentGold);

                db.ModifyData(cmd);
            }

        }
        public void SaveHeroes() {
            string sql;

            sql = "DELETE FROM tblhero WHERE fldTownID=@townID";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            db.ModifyData(cmd);

            foreach (Hero hero in _town.Herolist) {
                sql = "INSERT INTO tblhero (fldTownID, fldFirstname, fldLastname, fldLevel, fldHealth, fldDamage, fldCurrentExp) VALUES (@townID, @firstname, @lastname, @level, @health, @damage, @exp); SELECT last_insert_rowid();";

                cmd = new SQLiteCommand(sql);
                cmd.Parameters.AddWithValue("@townID", _town.TownID);
                cmd.Parameters.AddWithValue("@firstname", hero.FirstName);
                cmd.Parameters.AddWithValue("@lastname", hero.LastName);
                cmd.Parameters.AddWithValue("@level", hero.Level);
                cmd.Parameters.AddWithValue("@health", hero.Health);
                cmd.Parameters.AddWithValue("@damage", hero.Damage);
                cmd.Parameters.AddWithValue("@exp", hero.CurXp);

                hero.HeroID = db.GetScalarData(cmd);
            }
        }
        public void SaveHeroGroups() {
            string sql;

            sql = "DELETE FROM tblgroup WHERE fldTownID=@townID; DELETE FROM tblheroesingroup WHERE fldTownID=@townID;";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            db.ModifyData(cmd);

            sql = "";

            foreach (Group g in _town.Grouplist) {
                if (!g.Available) {
                    TimeSpan deltaTime = g.HomeWhen - DateTime.Now;
                    g.TimeTillHome = Convert.ToInt32(deltaTime.TotalSeconds);
                }

                sql = "INSERT INTO tblgroup (fldTownID, fldOnQuest, fldAvailable, fldTimeTillHome, fldTempLog) VALUES (@townID, @onQuest, @available, @timeTillHome, @log); SELECT last_insert_rowid();";

                cmd = new SQLiteCommand(sql);
                cmd.Parameters.AddWithValue("@townID", _town.TownID);
                cmd.Parameters.AddWithValue("@onQuest", g.OnQuest);
                cmd.Parameters.AddWithValue("@available", g.Available);
                cmd.Parameters.AddWithValue("@timeTillHome", g.TimeTillHome);
                cmd.Parameters.AddWithValue("@log", g.Log);

                g.GroupID = db.GetScalarData(cmd);

                foreach (Hero h in g.GroupHero) {
                    sql = "INSERT INTO tblheroesingroup (fldTownID, fldHeroID, fldGroupID) VALUES (@townID, @heroID, @groupID);";

                    cmd = new SQLiteCommand(sql);
                    cmd.Parameters.AddWithValue("@townID", _town.TownID);
                    cmd.Parameters.AddWithValue("@heroID", h.HeroID);
                    cmd.Parameters.AddWithValue("@groupID", g.GroupID);

                    db.ModifyData(cmd);
                }
            }
        }
        public void SaveCombatLogs() {
            string sql;

            sql = "DELETE FROM tblcombatlog WHERE fldTownID=@townID;";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            db.ModifyData(cmd);

            sql = "";

            foreach (string log in _town.Logs) {
                sql = "INSERT INTO tblcombatlog (fldTownID, fldTextLog) VALUES (@townID, @textLog);";

                cmd = new SQLiteCommand(sql);
                cmd.Parameters.AddWithValue("@townID", _town.TownID);
                cmd.Parameters.AddWithValue("@textLog", log);

                db.ModifyData(cmd);
            }
        }

        #endregion

        #region LOAD GAME

        public DataTable GetSavedGames() {
            string sql = "SELECT fldID, fldName, strftime('%d-%m-%Y %H:%M', fldCreationDate) AS Date FROM tbltown ORDER BY fldID DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            return db.GetData(cmd);
        }

        public void LoadSave() {
            LoadTown();
            LoadHeroes();
            LoadHeroGroups();
            LoadCombatLogs();
        }

        public void LoadTown() {
            string sql = "SELECT * FROM tbltown WHERE fldID = @townID";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            dt = db.GetData(cmd);

            if (dt.Rows.Count == 1) {
                _town.TownName = dt.Rows[0]["fldName"].ToString();
                _town.TownHallLevel = Convert.ToByte(dt.Rows[0]["fldTownHallLevel"].ToString());
                _town.StorageLevel = Convert.ToByte(dt.Rows[0]["fldStorageLevel"].ToString());
                _town.InfimaryLevel = Convert.ToByte(dt.Rows[0]["fldInfirmaryLevel"].ToString());
                _town.InnLevel = Convert.ToByte(dt.Rows[0]["fldInnLevel"].ToString());
                _town.BarrackLevel = Convert.ToByte(dt.Rows[0]["fldBarrackLevel"].ToString());
                _town.SanctumLevel = Convert.ToByte(dt.Rows[0]["fldSanctumLevel"].ToString());
                _town.ArcheryRangeLevel = Convert.ToByte(dt.Rows[0]["fldArcheryLevel"].ToString());
                _town.CurrentGold = Convert.ToInt32(dt.Rows[0]["fldGoldAmount"].ToString());
            }
        }
        public void LoadHeroes() {
            string sql = "SELECT * FROM tblHero WHERE fldTownID = @townID";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            dt = db.GetData(cmd);

            if (dt.Rows.Count > 0) {
                foreach (DataRow row in dt.Rows) {
                    _town.Herolist.Add(new Hero(Convert.ToInt32(row["fldID"].ToString()), row["fldFirstname"].ToString(), row["fldLastname"].ToString(), Convert.ToInt32(row["fldLevel"].ToString()), Convert.ToInt32(row["fldHealth"].ToString()), Convert.ToInt32(row["fldDamage"].ToString()), Convert.ToInt32(row["fldCurrentExp"].ToString())));
                }
            }
        }
        public void LoadHeroGroups() {
            string sql = "SELECT * FROM tblGroup WHERE fldTownID = @townID";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            dt = db.GetData(cmd);

            if (dt.Rows.Count > 0) {
                foreach (DataRow group in dt.Rows) {
                    _town.Grouplist.Add(new Group(Convert.ToInt32(group["fldID"].ToString()), Convert.ToBoolean(Convert.ToInt16(group["fldOnQuest"].ToString())), Convert.ToBoolean(Convert.ToInt16(group["fldAvailable"].ToString())), Convert.ToInt32(group["fldTimeTillHome"].ToString()), group["fldTempLog"].ToString(), _town));
                }

                foreach (Group group in _town.Grouplist) {
                    sql = "SELECT * FROM tblHeroesInGroup WHERE fldTownID = @townID AND fldGroupID = @groupID";
                    cmd = new SQLiteCommand(sql);
                    cmd.Parameters.AddWithValue("@townID", _town.TownID);
                    cmd.Parameters.AddWithValue("@groupID", group.GroupID);

                    dt = db.GetData(cmd);

                    foreach (DataRow rel in dt.Rows) {
                        foreach (Hero hero in _town.Herolist) {
                            if (hero.HeroID == Convert.ToInt32(rel["fldHeroID"].ToString())) {
                                hero.InGroup = true;
                                group.GroupHero.Add(hero);
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void LoadCombatLogs() {
            string sql = "SELECT * FROM tblCombatLog WHERE fldTownID = @townID";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@townID", _town.TownID);

            dt = db.GetData(cmd);

            if (dt.Rows.Count > 0) {
                foreach (DataRow row in dt.Rows) {
                    string log = row["fldTextLog"].ToString();

                    _town.Logs.Add(log);
                }
            }
        }

        #endregion
        
        #region DELETE SAVE

        public void DeleteSave(int deleteIndex) {
            DeleteTown(deleteIndex);
            DeleteHeroes(deleteIndex);
            DeleteHeroGroups(deleteIndex);
            DeleteCombatLogs(deleteIndex);
        }

        public void DeleteTown(int deleteIndex) {
            string sql = "DELETE FROM tbltown WHERE fldID = @deleteID";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@deleteID", deleteIndex);

            db.ModifyData(cmd);
        }
        public void DeleteHeroes(int deleteIndex) {
            string sql = "DELETE FROM tblhero WHERE fldTownID = @deleteID";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@deleteID", deleteIndex);

            db.ModifyData(cmd);
        }
        public void DeleteHeroGroups(int deleteIndex) {
            string sql = "DELETE FROM tblgroup WHERE fldTownID = @deleteID; DELETE FROM tblheroesingroup WHERE fldTownID = @deleteID";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@deleteID", deleteIndex);

            db.ModifyData(cmd);
        }
        public void DeleteCombatLogs(int deleteIndex) {
            string sql = "DELETE FROM tblcombatlog WHERE fldTownID = @deleteID";

            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.AddWithValue("@deleteID", deleteIndex);

            db.ModifyData(cmd);
        }

        #endregion

    }
}