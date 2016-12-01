using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace DXLibScene.source {
    class Function {
        public int getUpdateKey() {
            Byte[] tmpKey = new byte[256];
            GetHitKeyStateAll(out tmpKey[0]);
            for(int i = 0; i < 256; i++) {
                if(tmpKey[i] != 0) {
                    Program.Key[i]++;
                }else {
                    Program.Key[i] = 0;
                }
            }

            return 0;
        }
    }
}
