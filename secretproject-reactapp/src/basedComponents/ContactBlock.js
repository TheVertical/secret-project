//Библиотечные зависимости
import React from 'react'
import Col from 'bootstrap-4-react'
import { Modal, Button } from 'bootstrap-4-react';
import MyVerticallyCenteredModal from './MyVerticallyCenteredModal'

//Собственные зависимости
import VisualElement from './VisualElement'
import Picture from "../basedComponents/ImageBlock"
import "./ContactBlock.css"

class ContactBlock extends React.Component {
    constructor(props) {
        super();
        this.state = {
            Id: props.Id,
            Phone: props.Phone,
            OpeningHours: props.OpeningHours,
            IsHeaderStyle: props.IsHeaderStyle,
            modalShow: false,
            setModalShow:false
        }
    }


render(){
    if (this.state.IsHeaderStyle == true)
        return (
            <div className="globalblockStylle">
                <div className="blockStylle">
                    <a href={"tel:" + this.state.Phone} className="bigAStyle">{this.state.Phone}</a>
                    <p className="pppStyle">{this.state.OpeningHours}</p>
                    <a href="#" className="smallAStyle" data-toggle="modal" data-target="#exampleModal">Заказать обратный звонок</a>
                <MyVerticallyCenteredModal></MyVerticallyCenteredModal>
                </div>
            </div>
        );
    else
        return (
            <div className="blockStylle">
                <Picture src={'./Images/LogoDown.png'}></Picture>
                <a href={"tel:" + this.state.Phone} className="bigAAStyle">{this.state.Phone}</a>
                <p className="pppStyle">{this.state.OpeningHours}</p>
            </div>
        );

}
}
export default ContactBlock;