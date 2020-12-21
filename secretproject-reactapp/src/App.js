import Layout from "./hoc/Layout"
import React, { Children } from 'react';
import { Route } from 'react-router';


class App extends React.Component {

    render() {
        return (
            <Layout>
                {/* <Route exact path='/' component={Home} />
                <Route path='/counter' component={} />
                <Route path='/fetch-data' component={} /> ����� */}
            </Layout>
        )

    }

}

export default App;