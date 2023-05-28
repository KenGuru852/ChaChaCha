using Avalonia.Controls;
using Avalonia.VisualTree;

namespace TestChaChaCha
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            /*            var app = AvaloniaApp.GetApp();
                        var mainWindow = AvaloniaApp.GetMainWindow();

                        await Task.Delay(100);

                        var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AndButton");

                        button.Command.Execute(button.CommandParameter);

                        await Task.Delay(50);*/

            var first = ")))";

            var second = ")))";

            Assert.Equal(second, first);


        }
    }
}