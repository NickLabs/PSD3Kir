using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KirLab3.View;
using KirLab3.Service;

namespace KirLab3.Presenters
{
    public class Presenter
    {
        private readonly IView view;
        private readonly IModel model;

        public Presenter(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Run()
        {
            view.buttonClick += View_buttonClick;
            view.helpClick += View_helpClick;
            view.Start();
        }

        private void View_helpClick(object sender, EventArgs e)
        {
            view.HelpMessage();
        }

        private void View_buttonClick(object sender, EventArgs e)
        {
            GenerateDots();
        }

        public void GenerateDots()
        {
            double left = 0, right = 0, a = 0;
            bool isCorrectData = false;
            try
            {
                left = Convert.ToDouble(view.MinX);
                right = Convert.ToDouble(view.MaxX);
                a = Convert.ToDouble(view.A);
                isCorrectData = true;
            }
            catch(FormatException e)
            {
                view.WrongData();
            }
            if(left >= right || right > a)
            {
                isCorrectData = false;
                view.WrongInterval();
            }
           

            if (isCorrectData)
            {
                List<double> x = GenerateX(left, right);
                List<double> positiveY = GeneratePositiveY(left, right, a);
                List<double> negativeY = GenerateNegativeY(left, right, a);
                view.DrawChart(x, positiveY, negativeY);
                view.ShowPoints(x, positiveY, negativeY);
            }
        }
        #region Генерация точек
        public List<double> GenerateX(double left, double right)
        {
            List<double> X = new List<double>();
            for(double i = left; i < right; i++)
            {
                X.Add(i);
            }
            return X;
        }

        public List<double> GeneratePositiveY(double left, double right, double a)
        {
            List<double> Y = new List<double>();
            for (double i = left; i < right; i++)
            {
                Y.Add(model.PositiveEquation(a, i));
            }
            return Y;
        }

        public List<double> GenerateNegativeY(double left, double right, double a)
        {
            List<double> Y = new List<double>();
            for (double i = left; i < right; i++)
            {
                Y.Add(model.NegativeEquation(a, i));
            }
            return Y;
        }
        #endregion
    }
}
