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
        }

        static TreeViewItem GetParentItem(TreeViewItem item)
        {
            for (var i = VisualTreeHelper.GetParent(item); i != null; i = VisualTreeHelper.GetParent(i))
                if (i is TreeViewItem)
                    return (TreeViewItem)i;

            return null;
        }
            private void listOtherDirs(object sender, RoutedEventArgs e) {
            var node = (TreeViewItem)e.Source;
            node.Items.Clear();
            var result = Convert.ToString(node.Header);

            for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
                result = i.Header + "\\" + result;

            //MessageBox.Show(result, result);
            string pathToLoad = String.Format("{0}\\{1}", Globals.path, result);
            string[] foldersAndFiles = Directory.GetFileSystemEntries(pathToLoad);
            foreach (string fileOrFolder in foldersAndFiles)
            {
                if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", pathToLoad, fileOrFolder)))
                {
                    //File
                    string fNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string fName = fNameH.Replace(".", "");
                    node.Items.Add(new TreeViewItem() { Header = fNameH, Name = fName });
                }
                else
                {
                    //Folder
                    string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string dirName = Strings.RemoveSpecialCharacters(dirNameH);
                    TreeViewItem newDir = new TreeViewItem() { Header = dirNameH, Name = dirName };
                    newDir.AddHandler(Button.ClickEvent, new RoutedEventHandler(listOtherDirs));
                    TreeViewItem empty = new TreeViewItem() { Header = "empty", Name = "empty" };
                    newDir.Items.Add(empty);
                    node.Items.Add(newDir);
                }
            }
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            string path = @"D:\FileExplorerTest";
            Globals.path = @"D:\FileExplorerTest";
            string[] foldersAndFiles = Directory.GetFileSystemEntries(path);
            foreach (string fileOrFolder in foldersAndFiles)
            {
                if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", path, fileOrFolder)))
                {
                    //File
                    string fNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string fName = fNameH.Replace(".", "");
                    this.fsTree.Items.Add(new TreeViewItem() { Header = fNameH, Name = fName });
                }
                else
                {
                    //Folder
                    string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
                    string dirName = Strings.RemoveSpecialCharacters(dirNameH);
                    TreeViewItem newDir = new TreeViewItem() { Header = dirNameH, Name = dirName };
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