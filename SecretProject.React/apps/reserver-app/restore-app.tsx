import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import LocalizeService from '@/shared/localization-service';
import { Provider } from 'react-redux';
import Loader from 'react-spinners/CircleLoader';
import App from './app';

const rootElement = document.getElementById('root');

ReactDOM.render(
        <Suspense fallback={<Loader/>}>
            <App />
        </Suspense>,
    rootElement);
