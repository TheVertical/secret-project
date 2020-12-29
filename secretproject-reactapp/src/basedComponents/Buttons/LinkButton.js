import React from 'react'
import { Link } from 'react-router-dom'
import './Button.css'
import { connect } from "react-redux"

class LinkButton extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            Id: props.Id,
            Title: props.Title,
            Image: props.Image,
            Action: props.Action,
            NeedNotification:false
        }
    }
    
    
    render() { 
        let title = this.state.Title != undefined ? this.state.Title : "";
        let image = this.state.Image != undefined ? <img src={"./" + this.state.Image} /> : null;
        let action = this.state.Action != undefined ? "/" + this.state.Action : "#";
        let styleName= this.state.Id==4&&this.props.NeedNotification ? " LinkButton_ActiveStyle" :"";
        return (
            <Link to={this.state.Action ?? "#"}>
                <button type="button" className={"btn basic-button"+styleName} >{<img src={this.state.Image ?? null}/>}{this.state.Title}</button>
            </Link>
    );
    }

}
function mapStatetoProps(state){
    return {
        NeedNotification: state.NeedNotification
      }
}
export default connect(mapStatetoProps,null)(LinkButton)