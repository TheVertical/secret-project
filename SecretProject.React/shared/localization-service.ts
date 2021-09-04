import i18n from 'i18next';
import { initReactI18next } from 'react-i18next'
import LanguageCode from '@/constants/language-codes';
import Fetch from 'i18next-fetch-backend';
import RequestManager, { HttpMethod } from './request-manager';
import MAIN_URLS from '@/constants/main-urls';

const LocalizeService = {
    init(url: string): void {

        i18n
            .use(Fetch)
            .use(initReactI18next)
            .init({
                debug: true,
                ns: ['translations'],
                defaultNS: 'translations',
                lng: LanguageCode.RU,
                fallbackLng: false,
                interpolation: {
                    escapeValue: false
                },
                backend: {
                    loadPath: url
                }
            });
    },

    localize(key: string): string {
        return i18n.t(key);
    },

    async getDefaultLanguage(): Promise<string> {
        const responce = await RequestManager.sendRequest(HttpMethod.Get, MAIN_URLS.GET_DEFAULT_LANGUAGE);
        return responce;
    }
}

export default LocalizeService;