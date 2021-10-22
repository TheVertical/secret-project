import React from 'react';
import { withTranslation } from 'react-i18next';
import Layout from "./template/layout";

function App (): React.ReactElement {
    return (
        <Layout>
        </Layout>
    );
}

export default withTranslation()(App); 