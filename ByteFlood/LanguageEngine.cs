﻿using System;
using System.IO;
using System.ComponentModel;
using System.Linq;

namespace ByteFlood
{
    public class LanguageEngine : INotifyPropertyChanged
    {
        // I will stick to this naming convention: TorrentList_NameColumn, MainWindow_ExitButton and so on.

        public string Buttons_OK { get; set; }
        public string Buttons_Cancel { get; set; }
        public string Buttons_Add { get; set; }
        public string Buttons_Search { get; set; }
        public string Buttons_Paste { get; set; }

        public string Buttons_SaveSettings { get; set; }
        public string Buttons_DiscardSettings { get; set; }
        public string Buttons_LoadDefaultSettings { get; set; }

        // Torrent list columns

        public string TorrentList_NameColumn { get; set; }
        public string TorrentList_ProgressColumn { get; set; }
        public string TorrentList_StatusColumn { get; set; }
        public string TorrentList_WantedColumn { get; set; }
        public string TorrentList_DoneColumn { get; set; }
        public string TorrentList_ETAColumn { get; set; }
        public string TorrentList_DownSpeedColumn { get; set; }
        public string TorrentList_UpSpeedColumn { get; set; }
        public string TorrentList_PeersColumn { get; set; }
        public string TorrentList_SeedsColumn { get; set; }
        public string TorrentList_LeechsColumn { get; set; }
        public string TorrentList_RatioColumn { get; set; }

        // Tree list 

        public string TreeList_Torrents { get; set; }
        public string TreeList_Downloading { get; set; }
        public string TreeList_Seeding { get; set; }
        public string TreeList_Finished { get; set; }
        public string TreeList_Active { get; set; }
        public string TreeList_Inactive { get; set; }
        public string TreeList_Feeds { get; set; }

        // InfoTabs headers

        public string InfoTab_Overview { get; set; }
        public string InfoTab_Speed { get; set; }
        public string InfoTab_Files { get; set; }
        public string InfoTab_Trackers { get; set; }

        // Overview tab items

        public string OverviewTab_HeaderTransfer { get; set; }
        public string OverviewTab_TimeElapsed { get; set; }
        public string OverviewTab_Downloaded { get; set; }
        public string OverviewTab_DownSpeed { get; set; }
        public string OverviewTab_DownSpeedLimit { get; set; }
        public string OverviewTab_Status { get; set; }
        public string OverviewTab_ETA { get; set; }
        public string OverviewTab_Uploaded { get; set; }
        public string OverviewTab_UploadSpeed { get; set; }
        public string OverviewTab_UploadSpeedLimit { get; set; }
        public string OverviewTab_Wasted { get; set; }
        public string OverviewTab_Seeds { get; set; }
        public string OverviewTab_Peers { get; set; }
        public string OverviewTab_Ratio { get; set; }

        // Speed tab

        public string SpeedTab_DownloadAndUpload { get; set; }
        public string SpeedTab_Download { get; set; }
        public string SpeedTab_Upload { get; set; }

        // Files tab listview colums

        public string FilesTab_Path { get; set; }
        public string FilesTab_Progress { get; set; }
        public string FilesTab_Priority { get; set; }
        public string FilesTab_Size { get; set; }

        // Trackers tab

        public string TrackersTab_URL { get; set; }
        public string TrackersTab_UpdateIn { get; set; }
        public string TrackersTab_Message { get; set; }

        // Feeds items context menu

        public string FeedsItemsContextMenu_Refresh { get; set; }
        public string FeedsItemsContextMenu_Remove { get; set; }
        public string FeedsItemsContextMenu_Edit { get; set; }
        public string FeedsItemsContextMenu_ViewFeeds { get; set; }

        // Torrents list context menu

        public string TorrentListContextMenu_OpenContainingFolder { get; set; }
        public string TorrentListContextMenu_ForceStart { get; set; }
        public string TorrentListContextMenu_Start { get; set; }
        public string TorrentListContextMenu_Pause { get; set; }
        public string TorrentListContextMenu_ForcePause { get; set; }
        public string TorrentListContextMenu_Stop { get; set; }
        public string TorrentListContextMenu_ForceRecheck { get; set; }
        public string TorrentListContextMenu_CopyMagnetLink { get; set; }
        public string TorrentListContextMenu_DownloadMovieData { get; set; }
        public string TorrentListContextMenu_Remove { get; set; }
        public string TorrentListContextMenu_RemoveAnd { get; set; }
        public string TorrentListContextMenu_DeleteData { get; set; }
        public string TorrentListContextMenu_DeleteTorrentFile { get; set; }
        public string TorrentListContextMenu_DeleteDataAndTorrentFile { get; set; }
        public string TorrentListContextMenu_ChangeTorrentOptions { get; set; }

