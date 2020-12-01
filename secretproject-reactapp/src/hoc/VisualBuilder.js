import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
import Header from './LayoutElements/Header';
import VisualElement from '../AtomicComponents/VisualElement';

//Атомарные компоненты
import Block from '../../src/AtomicComponents/Block'
import ContactBlock from '../../src/AtomicComponents/ContactBlock'
import LinksMenu from '../../src/AtomicComponents/LinksMenu'
class VisualBuilder extends React.Component{
    constructor(){
        super();
        this.state = {
            IsLoading : true,
            Backbone: {}
        }
    }

    componentDidMount() {
        this.getBackbone();
    }

    async getBackbone(){
        let url = 'https://secrethost.azurewebsites.net/visual/backbone'
        const response = await fetch(url);
        let json = await response.json();
        this.setState({ Backbone: json, IsLoading: false });
    }

    static renderVisual(backbone){
        return(
            VisualElement.renderVisualElement(backbone.Header)
        );
    }
    
    render(){
        let contents = this.state.IsLoading
            ? <p><em>Loading...</em></p>
            : VisualBuilder.renderVisual(this.state.Backbone);
        return(
            <div>{contents}</div>
        );
    }

    
}
export default VisualBuilder
