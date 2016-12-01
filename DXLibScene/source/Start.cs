using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Start:Scene {
        enum selectScene {Scene_Map,Scene_DeskTop}
        selectScene select;
        public Start() {
            select = (int)selectScene.Scene_Map;
        }

        public void Draw() {
            DrawString(0, 0, "スタート画面です。", GetColor(255, 255, 255));
            DrawString(100, 200, "始めから(マップ画面へ移動)", GetColor(255, 255, 255));
            DrawString(100, 300, "終了(デスクトップへの移動)", GetColor(255, 255, 255));
            switch (select) {
                case selectScene.Scene_Map:
                    DrawString(80, 200, "■", GetColor(255, 255, 255));
                    break;
                case selectScene.Scene_DeskTop:
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
                    case selectScene.Scene_Map:
                        SceneController.SceneChange(new Map());
                        break;
                    case selectScene.Scene_DeskTop:
                        SceneController.SceneChange(new Desktop());
                        break;
                }
            }
        }
    }
}
