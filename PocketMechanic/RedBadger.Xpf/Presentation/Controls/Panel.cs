﻿namespace RedBadger.Xpf.Presentation.Controls
{
    using System.Collections.Generic;
    using System.Windows;

    using RedBadger.Xpf.Presentation.Media;

    using Rect = RedBadger.Xpf.Presentation.Rect;
    using UIElement = RedBadger.Xpf.Presentation.UIElement;

    public class Panel : UIElement
    {
        public static readonly XpfDependencyProperty BackgroundProperty = XpfDependencyProperty.Register(
            "Background", typeof(Brush), typeof(Panel), new PropertyMetadata(null));

        private readonly IList<UIElement> children;

        public Panel()
        {
            this.children = new UIElementCollection(this);
        }

        public Brush Background
        {
            get
            {
                return (Brush)this.GetValue(BackgroundProperty.Value);
            }

            set
            {
                this.SetValue(BackgroundProperty.Value, value);
            }
        }

        public IList<UIElement> Children
        {
            get
            {
                return this.children;
            }
        }

        protected override void OnRender(IDrawingContext drawingContext)
        {
            if (this.Background != null)
            {
                drawingContext.DrawRectangle(new Rect(0, 0, this.ActualWidth, this.ActualHeight), this.Background);
            }
        }
    }
}