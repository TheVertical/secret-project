import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
//Атомарные компоненты
import Block from '../../src/AtomicComponents/Block'
import ContactBlock from '../../src/AtomicComponents/ContactBlock'
import LinksMenu from '../../src/AtomicComponents/LinksMenu'

class VisualElement extends React.Component{
    static renderVisualElement(element){
        const TYPE = element.Type;
        switch(TYPE){
            case "Block":
        return(
                    <div>
                        <Block Id={element.Id} VisualElements={element.VisualElements}></Block>
                    </div>);
            break;
            case "Banner":
                return(
                    //Возвращает компонент банер
                    <div></div>
                    );
            case "Button":
                return(
                    //Возвращает компонент банер
                    <div></div>
                    );
            case "CheckBoxButton":
                return(
                    //Возвращает компонент CheckBoxButton
                    <div></div>
                    );
            case "ComboBoxButton":
                return(
                    //Возвращает компонент ComboBoxButton
                    <div></div>
                    );
            case "RadioButton":
                return(
                    //Возвращает компонент RadioButton
                    <div></div>
                    );
            case "ContactBlock":
                return(
                        <div>
                            <ContactBlock Id={element.Id} Phone={element.Phone} OpeningHours={element.OpeningHours} IsHeaderStyle={true}></ContactBlock>
                        </div>
                    );
            case "ImageBlock":
                return(
                    //Возвращает компонент ImageBlock
                    <div></div>
                    );
            case "LinksMenu":
                return( <div>
                            <LinksMenu Id={element.Id} Links={element.Links}></LinksMenu>
                        </div>
                    );
            case "DropdownMenu":
                return(
                    //Возвращает компонент DropdownMenu
                    <div></div>
                    );
        }
    }
}

export default VisualElement;
