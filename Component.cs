using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LillianTimer
{
    internal class Component
    {
        /// <summary>
        /// 使用者自行輸入備忘錄的文字框
        /// </summary>
        public TextBox TextBoxField;
        /// <summary>
        /// 顯示時間的文字框
        /// </summary>
        public TextBox TimerBoxField;
        public Timer TimerField;
        public Button StartBT;
        public Button StopBT;
        public Button ResetBT;
        /// <summary>
        /// 計時秒數
        /// </summary>
        public int Second;
    }
}
