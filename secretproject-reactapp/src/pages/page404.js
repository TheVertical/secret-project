import React from 'react'
import {Row, Col } from 'bootstrap-4-react'
import {Button} from "react-bootstrap"
import './page404.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import {NavLink} from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'

class Page404 extends React.Component {

    constructor() {
        super();
        this.state = {}
    }

    render() {
        return (
            <div className="mainStyle">
                <div className="Page404_GlobalStyle">
                <Row>
                    <Col className="Page404_FirstColumn">
                        <img src="./Images/zub_404.png"></img>
                    </Col>
                    <Col className="Page404_SecondColumn">
                    <img src="./Images/404.png"></img>
                    <h1 className="Page404_H1Style">Страница не найдена</h1>
                    <p>Проверьте правильность адреса или вернитесь на главную страницу</p>
                    <NavLink to="/first">
                    <Button className="Page404_BtnStyle">вернуться на главную</Button>
                    </NavLink>
                    </Col>
                </Row>
            </div>
        </div>
        )
    }

}
export default Page404