using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source
{
    class Menu_Status : Scene
    {
        enum selectScene
        {
            Scene_Menu
        }
        selectScene select;
        int Menu_StatusWindow, test;
        public Menu_Status()
        {
            select = (int)selectScene.Scene_Menu;
            Menu_StatusWindow = LoadGraph("Image\\Menu_Flame.png");
            test = LoadGraph("Image\\test.png");

        }

        public void Draw()
        {
            DrawGraph(0, 0, Menu_StatusWindow, TRUE);//画像描画
            DrawString(0, 0, "メニュー画面です。", GetColor(255, 255, 255));
            DrawString(320, 90, "レベル", GetColor(255, 255, 255));
            DrawString(320, 110, "HP", GetColor(255, 255, 255));
            DrawString(320, 140, "MP", GetColor(255, 255, 255));
            DrawString(320, 170, "攻撃力", GetColor(255, 255, 255));
            DrawString(320, 200, "防御力", GetColor(255, 255, 255));
            DrawString(320, 230, "魔法攻撃力", GetColor(255, 255, 255));
            DrawString(320, 260, "魔法防御力", GetColor(255, 255, 255));
            DrawString(320, 290, "力", GetColor(255, 255, 255));
            DrawString(320, 320, "体力", GetColor(255, 255, 255));
            DrawString(320, 350, "敏捷", GetColor(255, 255, 255));
            DrawString(320, 380, "精神", GetColor(255, 255, 255));
            DrawString(320, 410, "運", GetColor(255, 255, 255));
            DrawString(320, 440, "必要経験値", GetColor(255, 255, 255));
            DrawString(320, 470, "累積経験値", GetColor(255, 255, 255));


        }

        public void Update()
        {

            if (Program.Key[KEY_INPUT_RETURN] == 1)
            {
                switch (select)
                {
                    case selectScene.Scene_Menu:
                        SceneController.copyScene = null;
                        SceneController.SceneChange(new Menu());
                        break;
                }
            }
        }
    }
}
