using Avalonia.Controls;
using Avalonia.VisualTree;
using System.Diagnostics;

namespace TestChaChaCha
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var canvas = mainWindow.GetVisualDescendants().OfType<Canvas>().First(b => b.Name == "canvas");

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddButton");

            var buttonDelete = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DeleteButton");

            var buttonAnd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AndButton");

            var buttonOr = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OrButton");

            var buttonNot = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "NotButton");

            var buttonXor = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "XorButton");

            var buttonSM = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SMButton");

            var buttonInput = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "InputButton");

            var buttonOutput = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputButton");

            var buttonDel = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DelButton");

            var buttonRename = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RenameButton");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(b => b.Name == "textbox");

            var listbox = mainWindow.GetVisualDescendants().OfType<ListBox>().First(b => b.Name == "listbox");

            buttonAnd.Command.Execute(buttonAnd.CommandParameter);

            buttonDel.Command.Execute(buttonAnd.CommandParameter);

            buttonOr.Command.Execute(buttonOr.CommandParameter);

            buttonNot.Command.Execute(buttonNot.CommandParameter);

            buttonXor.Command.Execute(buttonXor.CommandParameter);

            buttonSM.Command.Execute(buttonSM.CommandParameter);

            buttonOutput.Command.Execute(buttonOutput.CommandParameter);

            buttonInput.Command.Execute(buttonInput.CommandParameter);

            buttonRename.Command.Execute(buttonRename.CommandParameter);

            textbox.Text = "NameForTest";

            buttonRename.Command.Execute(buttonRename.CommandParameter);

            listbox.SelectedIndex = 0;

            string fortest = listbox.SelectedItem.ToString();

            await Task.Delay(50);

            Assert.Equal(textbox.Text, fortest);


        }
        [Fact]
        public async void Test2()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var canvas = mainWindow.GetVisualDescendants().OfType<Canvas>().First(b => b.Name == "canvas");

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddButton");

            var buttonDelete = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DeleteButton");

            var buttonAnd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AndButton");

            var buttonOr = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OrButton");

            var buttonNot = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "NotButton");

            var buttonXor = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "XorButton");

            var buttonSM = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SMButton");

            var buttonInput = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "InputButton");

            var buttonOutput = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputButton");

            var buttonDel = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DelButton");

            var buttonRename = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RenameButton");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(b => b.Name == "textbox");

            var listbox = mainWindow.GetVisualDescendants().OfType<ListBox>().First(b => b.Name == "listbox");

            buttonAdd.Command.Execute(buttonAdd.CommandParameter);

            int tempo = listbox.ItemCount;

            string fortest = listbox.SelectedItem.ToString();

            await Task.Delay(50);

            int expected = 3;

            Assert.Equal(tempo, expected);
        }
        [Fact]
        public async void Test3()
        {
            var app2 = AvaloniaApp.GetApp();
            var mainWindow2 = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var buttonAdd2 = mainWindow2.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddButton");

            var buttonDelete2 = mainWindow2.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DeleteButton");

            var listbox2 = mainWindow2.GetVisualDescendants().OfType<ListBox>().First(b => b.Name == "listbox");

            buttonAdd2.Command.Execute(buttonAdd2.CommandParameter);
            buttonAdd2.Command.Execute(buttonAdd2.CommandParameter);
            buttonAdd2.Command.Execute(buttonAdd2.CommandParameter);

            listbox2.SelectedIndex = 2;

            buttonDelete2.Command.Execute(buttonDelete2.CommandParameter);

            listbox2.SelectedIndex = 2;

            buttonDelete2.Command.Execute(buttonDelete2.CommandParameter);

            int tempo2 = listbox2.ItemCount;

            int expected2 = 2;

            Assert.Equal(tempo2, expected2);
        }
    }
}