        // File list context menu

        public string FileListContextMenu_OpenFile { get; set; }
        public string FileListContextMenu_OpenContainingFolder { get; set; }
        public string FileListContextMenu_SetPriority { get; set; }

        // File priorities

        public string FilePriority_Immediate { get; set; }
        public string FilePriority_Highest { get; set; }
        public string FilePriority_High { get; set; }
        public string FilePriority_Normal { get; set; }
        public string FilePriority_Low { get; set; }
        public string FilePriority_Lowest { get; set; }
        public string FilePriority_Skip { get; set; }
        public string FilePriority_Custom { get; set; }

        // NotifyIcon menu

        public string NotifyIcon_ResumeAll { get; set; }
        public string NotifyIcon_PauseAll { get; set; }
        public string NotifyIcon_ShowHide { get; set; }
        public string NotifyIcon_Exit { get; set; }

        // MainWindow Toolbar tooltips

        public string MainWindowToolbarTooltips_AddTorrentFromFile { get; set; }
        public string MainWindowToolbarTooltips_AddTorrentMagnetLink { get; set; }
        public string MainWindowToolbarTooltips_AddRSSFeed { get; set; }
        public string MainWindowToolbarTooltips_SearchTorrentsOnline { get; set; }
        public string MainWindowToolbarTooltips_EditPreferences { get; set; }
        public string MainWindowToolbarTooltips_StartSelectedTorrents { get; set; }
        public string MainWindowToolbarTooltips_PauseSelectedTorrents { get; set; }
        public string MainWindowToolbarTooltips_StopSelectedTorrents { get; set; }
        public string MainWindowToolbarTooltips_RemoveSelectedTorrents { get; set; }

        // todo: status bar items and other windows

        public string AddMagnetLinkWindow_Title { get; set; }
        public string AddMagnetLinkWindow_EnterMagnetURL { get; set; } 

        #region Public methods

        public void ReloadLang(string name)
        {
            string dictionary_path = string.Format("./Assets/Languages/{0}.xml", name);

            if (File.Exists(dictionary_path))
            {
                try
                {
                    var new_lang = Utility.Deserialize<LanguageEngine>(dictionary_path);

                    Type t = typeof(LanguageEngine);

                    var props = t.GetProperties();

                    foreach (var prop in props)
                    {
                        prop.SetValue(this, prop.GetValue(new_lang));
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs(prop.Name));
                        }
                    }
                }
                catch { }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Static methods

        public static LanguageEngine LoadDefault()
        {
            string dictionary_path = string.Format("./Assets/Languages/{0}.xml", App.Settings.DefaultLanguage);

            LanguageEngine le = null;

            if (System.IO.File.Exists(dictionary_path))
            {
                try
                {
                    le = Utility.Deserialize<LanguageEngine>(dictionary_path);
                }
                catch (System.Xml.XmlException)
                {
                    //bad file, try to find another working file
                    foreach (string lang in Utility.GetAvailableLanguages())
                    {
                        if (lang.Equals(App.Settings.DefaultLanguage, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        try
                        {
                            le = Utility.Deserialize<LanguageEngine>(string.Format("./Assets/Languages/{0}.xml", lang));
                        }
                        catch
                        {
                            continue;
                        } //end of try-catch

                    } // loop
                } // end of the fallback-try-catch
                catch { }
            }

            if (le == null)
            {
                le = LanguageEngine.GetDummyLanguageEngine();
            }

            return le;
        }


        /// <summary>
        /// Save an empty .xml file on the desktop to be used by translators.
        /// </summary>
        public static void SaveDummy()
        {
            Utility.Serialize<LanguageEngine>(LanguageEngine.GetDummyLanguageEngine(),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "byteflood_lang_empty.xml"), true);
        }

        private static LanguageEngine GetDummyLanguageEngine()
        {
            var le = new LanguageEngine();

            Type t = typeof(LanguageEngine);

            var props = t.GetProperties();

            foreach (var prop in props)
            {
                prop.SetValue(le, prop.Name.Split('_').Last());
            }

            return le;
        }

        #endregion

    }
}