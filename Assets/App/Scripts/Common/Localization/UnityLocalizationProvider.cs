using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Scripts.Common.Localization.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.Localization.Settings;

namespace App.Scripts.Common.Localization {
    public class UnityLocalizationProvider : ILocalizationProvider {
        private LocalizationSettings _instance;
        
        public async Task InitializeAsync() {
            await LocalizationSettings.InitializationOperation;
            _instance = LocalizationSettings.Instance;
        }

        public event Action<string> LocaleChanged;

        public string GetLocalizedString(string key, params object[] args) {
            var database = _instance.GetStringDatabase();
            return database.GetLocalizedString(key, args);
        }

        public IEnumerable<string> GetLocales() {
            return _instance.GetAvailableLocales().Locales.Select(x => x.LocaleName);
        }

        public void SetLocale(string localeName) {
            var locale = _instance.GetAvailableLocales().Locales.First(x => x.LocaleName == localeName);
            _instance.SetSelectedLocale(locale);
            LocaleChanged?.Invoke(localeName);
        }
    }
}