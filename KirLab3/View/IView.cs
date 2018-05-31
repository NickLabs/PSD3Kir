using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirLab3.View
{
    public interface IView
    {
        string A { get; }
        string MinX { get;}
        string MaxX { get;  }
        void DrawChart(List<double> X, List<double> Y1, List<double> Y2);
        void ShowPoints(List<double> X, List<double> Y1, List<double> Y2);
        void WrongInterval();
        void WrongData();
        void HelpMessage();
        void Start();
        event EventHandler buttonClick;
        event EventHandler helpClick;
    }
}
