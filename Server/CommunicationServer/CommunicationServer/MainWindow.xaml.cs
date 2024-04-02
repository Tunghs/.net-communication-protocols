﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CommunicationServer
{
    public enum CommunicationMode
    {
        TcpIp,
        REST,
        IPC,
        WCF
    }

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CommunicationView> views;
        List<TabItem> tabs;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            views = new List<CommunicationView>() { TcpIpComuView, RestComuView, IpcComuView, WcfComuView };
            tabs = new List<TabItem>() { TcpIPTab, RestTab, IpcTab, WcfTab };
            for (int index = 0; index < 4; index++)
            {
                views[index].Intialize((CommunicationMode)index);
                views[index].OpenServer += (() => { tabs.ForEach(x => x.IsEnabled = false); tabs[ServerTab.SelectedIndex].IsEnabled = true; ServerTab.Items.Refresh(); });
                views[index].CloseServer += (() => { tabs.ForEach(x => x.IsEnabled = true); ServerTab.Items.Refresh(); });
            }
        }
    }
}
