import React, { Children } from 'react';
import VisualElement from './VisualFactory'
import { Container, Row, Col } from 'bootstrap-4-react'

class Block extends React.Component{
    constructor(props){
        super();
        this.state = {
            Id: props.Id,
            Row: props.Row,
            NeededColumns: props.NeededColumns,
            VisualElements: props.VisualElements
        }
    }
    render(){
        
        return(
            <Container id = "block">
                <Row>
                    {this.state.VisualElements.map(obj =><Col key={obj.Id} col={"col-sm-"+obj.NeededColumns}> {VisualElement.renderVisualElement(obj)}</Col>)}
                </Row>
            </Container>
        );
    }
}

export default Block