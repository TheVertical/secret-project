import i18n from 'i18next';
import {initReactI18next} from 'react-i18next'
import LanguageCode from '@/constants/language-codes';
import Fetch from 'i18next-fetch-backend';

const LocalizeService = {
    init(url: string, queryStringParams: object): void {
        i18n
            .use(Fetch)
            .use(initReactI18next)
            .init({
                debug:true,
                ns:['translation'],
                defaultNS: 'translation',
                lng: LanguageCode.RU,
                fallbackLng: LanguageCode.RU,
                interpolation: {
                    escapeValue: false
                },
                react: {
                    wait: true,
                    useSuspense: true
                },
                backend: {
                    loadPath: url,
                    queryStringParams
                }
            })
    },

    localize(key: string): string{
        return i18n.t(key);
    }
}

export default LocalizeService;