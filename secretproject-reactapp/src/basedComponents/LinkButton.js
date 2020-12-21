import React from 'react'
import { NavLink,Button } from 'react-bootstrap'

class LinkButton extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            Id: props.Id,
            Title: props.Title,
            Image: props.Image,
            Action: props.Action,
        }
    }
    render() {
        let title = this.state.Title != undefined ? this.state.Title : "";
        let image = this.state.Image != undefined ? <img src={"./" + this.state.Image} /> : null;
        let action = this.state.Action != undefined ? "/" + this.state.Action : "#";
        return (
            <NavLink>
                <Button>
                {title}{image}
                </Button>
            </NavLink>
    );
    }

}
export default LinkButton