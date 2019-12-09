﻿using System;
using System.Collections.Generic;
using System.Text;
using Jot.Configuration;

namespace REvernus.Settings
{
    public class AppSettings : ITrackingAware<AppSettings>
    {
        public CharacterManagerSettings CharacterManagerSettings { get; set; } = new CharacterManagerSettings();
        public MarginToolSettings MarginToolSettings { get; set; } = new MarginToolSettings();
        public MarketOrdersTabSettings MarketOrdersTabSettings { get; set; } = new MarketOrdersTabSettings();
        public MarketSettings MarketSettings { get; set; } = new MarketSettings();
        public NotificationSettings NotificationSettings { get; set; } = new NotificationSettings();

        public void ConfigureTracking(TrackingConfiguration<AppSettings> configuration)
        {
            configuration.Properties(s => new
            {
                s.CharacterManagerSettings,
                s.MarginToolSettings,
                s.MarketOrdersTabSettings,
                s.MarketSettings,
                s.NotificationSettings
            });
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
