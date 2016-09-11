using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onepicture.cs
{
    class randomclass
    {

        public int int1;
        public string zif;

        public void randome ()
        {
            Random rand = new Random();
            int1 = rand.Next(1,10);
        }

        public void stringzifu ()
        {
            if (int1 == 1)
                zif = "偷偷在背后交易，就是不告诉你……";
            else if (int1 == 2)
                zif = "滑稽树前做游戏，滑稽树后做交易~";
            else if (int1 == 3)
                zif = "交易还在继续，确定一发？";
            else if (int1 == 3)
                zif = "girigirieye~~girigirimind~~~";
            else if (int1 == 4)
                zif = "看到这句话，偷偷+1s";
            else if (int1 == 5)
                zif = "骚年，你渴望力量吗？";
            else if (int1 == 6)
                zif = "我会跟你说看到这句话时图片早就下载完了？";
            else if (int1 == 7)
                zif = "萌豚娘是吃货……";
            else if (int1 == 8)
                zif = "少年，我觉得你需要杨叔治疗下~";
            else if (int1 == 9)
                zif = "萝莉即是正义";
            else if (int1 == 10)
                zif = "请问，你们有没有……";
        }

    }
}
