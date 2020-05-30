using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PuzzleEnglish
{
    class Dictionary
    {
        int total = 0;

        string[] english;//apple
        string[] russian;//яблоко
        string[] audio_eng;//english/apple.mp3
        string[] audio_rus;
        string[] image;// image/apple.jpg
        string[] video;

        public Dictionary ()//конструктор
        {
            Init ();//инициализация массивов
        }

        public int Total ()
        {
            return total;
        }

        public string English (int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return english[nr];
        }

        public string Russian(int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return russian[nr];
        }

        public string Audio_eng(int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return audio_eng[nr];
        }

        public string Audio_rus(int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return audio_rus[nr];
        }

        public string Image(int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return image[nr];
        }

        public string Video(int nr)
        {
            if (nr < 0 || nr >= total) return "";
            return video[nr];
        }

        public void Init()
        {
            total = 0;
            DirectoryInfo di = new DirectoryInfo("data\\text\\");// открыть каталог с файлами
            FileInfo[] info = di.GetFiles("*.txt", SearchOption.TopDirectoryOnly);//массив из файлов полученных в директории, открытой предыдущей строкой кода
            total = info.Length;
            english = new string[total];//инициализация массива инглиш
            russian = new string[total];
            audio_eng = new string[total];
            audio_rus = new string[total];
            image = new string[total];
            video = new string[total];
            int j = 0;
            foreach (FileInfo file in info)//пройти по всем записям массива инфо
            {
                string filename = file.FullName;//в фуллнейм - имя файла с расширением, в нейм - без
                string name = file.Name.Replace(".txt", "");//удиляем расширение
                string[] lines = File.ReadAllLines(filename);//считать содержимое текстового файла
                english[j] = lines[0];
                russian[j] = lines[1];
                audio_eng[j] = "data\\english\\" + name + ".mp3";
                audio_rus[j] = "data\\russian\\" + name + ".mp3";
                if (!File.Exists(audio_eng[j])) audio_eng[j] = "";
                if (!File.Exists(audio_rus[j])) audio_rus[j] = "";

                image[j] = "data\\images\\" + name + ".jpg";
                video[j] = "data\\video\\" + name + ".mp4";

                if (!File.Exists(image[j])) image[j] = "";
                if (!File.Exists(video[j])) video[j] = "";

                j++;
            }
        }
    }
}
