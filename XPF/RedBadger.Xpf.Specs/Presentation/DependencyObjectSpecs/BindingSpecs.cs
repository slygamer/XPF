//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.DependencyObjectSpecs
{
    using System;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Data;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_one_way_from_source
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static Border border;

        private static BorderBrushBindingObject myBindingObject;

        private Establish context = () =>
            {
                myBindingObject = new BorderBrushBindingObject();
                border = new Border();

                border.Bind(Border.BorderBrushProperty, BindingFactory.CreateOneWay(myBindingObject, o => o.Brush));
            };

        private Because of = () => myBindingObject.Brush = expectedBrush;

        private It should_have_the_correct_brush = () => border.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_one_way_to_source
    {
        private const double ExpectedWidth = 100d;

        private static Border border;

        private static BindingObjectWithDouble myBindingObject;

        private Establish context = () =>
            {
                myBindingObject = new BindingObjectWithDouble();
                border = new Border();

                IObserver<double> binding = BindingFactory.CreateOneWayToSource(myBindingObject, o => o.Value);
                border.Bind(UIElement.WidthProperty, binding);
            };

        private Because of = () => border.Width = ExpectedWidth;

        private It should_have_the_correct_width = () => myBindingObject.Value.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_one_way_to_source_and_property_types_are_covariant
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static Border border;

        private static BorderBrushBindingObject myBindingObject;

        private Establish context = () =>
            {
                myBindingObject = new BorderBrushBindingObject();
                border = new Border();

                IObserver<Brush> binding =
                    BindingFactory.CreateOneWayToSource<BorderBrushBindingObject, Brush>(myBindingObject, o => o.Brush);
                border.Bind(Border.BorderBrushProperty, binding);
            };

        private Because of = () => border.BorderBrush = expectedBrush;

        private It should_have_the_correct_brush = () => myBindingObject.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_two_way
    {
        private static readonly SolidColorBrush expectedSourceBrush = new SolidColorBrush(Colors.Blue);

        private static readonly SolidColorBrush expectedTargetBrush = new SolidColorBrush(Colors.Red);

        private static SolidColorBrush actualBrushOnSource;

        private static Brush actualBrushOnTarget;

        private static Border border;

        private static BorderBrushBindingObject myBindingObject;

        private Establish context = () =>
            {
                myBindingObject = new BorderBrushBindingObject();
                border = new Border();

                TwoWayBinding<Brush> binding =
                    BindingFactory.CreateTwoWay<BorderBrushBindingObject, Brush>(myBindingObject, o => o.Brush);
                border.Bind(Border.BorderBrushProperty, binding);
            };

        private Because of = () =>
            {
                border.BorderBrush = expectedTargetBrush;
                actualBrushOnSource = myBindingObject.Brush;

                myBindingObject.Brush = expectedSourceBrush;
                actualBrushOnTarget = border.BorderBrush;
            };

        private It should_have_the_correct_brush_on_the_source =
            () => actualBrushOnSource.ShouldEqual(expectedTargetBrush);

        private It should_have_the_correct_brush_on_the_target =
            () => actualBrushOnTarget.ShouldEqual(expectedSourceBrush);
    }

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_changed
    {
        private const double ExpectedWidth = 100;

        private static MyBindingObject myBindingObject1;

        private static MyBindingObject myBindingObject2;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject1 = new MyBindingObject();
                myBindingObject2 = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                IDisposable binding = textBlock.Bind(UIElement.WidthProperty, myBindingObject1.MyWidthOut);
                binding.Dispose();
                textBlock.Bind(UIElement.WidthProperty, myBindingObject2.MyWidthOut);
            };

        private Because of = () =>
            {
                myBindingObject2.MyWidth = ExpectedWidth;
                myBindingObject1.MyWidth = ExpectedWidth + 1;
            };

        private It should_use_the_latest_binding = () => textBlock.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_cleared
    {
        private const double ExpectedWidth = 100;

        private static IDisposable binding;

        private static MyBindingObject myBindingObject;

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                myBindingObject = new MyBindingObject();
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                binding = textBlock.Bind(UIElement.WidthProperty, myBindingObject.MyWidthOut);
            };

        private Because of = () =>
            {
                myBindingObject.MyWidth = ExpectedWidth;
                binding.Dispose();
                myBindingObject.MyWidth = ExpectedWidth + 1;
            };

        private It should_not_use_the_binding = () => textBlock.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject), "Object Binding")]
    public class when_binding_to_an_object
    {
        private const string ExpectedValue = "Value";

        private static TextBlock textBlock;

        private Establish context = () => textBlock = new TextBlock(new Mock<ISpriteFont>().Object);

        private Because of = () => textBlock.Bind(TextBlock.TextProperty, BindingFactory.CreateOneWay(ExpectedValue));

        private It should_bind_to_the_object = () => textBlock.Text.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(DependencyObject), "Object Binding")]
    public class when_binding_to_the_data_context
    {
        private const string ExpectedValue = "Value";

        private static TextBlock textBlock;

        private Establish context =
            () => textBlock = new TextBlock(new Mock<ISpriteFont>().Object) { DataContext = ExpectedValue };

        private Because of = () => textBlock.Bind(TextBlock.TextProperty);

        private It should_bind_to_the_object = () => textBlock.Text.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(UIElement), "Data Context")]
    public class when_the_data_context_is_set_after_the_binding_has_been_created
    {
        private const string ExpectedValue = "Value";

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.Bind(TextBlock.TextProperty);
            };

        private Because of = () => textBlock.DataContext = ExpectedValue;

        private It should_bind_to_the_data_context = () => textBlock.Text.ShouldEqual(ExpectedValue);
    }

    /*[Subject(typeof(DependencyObject), "Binding")]
    public class when_a_binding_is_one_way_from_a_dependency_object_source
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static Border border;

        private static MyDependencyBindingObject myBindingObject;

        private Establish context = () =>
        {
            myBindingObject = new MyDependencyBindingObject();
            border = new Border();

            border.Bind(Border.BorderBrushProperty, BindingFactory.CreateOneWay<MyDependencyBindingObject, Brush>(myBindingObject, o => o.Brush));
        };

        private Because of = () => myBindingObject.Brush = expectedBrush;

        private It should_have_the_correct_brush = () => border.BorderBrush.ShouldEqual(expectedBrush);
    }*/
}