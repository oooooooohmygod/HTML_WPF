using KMCCC.Authentication;
using KMCCC.Launcher;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static KMCCC.Launcher.Version[]? versions;
        public static LauncherCore Core = LauncherCore.Create();
        public MainWindow()
        {
            InitializeComponent();
            KMCCC.Launcher.Version[] versions = Core.GetVersions().ToArray();
            versionsList.ItemsSource = versions;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            Core.JavaPath = @"C:\Program Files\Zulu\zulu-8\bin\javaw.exe";
            var ver = (KMCCC.Launcher.Version)versionsList.SelectedItem;
            var result = Core.Launch(new LaunchOptions
            {
                //启动配置在这里修改
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 4096, //最大内存，int类型
                Authenticator = new OfflineAuthenticator("HTMLuser"), 
                                                                          //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动，最后一个为是否twitch登录
                Mode = LaunchMode.MCLauncher, 
                                              // Server = new ServerInfo { Address = "服务器IP地址", Port = "服务器端口" }, //设置启动游戏后，自动加入指定IP的服务器，可以不要
                Size = new WindowSize { Height = 768, Width = 1280 }  //设置窗口大小，可以不要

            });
        }
    }
}
