//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.GridSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;

    [Subject(typeof(Grid), "Measure")]
    public class when_an_element_is_added : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_size_equal_to_that_of_its_child =
            () => Grid.DesiredSize.ShouldEqual(child.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_two_elements_are_added : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;

                Grid.Children.Add(largeChild.Object);
                Grid.Children.Add(smallChild.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_size_that_equal_to_that_of_the_largest_element =
            () => Grid.DesiredSize.ShouldEqual(largeChild.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_there_are_two_columns : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.ColumnDefinitions.Add(new ColumnDefinition());

                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;
                Grid.SetColumn(largeChild.Object, 0);

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
                Grid.SetColumn(smallChild.Object, 1);

                Grid.Children.Add(largeChild.Object);
                Grid.Children.Add(smallChild.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_highest_child =
            () => Grid.DesiredSize.Height.ShouldEqual(largeChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_sum_of_its_children =
            () =>
            Grid.DesiredSize.Width.ShouldEqual(
                largeChild.Object.DesiredSize.Width + smallChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_there_are_two_rows : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                Grid.RowDefinitions.Add(new RowDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());

                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;
                Grid.SetRow(largeChild.Object, 0);

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
                Grid.SetRow(smallChild.Object, 1);

                Grid.Children.Add(largeChild.Object);
                Grid.Children.Add(smallChild.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_the_sum_of_its_children =
            () =>
            Grid.DesiredSize.Height.ShouldEqual(
                largeChild.Object.DesiredSize.Height + smallChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_that_of_the_widest_child =
            () => Grid.DesiredSize.Width.ShouldEqual(largeChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_measuring_a_grid_with_two_rows_and_two_columns : a_Grid_with_two_rows_and_two_columns
    {
        private Because of = () => Grid.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_the_sum_of_the_tallest_children_in_each_row =
            () =>
            Grid.DesiredSize.Height.ShouldEqual(
                TopRightChild.Object.DesiredSize.Height + BottomRightChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_sum_of_the_widest_children_in_each_column =
            () =>
            Grid.DesiredSize.Width.ShouldEqual(
                TopLeftChild.Object.DesiredSize.Width + TopRightChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_a_grid_has_auto_columns_and_rows_defined_and_a_child_element_gets_bigger : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 10;
                child.Object.Height = 20;
                Grid.Children.Add(child.Object);

                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());

                Grid.Measure(availableSize);
            };

        private Because of = () =>
            {
                child.Object.Width = 30;
                child.Object.Height = 40;

                Grid.Measure(availableSize);
            };

        private It should_adjust_its_desired_size_accordingly = () => Grid.DesiredSize.ShouldEqual(new Size(30, 40));
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_a_grid_has_auto_columns_and_rows_defined_and_a_child_element_gets_smaller : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 30;
                child.Object.Height = 40;
                Grid.Children.Add(child.Object);

                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());

                Grid.Measure(availableSize);
            };

        private Because of = () =>
            {
                child.Object.Width = 10;
                child.Object.Height = 20;

                Grid.Measure(availableSize);
            };

        private It should_adjust_its_desired_size_accordingly = () => Grid.DesiredSize.ShouldEqual(new Size(10, 20));
    }

    [Subject(typeof(Grid), "Measure - Pixel")]
    public class when_there_is_a_column_with_pixel_width : a_Grid
    {
        private const double ColumnWidth = 10;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ColumnWidth) });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Height.ShouldEqual(child.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_that_of_the_column_width =
            () => Grid.DesiredSize.Width.ShouldEqual(ColumnWidth);
    }

    [Subject(typeof(Grid), "Measure - Pixel")]
    public class when_there_is_a_row_with_pixel_height : a_Grid
    {
        private const double RowHeight = 10;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeight) });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_row_height =
            () => Grid.DesiredSize.Height.ShouldEqual(RowHeight);

        private It should_have_a_desired_width_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Width.ShouldEqual(child.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Pixel")]
    public class when_measuring_a_grid_with_two_rows_and_two_columns_both_of_pixel_values :
        a_Grid_with_two_rows_and_two_columns
    {
        private const double ExpectedHeight1 = 66f;

        private const double ExpectedHeight2 = 80;

        private const double ExpectedWidth1 = 45f;

        private const double ExpectedWidth2 = 54f;

        private Establish context = () =>
            {
                ColumnOneDefinition.Width = new GridLength(ExpectedWidth1);
                ColumnTwoDefinition.Width = new GridLength(ExpectedWidth2);
                RowOneDefinition.Height = new GridLength(ExpectedHeight1);
                RowTwoDefinition.Height = new GridLength(ExpectedHeight2);
            };

        private Because of = () => Grid.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_the_sum_of_row_heights =
            () => Grid.DesiredSize.Height.ShouldEqual(ExpectedHeight1 + ExpectedHeight2);

        private It should_have_a_desired_width_equal_to_the_sum_of_the_column_widths =
            () => Grid.DesiredSize.Width.ShouldEqual(ExpectedWidth1 + ExpectedWidth2);
    }

    [Subject(typeof(Grid), "Measure - Min and Max")]
    public class when_there_is_a_column_with_min_width_and_the_child_is_smaller : a_Grid
    {
        private const double ColumnMinWidth = 10;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition { MinWidth = ColumnMinWidth });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 5;
                child.Object.Height = 60;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Height.ShouldEqual(child.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_min_width =
            () => Grid.DesiredSize.Width.ShouldEqual(ColumnMinWidth);
    }

    [Subject(typeof(Grid), "Measure - Min and Max")]
    public class when_there_is_a_column_with_max_width_and_the_child_is_larger : a_Grid
    {
        private const double ColumnMaxWidth = 50;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition { MaxWidth = ColumnMaxWidth });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 500;
                child.Object.Height = 60;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Height.ShouldEqual(child.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_max_width =
            () => Grid.DesiredSize.Width.ShouldEqual(ColumnMaxWidth);
    }

    [Subject(typeof(Grid), "Measure - Min and Max")]
    public class when_there_is_a_row_with_min_height_and_the_child_is_smaller : a_Grid
    {
        private const double RowMinHeight = 10;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.RowDefinitions.Add(new RowDefinition { MinHeight = RowMinHeight });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 60;
                child.Object.Height = 5;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_the_min_height =
            () => Grid.DesiredSize.Height.ShouldEqual(RowMinHeight);

        private It should_have_a_desired_width_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Width.ShouldEqual(child.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Min and Max")]
    public class when_there_is_a_row_with_max_height_and_the_child_is_larger : a_Grid
    {
        private const double RowMaxHeight = 50;

        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                Grid.RowDefinitions.Add(new RowDefinition { MaxHeight = RowMaxHeight });

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 60;
                child.Object.Height = 500;

                Grid.Children.Add(child.Object);
            };

        private Because of = () => Grid.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_the_max_height =
            () => Grid.DesiredSize.Height.ShouldEqual(RowMaxHeight);

        private It should_have_a_desired_width_equal_to_that_of_the_child =
            () => Grid.DesiredSize.Width.ShouldEqual(child.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_a_column_index_is_specified_greater_than_the_number_of_columns_available : a_Grid
    {
        private It should_put_it_in_the_last_column;
    }
}