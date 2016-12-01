using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Menu:Scene {
        enum selectScene {
            Scene_Menu_Item,
            Scene_Menu_Equip,
            Scene_Menu_Skill,
            Scene_Menu_Status,
            Scene_Menu_Config,
            Scene_Save,
            Scene_Load,
            Scene_Map
        }
        selectScene select;
        int MenuWindow,test;
        public Menu() {
            select = (int)selectScene.Scene_Menu_Item;
            MenuWindow = LoadGraph("Image\\Menu_Flame.png");
            test = LoadGraph("Image\\test.png");

        }

        public void Draw() {
            DrawGraph(0, 0, MenuWindow, TRUE);//画像描画
            DrawGraph(600, 100, test, TRUE);//画像描画
            DrawString(0, 0, "メニュー画面です。", GetColor(255, 255, 255));
            DrawString(90, 70, "アイテム", GetColor(255, 255, 255));
            DrawString(90, 120, "装備", GetColor(255, 255, 255));
            DrawString(90, 170, "特技", GetColor(255, 255, 255));
            DrawString(90, 220, "ステータス", GetColor(255, 255, 255));
            DrawString(90, 270, "コンフィグ", GetColor(255, 255, 255));
            DrawString(90, 320, "セーブ", GetColor(255, 255, 255));
            DrawString(90, 370, "ロード", GetColor(255, 255, 255));
            DrawString(90, 420, "戻る", GetColor(255, 255, 255));
            DrawString(55, 70 + (int)select * 50, "■", GetColor(255, 255, 255));

        }

        public void Update() {
            if (Program.Key[KEY_INPUT_DOWN] == 1)
            {//下キーが押されたら
                if ((int)select >= 0 && (int)select <= 6)
                {
                    select = select + 1;
                }
                else if((int)select == 7)
                {
                    select = selectScene.Scene_Menu_Item;
                }
            }
            if (Program.Key[KEY_INPUT_UP] == 1)
            {//上キーが押されたら
                if ((int)select >= 1 && (int)select <= 7)
                {
                    select = select - 1;
                }
                else if ((int)select == 0)
                {
                    select = selectScene.Scene_Map;
                }
            }

            if (Program.Key[KEY_INPUT_RETURN] == 1)
            {
                switch (select)
                {
                    case selectScene.Scene_Menu_Item:
                        SceneController.Copy(new Menu());
                        SceneController.SceneChange(new Menu_Item());

                        break;
                    case selectScene.Scene_Menu_Status:
                        SceneController.Copy(new Menu());
                        SceneController.SceneChange(new Menu_Status());

                        break;
                    case selectScene.Scene_Map:
                        SceneController.SceneChange(new Map());
                        break;
                }
            }
        }
    }
}
