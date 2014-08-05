﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MonoTorrent;
using MonoTorrent.Client;
using System.Text.RegularExpressions;

namespace ftorrent
{
    /// <summary>
    /// Interaction logic for TorrentProperties.xaml
    /// </summary>
    public partial class TorrentProperties : Window
    {
        public TorrentManager torrent;
        public TorrentProperties(TorrentManager tm)
        {
            InitializeComponent();
            torrent = tm;
        }
        public void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            maxcons.Text = torrent.Settings.MaxConnections.ToString();
            maxdown.Text = (torrent.Settings.MaxDownloadSpeed / 1024).ToString();
            maxup.Text = (torrent.Settings.MaxUploadSpeed / 1024).ToString();
            dht.IsChecked = torrent.Settings.UseDht;
            peerex.IsChecked = torrent.Settings.EnablePeerExchange;
            uploadslots.Text = torrent.Settings.UploadSlots.ToString();
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            torrent.Settings.MaxConnections = int.Parse(maxcons.Text);
            torrent.Settings.MaxDownloadSpeed = int.Parse(maxdown.Text) * 1024;
            torrent.Settings.MaxUploadSpeed = int.Parse(maxup.Text) * 1024;
            torrent.Settings.UseDht = (bool)dht.IsChecked;
            torrent.Settings.EnablePeerExchange = (bool)peerex.IsChecked;
            torrent.Settings.UploadSlots = int.Parse(uploadslots.Text);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
