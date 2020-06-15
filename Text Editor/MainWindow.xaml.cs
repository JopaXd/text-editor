using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Text_Editor.Helpers;

namespace Text_Editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static class Globals {
            public static string path;
            public static string iconsDirectory;
        }

        private string getIconByFormat(string format) {
            //Returns the path of the icon depending on the format.
            string iconPath = "";
            if (format.EndsWith(".cs"))
            {
                iconPath = String.Format(@"{0}\file_type_csharp.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".py"))
            {
                iconPath = String.Format(@"{0}\file_type_python.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".rb"))
            {
                iconPath = String.Format(@"{0}\file_type_ruby.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".js"))
            {
                iconPath = String.Format(@"{0}\file_type_js.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".ts"))
            {
                iconPath = String.Format(@"{0}\file_type_typescript.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".vue"))
            {
                iconPath = String.Format(@"{0}\file_type_vue.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".bat"))
            {
                iconPath = String.Format(@"{0}\file_type_windows.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".sh"))
            {
                iconPath = String.Format(@"{0}\file_type_shell.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".css"))
            {
                iconPath = String.Format(@"{0}\file_type_css.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".html"))
            {
                iconPath = String.Format(@"{0}\file_type_html.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".jsx"))
            {
                iconPath = String.Format(@"{0}\file_type_jsx.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".c"))
            {
                iconPath = String.Format(@"{0}\file_type_c.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".cpp") || format.EndsWith(".h"))
            {
                iconPath = String.Format(@"{0}\file_type_cpp.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".dart"))
            {
                iconPath = String.Format(@"{0}\file_type_dart.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".md"))
            {
                iconPath = String.Format(@"{0}\file_type_markdown.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".php"))
            {
                iconPath = String.Format(@"{0}\file_type_php.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".java"))
            {
                iconPath = String.Format(@"{0}\file_type_java.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".json"))
            {
                iconPath = String.Format(@"{0}\file_type_json.png", Globals.iconsDirectory);
            }
            else if (format == "Dockerfile")
            {
                iconPath = String.Format(@"{0}\file_type_docker.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".ex"))
            {
                iconPath = String.Format(@"{0}\file_type_ex.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".kt"))
            {
                iconPath = String.Format(@"{0}\file_type_kotlin.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".xml"))
            {
                iconPath = String.Format(@"{0}\file_type_xml.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".sql"))
            {
                iconPath = String.Format(@"{0}\file_type_sql.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".txt"))
            {
                iconPath = String.Format(@"{0}\file_type_text.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".r"))
            {
                iconPath = String.Format(@"{0}\file_type_r.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".ps"))
            {
                iconPath = String.Format(@"{0}\file_type_powershell.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".scss"))
            {
                iconPath = String.Format(@"{0}\file_type_sass.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".hs"))
            {
                iconPath = String.Format(@"{0}\file_type_haskell.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".lua"))
            {
                iconPath = String.Format(@"{0}\file_type_lua.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".go"))
            {
                iconPath = String.Format(@"{0}\file_type_go.png", Globals.iconsDirectory);
            }
            else if (format.EndsWith(".d"))
            {
                iconPath = String.Format(@"{0}\file_type_dlang.png", Globals.iconsDirectory);
            }
            else { 
                iconPath = String.Format(@"{0}\file_type_text.png", Globals.iconsDirectory);
            }
            return iconPath;
        }

        static TreeViewItem GetParentItem(TreeViewItem item)
        {
            for (var i = VisualTreeHelper.GetParent(item); i != null; i = VisualTreeHelper.GetParent(i))
                if (i is TreeViewItem)
                    return (TreeViewItem)i;
            return null;
        }

        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void setSyntax(string format) {
            if (format.EndsWith(".cs"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");
            }
            else if (format.EndsWith(".py"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Python");
            }
            else if (format.EndsWith(".rb"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Ruby");
            }
            else if (format.EndsWith(".js"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }
            else if (format.EndsWith(".ts"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }
            else if (format.EndsWith(".vue"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }
            else if (format.EndsWith(".bat"))
            {
                //No syntax.
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
            }
            else if (format.EndsWith(".sh"))
            {
                //No syntax.
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
            }
            else if (format.EndsWith(".css"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");
            }
            else if (format.EndsWith(".html"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");
            }
            else if (format.EndsWith(".jsx"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }
            else if (format.EndsWith(".c"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
            }
            else if (format.EndsWith(".cpp") || format.EndsWith(".h"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
            }
            else if (format.EndsWith(".dart"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".md"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".php"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("PHP");
            }
            else if (format.EndsWith(".java"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Java");
            }
            else if (format.EndsWith(".json"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }
            else if (format == "Dockerfile")
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".ex"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".kt"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".xml"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".sql"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".r"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".scss"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".hs"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".lua"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".go"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
            else if (format.EndsWith(".d"))
            {
                this.mainEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Text");
                //No syntax.
            }
        }

        private void loadFile(object sender, RoutedEventArgs e) {
            var node = (TreeViewItem)e.Source;
            TextBlock tblock = GetChildOfType<TextBlock>(node);
            var result = tblock.Text;
            for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
                result = GetChildOfType<TextBlock>(i).Text + "\\" + result;
            string pathToFile = Globals.path + @"\" + result;
            this.mainEditor.Load(pathToFile);
            //this.mainEditor.Save("");
            //this.mainEditor.Undo();
            //this.mainEditor.Redo();
            setSyntax(result);
        }
        private void listOtherDirs(object sender, RoutedEventArgs e) {
            var node = (TreeViewItem)e.Source;
            node.Items.Clear();
            TextBlock tblock = GetChildOfType<TextBlock>(node);
            var result = tblock.Text;

            for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
                result = GetChildOfType<TextBlock>(i).Text + "\\" + result;

            //MessageBox.Show(result, result);
            string pathToLoad = String.Format("{0}\\{1}", Globals.path, result);
            //For now i had an idea. To load a file, i will use the result, check if it has an extension and then work from there.
            string[] foldersAndFiles = Directory.GetFileSystemEntries(pathToLoad);
            foreach (string fileOrFolder in foldersAndFiles)
            {
                if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", pathToLoad, fileOrFolder)))
                {
                    //File
                    Orientation hOrientation = Orientation.Horizontal;
                    StackPanel container = new StackPanel() { Orientation = hOrientation };
                    Image fileIcon = new Image() { };
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string iconsDirectory = String.Format(@"{0}\FileIcons", projectDirectory);
                    Globals.iconsDirectory = iconsDirectory;
                    //For now working with a static image. Will create a function in a bit.
                    string fNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string fName = fNameH.Replace(".", "");
                    string icon = getIconByFormat(fNameH);
                    fileIcon.Source = new BitmapImage(new Uri(icon));
                    container.Children.Add(fileIcon);
                    TextBlock fileName = new TextBlock() { Name="fileName", Text = fNameH };
                    fileName.Foreground = new SolidColorBrush(Colors.White);
                    container.Children.Add(fileName);
                    TreeViewItem file = new TreeViewItem() { Header = container, Name = fName };
                    file.AddHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(loadFile));
                    node.Items.Add(file);
                }
                else
                {
                    //Folder
                    Orientation hOrientation = Orientation.Horizontal;
                    StackPanel container = new StackPanel() { Orientation = hOrientation };
                    Image folderIcon = new Image() { };
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string iconsDirectory = String.Format(@"{0}\FileIcons", projectDirectory);
                    Globals.iconsDirectory = iconsDirectory;
                    string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string dirName = Strings.RemoveSpecialCharacters(dirNameH);
                    string icon = String.Format(@"{0}\folder.png", iconsDirectory);
                    folderIcon.Source = new BitmapImage(new Uri(icon));
                    container.Children.Add(folderIcon);
                    TextBlock fileName = new TextBlock() { Name = "folderName", Text = dirNameH };
                    fileName.Foreground = new SolidColorBrush(Colors.White);
                    container.Children.Add(fileName);
                    TreeViewItem newDir = new TreeViewItem() { Header = container, Name = dirName };
                    newDir.Foreground = new SolidColorBrush(Colors.White);
                    newDir.AddHandler(Button.ClickEvent, new RoutedEventHandler(listOtherDirs));
                    TreeViewItem empty = new TreeViewItem() { Header = "empty", Name = "empty" };
                    newDir.Items.Add(empty);
                    node.Items.Add(newDir);
                }
            }
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            //For now working with a static path.
            string path = @"D:\FileExplorerTest";
            Globals.path = @"D:\FileExplorerTest";
            string[] foldersAndFiles = Directory.GetFileSystemEntries(path);
            foreach (string fileOrFolder in foldersAndFiles)
            {
                if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", path, fileOrFolder)))
                {
                    //File
                    Orientation hOrientation = Orientation.Horizontal;
                    StackPanel container = new StackPanel() { Orientation = hOrientation };
                    Image fileIcon = new Image() { };
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string iconsDirectory = String.Format(@"{0}\FileIcons", projectDirectory);
                    Globals.iconsDirectory = iconsDirectory;
                    string fNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string fName = fNameH.Replace(".", "");
                    string icon = getIconByFormat(fNameH);
                    fileIcon.Source = new BitmapImage(new Uri(icon));
                    container.Children.Add(fileIcon);
                    TextBlock fileName = new TextBlock() { Text = fNameH };
                    fileName.Foreground = new SolidColorBrush(Colors.White);
                    container.Children.Add(fileName);
                    TreeViewItem file = new TreeViewItem() { Header = container, Name = fName };
                    file.AddHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(loadFile));
                    this.fsTree.Items.Add(file);
                }
                else
                {
                    //Folder
                    Orientation hOrientation = Orientation.Horizontal;
                    StackPanel container = new StackPanel() { Orientation = hOrientation };
                    Image folderIcon = new Image() { };
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string iconsDirectory = String.Format(@"{0}\FileIcons", projectDirectory);
                    Globals.iconsDirectory = iconsDirectory;
                    string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string dirName = Strings.RemoveSpecialCharacters(dirNameH);
                    string icon = String.Format(@"{0}\folder.png", iconsDirectory);
                    folderIcon.Source = new BitmapImage(new Uri(icon));
                    container.Children.Add(folderIcon);
                    TextBlock fileName = new TextBlock() { Name = "folderName", Text = dirNameH };
                    fileName.Foreground = new SolidColorBrush(Colors.White);
                    container.Children.Add(fileName);
                    TreeViewItem newDir = new TreeViewItem() { Header = container, Name = dirName };
                    newDir.Foreground = new SolidColorBrush(Colors.White);
                    newDir.AddHandler(Button.ClickEvent, new RoutedEventHandler(listOtherDirs));
                    TreeViewItem empty = new TreeViewItem() { Header = "empty", Name = "empty" };
                    newDir.Items.Add(empty);
                    this.fsTree.Items.Add(newDir);
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}