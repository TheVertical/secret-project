import React from 'react'
import {Row, Col } from 'bootstrap-4-react'
import {Button} from "react-bootstrap"
import './SuccessfulRegistration.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import {NavLink} from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'
import LoadingPage from './LoadingPage'

class SuccessfulRegistration extends React.Component {

    constructor() {
        super();
      this.state = {
            isLoading:true
        }
    }
    componentDidMount(){
        this.setState({isLoading:false})
    }
    render() {
        if(this.state.isLoading){return(<LoadingPage></LoadingPage>)}
        return (
            <div className="mainStyle">
                <div className="SuccessfulRegistration_GlobalStyle">
                <Row>
                    <Col className="SuccessfulRegistration_FirstColumn">
                        <img src="./Images/zub(SR).png"></img>
                    </Col>
                    <Col className="SuccessfulRegistration_SecondColumn">
                    <span className="SuccessfulRegistration_SpanStyle">Спасибо за регистрацию!</span>
                    <p className="SuccessfulRegistration_PStyle">Поздравляем, вы успешно зарегистрировались в личном кабинете!</p>
                    <NavLink to="/first">
                    <Button className="SuccessfulRegistration_BtnStyle">вернуться на главную</Button>
                    </NavLink>
                    </Col>
                </Row>
            </div>
        </div>
        )
    }

}
export default SuccessfulRegistration