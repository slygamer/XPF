//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Media.DrawingContextSpecs
{
    using System;

    using Machine.Specifications;

    using Microsoft.Xna.Framework;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Media;

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text_starts_before_the_context_is_opened : a_DrawingContext
    {
        private static Exception exception;

        private Because of =
            () =>
            exception = Catch.Exception(() => DrawingContext.DrawText(SpriteFont.Object, string.Empty, Color.AliceBlue));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text : a_DrawingContext
    {
        private const string ExpectedString = "String Value";

        private static readonly Color expectedColor = Color.Black;

        private static readonly Vector2 expectedDrawPosition = Vector2.Zero;

        private Because of = () =>
            {
                DrawingContext.Open();
                DrawingContext.DrawText(SpriteFont.Object, ExpectedString, expectedColor);
                DrawingContext.Close();
                DrawingContext.Flush(SpriteBatch.Object);
            };

        private It should_render_text =
            () =>
            SpriteBatch.Verify(
                batch => batch.DrawString(SpriteFont.Object, ExpectedString, expectedDrawPosition, expectedColor));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle_starts_before_the_context_is_opened : a_DrawingContext
    {
        private static Exception exception;

        private Because of =
            () =>
            exception = Catch.Exception(() => DrawingContext.DrawRectangle(Rect.Empty, new SolidColorBrush(Color.AliceBlue)));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedColor = new SolidColorBrush(Color.AliceBlue);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private Because of = () =>
            {
                DrawingContext.Open();
                DrawingContext.DrawRectangle(expectedRect, expectedColor);
                DrawingContext.Close();
                DrawingContext.Flush(SpriteBatch.Object);
            };

        private It should_render_a_rectangle =
            () => SpriteBatch.Verify(batch => batch.Draw(Moq.It.IsAny<ITexture2D>(), expectedRect, expectedColor.Color));
    }
}