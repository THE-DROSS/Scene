using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class SceneController {

        static Scene currentScene;
        public static Scene copyScene;

        public SceneController(Scene cs)
        {
            currentScene = cs;
        }

        public void Draw()
        {
            currentScene.Draw();
        }

        public void Update()
        {
            currentScene.Update();
        }

        public void CopySceneDraw()
        {
            copyScene.Draw();
        }

        public static void Copy(Scene cs)
        {
            copyScene = cs;
        }

        public static void SceneChange(Scene cs) {
            currentScene = cs;
        }
    }
}
