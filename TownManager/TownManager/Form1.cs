using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TownManager {
    public partial class Form1 : Form {
        GameWorld gw;
        Graphics dc;

        int dungeonIndex;
        int deleteIndex;

        SaveLoad saveloadData = new SaveLoad();

        /// <summary>
        /// Form used in this program, sets the menu background image.
        /// </summary>
        public Form1() {
            InitializeComponent();

            pnlStartmenu.BackgroundImage = Image.FromFile("sprites/menuBackground.png");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void GameLoop_Tick(object sender, EventArgs e) {
            gw.GameLoop();
        }

        #region STARTMENU

        // New Game
        private void btnNewGame_Click(object sender, EventArgs e) {
            dc = CreateGraphics();

            GameWorld.SetRectangle(new Rectangle(0, 0, this.DisplayRectangle.Width, this.DisplayRectangle.Height));

            gw = new GameWorld(dc, this, -1);



            GameLoop.Enabled = true;

            pnlStartmenu.Visible = false;
            UpdateTooltips();
        }

        // Load Game
        private void btnStartmenuLoadGame_Click(object sender, EventArgs e) {
            ListOutSavedGames();

            btnNewGame.Enabled = false;
            btnStartmenuLoadGame.Enabled = false;
            btnStartmenuQuit.Enabled = false;

            btnLoadPanelLoadSave.Enabled = false;
            btnLoadPanelDeleteSave.Enabled = false;

            pnlLoadSave.Visible = true;
            pnlLoadSave.BringToFront();
        }

        private void lvSavesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvSavesList.SelectedItems.Count == 1) {
                deleteIndex = Convert.ToInt32(lvSavesList.SelectedItems[0].SubItems[0].Text);
            }
            if (lvSavesList.SelectedItems.Count == 1 && lvSavesList.SelectedItems[0].SubItems[0].Text != "") {
                btnLoadPanelLoadSave.Enabled = true;
                btnLoadPanelDeleteSave.Enabled = true;
            }
            else {
                btnLoadPanelLoadSave.Enabled = false;
                btnLoadPanelDeleteSave.Enabled = false;
            }
        }


        private void btnLoadPanelLoadSave_Click(object sender, EventArgs e) {
            dc = CreateGraphics();

            GameWorld.SetRectangle(new Rectangle(0, 0, this.DisplayRectangle.Width, this.DisplayRectangle.Height));

            gw = new GameWorld(dc, this, Convert.ToInt32(lvSavesList.SelectedItems[0].SubItems[0].Text));

            GameLoop.Enabled = true;

            pnlStartmenu.Visible = false;

            btnNewGame.Enabled = true;
            btnStartmenuLoadGame.Enabled = true;
            btnStartmenuQuit.Enabled = true;

            pnlLoadSave.Visible = false;


            UpdateAvailableHeros();
            UpdateCurrentGroups();
            UpdateGroupsToDungeon();
            UpdateTooltips();
        }

        private void btnLoadPanelDeleteSave_Click(object sender, EventArgs e) {
            saveloadData.DeleteSave(deleteIndex);
            ListOutSavedGames();
        }

        private void btnLoadPanelBack_Click(object sender, EventArgs e) {
            btnNewGame.Enabled = true;
            btnStartmenuLoadGame.Enabled = true;
            btnStartmenuQuit.Enabled = true;

            pnlLoadSave.Visible = false;
        }

        // Quit Game
        private void btnStartmenuQuit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        #endregion

        #region GAME MENU

        private void btnGroupManagement_Click(object sender, EventArgs e) {
            if (!pnlGroupCreation.Visible) {
                pnlGroupCreation.Visible = true;
            }
            else {
                pnlGroupCreation.Visible = false;
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e) {
            SaveGame();
        }

        private void btnSaveNQuit_Click(object sender, EventArgs e) {
            SaveGame();
            QuitGame();
        }

        private void btnGameQuit_Click(object sender, EventArgs e) {
            QuitGame();
        }

        public void SaveGame() {
            saveloadData._town = gw.town;
            saveloadData.SaveGame();
        }

        public void QuitGame() {
            GameLoop.Enabled = false;
            gw = null;
            dc = null;

            pnlStartmenu.Visible = true;
        }

        #endregion

        #region QUEST PANEL

        private void btnGroupToDungeon_Click(object sender, EventArgs e) {
            if (lvGroupToDungeonList.SelectedItems.Count == 1) {
                gw.town.Grouplist[Convert.ToInt32(lvGroupToDungeonList.SelectedItems[0].SubItems[4].Text)].SendToDungeon(dungeonIndex);
                UpdateGroupsToDungeon();
                lvGroupToDungeonList.SelectedItems.Clear();
            }


        }

        public void UpdateGroupsToDungeon() {
            lvGroupToDungeonList.Clear();

            lvGroupToDungeonList.Columns.Add("Group", 100);
            lvGroupToDungeonList.Columns.Add("Average Level", 100);
            lvGroupToDungeonList.Columns.Add("Damage", 65);
            lvGroupToDungeonList.Columns.Add("Health", 50);

            for (int i = 0; i < gw.town.Grouplist.Count; i++) {
                if (gw.town.Grouplist[i].Available) {
                    ListViewItem lvGroup;

                    int averageLevel = 0;
                    foreach (Hero hero in gw.town.Grouplist[i].GroupHero) {
                        averageLevel += hero.Level;
                    }

                    averageLevel = averageLevel / gw.town.Grouplist[i].GroupHero.Count;

                    lvGroup = new ListViewItem("Group " + (i + 1).ToString());
                    lvGroup.SubItems.Add(averageLevel.ToString());
                    lvGroup.SubItems.Add(gw.town.Grouplist[i].GroupDamage.ToString());
                    lvGroup.SubItems.Add(gw.town.Grouplist[i].GroupHp.ToString());
                    lvGroup.SubItems.Add(i.ToString());
                    lvGroupToDungeonList.Items.Add(lvGroup);
                }
            }
        }

        #endregion

        #region GROUP MANAGER PANEL

        private void btnCreateGroup_Click(object sender, EventArgs e) {
            List<int> heroListPos = new List<int>();

            for (int i = 0; i < lvHeroNotGrouped.Items.Count; i++) {
                if (lvHeroNotGrouped.Items[i].Checked) {
                    heroListPos.Add(Convert.ToInt32(lvHeroNotGrouped.Items[i].SubItems[3].Text.ToString()));
                }
            }

            if (heroListPos.Count > 0) {
                gw.town.CreateGroup(heroListPos);
            }
        }

        private void btnDisbandGroup_Click(object sender, EventArgs e) {
            List<int> groupListPos = new List<int>();

            for (int i = 0; i < lvHeroGroups.Items.Count; i++) {
                if (lvHeroGroups.Items[i].Checked) {
                    groupListPos.Add(Convert.ToInt32(lvHeroGroups.Items[i].SubItems[4].Text.ToString()));
                }
            }

            if (groupListPos.Count > 0) {
                gw.town.DisbandGroup(groupListPos);
            }

        }

        public void UpdateAvailableHeros() {
            lvHeroNotGrouped.Clear();

            lvHeroNotGrouped.Columns.Add("Hero", 200);
            lvHeroNotGrouped.Columns.Add("Lvl", 35);
            lvHeroNotGrouped.Columns.Add("XP", 50);
            lvHeroNotGrouped.CheckBoxes = true;

            for (int i = 0; i < gw.town.Herolist.Count; i++) {
                if (!gw.town.Herolist[i].InGroup) {
                    ListViewItem lvHero;

                    lvHero = new ListViewItem(gw.town.Herolist[i].FullName);
                    lvHero.Checked = false;
                    lvHero.SubItems.Add(gw.town.Herolist[i].Level.ToString());
                    lvHero.SubItems.Add(gw.town.Herolist[i].CurXp.ToString() + "/" + gw.town.Herolist[i].XPToNext.ToString());
                    lvHero.SubItems.Add(i.ToString());
                    lvHeroNotGrouped.Items.Add(lvHero);

                }
            }
        }

        public void UpdateCurrentGroups() {
            lvHeroGroups.Clear();

            lvHeroGroups.Columns.Add("Group", 100);
            lvHeroGroups.Columns.Add("Average Level", 100);
            lvHeroGroups.Columns.Add("Damage", 65);
            lvHeroGroups.Columns.Add("Health", 50);
            lvHeroGroups.CheckBoxes = true;

            for (int i = 0; i < gw.town.Grouplist.Count; i++) {
                if (gw.town.Grouplist[i].Available) {
                    ListViewItem lvGroup;

                    int averageLevel = 0;
                    foreach (Hero hero in gw.town.Grouplist[i].GroupHero) {
                        averageLevel += hero.Level;
                    }

                    averageLevel = averageLevel / gw.town.Grouplist[i].GroupHero.Count;

                    lvGroup = new ListViewItem("Group " + (i + 1).ToString());
                    lvGroup.Checked = false;
                    lvGroup.SubItems.Add(averageLevel.ToString());
                    lvGroup.SubItems.Add(gw.town.Grouplist[i].GroupDamage.ToString());
                    lvGroup.SubItems.Add(gw.town.Grouplist[i].GroupHp.ToString());
                    lvGroup.SubItems.Add(i.ToString());
                    lvHeroGroups.Items.Add(lvGroup);

                }
            }
        }

        #endregion

        private void lvHeroNotGrouped_SelectedIndexChanged(object sender, EventArgs e) {

            if (lvHeroNotGrouped.SelectedItems.Count == 1) {
                if (lvHeroNotGrouped.SelectedItems[0].Checked) {
                    lvHeroNotGrouped.SelectedItems[0].Checked = false;
                }
                else {
                    lvHeroNotGrouped.SelectedItems[0].Checked = true;
                }

                //foreach (ListViewItem i in lvHeroNotGrouped.Items)
                //{
                //    if (!i.Checked)
                //    {
                //        i.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
                //        i.BackColor = Color.FromKnownColor(KnownColor.Transparent);
                //    }
                //    else
                //    {
                //        i.ForeColor = Color.FromKnownColor(KnownColor.HighlightText);
                //        i.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                //    }
                //}
            }

            //lvHeroNotGrouped.SelectedItems.Clear();
        }


        #region CUSTOM METHODS


        public void ListOutSavedGames() {
            DataTable dt = new DataTable();

            dt = saveloadData.GetSavedGames();

            lvSavesList.Clear();

            lvSavesList.Columns.Add("#", 50);
            lvSavesList.Columns.Add("Town Name", 300);
            lvSavesList.Columns.Add("Creation Date", 300);

            if (dt.Rows.Count > 0) {
                lvSavesList.HideSelection = false;
                for (int i = 0; i < dt.Rows.Count; i++) {
                    ListViewItem lvSaves;

                    lvSaves = new ListViewItem(dt.Rows[i]["fldID"].ToString());
                    lvSaves.SubItems.Add((dt.Rows[i]["fldName"]).ToString());
                    lvSaves.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    lvSavesList.Items.Add(lvSaves);

                }
            }
            else {
                lvSavesList.HideSelection = true;

                ListViewItem lvSaves;

                lvSaves = new ListViewItem("");
                lvSaves.SubItems.Add("No Saves!");
                lvSavesList.Items.Add(lvSaves);
            }

            lvSavesList.SelectedItems.Clear();

        }

        public void ListOutDungeons() {
            lvQuestView.Clear();

            lvQuestView.Columns.Add("Type", 60);
            lvQuestView.Columns.Add("Lvl", 35);
            lvQuestView.Columns.Add("Xp", 30);
            lvQuestView.Columns.Add("Gold", 40);
            lvQuestView.Columns.Add("Expire", 120);
            //lvQuestView.Columns.Add("ID", 25);

            int i = 0;
            foreach (Dungeon d in gw.town.DungeonList) {
                ListViewItem lvDungeons;
                lvDungeons = new ListViewItem(d.Type.ToString());
                lvDungeons.SubItems.Add(d.Level.ToString());
                lvDungeons.SubItems.Add(d.XPReward.ToString());
                lvDungeons.SubItems.Add(d.GoldReward.ToString());
                lvDungeons.SubItems.Add(d.Expire.ToString());
                lvDungeons.SubItems.Add(i.ToString());

                lvQuestView.Items.Add(lvDungeons);
                i++;
            }

        }

        private void lvQuestView_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvQuestView.SelectedItems.Count == 1) {
                dungeonIndex = Convert.ToInt32(lvQuestView.SelectedItems[0].SubItems[5].Text);
            }
        }


        #endregion


        private void btnGate_Click(object sender, EventArgs e) {
            if (!pnlSendGroupToDungeon.Visible) {
                pnlSendGroupToDungeon.Visible = true;
            }
            else {
                pnlSendGroupToDungeon.Visible = false;
            }
        }

        private void btnCloseQuestPanel_Click(object sender, EventArgs e) {
            pnlSendGroupToDungeon.Visible = false;
        }

        private void btnCloseGroupManager_Click(object sender, EventArgs e) {
            pnlGroupCreation.Visible = false;
        }

        private void btnTownHall_Click(object sender, EventArgs e) {
            if (!pnlTownHall.Visible) {
                pnlTownHall.Visible = true;
            }
            else {
                pnlTownHall.Visible = false;
            }
            if (gw.town.Logs.Count > 0) {
                btnCombatLogTownHall.Enabled = true;
                btnCombatLogTownHall.Text = "View Logs";
            }
        }

        private void btnTownHallClose_Click(object sender, EventArgs e) {
            pnlTownHall.Visible = false;
            pnlListOfLogs.Visible = false;
        }

        #region UPGRADE BUTTONS

        private void btnUpgradeInn_Click(object sender, EventArgs e) {
            int innValue = gw.town.InnLevel * 100;
            bool buyAble = gw.town.UseGold(innValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.Inn);
                innValue = gw.town.InnLevel * 100;
                UpdatePrices(innValue);
            }
        }

        private void btnUpgradeInfirmary_Click(object sender, EventArgs e) {
            int infirmaryValue = gw.town.InfimaryLevel * 100;
            bool buyAble = gw.town.UseGold(infirmaryValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.Infirmary);
                infirmaryValue = gw.town.InfimaryLevel * 100;
                UpdatePrices(infirmaryValue);
            }
        }

        private void btnUpgradeStorage_Click(object sender, EventArgs e) {
            int storageValue = gw.town.StorageLevel * 100;
            bool buyAble = gw.town.UseGold(storageValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.Storage);
                storageValue = gw.town.StorageLevel * 100;
                UpdatePrices(storageValue);
            }
        }

        private void btnUpgradeTownHall_Click(object sender, EventArgs e) {
            int townHallValue = gw.town.TownHallLevel * 100;
            bool buyAble = gw.town.UseGold(townHallValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.TownHall);
                townHallValue = gw.town.TownHallLevel * 100;
                UpdatePrices(townHallValue);
            }
        }

        private void btnUpgradeBarrack_Click(object sender, EventArgs e) {
            int barrackValue = gw.town.BarrackLevel * 100;
            bool buyAble = gw.town.UseGold(barrackValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.Barrack);
                barrackValue = gw.town.BarrackLevel * 100;
                UpdatePrices(barrackValue);
            }
        }

        private void btnUpgradeArcheryRange_Click(object sender, EventArgs e) {
            int archeryValue = gw.town.ArcheryRangeLevel * 100;
            bool buyAble = gw.town.UseGold(archeryValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.ArcheryRange);
                archeryValue = gw.town.ArcheryRangeLevel * 100;
                UpdatePrices(archeryValue);
            }
        }

        private void btnUpgradeSanctum_Click(object sender, EventArgs e) {
            int sanctumValue = gw.town.SanctumLevel * 100;
            bool buyAble = gw.town.UseGold(sanctumValue);

            if (buyAble) {
                gw.town.UpgradeBuilding(BuildingType.Sanctum);
                sanctumValue = gw.town.SanctumLevel * 100;
                UpdatePrices(sanctumValue);
            }
        }

        private void btnCombatLogTownHall_Click(object sender, EventArgs e) {
            lvCombatLogs.FullRowSelect = true;
            if (!pnlListOfLogs.Visible) {
                pnlListOfLogs.Visible = true;
                UpdateCombatLog();
            }
            else {
                pnlListOfLogs.Visible = false;
            }

            if (lvCombatLogs.Items.Count > 0) {
                lvCombatLogs.Items[0].Selected = true;
                lvCombatLogs.Select();
            }

            UpdateTooltips();
        }

        private void btnCloseCombatLogPanel_Click(object sender, EventArgs e) {
            pnlCombatLog.Visible = false;
        }


        private void btnCombatLogsClose_Click(object sender, EventArgs e) {
            pnlListOfLogs.Visible = false;
        }


        private void btnSelectLog_Click(object sender, EventArgs e) {
            //int index = lvCombatLogs.SelectedItems[0].Index;

            txtMessageLog.Text = gw.town.Logs[lvCombatLogs.SelectedItems[0].Index];
            btnSelectLog.Enabled = false;
            UpdateCombatLog();
            pnlCombatLog.Visible = true;
        }

        public void UpdateCombatLog() {
            lvCombatLogs.Clear();
            lvCombatLogs.Columns.Add("ID", lvCombatLogs.Width);

            int i = 1;
            foreach (string log in gw.town.Logs) {
                ListViewItem lvLogs;
                lvLogs = new ListViewItem("Log " + i.ToString());

                lvCombatLogs.Items.Add(lvLogs);
                i++;
            }
        }

        public void UpdatePrices(int price) {
            UpdateTooltips();
        }

        #endregion


        public void UpdateTooltips() {
            ttUpgradeBuildings.SetToolTip(btnUpgradeInn, "Level: " + gw.town.InnLevel + " -> " + (gw.town.InnLevel + 1) + "\nMax heroes: " + gw.town.InnLevel * 5 + " -> " + ((gw.town.InnLevel + 1) * 5) + "\nCost: " + gw.town.InnLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeInfirmary, "Cost: " + gw.town.InfimaryLevel * 100 + "\n" + "");
            ttUpgradeBuildings.SetToolTip(btnUpgradeStorage, "Cost: " + gw.town.StorageLevel * 100 + "\n" + "Max storage: " + gw.town.StorageLevel * 100 + " -> " + ((gw.town.StorageLevel + 1)) * 5);
            ttUpgradeBuildings.SetToolTip(btnUpgradeTownHall, "Cost: " + gw.town.TownHallLevel * 100 + "\n" + "Its coming");
            ttUpgradeBuildings.SetToolTip(btnUpgradeBarrack, "Cost: " + gw.town.BarrackLevel * 100 + "\n" + "Damage increase: " + gw.town.BarrackLevel * 5 + " -> " + (gw.town.BarrackLevel + 1) * 5);
            ttUpgradeBuildings.SetToolTip(btnUpgradeArcheryRange, "Cost: " + gw.town.ArcheryRangeLevel * 100 + "\n" + "Damage increase: " + gw.town.ArcheryRangeLevel * 5 + " -> " + (gw.town.ArcheryRangeLevel + 1) * 5);
            ttUpgradeBuildings.SetToolTip(btnUpgradeSanctum, "Cost: " + gw.town.SanctumLevel * 100 + "\n" + "Health increase: " + gw.town.SanctumLevel * 5 + " -> " + (gw.town.SanctumLevel + 1) * 5);


            ttUpgradeBuildings.SetToolTip(btnUpgradeInn, "Level: " + gw.town.InnLevel + " -> " + (gw.town.InnLevel + 1) + "\nHeroes In Town: " + gw.town.InnLevel * 5 + " -> " + ((gw.town.InnLevel + 1) * 5) + "\nCost: " + gw.town.InnLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeInfirmary, "Level: " + gw.town.InfimaryLevel + " -> " + (gw.town.InfimaryLevel + 1) + "\n+Hero Max HP: (Future Update) \nCost: " + gw.town.InfimaryLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeStorage, "Level: " + gw.town.StorageLevel + " -> " + (gw.town.StorageLevel + 1) + "\nMax Stored Gold: " + ((gw.town.StorageLevel * 1000 + 500) + " -> " + (((gw.town.StorageLevel + 1) * 1000) + 500)) + "\nCost: " + gw.town.StorageLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeTownHall, "Level: " + gw.town.TownHallLevel + " -> " + (gw.town.TownHallLevel + 1) + "\n(Future Update) \nCost: " + gw.town.TownHallLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeBarrack, "Level: " + gw.town.BarrackLevel + " -> " + (gw.town.BarrackLevel + 1) + "\n+Hero Melee Damage: (Future Update) \nCost: " + gw.town.BarrackLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeArcheryRange, "Level: " + gw.town.ArcheryRangeLevel + " -> " + (gw.town.ArcheryRangeLevel + 1) + "\n+Hero Ranged Damage: (Future Update) \nCost: " + gw.town.ArcheryRangeLevel * 100);
            ttUpgradeBuildings.SetToolTip(btnUpgradeSanctum, "Level: " + gw.town.SanctumLevel + " -> " + (gw.town.SanctumLevel + 1) + "\n+Hero Magic Damage: (Future Update) \nCost: " + gw.town.SanctumLevel * 100);
        }

        private void lvCombatLogs_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvCombatLogs.SelectedItems.Count == 1) {
                btnSelectLog.Enabled = true;
            }
            else {
                btnSelectLog.Enabled = false;
            }
        }
    }
}