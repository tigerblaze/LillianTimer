using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LillianTimer
{
    public partial class Form1 : Form
    {
        Component[] Components;

        public Form1()
        {
            int timerCount = 9;
            Components = new Component[timerCount];
            InitializeComponent();
            CreateUI(timerCount);
            CreateTimer(timerCount);
        }

        private void CreateUI(int timerCount)
        {
            // 创建并布局多个 控件
            for (int i = 0; i < timerCount; i++)
            {
                int height = 25 + i * 50;
                Component component = new Component();

                TextBox textBox = new TextBox();
                textBox.Name = "textBox" + i;
                textBox.Tag = i;
                textBox.Location = new System.Drawing.Point(24, height);
                textBox.Size = new System.Drawing.Size(106, 22);
                component.TextBoxField = textBox;
                this.Controls.Add(textBox);

                TextBox timerBox = new TextBox();
                timerBox.Name = "timerBox" + i;
                timerBox.Tag = i;
                timerBox.Location = new System.Drawing.Point(136, height);
                timerBox.Size = new System.Drawing.Size(125, 22);
                timerBox.ReadOnly = true;
                component.TimerBoxField = timerBox;
                this.Controls.Add(timerBox);

                Button button = new Button();
                button.Name = "StartBT" + i;
                button.Tag = i;
                button.Location = new Point(271, height);
                button.Size = new Size(32, 23);
                button.Text = "▷";
                button.Click += StartBT_Click;
                component.StartBT = button;
                this.Controls.Add(button);

                button = new Button();
                button.Name = "StopBT" + i;
                button.Tag = i;
                button.Location = new Point(309, height);
                button.Size = new Size(32, 23);
                button.Text = "| |";
                component.StopBT = button;
                button.Click += StopBT_Click;
                this.Controls.Add(button);

                button = new Button();
                button.Name = "ResetBT" + i;
                button.Tag = i;
                button.Location = new Point(347, height);
                button.Size = new Size(43, 23);
                button.Text = "Reset";
                button.Click += ResetBT_Click;
                component.ResetBT = button;
                this.Controls.Add(button);

                Components[i] = component;
            }
        }

        private void CreateTimer(int timerCount)
        {
            for (int i = 0; i < timerCount; i++)
            {
                Timer timer = new Timer();
                timer.Tick += timer_Tick;
                timer.Tag = i;
                timer.Interval = 1000;
                Components[i].TimerField = timer;
            }
        }

        private void StopBT_Click(object sender, EventArgs e)
        {
            var component = GetComponent(sender);
            component.TimerField.Stop();
            component.StartBT.Enabled = true;
            component.StartBT.BackColor = Color.White;
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
            var component = GetComponent(sender);
            component.TimerField.Start();
            component.StartBT.Enabled = false;
            component.StartBT.BackColor = Color.LightGreen;
        }

        private void ResetBT_Click(object sender, EventArgs e)
        {
            var component = GetComponent(sender);
            component.Second = 0;
            component.TimerBoxField.Text = ParseTimeFormat(component.Second);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            int index = (int)timer.Tag;
            var component = Components[index];
            component.Second++;
            component.TimerBoxField.Text = ParseTimeFormat(component.Second);
        }

        private string ParseTimeFormat(int second)
        {
            int min = second / 60;
            int hour = min / 60;
            second = second % 3600;

            return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, second);
        }

        private Component GetComponent(object sender)
        {
            Button button = (Button)sender;
            int index = (int)button.Tag;
            return Components[index];
        }
    }
}
