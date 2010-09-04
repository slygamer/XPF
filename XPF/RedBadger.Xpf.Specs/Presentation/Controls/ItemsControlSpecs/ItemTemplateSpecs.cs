//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.ItemsControlSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    [Subject(typeof(ItemsControl), "Item Template")]
    public class when_an_item_template_has_not_been_specified : an_ItemsControl
    {
        private static Exception exception;

        private static IList<Color> items;

        private Establish context = () =>
            {
                items = new List<Color> { Colors.Blue, Colors.Red };
                ItemsControl.ItemsSource = items;
            };

        private Because of = () => exception = Catch.Exception(() => ItemsControl.Measure(new Size()));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(ItemsControl), "Item Template")]
    public class when_item_template_is_changed : an_ItemsControl
    {
        private static IList<Color> items;

        private Establish context = () =>
            {
                ItemsControl.ItemTemplate = () => new TextBlock(new Mock<ISpriteFont>().Object);
                items = new ObservableCollection<Color> { Colors.Blue };
                ItemsControl.ItemsSource = items;

                ItemsControl.Measure(new Size());
            };

        private Because of = () =>
            {
                ItemsControl.ItemTemplate = () => new Border();
                items.Add(Colors.Red);

                ItemsControl.Measure(new Size());
            };

        private It should_1_use_the_original_item_template_for_items_added_before_the_change =
            () => ItemsControl.ItemsPanel.Children[0].ShouldBeOfType<TextBlock>();

        private It should_2_use_the_new_item_template_for_items_added_after_the_change =
            () => ItemsControl.ItemsPanel.Children[1].ShouldBeOfType<Border>();
    }
}