using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source
{
    class Menu_Item : Scene
    {
        enum selectScene
        {
            Scene_Menu_Item1,
            Scene_Menu_Item2,
            Scene_Menu_Item3,
            Scene_Menu
        }
        selectScene select;
        int Menu_ItemWindow, test;
        public Menu_Item()
        {
            select = (int)selectScene.Scene_Menu_Item1;
            Menu_ItemWindow = LoadGraph("Image\\Menu_Flame.png");
            test = LoadGraph("Image\\test.png");

        }

        public void Draw()
        {
            DrawGraph(0, 0, Menu_ItemWindow, TRUE);//画像描画
            DrawString(0, 0, "アイテム画面です。", GetColor(255, 255, 255));
            DrawString(500, 70, "アイテム1", GetColor(255, 255, 255));
            DrawString(500, 120, "アイテム2", GetColor(255, 255, 255));
            DrawString(500, 170, "アイテム3", GetColor(255, 255, 255));
            DrawString(500, 220, "メニューに戻る", GetColor(255, 255, 255));
            DrawString(455, 70 + (int)select * 50, "■", GetColor(255, 255, 255));

        }

        public void Update()
        {
            if (Program.Key[KEY_INPUT_DOWN] == 1)
            {//下キーが押されたら
                if ((int)select >= 0 && (int)select <= 2)
                {
                    select = select + 1;
                }
                    else if ((int)select == 3)
                {
                    select = selectScene.Scene_Menu_Item1;
                }
            }
            if (Program.Key[KEY_INPUT_UP] == 1)
            {//上キーが押されたら
                if ((int)select >= 1 && (int)select <= 3)
                {
                    select = select - 1;
                }
                else if ((int)select == 0)
                {
                    select = selectScene.Scene_Menu;
                }

            }

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
