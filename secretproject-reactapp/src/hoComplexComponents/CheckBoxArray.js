import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./CheckBoxArray.css"
import { Row, Col } from 'bootstrap-4-react'
import Form from 'react-bootstrap/Form'
class CheckBoxArray extends React.Component {
    constructor() {
        super();
        // Здесь будут состояния
        this.state = {
            Direction: {},
            array: [
            "Colgate","Blend-A-Med","Чистая Линия","Splat","Mr Proper"
            ],
            IsLoading: true,
            Dowloaded: {}
        }
    }
    // componentDidMount()
    // {
    //   this.DownloadMiniProductCard();
    // }
    // async DownloadMiniProductCard(){
    //   // http://localhost:50258/catalog/product?manufacturerId=1&categoryId=1
    //   // http://localhost:50258/catalog/product/discounted?promotion=Спец&count=10
    //   let url = 'https://secrethost.azurewebsites.net/catalog/product/discounted?promotion=Спец&count=10';
    //   let response = await fetch(url); 
    //   let json = await response.json();
    //   this.setState({Dowloaded:json})
    // }

    render() {
        return (
            <Form.Group>
             { this.state.array.map((value) => {
                 return(
            <label className="CheckBoxArray_ItemStyle">
                <Form.Check
                    type="checkbox"
                    id="value"
                    
                />
                <span>{value}</span>
            </label>
                 )
        }
        )}
            </Form.Group>

        )
    }



}
//Здесь будет главная функция экспорта 
export default CheckBoxArray







