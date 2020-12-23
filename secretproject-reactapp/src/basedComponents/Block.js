import React, { Children } from 'react';
import VisualElement from './VisualFactory'
import { Container, Row, Col } from 'bootstrap-4-react'

class Block extends React.Component {
    constructor(props) {
        super();
        this.state = {
            Id: props.Id,
            Row: props.Row,
            NeededColumns: props.NeededColumns,
            VisualElements: props.VisualElements
        }
    }
    render() {
        return (
            <Container id="block">
                <Row>
                    {this.state.VisualElements.map(obj => {
                        let justify = obj.JustyfyContent == undefined ? " justify-content-center" : " justify-content-" + obj.JustyfyContent;
                        let align = obj.AlignContent == undefined ? " align-items-center" : " align-items-" + obj.AlignContent;
                        return (
                            <Col key={obj.Id} col={obj.Type == 'Block' ? "col-12" : "col-sm-" + obj.NeededColumns}
                                className={"d-flex" + justify + align}>
                                {VisualElement.renderVisualElement(obj)}
                            </Col>);
                    })}
                </Row>
            </Container>
        );
    }
}

export default Block