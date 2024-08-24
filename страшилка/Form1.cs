using System.Media;
using System.Numerics;

namespace страшилка
{
    public partial class Form1 : Form
    {
        Panel[] panels;
        static bool Crash(PictureBox player, Panel car)//top - .Location.Y      left - .Location.X
        {
            if (player.Location.Y < car.Location.Y + car.Size.Height && player.Location.Y + player.Size.Height > car.Location.Y &&
            ((player.Location.X < car.Location.X + car.Size.Width && player.Location.X > car.Location.X) ||
            (player.Location.X + player.Size.Width > car.Location.X && player.Location.X + player.Size.Width < car.Location.X + car.Size.Width)))
            {
                return true;
            }
            else { return false; }
        }
        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel7, panel8, panel9 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1094 || e.KeyChar == 119)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 3);
            }
            if (e.KeyChar == 1092 || e.KeyChar == 97)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - 3, pictureBox1.Location.Y);
            }
            if (e.KeyChar == 1099 || e.KeyChar == 115)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 3);
            }
            if (e.KeyChar == 1074 || e.KeyChar == 100)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 3, pictureBox1.Location.Y);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (Crash(pictureBox1, panels[i]))
                {
                    pictureBox1.Location = new Point(722, 418);
                    //timer1.Enabled = false;
                }
            }
            if (Crash(pictureBox1, panel6))
            {
                SoundPlayer music = new SoundPlayer("gdfgdgf.wav");
                music.Play();
                PictureBox pictureBox2 = new PictureBox();
                pictureBox2.Image = Image.FromFile("IMG_20190513_093646.jpg"); // Устанавливаем картинку
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Режим отображения
                pictureBox2.Size = new Size(this.Width, this.Height); // Устанавливаем размеры
                pictureBox2.Location = new Point(0, 0); // Устанавливаем расположение
                this.Controls.Add(pictureBox2); // Добавляем на форму
                foreach (var p in panels)
                {
                    p.Visible = false;
                }
                panel6.Visible = false;
                pictureBox1.Visible = false;
                //SoundPlayer music = new SoundPlayer("gdfgdgf.wav");
                //music.Play();
                timer2.Enabled = true;
                timer1.Enabled = false;
                //this.Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}