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

        //public static class Globals{
        //    public static string path;
        //    public static dynamic parent;
        //}

        //private void listOtherDirs(object sender, RoutedEventArgs e) {
        //    //Get clicked item.
        //    //This kind of works. Struggling to get the parent of the current element. I need that to be able to access a folder in a folder in a folder...
        //    dynamic dirObj = e.Source;
        //    dirObj.Items.Clear();
        //    bool whSwitch = false;
        //    List<string> parentFolders = new List<string>();
        //    while (true) {
        //        try
        //        {
        //            if (whSwitch == false)
        //            {
        //                Globals.parent = VisualTreeHelper.GetParent(dirObj);
        //                string folderName = Globals.parent.Header.ToString();
        //                parentFolders.Add(folderName);
        //                whSwitch = true;
        //            }
        //            else {
        //                Globals.parent = VisualTreeHelper.GetParent(Globals.parent);
        //            }
        //        }
        //        catch {
        //            break;
        //        }
        //    }
        //    TreeViewItem emptyE = new TreeViewItem() { Header = "empty", Name = "empty" };
        //    if (parentFolders.Count == 0) {
        //        string path = Globals.path + @"\" + dirObj.Header.ToString();
        //        string[] foldersAndFiles = Directory.GetFileSystemEntries(path);
        //        foreach (string fileOrFolder in foldersAndFiles)
        //        {
        //            if (System.IO.Path.HasExtension(fileOrFolder))
        //            {
        //                //File
        //                string fNameH = System.IO.Path.GetFileName(fileOrFolder);
        //                string fName = fNameH.Replace(".", "");
        //                dirObj.Items.Add(new TreeViewItem() { Header = fNameH, Name = fName });
        //            }
        //            else
        //            {
        //                //Folder
        //                string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
        //                string dirName = Strings.RemoveSpecialCharacters(dirNameH);
        //                TreeViewItem newDir = new TreeViewItem() { Header = dirNameH, Name = dirName };
        //                newDir.AddHandler(Button.ClickEvent, new RoutedEventHandler(listOtherDirs));
        //                TreeViewItem empty = new TreeViewItem() { Header = "empty", Name = "empty" };
        //                newDir.Items.Add(empty);
        //                dirObj.Items.Add(newDir);
        //            }
        //        }
        //    }
        //}

        //private void OpenFolder(object sender, RoutedEventArgs e)
        //{
        //    //For now will use a static folder.
        //    //Not working quite well.
        //    //string[] foldersAndFiles = Directory.GetFileSystemEntries(path);
        //    //foreach (string fileOrFolder in foldersAndFiles) {
        //    //    if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", path, fileOrFolder)))
        //    //    {
        //    //        string fNameH = System.IO.Path.GetFileName(fileOrFolder);
        //    //        string fName = fNameH.Replace(".", "");
        //    //        this.fsTree.Items.Add(new TreeViewItem() { Header = fNameH, Name=fName });
        //    //    }
        //    //    else {
        //    //        string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
        //    //        string dirName = Strings.RemoveSpecialCharacters(dirNameH);
        //    //        string[] foldersAndFilesChild = Directory.GetFileSystemEntries(fileOrFolder);
        //    //        foreach (string fleOrFldr in foldersAndFilesChild) {
        //    //            TreeViewItem newDir = new TreeViewItem() { Header = dirNameH, Name = dirName };
        //    //            if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", path, fleOrFldr)))
        //    //            {
        //    //                string fNameH = System.IO.Path.GetFileName(fleOrFldr);
        //    //                string fName = fNameH.Replace(".", "");
        //    //                newDir.Items.Add(new TreeViewItem() { Header = fNameH, Name = fName });
        //    //            }
        //    //        this.fsTree.Items.Add(newDir);
        //    //        }
        //    //    }
        //    //}
        //    string path = @"D:\FileExplorerTest";
        //    Globals.path = path;
        //    string[] foldersAndFiles = Directory.GetFileSystemEntries(path);
        //    foreach (string fileOrFolder in foldersAndFiles) {
        //        if (System.IO.Path.HasExtension(String.Format(@"{0}\{1}", path, fileOrFolder)))
        //        {
        //            //File
        //            string fNameH = System.IO.Path.GetFileName(fileOrFolder);
        //            string fName = fNameH.Replace(".", "");
        //            this.fsTree.Items.Add(new TreeViewItem() { Header = fNameH, Name = fName });
        //        }
        //        else {
        //            //Folder
        //            string dirNameH = System.IO.Path.GetFileName(fileOrFolder);
        //            string dirName = Strings.RemoveSpecialCharacters(dirNameH);
        //            TreeViewItem newDir = new TreeViewItem() { Header = dirNameH, Name = dirName };
        //            newDir.AddHandler(Button.ClickEvent, new RoutedEventHandler(listOtherDirs) );
        //            TreeViewItem empty = new TreeViewItem() { Header = "empty", Name = "empty" };
        //            newDir.Items.Add(empty);
        //            this.fsTree.Items.Add(newDir);
        //        }
        //    }
        //}

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}