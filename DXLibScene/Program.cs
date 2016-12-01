using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;
using DXLibScene.source;
using DROSS;

namespace DXLibScene {

    class Program {

        public static int[]Key = new int[256];

        static void Main(String[] args) {
            ChangeWindowMode(TRUE);
            DxLib_Init();
            SetDrawScreen(DX_SCREEN_BACK); //ウィンドウモード変更と初期化と裏画面設定
            SetMainWindowText("俺の冒険");//タイトル文字変更
            SetGraphMode(1280, 720, 32);//ウィンドウサイズ変更

            Scene scene = new Start();
            SceneController sc = new SceneController(scene);
            DXLibScene.source.Function fc = new Function();

            while (ScreenFlip() == 0 && ProcessMessage() == 0 && ClearDrawScreen() == 0
                    && CheckHitKey(KEY_INPUT_ESCAPE) == 0 && fc.getUpdateKey()==0) {
                if (SceneController.copyScene != null)
                {
                    sc.CopySceneDraw();

                }
                sc.Draw();
                sc.Update();
                
            }
            DxLib_End();
            return;
        }
    }
}
