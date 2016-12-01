using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Battle:Scene {
        enum selectScene {Scene_Defeate,Scene_Victory}
        selectScene select;
        public Battle() {
            select = (int)selectScene.Scene_Defeate;
        }

        public void Draw() {
            DrawString(0, 0, "戦闘画面です。", GetColor(255, 255, 255));
            DrawString(100, 200, "敗北しました！(敗北画面へ：未作成)", GetColor(255, 255, 255));
            DrawString(100, 300, "勝利しました！(クリア画面へ)", GetColor(255, 255, 255));
            switch (select) {
                case selectScene.Scene_Defeate:
                    DrawString(80, 200, "■", GetColor(255, 255, 255));
                    break;
                case selectScene.Scene_Victory:
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
            if (Program.Key[KEY_INPUT_RETURN] == 1) {
                
                switch (select) {
                    case selectScene.Scene_Defeate:
                        SceneController.SceneChange(new Battle());
                        break;
                    case selectScene.Scene_Victory:
                        SceneController.SceneChange(new Clear());
                        break;
                }
            }
        }
    }
}
