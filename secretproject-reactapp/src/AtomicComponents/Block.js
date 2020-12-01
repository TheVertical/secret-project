import React, { Children } from 'react';
import VisualElement from '../../src/AtomicComponents/VisualElement'
import { Container, Row, Col } from 'bootstrap-4-react'

class Block extends React.Component{
    constructor(props){
        super();
        this.state = {
            Id: props.Id,
            VisualElements: props.VisualElements
        }
    }
    render(){
        
        return(
            <div id = "block">
            {this.state.VisualElements.map(obj => VisualElement.renderVisualElement(obj))}
            </div>
        );
    }
}

export default Block