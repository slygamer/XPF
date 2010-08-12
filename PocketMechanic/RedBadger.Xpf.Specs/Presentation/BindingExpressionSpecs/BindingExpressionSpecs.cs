//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.BindingExpressionSpecs
{
    using System.ComponentModel;
    using System.Windows.Data;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;

    using BindingExpression = RedBadger.Xpf.Presentation.BindingExpression;
    using It = Machine.Specifications.It;
    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    public class MyBindingObject : INotifyPropertyChanged
    {
        private float myWidth;

        public event PropertyChangedEventHandler PropertyChanged;

        public float MyWidth
        {
            get
            {
                return this.myWidth;
            }

            set
            {
                this.myWidth = value;
                this.InvokePropertyChanged(new PropertyChangedEventArgs("MyWidth"));
            }
        }

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    [Subject(typeof(BindingExpression), "Binding")]
    public class when_the_width_of_a_textblock_is_set_through_a_binding
    {
        private const float ExpectedWidth = 100f;

        private static MyBindingObject myBindingObject;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.SetBinding(UIElement.WidthProperty, new Binding("MyWidth") { Source = myBindingObject });
            };

        private Because of = () => myBindingObject.MyWidth = ExpectedWidth;

        private It should_have_the_correct_width = () => textBlock.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(BindingExpression), "Binding")]
    public class when_the_width_of_a_textblock_is_set_and_the_binding_is_two_way
    {
        private const float ExpectedWidth = 100f;

        private static MyBindingObject myBindingObject;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.SetBinding(
                    UIElement.WidthProperty, new Binding("MyWidth") { Source = myBindingObject, Mode = BindingMode.TwoWay });
            };

        private Because of = () => textBlock.Width = ExpectedWidth;

        private It should_update_the_bound_property = () => myBindingObject.MyWidth.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(BindingExpression), "Binding")]
    public class when_a_binding_is_changed
    {
        private const float ExpectedWidth = 100f;

        private static MyBindingObject myBindingObject1;

        private static MyBindingObject myBindingObject2;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject1 = new MyBindingObject();
                myBindingObject2 = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.SetBinding(UIElement.WidthProperty, new Binding("MyWidth") { Source = myBindingObject1 });
                textBlock.SetBinding(UIElement.WidthProperty, new Binding("MyWidth") { Source = myBindingObject2 });
            };

        private Because of = () =>
            {
                myBindingObject2.MyWidth = ExpectedWidth;
                myBindingObject1.MyWidth = ExpectedWidth + 1;
            };

        private It should_use_the_latest_binding = () => textBlock.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(BindingExpression), "Binding")]
    public class when_a_binding_is_cleared
    {
        private const float ExpectedWidth = 100f;

        private static MyBindingObject myBindingObject1;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject1 = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.SetBinding(UIElement.WidthProperty, new Binding("MyWidth") { Source = myBindingObject1 });
            };

        private Because of = () =>
            {
                myBindingObject1.MyWidth = ExpectedWidth;
                textBlock.ClearBinding(UIElement.WidthProperty);
                myBindingObject1.MyWidth = ExpectedWidth + 1;
            };

        private It should_not_use_the_binding = () => float.IsNaN(textBlock.Width).ShouldBeTrue();
    }
}