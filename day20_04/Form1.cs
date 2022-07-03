using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day20_04
{
    public partial class Form1 : Form
    {
        BufferedGraphicsContext context;
        BufferedGraphics graphics;
        Image image;

        public Form1()
        {
            InitializeComponent();

            context = BufferedGraphicsManager.Current; // 참조
            context.MaximumBuffer = new Size(800, 600); // 버퍼 크기 설정
            //buffer graphics 객체 생성 및 참조
            graphics = context.Allocate(CreateGraphics(), new Rectangle(0, 0, 800, 600));
            graphics.Graphics.Clear(Color.Green);
            image = Image.FromFile("photo.png");
            SetClientSizeCore(800, 600);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random rand = new Random();
            for(int i = 0; i < 100; i++)
            {
                graphics.Graphics.DrawImage(image, rand.Next(0, 700), rand.Next(0, 500));
            }

            graphics.Render(e.Graphics); //화면에 출력
        }
    }
}
