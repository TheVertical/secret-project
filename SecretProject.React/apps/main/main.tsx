import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import App from './app';
import MAIN_URLS from '@/constants/main-urls';
import LocalizeService from '@/shared/localization-service';
import { Provider } from 'react-redux';
import { store } from './store/store';
import jQuery from 'jquery'
import Loader from './common-components/loader';

const languageId = jQuery("#root").attr("default-language-id");
const url: string = MAIN_URLS.LOCALIZE + "?languageId=" + languageId;
LocalizeService.init(url);

const rootElement = document.getElementById('root');

ReactDOM.render(
    <Provider store={store}>
        <Suspense fallback={<Loader/>}>
            <App />
        </Suspense>
    </Provider>,
    rootElement);
