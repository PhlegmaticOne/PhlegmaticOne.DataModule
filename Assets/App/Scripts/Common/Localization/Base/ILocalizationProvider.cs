using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Scripts.Common.Localization.Base {
    public interface ILocalizationProvider {
        Task InitializeAsync();
        public event Action<string> LocaleChanged; 
        string GetLocalizedString(string key, params object[] args);
        IEnumerable<string> GetLocales();
        void SetLocale(string locale);
    }
}