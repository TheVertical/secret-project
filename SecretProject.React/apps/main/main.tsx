import React from 'react';
import ReactDOM from 'react-dom';
import App from './app';
import jQuery from 'jquery';

import MAIN_URLS from '@/constants/main-urls';
import LocalizeService from '@/shared/localization-service';
import { Provider } from 'react-redux';
import { store } from './store/store';

const $root = jQuery('#root');
const languageId = $root.attr('language-id') || '';
LocalizeService.init(MAIN_URLS.LOCALIZE, {languageId});

const rootElement = document.getElementById('root');


ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
rootElement);
