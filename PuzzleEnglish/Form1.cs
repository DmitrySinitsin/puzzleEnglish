using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleEnglish
{
    public partial class Form1 : Form
    {
        Dictionary dict;
        int curr = 0;


        public Form1()
        {
            InitializeComponent();
            dict = new Dictionary();
            ShowCard();
        }

        public void ShowCard()
        {
            if(dict.Image(curr) !="")
            picture_card.Image = Image.FromFile(dict.Image(curr));//загрузка картинки
            label_english.Text = dict.English(curr);
            label_russian.Text = dict.Russian(curr);
            label_video.Visible = dict.Video(curr) != "";
            
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            if (curr <= 0) return;
            curr--;
            ShowCard();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (curr >= dict.Total() -1) return;
            curr++;
            ShowCard();
        }

        private void play_mp3 (string filename)
        {
            if (filename == "") return;
            player.Visible = false;
            player.URL = filename;
        }

        private void play_mp4(string filename)
        {
            if (filename == "") return;
            player.Visible = true;
            player.uiMode = "none";//убрать все кнопки с плеера
            player.URL = filename;
        }

        private void label_russian_Click(object sender, EventArgs e)
        {
            play_mp3(dict.Audio_rus(curr));
        }

        private void label_english_Click(object sender, EventArgs e)
        {
            play_mp3(dict.Audio_eng(curr));
        }

        private void label_video_Click(object sender, EventArgs e)
        {
            play_mp4(dict.Video(curr));
        }

        private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
                player.Visible = false;
        }
    }
}
