//import React, { Component } from 'react';
//import { Route } from 'react-router';
//import { Layout } from './components/Layout';
//import { Home } from './components/Home';
//import { FetchData } from './components/FetchData';
//import { Counter } from './components/Counter';

//import './custom.css'

//export default class App extends Component {
//  static displayName = App.name;

//  render () {
//    return (
//      <Layout>
//        <Route exact path='/' component={Home} />
//        <Route path='/counter' component={Counter} />
//        <Route path='/fetch-data' component={FetchData} />
//      </Layout>
//    );
//  }
//}
import Layout from "./hoc/Layout"
import React, { Children } from 'react';

class App extends React.Component {

    //state = {
    //    cars: ["honda", "mazda", "ferrari"],
    //    pageTitle: "NotClicked"
    //}


    render() {
        return (
            <Layout>
            </Layout>
        )

    }

}

export default App;