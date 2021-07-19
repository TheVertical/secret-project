import { Col } from 'bootstrap-4-react';
import React from 'react';
import VisualElement from '../../basedComponents/VisualElement';
;

class Footer extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            Content: props.Content
        }
    }

    render(_props) {
        return (
            <div className="globalStyleFooter">{this.state.Content}</div>
        );
    }
}

export default Footer