namespace TownManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.txtMessageLog = new System.Windows.Forms.TextBox();
            this.btnGroupToDungeon = new System.Windows.Forms.Button();
            this.lvGroupToDungeonList = new System.Windows.Forms.ListView();
            this.pnlSendGroupToDungeon = new System.Windows.Forms.Panel();
            this.btnCloseQuestPanel = new System.Windows.Forms.Button();
            this.lvQuestView = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlGroupCreation = new System.Windows.Forms.Panel();
            this.btnCloseGroupManager = new System.Windows.Forms.Button();
            this.btnDisbandGroup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvHeroGroups = new System.Windows.Forms.ListView();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.lvHeroNotGrouped = new System.Windows.Forms.ListView();
            this.btnGroupManagement = new System.Windows.Forms.Button();
            this.pnlCombatLog = new System.Windows.Forms.Panel();
            this.btnCloseCombatLogPanel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnGameQuit = new System.Windows.Forms.Button();
            this.btnSaveNQuit = new System.Windows.Forms.Button();
            this.pnlLoadSave = new System.Windows.Forms.Panel();
            this.btnLoadPanelBack = new System.Windows.Forms.Button();
            this.btnLoadPanelLoadSave = new System.Windows.Forms.Button();
            this.btnLoadPanelDeleteSave = new System.Windows.Forms.Button();
            this.lvSavesList = new System.Windows.Forms.ListView();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnStartmenuLoadGame = new System.Windows.Forms.Button();
            this.btnStartmenuQuit = new System.Windows.Forms.Button();
            this.pnlStartmenu = new System.Windows.Forms.Panel();
            this.btnGate = new System.Windows.Forms.Button();
            this.btnUpgradeSanctum = new System.Windows.Forms.Button();
            this.btnUpgradeArcheryRange = new System.Windows.Forms.Button();
            this.btnUpgradeTownHall = new System.Windows.Forms.Button();
            this.btnUpgradeBarrack = new System.Windows.Forms.Button();
            this.btnUpgradeStorage = new System.Windows.Forms.Button();
            this.btnUpgradeInfirmary = new System.Windows.Forms.Button();
            this.btnUpgradeInn = new System.Windows.Forms.Button();
            this.btnTownHall = new System.Windows.Forms.Button();
            this.pnlTownHall = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCombatLogTownHall = new System.Windows.Forms.Button();
            this.btnTownHallClose = new System.Windows.Forms.Button();
            this.ttUpgradeBuildings = new System.Windows.Forms.ToolTip(this.components);
            this.pnlListOfLogs = new System.Windows.Forms.Panel();
            this.btnSelectLog = new System.Windows.Forms.Button();
            this.lvCombatLogs = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCombatLogsClose = new System.Windows.Forms.Button();
            this.pnlSendGroupToDungeon.SuspendLayout();
            this.pnlGroupCreation.SuspendLayout();
            this.pnlCombatLog.SuspendLayout();
            this.pnlLoadSave.SuspendLayout();
            this.pnlStartmenu.SuspendLayout();
            this.pnlTownHall.SuspendLayout();
            this.pnlListOfLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Interval = 1;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // txtMessageLog
            // 
            this.txtMessageLog.Location = new System.Drawing.Point(3, 33);
            this.txtMessageLog.Multiline = true;
            this.txtMessageLog.Name = "txtMessageLog";
            this.txtMessageLog.ReadOnly = true;
            this.txtMessageLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageLog.Size = new System.Drawing.Size(308, 529);
            this.txtMessageLog.TabIndex = 0;
            // 
            // btnGroupToDungeon
            // 
            this.btnGroupToDungeon.Location = new System.Drawing.Point(3, 412);
            this.btnGroupToDungeon.Name = "btnGroupToDungeon";
            this.btnGroupToDungeon.Size = new System.Drawing.Size(353, 55);
            this.btnGroupToDungeon.TabIndex = 1;
            this.btnGroupToDungeon.Text = "Send On Quest!";
            this.btnGroupToDungeon.UseVisualStyleBackColor = true;
            this.btnGroupToDungeon.Click += new System.EventHandler(this.btnGroupToDungeon_Click);
            // 
            // lvGroupToDungeonList
            // 
            this.lvGroupToDungeonList.FullRowSelect = true;
            this.lvGroupToDungeonList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGroupToDungeonList.HideSelection = false;
            this.lvGroupToDungeonList.Location = new System.Drawing.Point(3, 47);
            this.lvGroupToDungeonList.MultiSelect = false;
            this.lvGroupToDungeonList.Name = "lvGroupToDungeonList";
            this.lvGroupToDungeonList.Size = new System.Drawing.Size(353, 183);
            this.lvGroupToDungeonList.TabIndex = 2;
            this.lvGroupToDungeonList.UseCompatibleStateImageBehavior = false;
            this.lvGroupToDungeonList.View = System.Windows.Forms.View.Details;
            // 
            // pnlSendGroupToDungeon
            // 
            this.pnlSendGroupToDungeon.Controls.Add(this.btnCloseQuestPanel);
            this.pnlSendGroupToDungeon.Controls.Add(this.lvQuestView);
            this.pnlSendGroupToDungeon.Controls.Add(this.label11);
            this.pnlSendGroupToDungeon.Controls.Add(this.label9);
            this.pnlSendGroupToDungeon.Controls.Add(this.label6);
            this.pnlSendGroupToDungeon.Controls.Add(this.btnGroupToDungeon);
            this.pnlSendGroupToDungeon.Controls.Add(this.lvGroupToDungeonList);
            this.pnlSendGroupToDungeon.Location = new System.Drawing.Point(106, 7);
            this.pnlSendGroupToDungeon.Name = "pnlSendGroupToDungeon";
            this.pnlSendGroupToDungeon.Size = new System.Drawing.Size(359, 469);
            this.pnlSendGroupToDungeon.TabIndex = 3;
            this.pnlSendGroupToDungeon.Visible = false;
            // 
            // btnCloseQuestPanel
            // 
            this.btnCloseQuestPanel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseQuestPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseQuestPanel.ForeColor = System.Drawing.Color.Red;
            this.btnCloseQuestPanel.Location = new System.Drawing.Point(328, 5);
            this.btnCloseQuestPanel.Name = "btnCloseQuestPanel";
            this.btnCloseQuestPanel.Size = new System.Drawing.Size(28, 23);
            this.btnCloseQuestPanel.TabIndex = 3;
            this.btnCloseQuestPanel.Text = "X";
            this.btnCloseQuestPanel.UseVisualStyleBackColor = false;
            this.btnCloseQuestPanel.Click += new System.EventHandler(this.btnCloseQuestPanel_Click);
            // 
            // lvQuestView
            // 
            this.lvQuestView.FullRowSelect = true;
            this.lvQuestView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvQuestView.HideSelection = false;
            this.lvQuestView.Location = new System.Drawing.Point(3, 258);
            this.lvQuestView.MultiSelect = false;
            this.lvQuestView.Name = "lvQuestView";
            this.lvQuestView.Size = new System.Drawing.Size(353, 148);
            this.lvQuestView.TabIndex = 2;
            this.lvQuestView.UseCompatibleStateImageBehavior = false;
            this.lvQuestView.View = System.Windows.Forms.View.Details;
            this.lvQuestView.SelectedIndexChanged += new System.EventHandler(this.lvQuestView_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Available Dungeons";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Groups";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "Quests";
            // 
            // pnlGroupCreation
            // 
            this.pnlGroupCreation.Controls.Add(this.btnCloseGroupManager);
            this.pnlGroupCreation.Controls.Add(this.btnDisbandGroup);
            this.pnlGroupCreation.Controls.Add(this.label10);
            this.pnlGroupCreation.Controls.Add(this.label8);
            this.pnlGroupCreation.Controls.Add(this.label7);
            this.pnlGroupCreation.Controls.Add(this.lvHeroGroups);
            this.pnlGroupCreation.Controls.Add(this.btnCreateGroup);
            this.pnlGroupCreation.Controls.Add(this.lvHeroNotGrouped);
            this.pnlGroupCreation.Location = new System.Drawing.Point(332, 12);
            this.pnlGroupCreation.Name = "pnlGroupCreation";
            this.pnlGroupCreation.Size = new System.Drawing.Size(351, 467);
            this.pnlGroupCreation.TabIndex = 4;
            this.pnlGroupCreation.Visible = false;
            // 
            // btnCloseGroupManager
            // 
            this.btnCloseGroupManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseGroupManager.ForeColor = System.Drawing.Color.Red;
            this.btnCloseGroupManager.Location = new System.Drawing.Point(321, 1);
            this.btnCloseGroupManager.Name = "btnCloseGroupManager";
            this.btnCloseGroupManager.Size = new System.Drawing.Size(26, 24);
            this.btnCloseGroupManager.TabIndex = 4;
            this.btnCloseGroupManager.Text = "X";
            this.btnCloseGroupManager.UseVisualStyleBackColor = true;
            this.btnCloseGroupManager.Click += new System.EventHandler(this.btnCloseGroupManager_Click);
            // 
            // btnDisbandGroup
            // 
            this.btnDisbandGroup.Location = new System.Drawing.Point(3, 429);
            this.btnDisbandGroup.Name = "btnDisbandGroup";
            this.btnDisbandGroup.Size = new System.Drawing.Size(345, 34);
            this.btnDisbandGroup.TabIndex = 3;
            this.btnDisbandGroup.Text = "Disband Group";
            this.btnDisbandGroup.UseVisualStyleBackColor = true;
            this.btnDisbandGroup.Click += new System.EventHandler(this.btnDisbandGroup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Groups";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Heroes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Group Management";
            // 
            // lvHeroGroups
            // 
            this.lvHeroGroups.FullRowSelect = true;
            this.lvHeroGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHeroGroups.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvHeroGroups.Location = new System.Drawing.Point(3, 289);
            this.lvHeroGroups.MultiSelect = false;
            this.lvHeroGroups.Name = "lvHeroGroups";
            this.lvHeroGroups.Size = new System.Drawing.Size(345, 134);
            this.lvHeroGroups.TabIndex = 2;
            this.lvHeroGroups.UseCompatibleStateImageBehavior = false;
            this.lvHeroGroups.View = System.Windows.Forms.View.Details;
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(3, 234);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(345, 34);
            this.btnCreateGroup.TabIndex = 1;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // lvHeroNotGrouped
            // 
            this.lvHeroNotGrouped.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvHeroNotGrouped.FullRowSelect = true;
            this.lvHeroNotGrouped.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHeroNotGrouped.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvHeroNotGrouped.LabelWrap = false;
            this.lvHeroNotGrouped.Location = new System.Drawing.Point(3, 50);
            this.lvHeroNotGrouped.MultiSelect = false;
            this.lvHeroNotGrouped.Name = "lvHeroNotGrouped";
            this.lvHeroNotGrouped.Size = new System.Drawing.Size(345, 178);
            this.lvHeroNotGrouped.TabIndex = 0;
            this.lvHeroNotGrouped.UseCompatibleStateImageBehavior = false;
            this.lvHeroNotGrouped.View = System.Windows.Forms.View.Details;
            this.lvHeroNotGrouped.SelectedIndexChanged += new System.EventHandler(this.lvHeroNotGrouped_SelectedIndexChanged);
            // 
            // btnGroupManagement
            // 
            this.btnGroupManagement.BackColor = System.Drawing.Color.DarkViolet;
            this.btnGroupManagement.FlatAppearance.BorderSize = 2;
            this.btnGroupManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupManagement.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGroupManagement.Location = new System.Drawing.Point(479, 233);
            this.btnGroupManagement.Name = "btnGroupManagement";
            this.btnGroupManagement.Size = new System.Drawing.Size(48, 30);
            this.btnGroupManagement.TabIndex = 5;
            this.btnGroupManagement.Text = "Inn";
            this.btnGroupManagement.UseVisualStyleBackColor = false;
            this.btnGroupManagement.Click += new System.EventHandler(this.btnGroupManagement_Click);
            // 
            // pnlCombatLog
            // 
            this.pnlCombatLog.Controls.Add(this.btnCloseCombatLogPanel);
            this.pnlCombatLog.Controls.Add(this.txtMessageLog);
            this.pnlCombatLog.Controls.Add(this.label5);
            this.pnlCombatLog.Location = new System.Drawing.Point(1031, 158);
            this.pnlCombatLog.Name = "pnlCombatLog";
            this.pnlCombatLog.Size = new System.Drawing.Size(313, 565);
            this.pnlCombatLog.TabIndex = 6;
            this.pnlCombatLog.Visible = false;
            // 
            // btnCloseCombatLogPanel
            // 
            this.btnCloseCombatLogPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseCombatLogPanel.ForeColor = System.Drawing.Color.Red;
            this.btnCloseCombatLogPanel.Location = new System.Drawing.Point(289, 2);
            this.btnCloseCombatLogPanel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseCombatLogPanel.Name = "btnCloseCombatLogPanel";
            this.btnCloseCombatLogPanel.Size = new System.Drawing.Size(22, 23);
            this.btnCloseCombatLogPanel.TabIndex = 1;
            this.btnCloseCombatLogPanel.Text = "X";
            this.btnCloseCombatLogPanel.UseVisualStyleBackColor = true;
            this.btnCloseCombatLogPanel.Click += new System.EventHandler(this.btnCloseCombatLogPanel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Combat Log";
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(1202, 12);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(136, 23);
            this.btnSaveGame.TabIndex = 1;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnGameQuit
            // 
            this.btnGameQuit.Location = new System.Drawing.Point(1202, 73);
            this.btnGameQuit.Name = "btnGameQuit";
            this.btnGameQuit.Size = new System.Drawing.Size(136, 23);
            this.btnGameQuit.TabIndex = 7;
            this.btnGameQuit.Text = "Just Quit";
            this.btnGameQuit.UseVisualStyleBackColor = true;
            this.btnGameQuit.Click += new System.EventHandler(this.btnGameQuit_Click);
            // 
            // btnSaveNQuit
            // 
            this.btnSaveNQuit.Location = new System.Drawing.Point(1202, 44);
            this.btnSaveNQuit.Name = "btnSaveNQuit";
            this.btnSaveNQuit.Size = new System.Drawing.Size(136, 23);
            this.btnSaveNQuit.TabIndex = 6;
            this.btnSaveNQuit.Text = "Save && Quit";
            this.btnSaveNQuit.UseVisualStyleBackColor = true;
            this.btnSaveNQuit.Click += new System.EventHandler(this.btnSaveNQuit_Click);
            // 
            // pnlLoadSave
            // 
            this.pnlLoadSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoadSave.Controls.Add(this.btnLoadPanelBack);
            this.pnlLoadSave.Controls.Add(this.btnLoadPanelLoadSave);
            this.pnlLoadSave.Controls.Add(this.btnLoadPanelDeleteSave);
            this.pnlLoadSave.Controls.Add(this.lvSavesList);
            this.pnlLoadSave.Location = new System.Drawing.Point(274, 29);
            this.pnlLoadSave.Name = "pnlLoadSave";
            this.pnlLoadSave.Size = new System.Drawing.Size(743, 486);
            this.pnlLoadSave.TabIndex = 1;
            this.pnlLoadSave.Visible = false;
            // 
            // btnLoadPanelBack
            // 
            this.btnLoadPanelBack.Location = new System.Drawing.Point(439, 411);
            this.btnLoadPanelBack.Name = "btnLoadPanelBack";
            this.btnLoadPanelBack.Size = new System.Drawing.Size(133, 60);
            this.btnLoadPanelBack.TabIndex = 3;
            this.btnLoadPanelBack.Text = "Back";
            this.btnLoadPanelBack.UseVisualStyleBackColor = true;
            this.btnLoadPanelBack.Click += new System.EventHandler(this.btnLoadPanelBack_Click);
            // 
            // btnLoadPanelLoadSave
            // 
            this.btnLoadPanelLoadSave.Location = new System.Drawing.Point(578, 411);
            this.btnLoadPanelLoadSave.Name = "btnLoadPanelLoadSave";
            this.btnLoadPanelLoadSave.Size = new System.Drawing.Size(144, 60);
            this.btnLoadPanelLoadSave.TabIndex = 2;
            this.btnLoadPanelLoadSave.Text = "Load Save";
            this.btnLoadPanelLoadSave.UseVisualStyleBackColor = true;
            this.btnLoadPanelLoadSave.Click += new System.EventHandler(this.btnLoadPanelLoadSave_Click);
            // 
            // btnLoadPanelDeleteSave
            // 
            this.btnLoadPanelDeleteSave.Location = new System.Drawing.Point(19, 410);
            this.btnLoadPanelDeleteSave.Name = "btnLoadPanelDeleteSave";
            this.btnLoadPanelDeleteSave.Size = new System.Drawing.Size(152, 61);
            this.btnLoadPanelDeleteSave.TabIndex = 1;
            this.btnLoadPanelDeleteSave.Text = "Delete Save";
            this.btnLoadPanelDeleteSave.UseVisualStyleBackColor = true;
            this.btnLoadPanelDeleteSave.Click += new System.EventHandler(this.btnLoadPanelDeleteSave_Click);
            // 
            // lvSavesList
            // 
            this.lvSavesList.FullRowSelect = true;
            this.lvSavesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSavesList.Location = new System.Drawing.Point(20, 12);
            this.lvSavesList.MultiSelect = false;
            this.lvSavesList.Name = "lvSavesList";
            this.lvSavesList.Size = new System.Drawing.Size(704, 392);
            this.lvSavesList.TabIndex = 0;
            this.lvSavesList.UseCompatibleStateImageBehavior = false;
            this.lvSavesList.View = System.Windows.Forms.View.Details;
            this.lvSavesList.SelectedIndexChanged += new System.EventHandler(this.lvSavesList_SelectedIndexChanged);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(29, 29);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(176, 58);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnStartmenuLoadGame
            // 
            this.btnStartmenuLoadGame.Location = new System.Drawing.Point(29, 93);
            this.btnStartmenuLoadGame.Name = "btnStartmenuLoadGame";
            this.btnStartmenuLoadGame.Size = new System.Drawing.Size(176, 58);
            this.btnStartmenuLoadGame.TabIndex = 0;
            this.btnStartmenuLoadGame.Text = "Load Game";
            this.btnStartmenuLoadGame.UseVisualStyleBackColor = true;
            this.btnStartmenuLoadGame.Click += new System.EventHandler(this.btnStartmenuLoadGame_Click);
            // 
            // btnStartmenuQuit
            // 
            this.btnStartmenuQuit.Location = new System.Drawing.Point(29, 295);
            this.btnStartmenuQuit.Name = "btnStartmenuQuit";
            this.btnStartmenuQuit.Size = new System.Drawing.Size(176, 58);
            this.btnStartmenuQuit.TabIndex = 0;
            this.btnStartmenuQuit.Text = "Quit Game";
            this.btnStartmenuQuit.UseVisualStyleBackColor = true;
            this.btnStartmenuQuit.Click += new System.EventHandler(this.btnStartmenuQuit_Click);
            // 
            // pnlStartmenu
            // 
            this.pnlStartmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStartmenu.Controls.Add(this.btnStartmenuQuit);
            this.pnlStartmenu.Controls.Add(this.btnStartmenuLoadGame);
            this.pnlStartmenu.Controls.Add(this.btnNewGame);
            this.pnlStartmenu.Controls.Add(this.pnlLoadSave);
            this.pnlStartmenu.Location = new System.Drawing.Point(-2, -1);
            this.pnlStartmenu.Name = "pnlStartmenu";
            this.pnlStartmenu.Size = new System.Drawing.Size(1354, 731);
            this.pnlStartmenu.TabIndex = 7;
            // 
            // btnGate
            // 
            this.btnGate.BackColor = System.Drawing.Color.DarkViolet;
            this.btnGate.FlatAppearance.BorderSize = 2;
            this.btnGate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGate.Location = new System.Drawing.Point(229, 135);
            this.btnGate.Name = "btnGate";
            this.btnGate.Size = new System.Drawing.Size(110, 40);
            this.btnGate.TabIndex = 10;
            this.btnGate.Text = "Quests";
            this.btnGate.UseVisualStyleBackColor = false;
            this.btnGate.Click += new System.EventHandler(this.btnGate_Click);
            // 
            // btnUpgradeSanctum
            // 
            this.btnUpgradeSanctum.Location = new System.Drawing.Point(66, 305);
            this.btnUpgradeSanctum.Name = "btnUpgradeSanctum";
            this.btnUpgradeSanctum.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeSanctum.TabIndex = 18;
            this.btnUpgradeSanctum.Text = "Upgrade Sanctum";
            this.btnUpgradeSanctum.UseVisualStyleBackColor = true;
            this.btnUpgradeSanctum.Click += new System.EventHandler(this.btnUpgradeSanctum_Click);
            // 
            // btnUpgradeArcheryRange
            // 
            this.btnUpgradeArcheryRange.Location = new System.Drawing.Point(66, 263);
            this.btnUpgradeArcheryRange.Name = "btnUpgradeArcheryRange";
            this.btnUpgradeArcheryRange.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeArcheryRange.TabIndex = 19;
            this.btnUpgradeArcheryRange.Text = "Upgrade Archery";
            this.btnUpgradeArcheryRange.UseVisualStyleBackColor = true;
            this.btnUpgradeArcheryRange.Click += new System.EventHandler(this.btnUpgradeArcheryRange_Click);
            // 
            // btnUpgradeTownHall
            // 
            this.btnUpgradeTownHall.Location = new System.Drawing.Point(66, 137);
            this.btnUpgradeTownHall.Name = "btnUpgradeTownHall";
            this.btnUpgradeTownHall.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeTownHall.TabIndex = 20;
            this.btnUpgradeTownHall.Text = "Upgrade Town Hall";
            this.btnUpgradeTownHall.UseVisualStyleBackColor = true;
            this.btnUpgradeTownHall.Click += new System.EventHandler(this.btnUpgradeTownHall_Click);
            // 
            // btnUpgradeBarrack
            // 
            this.btnUpgradeBarrack.Location = new System.Drawing.Point(66, 221);
            this.btnUpgradeBarrack.Name = "btnUpgradeBarrack";
            this.btnUpgradeBarrack.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeBarrack.TabIndex = 21;
            this.btnUpgradeBarrack.Text = "Upgrade Barrack";
            this.btnUpgradeBarrack.UseVisualStyleBackColor = true;
            this.btnUpgradeBarrack.Click += new System.EventHandler(this.btnUpgradeBarrack_Click);
            // 
            // btnUpgradeStorage
            // 
            this.btnUpgradeStorage.Location = new System.Drawing.Point(66, 179);
            this.btnUpgradeStorage.Name = "btnUpgradeStorage";
            this.btnUpgradeStorage.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeStorage.TabIndex = 22;
            this.btnUpgradeStorage.Text = "Upgrade Storage";
            this.btnUpgradeStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeStorage.Click += new System.EventHandler(this.btnUpgradeStorage_Click);
            // 
            // btnUpgradeInfirmary
            // 
            this.btnUpgradeInfirmary.Location = new System.Drawing.Point(66, 95);
            this.btnUpgradeInfirmary.Name = "btnUpgradeInfirmary";
            this.btnUpgradeInfirmary.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeInfirmary.TabIndex = 23;
            this.btnUpgradeInfirmary.Text = "Upgrade Infirmary";
            this.btnUpgradeInfirmary.UseVisualStyleBackColor = true;
            this.btnUpgradeInfirmary.Click += new System.EventHandler(this.btnUpgradeInfirmary_Click);
            // 
            // btnUpgradeInn
            // 
            this.btnUpgradeInn.Location = new System.Drawing.Point(66, 53);
            this.btnUpgradeInn.Name = "btnUpgradeInn";
            this.btnUpgradeInn.Size = new System.Drawing.Size(111, 36);
            this.btnUpgradeInn.TabIndex = 24;
            this.btnUpgradeInn.Text = "Upgrade Inn";
            this.btnUpgradeInn.UseVisualStyleBackColor = true;
            this.btnUpgradeInn.Click += new System.EventHandler(this.btnUpgradeInn_Click);
            // 
            // btnTownHall
            // 
            this.btnTownHall.BackColor = System.Drawing.Color.DarkViolet;
            this.btnTownHall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTownHall.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTownHall.Location = new System.Drawing.Point(752, 429);
            this.btnTownHall.Margin = new System.Windows.Forms.Padding(2);
            this.btnTownHall.Name = "btnTownHall";
            this.btnTownHall.Size = new System.Drawing.Size(115, 28);
            this.btnTownHall.TabIndex = 4;
            this.btnTownHall.Text = "Town Hall";
            this.btnTownHall.UseVisualStyleBackColor = false;
            this.btnTownHall.Click += new System.EventHandler(this.btnTownHall_Click);
            // 
            // pnlTownHall
            // 
            this.pnlTownHall.Controls.Add(this.label3);
            this.pnlTownHall.Controls.Add(this.label2);
            this.pnlTownHall.Controls.Add(this.label1);
            this.pnlTownHall.Controls.Add(this.btnCombatLogTownHall);
            this.pnlTownHall.Controls.Add(this.btnUpgradeSanctum);
            this.pnlTownHall.Controls.Add(this.btnUpgradeArcheryRange);
            this.pnlTownHall.Controls.Add(this.btnUpgradeBarrack);
            this.pnlTownHall.Controls.Add(this.btnUpgradeTownHall);
            this.pnlTownHall.Controls.Add(this.btnUpgradeStorage);
            this.pnlTownHall.Controls.Add(this.btnUpgradeInfirmary);
            this.pnlTownHall.Controls.Add(this.btnUpgradeInn);
            this.pnlTownHall.Controls.Add(this.btnTownHallClose);
            this.pnlTownHall.Location = new System.Drawing.Point(548, 114);
            this.pnlTownHall.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTownHall.Name = "pnlTownHall";
            this.pnlTownHall.Size = new System.Drawing.Size(232, 408);
            this.pnlTownHall.TabIndex = 5;
            this.pnlTownHall.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Combat Logs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Upgrades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Town Hall";
            // 
            // btnCombatLogTownHall
            // 
            this.btnCombatLogTownHall.Enabled = false;
            this.btnCombatLogTownHall.Location = new System.Drawing.Point(66, 370);
            this.btnCombatLogTownHall.Margin = new System.Windows.Forms.Padding(2);
            this.btnCombatLogTownHall.Name = "btnCombatLogTownHall";
            this.btnCombatLogTownHall.Size = new System.Drawing.Size(111, 24);
            this.btnCombatLogTownHall.TabIndex = 26;
            this.btnCombatLogTownHall.Text = "No Logs";
            this.btnCombatLogTownHall.UseVisualStyleBackColor = true;
            this.btnCombatLogTownHall.Click += new System.EventHandler(this.btnCombatLogTownHall_Click);
            // 
            // btnTownHallClose
            // 
            this.btnTownHallClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTownHallClose.ForeColor = System.Drawing.Color.Red;
            this.btnTownHallClose.Location = new System.Drawing.Point(204, 0);
            this.btnTownHallClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnTownHallClose.Name = "btnTownHallClose";
            this.btnTownHallClose.Size = new System.Drawing.Size(23, 24);
            this.btnTownHallClose.TabIndex = 4;
            this.btnTownHallClose.Text = "X";
            this.btnTownHallClose.UseVisualStyleBackColor = true;
            this.btnTownHallClose.Click += new System.EventHandler(this.btnTownHallClose_Click);
            // 
            // ttUpgradeBuildings
            // 
            this.ttUpgradeBuildings.AutomaticDelay = 1;
            this.ttUpgradeBuildings.AutoPopDelay = 0;
            this.ttUpgradeBuildings.InitialDelay = 1;
            this.ttUpgradeBuildings.ReshowDelay = 0;
            this.ttUpgradeBuildings.UseAnimation = false;
            this.ttUpgradeBuildings.UseFading = false;
            // 
            // pnlListOfLogs
            // 
            this.pnlListOfLogs.Controls.Add(this.btnSelectLog);
            this.pnlListOfLogs.Controls.Add(this.lvCombatLogs);
            this.pnlListOfLogs.Controls.Add(this.label4);
            this.pnlListOfLogs.Controls.Add(this.btnCombatLogsClose);
            this.pnlListOfLogs.Location = new System.Drawing.Point(780, 114);
            this.pnlListOfLogs.Margin = new System.Windows.Forms.Padding(2);
            this.pnlListOfLogs.Name = "pnlListOfLogs";
            this.pnlListOfLogs.Size = new System.Drawing.Size(247, 408);
            this.pnlListOfLogs.TabIndex = 2;
            this.pnlListOfLogs.Visible = false;
            // 
            // btnSelectLog
            // 
            this.btnSelectLog.Location = new System.Drawing.Point(2, 345);
            this.btnSelectLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectLog.Name = "btnSelectLog";
            this.btnSelectLog.Size = new System.Drawing.Size(243, 61);
            this.btnSelectLog.TabIndex = 1;
            this.btnSelectLog.Text = "Show log";
            this.btnSelectLog.UseVisualStyleBackColor = true;
            this.btnSelectLog.Click += new System.EventHandler(this.btnSelectLog_Click);
            // 
            // lvCombatLogs
            // 
            this.lvCombatLogs.Location = new System.Drawing.Point(2, 31);
            this.lvCombatLogs.Margin = new System.Windows.Forms.Padding(2);
            this.lvCombatLogs.MultiSelect = false;
            this.lvCombatLogs.Name = "lvCombatLogs";
            this.lvCombatLogs.Size = new System.Drawing.Size(243, 310);
            this.lvCombatLogs.TabIndex = 0;
            this.lvCombatLogs.UseCompatibleStateImageBehavior = false;
            this.lvCombatLogs.View = System.Windows.Forms.View.Details;
            this.lvCombatLogs.SelectedIndexChanged += new System.EventHandler(this.lvCombatLogs_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Logs";
            // 
            // btnCombatLogsClose
            // 
            this.btnCombatLogsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombatLogsClose.ForeColor = System.Drawing.Color.Red;
            this.btnCombatLogsClose.Location = new System.Drawing.Point(222, 1);
            this.btnCombatLogsClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnCombatLogsClose.Name = "btnCombatLogsClose";
            this.btnCombatLogsClose.Size = new System.Drawing.Size(23, 24);
            this.btnCombatLogsClose.TabIndex = 4;
            this.btnCombatLogsClose.Text = "X";
            this.btnCombatLogsClose.UseVisualStyleBackColor = true;
            this.btnCombatLogsClose.Click += new System.EventHandler(this.btnCombatLogsClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlStartmenu);
            this.Controls.Add(this.btnGameQuit);
            this.Controls.Add(this.btnSaveNQuit);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.pnlListOfLogs);
            this.Controls.Add(this.pnlCombatLog);
            this.Controls.Add(this.pnlTownHall);
            this.Controls.Add(this.pnlSendGroupToDungeon);
            this.Controls.Add(this.pnlGroupCreation);
            this.Controls.Add(this.btnTownHall);
            this.Controls.Add(this.btnGroupManagement);
            this.Controls.Add(this.btnGate);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlSendGroupToDungeon.ResumeLayout(false);
            this.pnlSendGroupToDungeon.PerformLayout();
            this.pnlGroupCreation.ResumeLayout(false);
            this.pnlGroupCreation.PerformLayout();
            this.pnlCombatLog.ResumeLayout(false);
            this.pnlCombatLog.PerformLayout();
            this.pnlLoadSave.ResumeLayout(false);
            this.pnlStartmenu.ResumeLayout(false);
            this.pnlTownHall.ResumeLayout(false);
            this.pnlTownHall.PerformLayout();
            this.pnlListOfLogs.ResumeLayout(false);
            this.pnlListOfLogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.TextBox txtMessageLog;
        private System.Windows.Forms.Button btnGroupToDungeon;
        private System.Windows.Forms.ListView lvGroupToDungeonList;
        private System.Windows.Forms.Panel pnlSendGroupToDungeon;
        private System.Windows.Forms.Panel pnlGroupCreation;
        private System.Windows.Forms.Button btnDisbandGroup;
        private System.Windows.Forms.ListView lvHeroGroups;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.ListView lvHeroNotGrouped;
        private System.Windows.Forms.Button btnGroupManagement;
        private System.Windows.Forms.Panel pnlCombatLog;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.Button btnGameQuit;
        private System.Windows.Forms.Button btnSaveNQuit;
        private System.Windows.Forms.ListView lvQuestView;
        private System.Windows.Forms.Panel pnlLoadSave;
        private System.Windows.Forms.Button btnLoadPanelBack;
        private System.Windows.Forms.Button btnLoadPanelLoadSave;
        private System.Windows.Forms.Button btnLoadPanelDeleteSave;
        private System.Windows.Forms.ListView lvSavesList;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnStartmenuLoadGame;
        private System.Windows.Forms.Button btnStartmenuQuit;
        private System.Windows.Forms.Panel pnlStartmenu;
        private System.Windows.Forms.Button btnGate;
        private System.Windows.Forms.Button btnCloseQuestPanel;
        private System.Windows.Forms.Button btnCloseGroupManager;
        private System.Windows.Forms.Button btnUpgradeSanctum;
        private System.Windows.Forms.Button btnUpgradeArcheryRange;
        private System.Windows.Forms.Button btnUpgradeTownHall;
        private System.Windows.Forms.Button btnUpgradeBarrack;
        private System.Windows.Forms.Button btnUpgradeStorage;
        private System.Windows.Forms.Button btnUpgradeInfirmary;
        private System.Windows.Forms.Button btnUpgradeInn;
        private System.Windows.Forms.Button btnTownHall;
        private System.Windows.Forms.Panel pnlTownHall;
        public System.Windows.Forms.ToolTip ttUpgradeBuildings;
        private System.Windows.Forms.Button btnTownHallClose;
        private System.Windows.Forms.Button btnCombatLogTownHall;
        private System.Windows.Forms.Panel pnlListOfLogs;
        private System.Windows.Forms.ListView lvCombatLogs;
        private System.Windows.Forms.Button btnSelectLog;
        private System.Windows.Forms.Button btnCloseCombatLogPanel;
        private System.Windows.Forms.Button btnCombatLogsClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

