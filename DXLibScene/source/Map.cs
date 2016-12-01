using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Map:Scene {
        enum selectScene {Scene_Menu,Scene_Battle}
        selectScene select;
        public Map() {
            select = (int)selectScene.Scene_Menu;
        }

        public void Draw() {
            DrawString(0, 0, "マップ画面です。", GetColor(255, 255, 255));
            DrawString(100, 200, "メニュー(メニュー画面へ移動)", GetColor(255, 255, 255));
            DrawString(100, 300, "先頭する(戦闘画面への移動)", GetColor(255, 255, 255));
            switch (select) {
                case selectScene.Scene_Menu:
                    DrawString(80, 200, "■", GetColor(255, 255, 255));
                    break;
                case selectScene.Scene_Battle:
                    DrawString(80, 300, "■", GetColor(255, 255, 255));
                    break;
            }
        }

        public void Update() {
            DrawString(20, 50, select.ToString(), GetColor(255, 255, 255));
            if (Program.Key[KEY_INPUT_DOWN] == 1) {//下キーが押されたら
                if ((int)select <= 0) {
                    select = select + 1;
                }
            }
            if (Program.Key[KEY_INPUT_UP] == 1) {//上キーが押されたら
                if ((int)select >= 1) {
                    select = select - 1;
                }
            }
            if (Program.Key[KEY_INPUT_RETURN] ==1) {
                switch (select) {
                    case selectScene.Scene_Menu:
                        SceneController.SceneChange(new Menu());
                        break;
                    case selectScene.Scene_Battle:
                        SceneController.SceneChange(new Battle());
                        break;
                }
            }
        }
    }
}
