using System;
using System.Drawing;

namespace TownManager {
    class GameWorld {
        // MY Ball! tester
        int testcoordinate;
        bool goingRight = true;
        // END BALL!

        public Form1 form1;

        public Town town;

        private int sentGroup = 0;

        #region GRAPHIC STUFF

        private Pen p;

        private Graphics dc;
        static Rectangle displayRectangle;
        private BufferedGraphics backBuffer;

        private Image backgroundImage;

        float currentFPS;
        private DateTime endTime;

        #endregion

        #region PROPERTIES

        public static void SetRectangle(Rectangle rect) {
            displayRectangle = rect;
        }


        #endregion

        public GameWorld(Graphics dc, Form1 form1, int saveID) {

            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            this.dc = backBuffer.Graphics;

            this.form1 = form1;

            if (saveID == -1) {
                SetupWorld();
            }
            else {
                LoadWorld(saveID);
            }
        }

        public void SetupWorld() {
            backgroundImage = Image.FromFile("sprites/background.png");

            p = new Pen(Color.Black);

            town = new Town(form1);
        }

        public void LoadWorld(int saveID) {
            backgroundImage = Image.FromFile("sprites/background.png");

            p = new Pen(Color.Black);

            town = new Town(form1);
            town.TownID = saveID;

            SaveLoad saveloadData = new SaveLoad();
            saveloadData._town = town;
            saveloadData.LoadSave();

            foreach (Group group in town.Grouplist) {
                group.CalcAverageLevel();
                group.CalcHealthAndDamage();
            }
        }

        public void GameLoop() {
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFPS = 1000 / milliSeconds;
            endTime = DateTime.Now;

            Update();
            UpdateAnimation();
            Draw();
        }

        public void Update() {
            if (testcoordinate < displayRectangle.Width - 20 && goingRight) {
                testcoordinate += 4;
            }
            else if (testcoordinate >= displayRectangle.Width - 20) {
                goingRight = false;
                testcoordinate -= 4;
            }
            else if (testcoordinate < 0) {
                goingRight = true;
                testcoordinate += 4;
            }
            else {
                testcoordinate -= 4;
            }

            town.Update();
        }

        public void UpdateAnimation() {

        }

        public void Draw() {//Rettet i
            dc.DrawImage(backgroundImage, 0, 0, 1350, 729);

            //dc.DrawEllipse(p, new Rectangle(testcoordinate, 10, 20, 20));

            string timeLeft = "";

            foreach (Group group in town.Grouplist) {
                if (!group.Available) {
                    TimeSpan delta = group.HomeWhen - DateTime.Now;
                    timeLeft += "Time left: " + (delta.Minutes).ToString() + ":" + (delta.Seconds).ToString() + Environment.NewLine;
                }
            }

            dc.DrawString(timeLeft, new Font("Arial", 16), new SolidBrush(Color.Red), new PointF(0, 0));
            dc.DrawString("Gold: " + town.CurrentGold.ToString(), new Font("Arial", 16), new SolidBrush(Color.Gold), new PointF(displayRectangle.Width - 300, 0));

            backBuffer.Render();
            dc.Clear(Color.Green);
        }
    }
}