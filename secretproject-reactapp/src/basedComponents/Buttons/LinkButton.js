import React from 'react'
import { NavLink,Button } from 'react-bootstrap'
import './Button.css'
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
            <NavLink to={this.state.Action}>
                <button type="button" className="btn basic-button">{<img src={this.state.Image ?? null}/>}{this.state.Title}</button>
            </NavLink>
    );
    }

}
export default LinkButton