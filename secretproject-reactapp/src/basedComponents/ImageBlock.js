import React from "react"
import { NavLink } from "react-router-dom"
import "./ImageBlock.css"
class ImageBlock  extends React.Component{
    constructor(props) {
        super();
        if (props.Id != undefined && props.Alt != undefined && props.Source != undefined)
            this.state = {
                Id: props.Id,
                Alt: props.Alt,
                Source: props.Source
            }
        else
            this.state = {
                Id: 0,
                Alt: 'Bad',
                Source: undefined
            }
    }

    render() {
        let out;
        if (this.state.Source == undefined)
            out = <img alt={this.state.Alt} />
        else
            out = <NavLink to='/home'><img src={this.state.Source} alt={this.state.Alt} /></NavLink>;
        return (
            <div className="ImageBlock_DivStyle">{out}</div>
        );

    }
}



export default ImageBlock
