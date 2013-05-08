using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.Generic;

namespace ConferenceSignage
{
  public class AnimatingStackPanel : AnimatingPanelBase
  {
    private bool _firstArrange = true;

    public AnimatingStackPanel()
    {
      AnimationCompleted += new RoutedEventHandler(AnimatingStackPanel_AnimationCompleted);
    }

    void AnimatingStackPanel_AnimationCompleted(object sender, RoutedEventArgs e)
    {
      _firstArrange = true;
    }

    protected override Size MeasureOverride(Size availableSize)
    {
      foreach (UIElement e in this.Children)
      {
          Size s = new Size(this.DesiredSize.Width, this.DesiredSize.Height);//Double.NaN);
        e.Measure(s);
      }
      return availableSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
      Double top = 0;
      foreach (UIElement e in this.Children)
      {
        if (_firstArrange)
        {
          SetElementLocation(e, new Rect(0, 1500, this.DesiredSize.Width, e.DesiredSize.Height), false);
        }
        else
        {
          SetElementLocation(e, new Rect(0, top, this.DesiredSize.Width, e.DesiredSize.Height));
        }
        top += e.DesiredSize.Height;
      }

      if (_firstArrange && this.Children.Count > 0)
      {
        _firstArrange = false;
        this.InvalidateMeasure();
      }
      return finalSize;
    }
  }
}

