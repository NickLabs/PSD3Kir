using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KirLab3.View;
using System.Windows.Forms;

namespace KirLab3
{
    public partial class Form1 : Form,IView
    {
        #region реализация интерфейса
        public string A { get { return ParamA.Text; } }
        public string MinX { get { return LeftBorder.Text; } }
        public string MaxX { get { return RightBorder.Text; } }
        public event EventHandler buttonClick;
        public event EventHandler helpClick;

        public void DrawChart(List<double> X, List<double> Y1, List<double> Y2)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for(int i = 0; i < X.Count; i++)
            {
                
                chart1.Series[0].Points.AddXY(X[i], Y1[i]);
                chart1.Series[1].Points.AddXY(X[i], Y2[i]);
            }
        }

        public void ShowPoints(List<double> X, List<double> Y1, List<double> Y2)
        {
            DotsList.Rows.Clear();
            for(int i = 0; i< X.Count; i++)
            {
                if (!double.IsNaN(Y1[i]) || !double.IsNaN(Y2[i]))
                {
                    DotsList.Rows.Add(X[i], Y1[i], Y2[i]);
                }
            }
        }
        public void HelpMessage()
        {
            string message = "Данная программа строит график функции Y = +-X * SQRT((X+A)/(X-A))\n" + 
                "и выводит точки, по которым был построен график";
            string caption = "Приветствие";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        public void WrongData()
        {
            string message = "Должны быть введены числа, повторите ввод";
            string caption = "Неверный формат данных";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        public void WrongInterval()
        {
            string message = "Неверно указан интервал\n Левая граница должны быть меньше правой\n Правая граница не должна превышать значение параметра A";
            string caption = "Неверный интервал";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        #endregion
        #region Для запуска формы через Презентер
        public void Start()
        {
            this.Show();
        }

        public new void Show()
        {
            Application.Run(this);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            buttonClick?.Invoke(this, null);
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpClick?.Invoke(this, null);
        }
    }
}
