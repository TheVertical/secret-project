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

//     function MyVerticallyCenteredModal(props) {
//     return (
//         <Modal
//             {...props}
//             size="lg"
//             aria-labelledby="contained-modal-title-vcenter"
//             centered
//         >
//             <Modal.Header closeButton>
//                 <Modal.Title id="contained-modal-title-vcenter">
//                     Modal heading
//               </Modal.Title>
//             </Modal.Header>
//             <Modal.Body>
//                 <h4>Centered Modal</h4>
//                 <p>
//                     Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
//                     dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac
//                     consectetur ac, vestibulum at eros.
//               </p>
//             </Modal.Body>
//             <Modal.Footer>
//                 <Button onClick={props.onHide}>Close</Button>
//             </Modal.Footer>
//         </Modal>
//     );
// }

render(){
    // const [modalShow, setModalShow] = React.useState(false);
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