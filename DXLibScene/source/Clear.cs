using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Clear:Scene {
        enum selectScene {Scene_Map,Scene_DeskTop}
        selectScene select;
        public Clear() {
            select = (int)selectScene.Scene_Map;
        }

        public void Draw() {
            DrawString(0, 0, "勝利画面です。", GetColor(255, 255, 255));
            DrawString(100, 200, "マップ画面に戻る。", GetColor(255, 255, 255));
            
            DrawString(80, 200, "■", GetColor(255, 255, 255));
            
        }

        public void Update() {
            select = 0;
            DrawString(20, 50, select.ToString(), GetColor(255, 255, 255));

            if (Program.Key[KEY_INPUT_RETURN] == 1) {

                        SceneController.SceneChange(new Map());

            }
        }
    }
}
